using System.Net.Http;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using SoftCastStudioCreator.Models;
using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator.Views
{
    public partial class NewContentPage : ContentPage
    {       
        private readonly UserService _userService;
        private readonly ContentService _contentService;
        public NewContentPage(UserService userService, ContentService contentService)
        {
            InitializeComponent();            
            _userService = userService;
            _contentService = contentService;
        }

        private async void OnSelectVideoClicked(object sender, EventArgs e)
        {
            try
            {
                // Abre o seletor de arquivos e permite escolher um arquivo de vídeo
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Selecione um vídeo",
                    FileTypes = FilePickerFileType.Videos // Filtra para vídeos
                });

                if (result != null)
                {
                    // Se um arquivo for selecionado, preenche o campo de texto com o caminho do vídeo
                    videoPathEntry.Text = result.FullPath;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao selecionar o vídeo: {ex.Message}", "OK");
            }
        }
        private async void OnIncludeClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleEntry.Text) ||
                string.IsNullOrWhiteSpace(descriptionEntry.Text) ||
                string.IsNullOrWhiteSpace(tipeEntry.Text) ||
                string.IsNullOrWhiteSpace(videoPathEntry.Text))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            // Obtendo o criador logado
            var criadorAtual = _userService.GetCriadorAtual();

            if (criadorAtual == null)
            {
                await DisplayAlert("Erro", "Não foi possível identificar o criador logado.", "OK");
                return;
            }

            var novoConteudo = new Conteudo
            {
                Titulo = titleEntry.Text,
                Tipo = tipeEntry.Text,
                Descricao = descriptionEntry.Text,
                ClassificacaoIndicativa = classindicEntry.Text,
                VideoPath = videoPathEntry.Text,
                CriadorID = criadorAtual.ID
            };

            Console.WriteLine("Title: " + titleEntry?.Text);
            Console.WriteLine("Description: " + descriptionEntry?.Text);
            Console.WriteLine("Category: " + tipeEntry?.Text);
            Console.WriteLine("Video Path: " + videoPathEntry?.Text);

            try
            {
                bool sucesso = await _contentService.CreateContentAsync(novoConteudo);
                if (sucesso)
                {
                    await DisplayAlert("Sucesso", "Conteúdo incluído com sucesso!", "OK");
                    await Navigation.PushAsync(new DashboardPage(_userService, _contentService));
                }
                else
                {
                    await DisplayAlert("Erro", "Falha ao incluir o conteúdo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Erro ao incluir o conteúdo: " + ex.Message, "OK");
            }
        }

        private async void OnBackToDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage(_userService, _contentService)); 
        }
    }
}
