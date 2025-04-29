using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Helpers
{
    public static class SessionManager
    {
        public static void SignOut()
        {
            UserSession.LoggedInFarmer = null;
            UserSession.LoggedInConsumer = null;
            // Clear token, etc.
        }
    }

}
