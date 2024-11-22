using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SoftCastStudioCreator.Services;
using SoftCastStudioCreator.Views;
using CommunityToolkit.Maui;

namespace SoftCastStudioCreator
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitMediaElement()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
                });

                        
            // Configurar endereço base da API
            builder.Services.AddSingleton(sp => new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7216")
            });

            // Registrar serviços
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<ContentService>();

            builder.Services.AddTransient<DashboardPage>();
            builder.Services.AddTransient<NewContentPage>();
            builder.Services.AddTransient<AllContentPage>();
            builder.Services.AddTransient<EditContentPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
