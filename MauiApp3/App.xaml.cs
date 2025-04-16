namespace MauiApp3
{
    public partial class App : Application
    {
        public static string UserType = ""; 

        public App()
        {
            InitializeComponent();

            if (UserType == "consumer")
            {
                MainPage = new ConsumerShell();
            }
            else if (UserType == "farmer")
            {
                MainPage = new FarmerShell();
            }
            else
            {
              
                MainPage = new NavigationPage(new MainPage());
            }
       

        }

    }
}
