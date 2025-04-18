using MauiApp3.Services;
using System.Collections.ObjectModel;
using SharedLibraryy.Models;

namespace MauiApp3.ModelView
{
    public class FarmersViewModel : BaseViewModel
    {
        private readonly FarmerService _service;
        public ObservableCollection<Farmer> Farmers { get; set; } = new();

        public Command LoadFarmersCommand { get; }

        public FarmersViewModel()
        {
            _service = new FarmerService();
            LoadFarmersCommand = new Command(async () => await LoadFarmers());
            LoadFarmersCommand.Execute(null);
        }

        private async Task LoadFarmers()
        {
            var farmersList = await _service.GetFarmersAsync();

            foreach (var farmer in farmersList)
            {
                Console.WriteLine($"Farmer: {farmer.Name} | City: {farmer.City} | IsOrganic: {farmer.Specification?.IsOrganic}");
            }

            Farmers.Clear();
            foreach (var farmer in farmersList)
                Farmers.Add(farmer);
        }
    }
}
