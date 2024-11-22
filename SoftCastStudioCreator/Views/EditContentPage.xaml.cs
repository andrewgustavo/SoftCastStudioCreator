using System.Net.Http;
using Microsoft.Maui.Storage;
using SoftCastStudioCreator.Models;
using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator.Views
{
    public partial class EditContentPage : ContentPage
    {
        private readonly ContentService _contentService;

        private int _conteudoId;
        // O ContentService será injetado automaticamente pelo .NET MAUI
        public EditContentPage(int conteudoId, ContentService contentService)
        {
            InitializeComponent();
            _contentService = contentService;
            _conteudoId = conteudoId;
            LoadConteudo(conteudoId);  // Carregar conteúdo para edição
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
        // Método para carregar o conteúdo da API
        private async void LoadConteudo(int conteudoId)
        {
            try
            {
                // Chama o método GetConteudoAsync para obter o conteúdo da API
                var conteudo = await _contentService.GetConteudoAsync(conteudoId);

                if (conteudo != null)
                {
                    // Preencher os campos de edição com os dados do conteúdo                    
                    titleEntry.Text = conteudo.Titulo;
                    tipeEntry.Text = conteudo.Tipo;
                    descriptionEntry.Text = conteudo.Descricao;
                    classindicEntry.Text = conteudo.ClassificacaoIndicativa;
                    videoPathEntry.Text = conteudo.VideoPath;

                    _conteudoId = conteudo.ID;
                }
                else
                {
                    await DisplayAlert("Erro", "Conteúdo não encontrado.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao carregar o conteúdo: {ex.Message}", "OK");
            }
        }

        // Método para salvar as alterações no conteúdo
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            
            // Cria o objeto Conteudo com os dados dos campos de edição
            var conteudo = new Conteudo
            {
                ID = _conteudoId,
                Titulo = titleEntry.Text,
                Tipo = tipeEntry.Text,
                Descricao = descriptionEntry.Text,
                ClassificacaoIndicativa = classindicEntry.Text,
                VideoPath = videoPathEntry.Text,
                CriadorID = (titleEntry.BindingContext as Conteudo)?.CriadorID ?? 0 // Exemplo de recuperação do CriadorID
            };

            // Enviar as alterações para a API
            var sucesso = await _contentService.EditarConteudo(conteudo);

            try
            {
                if (sucesso)
                {
                    await DisplayAlert("Sucesso", "Conteúdo atualizado com sucesso!", "OK");
                    await Navigation.PopAsync();  // Voltar para a tela anterior
                }
                else
                {
                    await DisplayAlert("Erro", $"Conteúdo não encontrado.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Falha ao editar o conteúdo: {ex.Message}", "OK");
            }
        }
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}