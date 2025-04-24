using AdminApp.ViewModel;
namespace AdminApp.Pages;

public partial class QuestionPage : ContentPage
{
	public QuestionPage()
	{
		InitializeComponent();
        BindingContext = new QuestionViewModel();
    }
}