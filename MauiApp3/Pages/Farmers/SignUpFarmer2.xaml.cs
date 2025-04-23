using Newtonsoft.Json;

namespace MauiApp3.Pages.Farmers
{
    public partial class SignUpFarmer2 : ContentPage
    {
        private FarmerApplication _farmer;
        private string CertificateUrl = "";
        private string apiUrl = "8a055776c7d5188e7a86f1c50a071a56";
        private readonly HttpClient _httpClient = new HttpClient();

        public SignUpFarmer2(FarmerApplication farmer)
        {
            _farmer = farmer;

            InitializeComponent();
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

                CertificateUrl = result.FullPath;



                // رفع الصورة
                using var form = new MultipartFormDataContent
        {
            { new ByteArrayContent(File.ReadAllBytes(CertificateUrl)), "image", Path.GetFileName(CertificateUrl) }
        };
                var response = await _httpClient.PostAsync($"https://api.imgbb.com/1/upload?key={apiUrl}", form);
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                string uploadedImageUrl = jsonResponse["data"]["url"].ToString();

                await DisplayAlert("نجاح", "تم رفع الصورة بنجاح", "موافق");


                // إذا كنت بحاجة للاحتفاظ بالرابط المرفوع لاستخدامه لاحقًا
                CertificateUrl = uploadedImageUrl; // إضافة هذا السطر

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
                // التحقق من إدخال جميع الحقول في الصفحة الثانية
               

                  
                {
                  
                }

                // دمج البيانات من الصفحة الأولى والصفحة الثانية
                _farmer.FarmName = FarmNameEntry.Text;
                _farmer.FarmNum = string.IsNullOrWhiteSpace(FarmNumberEntry.Text) ? (int?)null : int.Parse(FarmNumberEntry.Text);
                _farmer.City = CityEntry.Text;
                _farmer.Neighborhood = DistrictEntry.Text;
                _farmer.Street = StreetEntry.Text;
                _farmer.Description = FarmDescriptionEntry.Text;
                _farmer.Certificate = CertificateUrl;
                _farmer.VerificationStatus = "pending";

                // تمرير farmer إلى صفحة التحقق من البريد الإلكتروني
                await Navigation.PushAsync(new EmailVerification(_farmer));
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
                Console.WriteLine($"Error: {ex}");
            }
        }
    }
}
