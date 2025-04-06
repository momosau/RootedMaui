using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Models
{
   public class Productemp : INotifyPropertyChanged
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
        public int CategoryId { get; set; }
        public int Quantity { get; set; }
        public double Weight { get; set; }
        public string ImageUrl { get; set; }
        public string Unit { get; set; }
    

        private bool _isInCart;
        public bool IsInCart
        {
            get => _isInCart;
            set
            {
                if (_isInCart != value)
                {
                    _isInCart = value;
                    OnPropertyChanged(nameof(IsInCart));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
