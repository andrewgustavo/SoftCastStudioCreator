using System.Net.Http;
using Microsoft.Maui.Controls;
using SoftCastStudioCreator.Services;

namespace SoftCastStudioCreator.Views
{
    public partial class NewContentPage : ContentPage
    {
        private string? selectedVideoPath;
        private readonly UserService _userService;
        public NewContentPage()
        {
            InitializeComponent();
        }
        private async void OnSelectVideoClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Videos,
                    PickerTitle = "Selecione um vídeo"
                });

                if (result != null)
                {
                    selectedVideoPath = result.FullPath;
                    SelectedVideoLabel.Text = result.FileName;
                }
                else
                {
                    SelectedVideoLabel.Text = "Nenhum vídeo selecionado";                    
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Erro ao selecionar o arquivo: " + ex.Message, "OK");
            }
        }
        private async void OnIncludeClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleEntry.Text) ||
                string.IsNullOrWhiteSpace(descriptionEntry.Text) ||
                string.IsNullOrWhiteSpace(categoryEntry.Text)||
                string.IsNullOrEmpty(selectedVideoPath))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            await DisplayAlert("Sucesso", "Conteúdo incluído com sucesso!", "OK");
            await Navigation.PushAsync(new DashboardPage(_userService));
        }

        private async void OnBackToDashboardClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage(_userService)); 
        }
    }
}
