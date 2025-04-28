using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharedLibraryy.Models;
namespace MauiApp3.Helpers
{
    public static class UserSession
    {
        public static Farmer LoggedInFarmer { get; set; }
        public static Consumer LoggedInConsumer { get; set; }
    }
}
