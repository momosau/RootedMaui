using MauiApp3.Pages;

namespace MauiApp3
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AboutUsPage", typeof(AboutUsPage));
            Routing.RegisterRoute("AccountPageFarmer", typeof(AccountPageFarmer));
            Routing.RegisterRoute("SignInFarmer", typeof(SignInFarmer));
            Routing.RegisterRoute("SplashFarmer", typeof(SplashFarmer));
            Routing.RegisterRoute("AddProductsFarmer", typeof(AddProductsFarmer));
            Routing.RegisterRoute("Chatbot", typeof(Chatbot));
            Routing.RegisterRoute("FarmerHome", typeof(FarmerHome));
            Routing.RegisterRoute("ConsumerMainPage", typeof(ConsumerMainPage));
            Routing.RegisterRoute("ContactUsPage", typeof(ContactUsPage));
            Routing.RegisterRoute("EditProductsFarmer", typeof(EditProductsFarmer));
            Routing.RegisterRoute("FarmerOrders", typeof(FarmerOrders));
            Routing.RegisterRoute("FarmerProducts", typeof(FarmerProducts));
            Routing.RegisterRoute("FarmerProfilePage", typeof(FarmerProfilePage));
            Routing.RegisterRoute("ForgotPasswordEmail", typeof(ForgotPasswordEmail));
            Routing.RegisterRoute("LocationPage", typeof(LocationPage));
            Routing.RegisterRoute("PaymentMethodPage", typeof(PaymentMethodPage));
            Routing.RegisterRoute("PhoneVerification", typeof(PhoneVerification));
            Routing.RegisterRoute("PrivacyPolicyPage", typeof(PrivacyPolicyPage));
            Routing.RegisterRoute("ResetPasswordPage", typeof(ResetPasswordPage));
            Routing.RegisterRoute("SignInConsumer", typeof(SignInConsumer));
            Routing.RegisterRoute("SignUpFarmer", typeof(SignUpFarmer));
            Routing.RegisterRoute("SignUpFarmer2", typeof(SignUpFarmer2));
            Routing.RegisterRoute("SplashConsumer", typeof(SplashConsumer));
            Routing.RegisterRoute("SplashFarmerFinal", typeof(SplashFarmerFinal));
            Routing.RegisterRoute("VerificationCodePage", typeof(VerificationCodePage));
            Routing.RegisterRoute("ProductPage", typeof(ProductPage)); 
                  Routing.RegisterRoute("MyLocationPage", typeof(MyLocationPage));
            Routing.RegisterRoute("Payment", typeof(Payment));
            Routing.RegisterRoute("DeliveryPage", typeof(DeliveryPage));
            Routing.RegisterRoute("ShoppingCart", typeof(ShoppingCart));


            Routing.RegisterRoute("ProductPage", typeof(ProductPage));
            Routing.RegisterRoute("CategoriesPage", typeof(CategoriesPage));
            Routing.RegisterRoute("AddProductsFarmer", typeof(AddProductsFarmer));




































        }
    }
}
