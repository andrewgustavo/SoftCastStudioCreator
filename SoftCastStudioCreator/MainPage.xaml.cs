using Microsoft.Maui.Controls;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SoftCastStudioCreator.Views;
using Microsoft.Maui.Controls;
using SoftCastStudioCreator.Models;
using SoftCastStudioCreator.Services;
using System;

namespace SoftCastStudioCreator
{
    public partial class MainPage : ContentPage
    {
        private readonly AuthenticationService _authService;
        private readonly UserService _userService;

        public MainPage(AuthenticationService authService, UserService userService)
        {
            InitializeComponent();
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        //private async void OnEntryCompleted(object sender, EventArgs e)
        //{
        //    await OnLoginClicked(sender, e);
        //}

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text?.Trim();
            string senha = senhaEntry.Text?.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            var login = new CriadorLogin
            {
                Email = email,
                Senha = senha
            };

            try
            {
                var json = JsonSerializer.Serialize(login);
                Console.WriteLine(json);
                // Tenta autenticar o usuário
                bool loginSuccess = await _authService.LoginAsync(login);

                if (loginSuccess)
                {
                    // Obter dados do usuário autenticado
                    Criador criador = await _userService.GetUserByEmailAsync(email);
                    if (criador != null)
                    {
                        // Armazena os dados no serviço para reutilização
                        _userService.SetUser(criador);

                        // Navega para a Dashboard
                        await Navigation.PushAsync(new DashboardPage(_userService));
                    }
                    else
                    {
                        await DisplayAlert("Erro", "Usuário não encontrado.", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Erro", "Login ou senha inválidos.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Ocorreu um erro: {ex.Message}", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage(_userService));
        }
    }
}