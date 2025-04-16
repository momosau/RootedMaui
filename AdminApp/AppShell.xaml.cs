using AdminApp.Pages;
namespace AdminApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AdminApproval", typeof(AdminApproval));

        }
    }
}
