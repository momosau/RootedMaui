
using System.Text.Json;



using SharedLibraryy.Models; // Supports JSON serialization/deserializationicrosoft.Maui.Controls; // Provides access to UI elements for .NET MAUI applications


namespace MauiApp3.Pages.Consumers
{

    public partial class DeliveryPage : ContentPage
    {
        //private int _orderId; // Stores the order ID for fetching details

        public DeliveryPage() // Takes an order ID as a parameter
        { }
            //        InitializeComponent(); // Initializes the UI components (defined in XAML)
            //        _orderId = orderId; // Stores the order ID in a private field
            //        LoadOrderDetails(); // Calls a function to fetch and display the order details
            //    }
            //    private readonly HttpClient _httpClient = new HttpClient();
            //    private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
            //        ? "http://10.0.2.2:5140"
            //        : "https://localhost:7168";
            //    private async void LoadOrderDetails() // Declares an async method for loading order details
            //    {
            //        var order = await FetchOrderFromDatabase(_orderId); // Retrieve order details from API
            //        if (order == null)
            //        {
            //            await DisplayAlert("خطأ", "تعذر تحميل الطلب", "موافق");
            //            return;
            //        }

            //        // Update order status and image
            //        StatusLabel.Text = order.Status;
            //        StatusImage.Source = GetStatusImage(order.Status);
            //        UpdateStatusIcons(order.Status);

            //        // Update order details
            //        OrderNumberLabel.Text = $"رقم الطلب : {order.OrderNumber}";
            //        OrderItemsList.ItemsSource = order.Items;

            //        // Update the order summary
            //        ItemTotalLabel.Text = $"{order.ItemTotal} SAR";
            //        DeliveryFeeLabel.Text = $"{order.DeliveryFee} SAR";
            //        TotalLabel.Text = $"{order.Total} SAR";
            //    }

            //    private void UpdateStatusIcons(string status)
            //    {
            //        // Reset all icons to gray
            //        IconAccepted.Opacity = 0.5;
            //        IconShipped.Opacity = 0.5;
            //        IconOutForDelivery.Opacity = 0.5;
            //        IconDelivered.Opacity = 0.5;

            //        // Highlight the icon matching the current status
            //        switch (status)
            //        {
            //            case "Order Accepted":
            //                IconAccepted.Opacity = 1;
            //                break;
            //            case "Shipped":
            //                IconShipped.Opacity = 1;
            //                break;
            //            case "Out for Delivery":
            //                IconOutForDelivery.Opacity = 1;
            //                break;
            //            case "Delivered":
            //                IconDelivered.Opacity = 1;
            //                break;
            //        }
            //    }

            //    private string GetStatusImage(string status)
            //    {
            //        // Map status to image filename
            //        return status switch
            //        {
            //            "Order Accepted" => "status_accepted.png",
            //            "Shipped" => "status_shipped.png",
            //            "Out for Delivery" => "status_out_for_delivery.png",
            //            "Delivered" => "status_delivered.png",
            //            _ => "default_status.png"
            //        };
            //    }

            //    private async Task<Order> FetchOrderFromDatabase(int orderId)
            //    {
            //        try
            //        {
            //            using var httpClient = new HttpClient();
            //            string apiUrl = $"https://your-swagger-api-url/api/orders/{orderId}"; // Replace with real API URL

            //            var response = await httpClient.GetAsync(apiUrl);
            //            if (response.IsSuccessStatusCode)
            //            {
            //                var json = await response.Content.ReadAsStringAsync();
            //                var order = JsonSerializer.Deserialize<Order>(json, new JsonSerializerOptions
            //                {
            //                    //////PropertyNameCaseInsensitive = true
            //                });

            //                return order;
            //            }
            //            else
            //            {
            //                await DisplayAlert("خطأ", "فشل تحميل تفاصيل الطلب من الخادم.", "موافق");
            //                return null;
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
            //            return null;
            //        }
            //    }
        }
}