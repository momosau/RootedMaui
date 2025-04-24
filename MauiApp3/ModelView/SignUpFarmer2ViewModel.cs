using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp3.ModelView
{
    public partial class SignUpFarmer2ViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isLocal = false;

        [ObservableProperty]
        private bool _isOrganic = false;

        [ObservableProperty]
        private bool _isGmoFree = false;

        [ObservableProperty]
        private bool _isHydroponicallyGrown = false;

        [ObservableProperty]
        private bool _isPesticideFree = false;
    }
}
