namespace MauiApp3.Pages;

public partial class ConsumerMainPage : ContentPage
{
	public ConsumerMainPage()
	{
		InitializeComponent();
	}
    void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
    {
        double value = args.NewValue;

    }
}