using System.Net.Http;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Layouts;
using System;
using System.Text.RegularExpressions;

namespace SoftCastStudioCreator.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            string nome = nomeEntry.Text?.Trim();
            string email = emailEntry.Text?.Trim();
            string senha = senhaEntry.Text?.Trim();
            string confirmarSenha = confirmSenhaEntry.Text?.Trim();

            // Lógica de validação de campos
            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(confirmarSenha))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            // Validar e-mail
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Erro", "Por favor, insira um e-mail válido.", "OK");
                return;
            }

            // Validar senhas
            if (senha != confirmarSenha)
            {
                await DisplayAlert("Erro", "As senhas não coincidem.", "OK");
                return;
            }
            // Simulação de cadastro bem-sucedido
            await DisplayAlert("Cadastro Concluído", "Seu cadastro foi realizado com sucesso!", "OK");

                        
            // Aqui você pode salvar os dados em algum serviço ou banco de dados
            string nomeCriador = nome;
            // Cadastro bem-sucedido, agora navegamos para a Dashboard            
            await Navigation.PushAsync(new DashboardPage(nomeCriador));
        }
        private bool IsValidEmail(string email)
        {
            // Expressão regular para validar o formato do e-mail
            var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return emailRegex.IsMatch(email);
        }
        private void OnBackToLoginClicked(object sender, EventArgs e)
        {
            // Navegar de volta para a tela de login
            Navigation.PopAsync();
        }        
    }
}
