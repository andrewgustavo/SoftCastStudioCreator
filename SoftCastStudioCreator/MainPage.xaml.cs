using Microsoft.Maui.Controls;
using SoftCastStudioCreator.Views;

namespace SoftCastStudioCreator

{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnEntryCompleted(object sender, EventArgs e)
        {
            // Chama o método de login quando Enter for pressionado
            OnLoginClicked(sender, e);
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text?.Trim();
            string senha = senhaEntry.Text?.Trim();

            // Validação simplificada de login
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Lógica de validação de login (simulada aqui, pode ser feito via API)
            if (email == "teste" && senha == "teste")
            {
                // Navegar para a DashboardPage com o nome do criador
                await Navigation.PushAsync(new DashboardPage("Andrew Silva"));
            }
            else
            {
                await DisplayAlert("Erro", "Login ou senha inválidos.", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            // Navegação para a tela de cadastro
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
