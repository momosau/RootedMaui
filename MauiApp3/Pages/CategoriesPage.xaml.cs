using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MauiApp3.Pages;

public partial class CategoriesPage : ContentPage
{
	public CategoriesPage()
	{
		InitializeComponent();
        BindingContext = this;
    }


        private readonly HttpClient _httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:7168/api/Categories"; // ���� �� ��� �������

        public ObservableCollection<Categooo> Categories { get; set; } = new ObservableCollection<Categooo>();


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadCategories();
        }

        private async Task LoadCategories()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(ApiUrl);
                var categories = JsonConvert.DeserializeObject<List<Categooo>>(response);

                if (categories != null)
                {
                    Categories.Clear();
                    foreach (var category in categories)
                    {
                        Categories.Add(category);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("���", "��� �� ����� ��������: " + ex.Message, "�����");
            }
        }
    }

    public class Categooo
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string imagesURL { get; set; }
    }

