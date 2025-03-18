
using CommunityToolkit.Maui;
using MauiApp3.Services;
using Microsoft.Extensions.Logging;
using Refit;
using SharedLibraryy.Services;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Maui.Core.Hosting;
using MauiApp3.ModelView;
using MauiApp3.Pages;

namespace MauiApp3
{
    public static class MauiProgram
    {
        
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Rubik-Bold.ttf", "FontArabic");
                })
                  .UseMauiCommunityToolkit();

            builder.Services.AddSingleton<ProductPageViewModel>();
            builder.Services.AddSingleton<ProductPage>();
            builder.Services.AddHttpClient<IProductService, ProductService>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
};