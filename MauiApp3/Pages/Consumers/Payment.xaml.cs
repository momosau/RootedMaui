using System.Text.RegularExpressions;

namespace MauiApp3.Pages.Consumers
{

    public partial class Payment : ContentPage
    {
        public Payment()
        {
            InitializeComponent();
        }
        private void OnCardNumberChanged(object sender, TextChangedEventArgs e)//triggered when the user types in the card number
        {
            string cardNumber = CardNumber.Text; //Retrieves the card number from the input field
            if (string.IsNullOrEmpty(cardNumber)) //If empty, removes the card logo and exits the method
            {
                CardLogo.Source = null;
                return;
            }
            // Check card type based on number prefix
            // sets card logo based on card type
            if (Regex.IsMatch(cardNumber, @"^4")) // Visa starts with 4
                CardLogo.Source = "visalogo.png";
            else if (Regex.IsMatch(cardNumber, @"^5[1-5]")) // MasterCard starts with 51-55
                CardLogo.Source = "mastercardlogo.png";
            else if (Regex.IsMatch(cardNumber, @"^6(011|5)")) // Mada starts with 6011 or 65
                CardLogo.Source = "madalogo.png";
            else
                CardLogo.Source = null;
        }
        
        private async void OnPayClicked(object sender, EventArgs e) //triggered when the user clicks the "Pay" button
        {
            if (string.IsNullOrWhiteSpace(CardNumber.Text) ||
                  string.IsNullOrWhiteSpace(ExpiryDateEntry.Text) ||
                    string.IsNullOrWhiteSpace(CvcEntry.Text))
            {
                await DisplayAlert("خطأ", "يرجى ملء جميع الحقول", "موافق"); //show alert message if user didn't enter all fields
                return;
            }

            await Shell.Current.GoToAsync("DeliveryPage");
        }
    }
}