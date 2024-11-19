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

            await DisplayAlert("Cadastro Concluído", "Seu cadastro foi realizado com sucesso!", "OK");
                        
            string nomeCriador = nome;
            await Navigation.PushAsync(new DashboardPage(nomeCriador));
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