using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibraryy.Models
{
    [Table("Product")]
    public partial class Product : INotifyPropertyChanged
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
        public string Name { get; set; } = null!;

        [Range(0, double.MaxValue, ErrorMessage = "Weight must be a positive number.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = null!;

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public double Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "FarmerId is required.")]
        public int FarmerId { get; set; }

        [Required(ErrorMessage = "CategoryId is required.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Unit is required.")]
        public string Unit { get; set; } = null!;
       
        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public Farmer? Farmer { get; set; }  // Make it nullable
        public Category? CategoryNavigation { get; set; } // Nullable too


        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual Specification? Specification { get; set; }

        [NotMapped]
        private bool _isInCart;

        [NotMapped]
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
