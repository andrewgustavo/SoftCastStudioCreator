using Microsoft.Maui.Controls;

namespace SoftCastStudioCreator.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage(string nomeCriador)
        {
            InitializeComponent();
            BemVindoLabel.Text = $"Bem-vindo, {nomeCriador}, a sua Dashboard SoftCast";
        }
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
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