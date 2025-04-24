using MauiApp3.Pages;

namespace MauiApp3
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AboutUsPage", typeof(Pages.Farmers.AboutUsPage));
            Routing.RegisterRoute("AccountPageFarmer", typeof(Pages.Farmers.AccountPageFarmer));
            Routing.RegisterRoute("SignInFarmer", typeof(Pages.Farmers.SignInFarmer));
            Routing.RegisterRoute("SplashFarmer", typeof(SplashFarmer));
            Routing.RegisterRoute("AddProductsFarmer", typeof(Pages.Farmers.AddProductsFarmer));

            Routing.RegisterRoute("Chatbot", typeof(Pages.Farmers.Chatbot));
            Routing.RegisterRoute("FarmerHome", typeof(Pages.Farmers.FarmerHome));
            Routing.RegisterRoute("ConsumerMainPage", typeof(Pages.Consumers.ConsumerMainPage));
            Routing.RegisterRoute("ContactUsPage", typeof(Pages.Farmers.ContactUsPage));
            Routing.RegisterRoute("EditProductsFarmer", typeof(EditProductsFarmer));
            Routing.RegisterRoute("FarmerOrders", typeof(Pages.Farmers.FarmerOrders));

            Routing.RegisterRoute("FarmerProducts", typeof(Pages.Farmers.FarmerProducts));
            Routing.RegisterRoute("FarmerProfilePage", typeof(Pages.Farmers.FarmerProfilePage));
            Routing.RegisterRoute("ForgotPasswordEmail", typeof(ForgotPasswordEmail));
            Routing.RegisterRoute("LocationPage", typeof(Pages.Consumers.LocationPage));
            Routing.RegisterRoute("MyLocationPage", typeof(Pages.Consumers.MyLocationPage));

            Routing.RegisterRoute("PaymentMethodPage", typeof(Pages.Consumers.PaymentMethodPage));
            Routing.RegisterRoute("CEmailVerification", typeof(Pages.Consumers.CEmailVerification));
            Routing.RegisterRoute("ConsumerHomePage", typeof(Pages.Consumers.ConsumerHomePage));


            Routing.RegisterRoute("PhoneVerification", typeof(Pages.Farmers.EmailVerification));

            Routing.RegisterRoute("PrivacyPolicyPage", typeof(Pages.Farmers.PrivacyPolicyPage));
            Routing.RegisterRoute("ResetPasswordPage", typeof(ResetPasswordPage));
            Routing.RegisterRoute("SignInConsumer", typeof(Pages.Consumers.SignInConsumer));
            Routing.RegisterRoute("SignUpFarmer", typeof(Pages.Farmers.SignUpFarmer));
            Routing.RegisterRoute("SignUpFarmer2", typeof(Pages.Farmers.SignUpFarmer2));
            Routing.RegisterRoute("SplashConsumer", typeof(Pages.Consumers.SplashConsumer));
            Routing.RegisterRoute("SplashFarmerFinal", typeof(SplashFarmerFinal));
            Routing.RegisterRoute("VerificationCodePage", typeof(VerificationCodePage));
            Routing.RegisterRoute("ProductPage", typeof(Pages.Consumers.ProductPage));
        
            Routing.RegisterRoute("Payment", typeof(Pages.Consumers.Payment));
            Routing.RegisterRoute("DeliveryPage", typeof(Pages.Consumers.DeliveryPage));
            Routing.RegisterRoute("ShoppingCart", typeof(Pages.Consumers.ShoppingCart));
            Routing.RegisterRoute("ProductPage", typeof(Pages.Consumers.ProductPage));
            Routing.RegisterRoute("CategoriesPage", typeof(Pages.Consumers.CategoriesPage));
            Routing.RegisterRoute("FarmersListPage", typeof(Pages.Consumers.FarmersListPage));
            Routing.RegisterRoute("FarmerDetailPage", typeof(Pages.Consumers.FarmerDetailPage));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("AccountPageConsumer", typeof(Pages.Consumers.AccountPageConsumer));
            Routing.RegisterRoute("ConsumerProfilePage", typeof(Pages.Consumers.ConsumerProfilePage));

            Routing.RegisterRoute("AboutUsPageC", typeof(Pages.Consumers.AboutUsPageC));
            Routing.RegisterRoute("ContactUsPageC", typeof(Pages.Consumers.ContactUsPageC));
            Routing.RegisterRoute("PrivacyPolicyPageC", typeof(Pages.Consumers.PrivacyPolicyPageC));
            Routing.RegisterRoute("Search", typeof(Pages.Consumers.Search));








        }
    }
}
