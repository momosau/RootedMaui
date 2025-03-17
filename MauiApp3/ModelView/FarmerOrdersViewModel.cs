using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.ModelView;

    public partial class FarmerOrdersViewModel:ObservableObject
    {
        public ObservableCollection<Order> Orders { get; set; }

        public FarmerOrdersViewModel()
        {
            // Create mock data for testing
            Orders = new ObservableCollection<Order>
            {
                new Order
                {
                    OrderNumber = "123",
                    OrderDate = "2025-02-26",
                    TotalAmount = "150 SAR",
                    Status = "Pending",
                    StatusColor = Microsoft.Maui.Graphics.Colors.Orange
                },
                new Order
                {
                    OrderNumber = "124",
                    OrderDate = "2025-02-25",
                    TotalAmount = "200 SAR",
                    Status = "Delivered",
                    StatusColor = Microsoft.Maui.Graphics.Colors.Green
                },
                new Order
                {
                    OrderNumber = "125",
                    OrderDate = "2025-02-24",
                    TotalAmount = "50 SAR",
                    Status = "Cancelled",
                    StatusColor = Microsoft.Maui.Graphics.Colors.Red
                }
            };
        }
    }

    // Order model
    public class Order
    {
   
        public string OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string TotalAmount { get; set; }
        public string Status { get; set; }
        public Microsoft.Maui.Graphics.Color StatusColor { get; set; }
    }
