using MauiApp3.Services;
using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.ModelView
{
    public class FarmerDetailViewModel
    {
        public Farmer Farmer { get; set; }

        public ObservableCollection<Review> Reviews { get; set; } = new();

        private readonly FarmerService _farmerService = new();

        public FarmerDetailViewModel(Farmer selectedFarmer)
        {
            Farmer = selectedFarmer;
            LoadFarmerReviews(selectedFarmer.FarmerId);
        }

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