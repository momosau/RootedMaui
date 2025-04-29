using SharedLibraryy.Models;
using System.Text.Json;

namespace MauiApp3.Pages.Consumers
{
    public partial class DeliveryPage : ContentPage
    {
        private readonly int _orderId;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5140"
            : "https://localhost:7168";

        public DeliveryPage(int orderId)
        {
            InitializeComponent();
            _orderId = orderId;
            //  LoadOrderDetails();
        }

        //private async void LoadOrderDetails()
        //{
        //    var order = await FetchOrderFromDatabase(_orderId);
        //    if (order == null)
        //    {
        //        await DisplayAlert("خطأ", "تعذر تحميل الطلب", "موافق");
        //        return;
        //    }

        //    // Update UI with order data
        //    StatusLabel.Text = order.Status;
        //    StatusImage.Source = GetStatusImage(order.Status);
        //    UpdateStatusIcons(order.Status);

        //    OrderNumberLabel.Text = $"رقم الطلب : {order.OrderNumber}";
        //    OrderItemsList.ItemsSource = order.Items;

        //    ItemTotalLabel.Text = $"{order.ItemTotal} SAR";
        //    DeliveryFeeLabel.Text = $"{order.DeliveryFee} SAR";
        //    TotalLabel.Text = $"{order.Total} SAR";
        //}

        private void UpdateOrderStatus(string status)
        {
            IconAccepted.Opacity = status == "Accepted" || status == "Shipped" || status == "OutForDelivery" || status == "Delivered" ? 1 : 0.5;
            IconShipped.Opacity = status == "Shipped" || status == "OutForDelivery" || status == "Delivered" ? 1 : 0.5;
            IconOutForDelivery.Opacity = status == "OutForDelivery" || status == "Delivered" ? 1 : 0.5;
            IconDelivered.Opacity = status == "Delivered" ? 1 : 0.5;

            StatusLabel.Text = status switch
            {
                "Accepted" => "تم قبول الطلب",
                "Shipped" => "تم شحن الطلب",
                "OutForDelivery" => "الطلب في الطريق",
                "Delivered" => "تم التوصيل",
                _ => "في انتظار المعالجة"
            };
        }

        private string GetStatusImage(string status)
        {
            return status switch
            {
                "Order Accepted" => "status_accepted.png",
                "Shipped" => "status_shipped.png",
                "Out for Delivery" => "status_out_for_delivery.png",
                "Delivered" => "status_delivered.png",
                _ => "default_status.png"
            };
        }

        private async Task<Order> FetchOrderFromDatabase(int orderId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}/api/orders/{orderId}");
                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("خطأ", "فشل تحميل تفاصيل الطلب من الخادم.", "موافق");
                    return null;
                }

                var json = await response.Content.ReadAsStringAsync();
                var order = JsonSerializer.Deserialize<Order>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return order;
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
                return null;
            }
        }
    }
}
