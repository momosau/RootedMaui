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

        private Farmer _farmer;

        public Farmer Farmer
        {
            get => _farmer;
            set
            {
                _farmer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FarmerName));
            }
        }

        public string FarmerName => Farmer?.Name ?? "Loading...";

        public FarmerHomeViewModel()
        {
            LoadFarmer();
            Farmer = new Farmer { Name = "Test Farmer" }; 
        }

        private async void LoadFarmer()
        {
            int farmerId = 1; // Hardcoded for testing
            Farmer = await _farmerService.GetFarmerByIdAsync(farmerId);
            Console.WriteLine("Farmer loaded: " + Farmer?.Name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
