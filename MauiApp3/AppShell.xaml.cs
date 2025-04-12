using MauiApp3.Pages;
using MauiApp3;

namespace MauiApp3
{
    public partial class AppShell : Shell
    {

public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AboutUsPage", typeof(AboutUsPage));
            Routing.RegisterRoute("AccountPageFarmer", typeof(Pages.Farmers.AccountPageFarmer));
            Routing.RegisterRoute("SignInFarmer", typeof(SignInFarmer));
            Routing.RegisterRoute("SplashFarmer", typeof(SplashFarmer));
            Routing.RegisterRoute("AddProductsFarmer", typeof(Pages.Farmers.AddProductsFarmer));
            Routing.RegisterRoute("Chatbot", typeof(Chatbot));
            Routing.RegisterRoute("FarmerHome", typeof(FarmerHome));
            Routing.RegisterRoute("ConsumerMainPage", typeof(Pages.Consumers.ConsumerMainPage));
            Routing.RegisterRoute("ContactUsPage", typeof(ContactUsPage));
            Routing.RegisterRoute("EditProductsFarmer", typeof(EditProductsFarmer));
            Routing.RegisterRoute("FarmerOrders", typeof(FarmerOrders));
            Routing.RegisterRoute("FarmerProducts", typeof(Pages.Farmers.FarmerProducts));
            Routing.RegisterRoute("FarmerProfilePage", typeof(FarmerProfilePage));
            Routing.RegisterRoute("ForgotPasswordEmail", typeof(ForgotPasswordEmail));
            Routing.RegisterRoute("LocationPage", typeof(LocationPage));
            Routing.RegisterRoute("PaymentMethodPage", typeof(Pages.Consumers.PaymentMethodPage));
            Routing.RegisterRoute("PhoneVerification", typeof(PhoneVerification));
            Routing.RegisterRoute("PrivacyPolicyPage", typeof(PrivacyPolicyPage));
            Routing.RegisterRoute("ResetPasswordPage", typeof(ResetPasswordPage));
            Routing.RegisterRoute("SignInConsumer", typeof(Pages.Consumers.SignInConsumer));
            Routing.RegisterRoute("SignUpFarmer", typeof(SignUpFarmer));
           
            Routing.RegisterRoute("SplashConsumer", typeof(Pages.Consumers.SplashConsumer));
            Routing.RegisterRoute("SplashFarmerFinal", typeof(SplashFarmerFinal));
            Routing.RegisterRoute("VerificationCodePage", typeof(VerificationCodePage));
            Routing.RegisterRoute("ProductPage", typeof(Pages.Consumers.ProductPage)); 
                  Routing.RegisterRoute("MyLocationPage", typeof(MyLocationPage));
            Routing.RegisterRoute("Payment", typeof(Pages.Consumers.Payment));
            Routing.RegisterRoute("DeliveryPage", typeof(DeliveryPage));
            Routing.RegisterRoute("ShoppingCart", typeof(Pages.Consumers.ShoppingCart));


            Routing.RegisterRoute("ProductPage", typeof(Pages.Consumers.ProductPage));
            Routing.RegisterRoute("CategoriesPage", typeof(Pages.Consumers.CategoriesPage));



           


































        }
    }
}
