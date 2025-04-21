using Microsoft.Maui.Controls;
namespace MauiApp3;

public partial class FarmerShell : Shell
{
    public FarmerShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("Chatbot", typeof(Pages.Farmers.Chatbot));
        Routing.RegisterRoute("FarmerProfilePage", typeof(Pages.Farmers.FarmerProfilePage));
        Routing.RegisterRoute("PrivacyPolicyPage", typeof(Pages.Farmers.PrivacyPolicyPage));

        Routing.RegisterRoute("ContactUsPage", typeof(Pages.Farmers.ContactUsPage));
        Routing.RegisterRoute("AboutUsPage", typeof(Pages.Farmers.AboutUsPage));
        Routing.RegisterRoute("AddProductsFarmer", typeof(Pages.Farmers.AddProductsFarmer));

        Routing.RegisterRoute("FarmerOrders", typeof(Pages.Farmers.FarmerOrders));




    }
}