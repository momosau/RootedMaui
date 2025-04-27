namespace MauiApp3;
using Microsoft.Maui.Controls;
public partial class ConsumerShell : Shell
{
	public ConsumerShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("ConsumerProfilePage", typeof(Pages.Consumers.ConsumerProfilePage));

        Routing.RegisterRoute("AboutUsPageC", typeof(Pages.Consumers.AboutUsPageC));
        Routing.RegisterRoute("ContactUsPageC", typeof(Pages.Consumers.ContactUsPageC));
        Routing.RegisterRoute("PrivacyPolicyPageC", typeof(Pages.Consumers.PrivacyPolicyPageC));
        Routing.RegisterRoute("LocationPage", typeof(Pages.Consumers.LocationPage));
        Routing.RegisterRoute("MyLocationPage", typeof(Pages.Consumers.MyLocationPage));
        Routing.RegisterRoute("PaymentMethodPage", typeof(Pages.Consumers.PaymentMethodPage));
        Routing.RegisterRoute("Payment", typeof(Pages.Consumers.Payment));
        Routing.RegisterRoute("DeliveryPage", typeof(Pages.Consumers.DeliveryPage));
        Routing.RegisterRoute("Search", typeof(Pages.Consumers.Search));
        Routing.RegisterRoute("CForgotPassEmail", typeof(Pages.Consumers.CForgotPassEmail));

        Routing.RegisterRoute("CResetPasswordPage", typeof(Pages.Consumers.CResetPasswordPage));

    }
}