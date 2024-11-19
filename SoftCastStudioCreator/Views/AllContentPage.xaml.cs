using Microsoft.Maui.Controls;
using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Views
{
    public partial class AllContentPage : ContentPage
    {
        public AllContentPage()
        {
            InitializeComponent();
            // Aqui você pode chamar um método para buscar os conteúdos, como uma chamada à API.
            ConteudosCollectionView.ItemsSource = new List<Conteudo>
            {
                new Conteudo { ID = 1, Titulo = "Vídeo 1", Tipo = "Tutorial", Descricao = "Descrição do vídeo 1", ClassificacaoIndicativa = "Livre" },
                new Conteudo { ID = 2, Titulo = "Vídeo 2", Tipo = "Entretenimento", Descricao = "Descrição do vídeo 2", ClassificacaoIndicativa = "16" }
            };
        }

        // Função para o botão "Voltar à Dashboard"
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage("Andrew Silva")); // Volta para a página anterior (Dashboard)
        }

        // Função para o botão "Cadastrar Novo Conteúdo"
        private async void OnNovoConteudoClicked(object sender, EventArgs e)
        {
            // Navegar para a página de cadastro de conteúdo
            await Navigation.PushAsync(new NewContentPage());
        }

        // Função para o botão "Editar" (Passando o ID do conteúdo)
        private async void OnEditarConteudoClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int conteudoId = (int)button.CommandParameter; // Pega o ID do conteúdo a ser editado
            // Navegar para a página de edição, passando o ID do conteúdo
            await Navigation.PushAsync(new EditContentPage(conteudoId));
            //DisplayAlert("Acessar Conteúdos", "Aqui você pode acessar suas listas de conteúdo.", "OK");
        }

    }
}
