
using Microsoft.Maui.Storage;
using Syncfusion.Maui.Core.Carousel;
using MauiApp3.ModelView;
namespace MauiApp3.Pages.Farmers
{
    public partial class FarmerHome : ContentPage
    {
        private FarmerHomeViewModel viewModel;
        public FarmerHome()
        {
            InitializeComponent();
         //   NavigationPage.SetHasNavigationBar(this, false);
            BindingContext = viewModel = new FarmerHomeViewModel();
        }
        private async void GoToHome(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Pages.Farmers.FarmerHome));
        }

        private async void GoToChatbot(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("Chatbot");


        }
        private async void GoToProfile(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync( nameof(AccountPageFarmer));
        }


        /*  private async void PickImageAsync(object sender, EventArgs e)
          {
              try
              {
                  var result = await FilePicker.PickAsync(new PickOptions
                  {
                      FileTypes = FilePickerFileType.Images,
                      PickerTitle = "Select Profile Picture"
                  });

                  if (result != null)
                  {
                      Profile_image.Source = ImageSource.FromFile(result.FullPath);
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine($"Error picking image: {ex.Message}");
              }
          }*/



        /*


            <ImageButton
                    Source="pen1.png"

                    HorizontalOptions="Start"
                    Grid.Column="0"
                            Grid.Row="1"
                    Clicked="PickImage"


                    />
         */
        private async void PickImage(object sender, EventArgs e)
        {
            await PickImageAsync();
        }

        private async Task PickImageAsync()
        {
            try
            {
                var fileResult = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "PLease select an image",
                    FileTypes = FilePickerFileType.Images
                });
                if (fileResult is not null)
                {
                    var stream = await fileResult.OpenReadAsync();
                    var uploadedImagePath = await UploadLocalAsync(fileResult.FileName, stream);
                 //   imagee.Source = uploadedImagePath;
                 
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error in picking image", ex.Message, "Ok");
            }
        }

        private async Task<string> UploadLocalAsync(string fileName, Stream stream)
        {
            var localPath = Path.Combine(FileSystem.AppDataDirectory, fileName);

            using var fs = new FileStream(localPath, FileMode.Create, FileAccess.Write);
            await stream.CopyToAsync(fs);

            return localPath;
        }

        private async void ContactUsClicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("ContactUsPage");
        }

        private async void FarmersOrdersClicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(Pages.Farmers.FarmerOrders));
        }
        private async void EditProductsButton(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync(nameof(Pages.Farmers.ProductsPage));
        }

    }
}