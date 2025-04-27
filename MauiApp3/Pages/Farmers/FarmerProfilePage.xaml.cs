using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml;

namespace MauiApp3.Pages.Farmers;

public partial class FarmerProfilePage : ContentPage
{
    private readonly HttpClient httpClient = new HttpClient();
    private string imageUrl = "";
    private string apiKey = "8a055776c7d5188e7a86f1c50a071a56";
    private Farmer _farmer;

    public FarmerProfilePage(Farmer farmer)
    {
        InitializeComponent();
        LoadProfile();
        _farmer = farmer;
    }


 
    private async void LoadProfile()
    {
        try
        {
            var response = await httpClient.GetStringAsync("https://localhost:7168/api/Farmers");
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
            var updateRequest = new UpdateProfileRequest
            {
                PhoneNumber = phoneEntry.Text,
                ImageUrl = imageUrl
            };

            var json = JsonConvert.SerializeObject(updateRequest);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync("https://localhost:7168/api/Farmers/UpdateProfile", content);

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
    
