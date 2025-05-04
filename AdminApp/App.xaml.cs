using AdminApp.Pages;

namespace AdminApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SignInAdmin();
        }
    }
}
