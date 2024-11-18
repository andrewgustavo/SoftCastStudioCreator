using Microsoft.Maui.Controls;

namespace SoftCastStudioCreator.Views
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage(string nomeCriador)
        {
            InitializeComponent();

            // Certifique-se de que a Label BemVindoLabel foi corretamente encontrada
            BemVindoLabel.Text = $"Bem-vindo, {nomeCriador}, a sua Dashboard SoftCast";
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Navegar de volta para a página de login
            await Navigation.PushAsync(new MainPage());
        }

        // Evento para o botão "Incluir Lista de Conteúdo"
        private async void OnIncluirListaClicked(object sender, EventArgs e)
        {
            // Lógica para incluir lista de conteúdo
            //DisplayAlert("Incluir Lista", "Aqui você poderá incluir suas listas de conteúdo.", "OK");
            await Navigation.PushAsync(new NewContentPage());
        }

        // Evento para o botão "Indicadores de Performance"
        private void OnIndicadoresClicked(object sender, EventArgs e)
        {
            // Lógica para acessar indicadores de performance
            DisplayAlert("Indicadores de Performance", "Aqui você pode visualizar os indicadores de performance.", "OK");
        }
    }
}
