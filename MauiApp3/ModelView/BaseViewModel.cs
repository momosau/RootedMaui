using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp3.ModelView
{
    public partial class BaseViewModel:ObservableObject
    {
        public BaseViewModel()
        {
        }
        [ObservableProperty]
         bool isBusy;

        [ObservableProperty]
        string title;
        public bool IsNotBusy => ! isBusy;

    }
}
