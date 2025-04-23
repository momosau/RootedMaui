using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp3.ModelView
{
    public class FarmerDetailViewModel
    {
        public Farmer Farmer { get; set; }
        private readonly IProductService _productService;

        public ObservableCollection<Product> Products { get; set; } = new();

        public ObservableCollection<Review> Reviews { get; set; } = new();

        private readonly FarmerService _farmerService = new();

        public FarmerDetailViewModel(IProductService productService, Farmer selectedFarmer)
        {
            if (selectedFarmer == null)
                throw new ArgumentNullException(nameof(selectedFarmer), "Selected farmer is null");

            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
            Farmer = selectedFarmer;

            LoadFarmerReviews(Farmer.FarmerId);
            LoadProductsAsync(Farmer.FarmerId);
        }

        public async Task LoadProductsAsync(int farmerId)
        {
        
            var products = await _productService.GetProductsByFarmer(farmerId);
            Products.Clear();

            foreach (var product in products)
                Products.Add(product);

            // Notify UI in case it needs to update binding
            OnPropertyChanged(nameof(Products));
        }

        // INotifyPropertyChanged boilerplate
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private async void LoadFarmerReviews(int farmerId)
        {
            try
            {
                // Ensure reviews is not null and load the reviews from the service
                var reviews = await _farmerService.GetFarmerReviewsAsync(farmerId);

                // Clear existing reviews (if any)
                Reviews.Clear();

                // Check if reviews are not null or empty
                if (reviews != null && reviews.Any())
                {
                    // Add reviews to the ObservableCollection
                    foreach (var review in reviews)
                    {
                        Reviews.Add(review);
                    }
                }
                else
                {
                    // Optionally, add a default "No Reviews" if there are no reviews
                    // Reviews.Add(new Review { Comment = "No reviews yet." });
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during fetching reviews
                Console.WriteLine($"Error loading reviews: {ex.Message}");
                // Optionally, you can set a flag or message to display an error to the user
            }
        }

    }


}