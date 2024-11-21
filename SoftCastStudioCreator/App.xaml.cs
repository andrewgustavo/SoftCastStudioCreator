using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator
{
    public partial class App : Application
    {
        public App(AuthenticationService authService,UserService userService)
        {
            InitializeComponent();

            // Passa o serviço de autenticação para o MainPage
            MainPage = new NavigationPage(new MainPage(authService, userService));
        }
    }
}