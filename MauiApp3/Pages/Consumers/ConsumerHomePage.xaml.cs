using Microsoft.Maui.Controls;
using SharedLibraryy.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace MauiApp3.Pages.Consumers;

    public partial class ConsumerHomePage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string BaseUrl = DeviceInfo.Platform == DevicePlatform.Android
? "http://10.0.2.2:5140/"
: "https://localhost:7168/";
    private Consumer _consumer;


        public ObservableCollection<LFarm> Farmers { get; set; } = new ObservableCollection<LFarm>();
         public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();
    public ConsumerHomePage(): this (new Consumer())
    {
    }


    public ConsumerHomePage(Consumer consumer)
         {
             InitializeComponent();
            _consumer = consumer;
            FarmersListView.ItemsSource = Farmers;
             LoadData();
         }
   


    private async void LoadData()
         {
             await LoadTopFarmers();
             await LoadCategories();
         }

         private async void OnShowAllCategoriesClicked(object sender, EventArgs e)
         {
             await Navigation.PushAsync(new CategoriesPage());
         }


         private async Task LoadTopFarmers()
         {
             try
             {
                 string url = $"{BaseUrl}api/TopFarmer/top10";
            var response = await _httpClient.GetStringAsync(url);
                 var farmers = JsonSerializer.Deserialize<List<LFarm>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                 if (farmers != null)
                 {
                     Farmers.Clear();
                     foreach (var farmer in farmers)
                     {
                         if (farmer.AvgRating >= 1 && farmer.AvgRating < 2)
                         {
                             farmer.review = "★☆☆☆☆";
                         }
                         else if (farmer.AvgRating >= 2 && farmer.AvgRating < 3)
                         {
                             farmer.review = "★★☆☆☆";
                         }
                         else if (farmer.AvgRating >= 3 && farmer.AvgRating < 4)
                         {
                             farmer.review = "★★★☆☆";
                         }
                         else if (farmer.AvgRating >= 4 && farmer.AvgRating < 5)
                         {
                             farmer.review = "★★★★☆";
                         }
                         else if (farmer.AvgRating == 5)
                         {
                             farmer.review = "★★★★★";
                         }

                         Farmers.Add(farmer);
                     }
                 }
             }
             catch (Exception ex)
             {
                 await DisplayAlert("خطأ", $"حدث خطأ أثناء تحميل المزارعين: {ex.Message}", "موافق");
             }
         }

         private async Task LoadCategories()
         {
             try
             {
                 string url = $"{BaseUrl}api/Categories";
                 var response = await _httpClient.GetStringAsync(url);
                 var categories = JsonSerializer.Deserialize<List<Category>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                 if (categories != null)
                 {
                     Categories.Clear();
                     CategoriesStack.Children.Clear(); // تنظيف المحتوى السابق قبل إعادة التحميل

                     foreach (var category in categories)
                     {
                         Categories.Add(category);

                         // إنشاء البطاقة
                         var categoryFrame = new Frame
                         {
                             CornerRadius = 15,
                             Padding = 10,
                             Margin = 5,
                             BackgroundColor = Colors.White,
                             HasShadow = true,
                             Content = new StackLayout
                             {
                                 Spacing = 10,
                                 HorizontalOptions = LayoutOptions.Center,
                                 VerticalOptions = LayoutOptions.Center,
                                 Children =
                         {
                          
                             new Image
                             {
                                 Source =string.IsNullOrEmpty(category.ImagesUrl) ? "default_image.png" : category.ImagesUrl,
                                 WidthRequest = 80,
                                 HeightRequest = 80,
                                 Aspect = Aspect.AspectFill

                             },

                         
                             new Label
                             {
                                 Text = category.CategoryName,
                                 FontSize = 16,
                                 FontAttributes = FontAttributes.Bold,
                                 HorizontalOptions = LayoutOptions.Center,
                                 TextColor = Colors.Black
                             }
                         }
                             }
                         };

                      
                         CategoriesStack.Children.Add(categoryFrame);
                     }
                 }
             }
             catch (Exception ex)
             {
                 await DisplayAlert("خطأ", $"حدث خطأ أثناء تحميل الأصناف: {ex.Message}", "موافق");
             }
         }

    private async void OnSearchTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Search");
    }


}





public class LFarm
     {
         public int FarmerId { get; set; }
         public string Name { get; set; }
         public string City { get; set; }
         public string FarmName { get; set; }
         public string Email { get; set; }
         public string ImageUrl { get; set; }
         public string review { get; set; }
         public double AvgRating { get; set; }
 
   
}

     public class Category
     {
         public int CategoryId { get; set; }
         public string CategoryName { get; set; }
         public string ImagesUrl { get; set; }

      
    }





