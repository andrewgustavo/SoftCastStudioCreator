using SoftCastStudioCreator.Models;
using SoftCastStudioCreator.Services;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SoftCastStudioCreator.Views
{
    public partial class RegisterPage : ContentPage
    {
        private readonly UserService _userService;
        private readonly ContentService _contentService;

        public RegisterPage(UserService userService, ContentService contentService)
        {
            InitializeComponent();
            _userService = userService;
            _contentService = contentService;
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            string nome = nomeEntry.Text?.Trim();
            string email = emailEntry.Text?.Trim();
            string senha = senhaEntry.Text?.Trim();
            string confirmarSenha = confirmSenhaEntry.Text?.Trim();

            // Validações de entrada
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmarSenha))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            if (!IsValidEmail(email))
            {
                await DisplayAlert("Erro", "Por favor, insira um e-mail válido.", "OK");
                return;
            }

            if (senha != confirmarSenha)
            {
                await DisplayAlert("Erro", "As senhas não coincidem.", "OK");
                return;
            }

            // Criar objeto Criador
            var criador = new Criador
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            try
            {
                // Registrar criador via UserService
                var sucesso = await _userService.RegisterCriadorAsync(criador);

                if (sucesso)
                {
                    await DisplayAlert("Cadastro Concluído", "Seu cadastro foi realizado com sucesso!", "OK");
                    await Navigation.PushAsync(new DashboardPage(_userService, _contentService));
                }
                else
                {
                    await DisplayAlert("Erro", "Não foi possível realizar o cadastro. Tente novamente.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao se comunicar com a API: {ex.Message}", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }

        private void OnBackToLoginClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
