using MauiApp3.Services;
using SharedLibraryy.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MauiApp3.ModelView
{
    public class FarmerHomeViewModel : INotifyPropertyChanged
    {
        private readonly FarmerService _farmerService = new FarmerService();
        private readonly ProductService _productService = new ProductService(new HttpClient());


        private Farmer _farmer;
        public Farmer Farmer
        {
            get => _farmer;
            set
            {
                _farmer = value;
                OnPropertyChanged();
            }
        }

        private double _rating;
        public double Rating
        {
            get => _rating;
            set
            {
                _rating = value;
                OnPropertyChanged();
            }
        }

        private int _productCount;
        public int ProductCount
        {
            get => _productCount;
            set
            {
                _productCount = value;
                OnPropertyChanged();
            }
        }
        public FarmerHomeViewModel()
        {
            LoadFarmer();
        }

        private async void LoadFarmer()
        {
            var farmerId = Preferences.Get("FarmerId", 0);
            if (farmerId == 0)
                farmerId = 1; // fallback

            Farmer = await _farmerService.GetFarmerByIdAsync(farmerId);
            Console.WriteLine("Farmer loaded: " + Farmer?.Name);

            var reviews = await _farmerService.GetFarmerReviewsAsync(farmerId);
            Rating = reviews.Any() ? reviews.Average(r => (double)r.Rating) : 0;

            var products = await _productService.GetProductsByFarmerIdAsync(farmerId);
            ProductCount = products.Count;
            Console.WriteLine("Farmer has " + ProductCount + " products");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
