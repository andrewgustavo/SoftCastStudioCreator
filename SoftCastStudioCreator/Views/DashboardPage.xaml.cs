using Microsoft.Maui.Controls;
using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator.Views
{
    public partial class DashboardPage : ContentPage
    {
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;

        public DashboardPage(UserService userService)
        {
            InitializeComponent();
            _userService = userService;

            var criador = _userService.GetCriadorAtual();
            BemVindoLabel.Text = $"Bem-vindo, {criador.Nome}, à sua Dashboard SoftCast!";
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(null,null));
        }

        private async void OnIncluirConteudoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewContentPage());
        }
        private async void OnAcessarConteudosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllContentPage());
        }
        private void OnIndicadoresClicked(object sender, EventArgs e)
        {
            DisplayAlert("Indicadores de Performance", "Aqui você poderá visualizar os indicadores de performance.", "OK");
        }
    }
}