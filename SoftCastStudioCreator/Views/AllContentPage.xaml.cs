using Microsoft.Maui.Controls;
using System.Net.Http;
using SoftCastStudioCreator.Models;
using SoftCastStudioCreator.Services;
using CommunityToolkit.Maui;


namespace SoftCastStudioCreator.Views
{
    public partial class AllContentPage : ContentPage
    {
        private readonly UserService _userService;
        private readonly ContentService _contentService;
        public AllContentPage(UserService userService, ContentService contentService)
        {
            InitializeComponent();
            _userService = userService;
            _contentService = contentService;
            LoadConteudos();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            // Recarregar os conteúdos toda vez que a página aparecer
            LoadConteudos();
        }

        private async void LoadConteudos()
        {
            var criadorAtual = _userService.GetCriadorAtual();
            if (criadorAtual != null)
            {
                var conteudos = await _contentService.GetConteudosByCriadorAsync(criadorAtual.ID);
                ConteudosCollectionView.ItemsSource = conteudos;
            }
            else
            {
                await DisplayAlert("Erro", "Não foi possível carregar os conteúdos do criador logado.", "OK");
            }
        }
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage(_userService, _contentService));
        }
        private async void OnNovoConteudoClicked(object sender, EventArgs e)
        {
            var newContentPage = new NewContentPage(_userService, _contentService);
            await Navigation.PushAsync(newContentPage);
        }
        private async void OnEditarConteudoClicked(object sender, EventArgs e)
        {
            var conteudoId = (int)((Button)sender).CommandParameter;

            await Navigation.PushAsync(new EditContentPage(conteudoId, _contentService));
        }
        private async void OnDeletarConteudoClicked(object sender, EventArgs e)
        {
            var conteudoId = (int)((Button)sender).CommandParameter;
            bool confirmar = await DisplayAlert(
                "Confirmação",
                "Tem certeza de que deseja deletar este conteúdo?",
                "Sim",
                "Não"
             );

            if (confirmar)
            {
                var resultado = await _contentService.DeletarConteudo(conteudoId);

                if (resultado)
                {
                    await DisplayAlert("Sucesso", "Conteúdo deletado com sucesso!", "OK");
                    AtualizarLista();
                }
                else
                {
                    await DisplayAlert("Erro", "Falha ao deletar o conteúdo.", "OK");
                }
            }

        }
        private async void AtualizarLista()
        {
            try
            {
                var criadorAtual = _userService.GetCriadorAtual();
                if (criadorAtual != null)
                {
                    var conteudos = await _contentService.GetConteudosByCriadorAsync(criadorAtual.ID);
                    ConteudosCollectionView.ItemsSource = conteudos; // Atualiza a interface
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Não foi possível atualizar a lista: {ex.Message}", "OK");
            }
        }
    }
}
