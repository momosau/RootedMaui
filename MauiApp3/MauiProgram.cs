
using CommunityToolkit.Maui;
using MauiApp3.Services;
using Microsoft.Extensions.Logging;
using Refit;
using SharedLibraryy.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MauiApp3
{
    public static class MauiProgram
    {
        
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Rubik-Bold.ttf", "FontArabic");
                })
                  .UseMauiCommunityToolkit();

            builder.Services.AddSingleton<HttpClient>();
            builder.Services.AddSingleton<IApiServices, ApiServices>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
};