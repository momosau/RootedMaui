using Newtonsoft.Json;
using SharedLibraryy.Models;

namespace MauiApp3.Pages.Farmers
{
    public partial class SignUpFarmer : ContentPage
    {


        private bool PasswordVisible1 = false;
        private string imageUrl = "";
        private string apiKey = "8a055776c7d5188e7a86f1c50a071a56";

        public SignUpFarmer()
        {
            InitializeComponent();
        }
        private void EyeClicked(object sender, EventArgs e)
        {
            PasswordVisible1 = !PasswordVisible1;
            passwordEntry.IsPassword = !PasswordVisible1;
            eyeButton.Source = PasswordVisible1 ? "eyeo.png" : "eyec.png";
        }

        private async void PickAndUploadImage(object sender, EventArgs e)
        {
            try
            {
                // اختيار الصورة
                var result = await FilePicker.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images });
                if (result == null)
                {
                    await DisplayAlert("خطأ", "لم يتم اختيار صورة", "موافق");
                    return;
                }

                string ImageUrl = result.FullPath;

                //عرض الصورة المختارة
                selectedImage.Source = ImageSource.FromFile(ImageUrl);

                // رفع الصورة
                using var client = new HttpClient();
                using var form = new MultipartFormDataContent
        {
            { new ByteArrayContent(File.ReadAllBytes(ImageUrl)), "image", Path.GetFileName(ImageUrl) }
        };
                var response = await client.PostAsync($"https://api.imgbb.com/1/upload?key={apiKey}", form);
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                string uploadedImageUrl = jsonResponse["data"]["url"].ToString();

                await DisplayAlert("نجاح", "تم رفع الصورة بنجاح", "موافق");


                // إذا كنت بحاجة للاحتفاظ بالرابط المرفوع لاستخدامه لاحقًا
                imageUrl = uploadedImageUrl; // إضافة هذا السطر

            }
            catch
            {
                await DisplayAlert("خطأ", "حدث خطأ أثناء اختيار أو رفع الصورة", "موافق");
            }
        }
        private async void NextClicked(object sender, EventArgs e)
        {
            try
            {
                // التحقق من إدخال جميع الحقول
                if (string.IsNullOrWhiteSpace(fullNameEntry.Text) ||
                    string.IsNullOrWhiteSpace(phoneNumberEntry.Text) ||
                    string.IsNullOrWhiteSpace(emailEntry.Text) ||
                    string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                    string.IsNullOrWhiteSpace(usernameEntry.Text))

                {
                    await DisplayAlert("خطأ", "يرجى ملء جميع الحقول ورفع الصورة", "موافق");
                    return;
                }

                var farmer = new FarmerApplication
                {
                    Name = fullNameEntry.Text,
                    PhoneNumber = phoneNumberEntry.Text,
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text,
                    UserName = usernameEntry.Text,
                    ImageUrl = imageUrl,

                };

                await Navigation.PushAsync(new SignUpFarmer2(farmer));
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}


public class FarmerApplication
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string FarmName { get; set; }
    public int? FarmNum { get; set; }
    public string Certificate { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool VerificationStatus { get; set; }

    public Specification Specification { get; set; } = default!;
}
