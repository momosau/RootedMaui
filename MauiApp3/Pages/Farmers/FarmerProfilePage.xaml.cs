namespace MauiApp3.Pages.Farmers;

public partial class FarmerProfilePage : ContentPage
{
   
    public FarmerProfilePage()
	{
		InitializeComponent();
	}


   

    private async void EditProfilePicture(object sender, EventArgs e)
    {
        try
        {
            var file = await MediaPicker.PickPhotoAsync();
            if (file != null)
            {
                string localPath = Path.Combine(FileSystem.AppDataDirectory, file.FileName);
                using (var stream = await file.OpenReadAsync())
                using (var newStream = File.OpenWrite(localPath))
                {
                    await stream.CopyToAsync(newStream);
                }

                ProfileImage.Source = localPath;
             
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", "حدث خطأ أثناء اختيار الصورة", "حسناً");
        }
    }

   

}