using System.Diagnostics;

namespace MauiApp3.Pages;

public partial class SignUpFarmer2 : ContentPage
{
    public bool IsOrganic { get; private set; }
    public bool IsWaterGrown { get; private set; }
    public bool IsGmoFree { get; private set; }
    public bool IsPesticideFree { get; private set; }

    public SignUpFarmer2()
    {
        InitializeComponent();
    }
    private async void UploadFileClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "اختر شهادة التوثيق",
                FileTypes = FilePickerFileType.Pdf
            });

            if (result != null)
            {
                string filePath = result.FullPath;
                await DisplayAlert("تم اختيار الملف", $"المسار: {filePath}", "موافق");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"File pick error: {ex.Message}");
            await DisplayAlert("خطأ", "لم يتم اختيار ملف", "موافق");
        }
    }

    private void CheckboxStates()
    {
        // Save the states of the checkboxes
        IsOrganic = OrganicCheck.IsChecked;
        IsWaterGrown = WatergrownCheck.IsChecked;
        IsGmoFree = GMOFreeCheck.IsChecked;
        IsPesticideFree = PesticideFreeCheck.IsChecked;
    }
    private async void NextClicked(object sender, EventArgs e)
    {
        // Save checkbox states before navigating to the next page
        CheckboxStates();

        await Navigation.PushAsync(new Pages.PhoneVerification());
    }





}