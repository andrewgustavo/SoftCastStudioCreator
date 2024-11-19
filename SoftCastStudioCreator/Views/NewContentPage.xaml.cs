using Microsoft.Maui.Controls;

namespace SoftCastStudioCreator.Views
{
    public partial class NewContentPage : ContentPage
    {
        private string? selectedVideoPath;

        public NewContentPage()
        {
            InitializeComponent();
        }

        private async void OnSelectVideoClicked(object sender, EventArgs e)
        {
            try
            {
                // Abrir o FilePicker para escolher um arquivo de vídeo
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Videos,  // Restrição para arquivos de vídeo
                    PickerTitle = "Selecione um vídeo"
                });

                if (result != null)
                {
                    // Exibir o nome do arquivo selecionado
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
                // Tratar erro, por exemplo, se não conseguir abrir o FilePicker
                await DisplayAlert("Erro", "Erro ao selecionar o arquivo: " + ex.Message, "OK");
            }
        }
        private async void OnIncludeClicked(object sender, EventArgs e)
        {
            // Validação de campos obrigatórios
            if (string.IsNullOrWhiteSpace(titleEntry.Text) ||
                string.IsNullOrWhiteSpace(descriptionEntry.Text) ||
                string.IsNullOrWhiteSpace(categoryEntry.Text)||
                !string.IsNullOrEmpty(selectedVideoPath))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            // Lógica de inclusão (a ser implementada)
            await DisplayAlert("Sucesso", "Conteúdo incluído com sucesso!", "OK");
        }

        private async void OnBackToDashboardClicked(object sender, EventArgs e)
        {
            // Navegação de retorno para a Dashboard
            await Navigation.PushAsync(new DashboardPage("Andrew Silva")); 
        }
    }
}
