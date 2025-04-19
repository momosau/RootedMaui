using SharedLibraryy.Models;
using System.Collections.ObjectModel;
namespace MauiApp3.Pages.Consumers;

public partial class ConsumerHomePage : ContentPage
{
    private Consumer _consumer;



    public ConsumerHomePage(Consumer consumer)
    {
        InitializeComponent();
        _consumer = consumer;
        
    }
}