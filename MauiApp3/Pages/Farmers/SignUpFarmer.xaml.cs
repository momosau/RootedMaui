using Newtonsoft.Json;

namespace MauiApp3.Pages
{
    public partial class SignUpFarmer : ContentPage
    {
        private bool PasswordVisible1 = false;
        private string Certificate = "8a055776c7d5188e7a86f1c50a071a56";
        private const string apiKey = "http://localhost:7168/api/Farmers";
        private readonly HttpClient _httpClient = new HttpClient();

        public SignUpFarmer()
        {
            InitializeComponent();
        }

        private void EyeClicked(object sender, EventArgs e)
        {
            PasswordVisible1 = !PasswordVisible1;
            //passwordEntry.IsPassword = !PasswordVisible1;
            //eyeButton.Source = PasswordVisible1 ? "eyeo.png" : "eyec.png";
        }

        private async void PickAndUploadImage(object sender, EventArgs e)
        {
            try
            {
                // «Œ Ì«— «·’Ê—…
                var result = await FilePicker.PickAsync(new PickOptions { FileTypes = FilePickerFileType.Images });
                if (result == null)
                {
                    await DisplayAlert("Œÿ√", "·„ Ì „ «Œ Ì«— ’Ê—…", "„Ê«›ﬁ");
                    return;
                }

                string Certificate = result.FullPath;

                // ⁄—÷ «·’Ê—… «·„Œ «—…
                // selectedImage.Source = ImageSource.FromFile(Certificate);

                // —›⁄ «·’Ê—…
                using var client = new HttpClient();
                using var form = new MultipartFormDataContent
        {
            { new ByteArrayContent(File.ReadAllBytes(Certificate)), "image", Path.GetFileName(Certificate) }
        };
                var response = await client.PostAsync($"https://api.imgbb.com/1/upload?key={apiKey}", form);
                var jsonResponse = JsonConvert.DeserializeObject<dynamic>(await response.Content.ReadAsStringAsync());
                string uploadedImageUrl = jsonResponse["data"]["url"].ToString();

                await DisplayAlert("‰Ã«Õ", " „ —›⁄ «·’Ê—… »‰Ã«Õ", "„Ê«›ﬁ");

                // ≈–« ﬂ‰  »Õ«Ã… ··«Õ ›«Ÿ »«·—«»ÿ «·„—›Ê⁄ ·«” Œœ«„Â ·«Õﬁ«
                Certificate = uploadedImageUrl;
            }
            catch
            {
                await DisplayAlert("Œÿ√", "ÕœÀ Œÿ√ √À‰«¡ «Œ Ì«— √Ê —›⁄ «·’Ê—…", "„Ê«›ﬁ");
            }
        }
        /*
                private async void NextClicked(object sender, EventArgs e)
                {
                    try
                    {
                        // «· Õﬁﬁ „‰ ≈œŒ«· Ã„Ì⁄ «·ÕﬁÊ·
                        if (string.IsNullOrWhiteSpace(fullNameEntry.Text) ||
                            string.IsNullOrWhiteSpace(phoneNumberEntry.Text) ||
                            string.IsNullOrWhiteSpace(emailEntry.Text) ||
                            string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                            string.IsNullOrWhiteSpace(FarmNameEntry.Text) ||
                            string.IsNullOrWhiteSpace(FarmLocationEntry.Text) ||
                            string.IsNullOrWhiteSpace(ProductsEntry.Text) ||
                            string.IsNullOrEmpty(Certificate))
                        {
                            await DisplayAlert("Œÿ√", "Ì—ÃÏ „·¡ Ã„Ì⁄ «·ÕﬁÊ· Ê—›⁄ «·’Ê—…", "„Ê«›ﬁ");
                            return;
                        }

                        var farmer = new Farmer
                        {
                            Name = fullNameEntry.Text,
                            PhoneNumber = phoneNumberEntry.Text,
                            Email = emailEntry.Text,
                            Password = passwordEntry.Text,
                            UserName = FarmNameEntry.Text,
                            Location = FarmLocationEntry.Text,
                            Description = ProductsEntry.Text,
                            Certificate = Certificate,
                            VerificationStatus = "Pending",
                        };

                        await Navigation.PushAsync(new PhoneVerification(farmer));
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Œÿ√", $"ÕœÀ Œÿ√: {ex.Message}", "„Ê«›ﬁ");
                        Console.WriteLine($"Error: {ex}");
                    }
                }*/
    }



    public partial class Farmer
    {
        public int FarmerId { get; set; }

        public string Description { get; set; }

        public string Certificate { get; set; }

        public string Location { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string VerificationStatus { get; set; }

        public string UserName { get; set; }

    }
}