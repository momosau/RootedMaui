

using Microsoft.Maui.Controls;


namespace MauiApp3.Pages.Consumers;

public partial class PaymentMethodPage : ContentPage
{
    public PaymentMethodPage()
    {
        InitializeComponent();
    }




    /* Unmerged change from project 'MauiApp3 (net8.0-maccatalyst)'
    Before:
        private void nextPaymnet_Clicked(object sender, EventArgs e)
        {
    After:
        private async Task nextPaymnet_ClickedAsync(object sender, EventArgs e)
        {
    */

    /* Unmerged change from project 'MauiApp3 (net8.0-maccatalyst)'
    Before:
        private async Task NextPaymnet_ClickedAsync(object sender, EventArgs e)
        {
    After:
        private void NextPaymnet_Clicked(object sender, EventArgs e)
        {
    */
    private async void NextPaymnet_Clicked(object sender, EventArgs e)
    {
        //if (!CashRadioButton.IsChecked && !CardRadioButton.IsChecked)
        //{
        //    await DisplayAlert("Error", "الرجاء اختيار طريقة دفع", "OK");
        //    return;
        //}
        //if (CashRadioButton.IsChecked)
        //{
        //    // Navigate to the normal confirmation page

        //    await Shell.Current.GoToAsync("LocationPage");
        //}
        //else { await Shell.Current.GoToAsync("Payment"); }
    }
}