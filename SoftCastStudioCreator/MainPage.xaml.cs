using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
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
            OnLoginClicked(sender, e);
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text?.Trim();
            string senha = senhaEntry.Text?.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            if (email == "teste" && senha == "teste")
            {
                await Navigation.PushAsync(new DashboardPage("Andrew Silva"));
            }
            else

            {
                await DisplayAlert("Erro", "Login ou senha inválidos.", "OK");
            }
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
