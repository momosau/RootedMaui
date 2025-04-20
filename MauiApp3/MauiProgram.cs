
using CommunityToolkit.Maui;
using CommunityToolkit.Mvvm.DependencyInjection;
using MauiApp3.ModelView;
using MauiApp3.Pages.Consumers;
using MauiApp3.Services;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

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
            builder.Services.AddTransient<Pages.Consumers.ProductPage>();
            builder.Services.AddHttpClient<IProductService, ProductService>();
            builder.Services.AddSingleton<CartViewModel>();
            builder.Services.AddTransient<ShoppingCart>();
            builder.Services.AddSingleton<CartViewModel>();
            builder.Services.AddHttpClient<ICartService, CartService>();
            builder.Services.AddSingleton<ProductInfoVIewModel>();
            builder.Services.AddTransient<Pages.Consumers.ProductInfo>();
            Ioc.Default.ConfigureServices(builder.Services.BuildServiceProvider());
            builder.Services.AddTransient<FarmerDetailViewModel>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
};