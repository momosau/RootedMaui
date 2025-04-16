using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui;
using AdminApp.ViewModel;
using AdminApp.Services;

namespace AdminApp
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
                });
            builder.UseMauiApp<App>().UseMauiCommunityToolkitCore();
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<AdminApprovalViewModel>();
            builder.Services.AddTransient<Pages.AdminApproval>();
            builder.Services.AddHttpClient<IFarmerApplicationService, FarmerApilicationService>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
