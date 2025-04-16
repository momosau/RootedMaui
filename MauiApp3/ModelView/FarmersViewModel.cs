using MauiApp3.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryy.Models;

namespace MauiApp3.ModelView

{
    public class FarmersViewModel : BaseViewModel
    {
        private readonly FarmerService _service;
        public ObservableCollection<Farmer> Farmers { get; set; } = new();

        public FarmersViewModel()
        {
            _service = new FarmerService();
            LoadFarmersCommand = new Command(async () => await LoadFarmers());
            LoadFarmersCommand.Execute(null);
        }

        public Command LoadFarmersCommand { get; }

        private async Task LoadFarmers()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var farmers = await _service.GetFarmersAsync();
                Farmers.Clear();

                if (farmers != null)
                {
                    foreach (var farmer in farmers)
                        Farmers.Add(farmer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in LoadFarmers: {ex.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
    }
