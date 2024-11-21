using Microsoft.Maui.Controls;
using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator.Views
{
    public partial class DashboardPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;
        private readonly ContentService _contentService;
        public DashboardPage(UserService userService, ContentService contentService)
        {
            InitializeComponent();
            _userService = userService;
            _contentService = contentService;

            var criador = _userService.GetCriadorAtual();
            BemVindoLabel.Text = $"Bem-vindo, {criador.Nome}, à sua Dashboard SoftCast!";
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(_authService, _userService, _contentService));
        }

        private async void OnIncluirConteudoClicked(object sender, EventArgs e)
        {
            var newContentPage = new NewContentPage(_userService, _contentService);
            await Navigation.PushAsync(newContentPage);
        }
        private async void OnAcessarConteudosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllContentPage(_userService, _contentService));
        }
        private void OnIndicadoresClicked(object sender, EventArgs e)
        {
            DisplayAlert("Indicadores de Performance", "Aqui você poderá visualizar os indicadores de performance.", "OK");
        }
    }
}