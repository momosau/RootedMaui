using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;
using MauiApp3.Helpers;

namespace MauiApp3.Pages.Farmers;

public partial class FarmerProfilePage : ContentPage
{
    private readonly HttpClient httpClient = new HttpClient();
    private string imageUrl = "";
    private string apiKey = "8a055776c7d5188e7a86f1c50a071a56";
    private Farmer _farmer;
    private static readonly string _baseUrl =
#if ANDROID
       "http://10.0.2.2:5140/api";
#else
       "https://localhost:7168/api";
#endif
    public FarmerProfilePage()
    {
        InitializeComponent();
        LoadProfile();
    }



    private async void LoadProfile()
    {
        try
        {
            var farmerId = UserSession.LoggedInFarmer.FarmerId;

        
         
            var response = await httpClient.GetStringAsync($"{_baseUrl}/Farmers/{farmerId}");
            var farmer = JsonConvert.DeserializeObject<Farmer>(response);

            if (farmer != null)
            {
                nameLabel.Text = farmer.Name;
                emailLabel.Text = farmer.Email;
                phoneEntry.Text = farmer.PhoneNumber;
                selectedImage.Source = farmer.ImageUrl;
                imageUrl = farmer.ImageUrl;
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", $"فشل تحميل البيانات: {ex.Message}", "موافق");
        }
    }

    private async void PickAndUploadImage(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images });
            if (result == null) return;

            string path = result.FullPath;
            selectedImage.Source = ImageSource.FromFile(path);

            var form = new MultipartFormDataContent
                {
                    { new ByteArrayContent(File.ReadAllBytes(path)), "image", Path.GetFileName(path) }
                };

            var response = await httpClient.PostAsync($"https://api.imgbb.com/1/upload?key={apiKey}", form);
            var jsonResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
            imageUrl = jsonResponse["data"]["url"].ToString();
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", $"فشل رفع الصورة: {ex.Message}", "موافق");
        }
    }

    private async void SaveChanges(object sender, EventArgs e)
    {
        try
        {
            var farmerId = UserSession.LoggedInFarmer.FarmerId;

            var updateRequest = new UpdateProfileRequest
            {
                FarmerId = farmerId,
                PhoneNumber = phoneEntry.Text,
                ImageUrl = imageUrl
            };

            var json = JsonConvert.SerializeObject(updateRequest);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            // ❗ No token needed
            var response = await httpClient.PutAsync($"{_baseUrl}/Farmers/UpdateProfile", content);


            if (response.IsSuccessStatusCode)
                await DisplayAlert("تم", "تم حفظ التعديلات بنجاح", "موافق");
            else
                await DisplayAlert("خطأ", "فشل حفظ التعديلات", "موافق");
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", $"حدث خطأ أثناء حفظ التعديلات: {ex.Message}", "موافق");
        }
    }
}



        public class UpdateProfileRequest
        {
            public int FarmerId { get; set; }
            public string PhoneNumber { get; set; }
            public string ImageUrl { get; set; }
        }
    
