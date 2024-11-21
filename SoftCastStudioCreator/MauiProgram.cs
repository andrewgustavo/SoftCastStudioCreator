using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
