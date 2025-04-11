
using CommunityToolkit.Maui;
using MauiApp3.Services;
using Microsoft.Extensions.Logging;
using Refit;
using SharedLibraryy.Services;
using Microsoft.Extensions.DependencyInjection;
using Syncfusion.Maui.Core.Hosting;
using MauiApp3.ModelView;
using MauiApp3.Pages;
using CommunityToolkit.Mvvm.DependencyInjection;

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




            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<ProductPageViewModel>();
            builder.Services.AddTransient<ProductPage>();
            builder.Services.AddHttpClient<IProductService, ProductService>();
            builder.Services.AddSingleton<CartViewModel>();
            builder.Services.AddTransient<ShoppingCart>();
            builder.Services.AddHttpClient<ICartService, CartService>();
            builder.Services.AddSingleton<ProductInfoVIewModel>();
            builder.Services.AddTransient<ProductInfo>();
            Ioc.Default.ConfigureServices(builder.Services.BuildServiceProvider());

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
};