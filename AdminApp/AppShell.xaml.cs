using AdminApp.Pages;
namespace AdminApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("AdminApproval", typeof(AdminApproval));
            Routing.RegisterRoute("FarmerInfo", typeof(FarmerInfo));
            Routing.RegisterRoute("QuestionPage", typeof(QuestionPage));


        }
    }
}
