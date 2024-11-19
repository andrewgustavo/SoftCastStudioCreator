using System.Net.Http;
using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Views
{
    public partial class EditContentPage : ContentPage
    {
        private int _conteudoId;
        public EditContentPage(int conteudoId)
        {
            InitializeComponent();
            _conteudoId = conteudoId;
            LoadConteudo(conteudoId);
        }
        private void LoadConteudo(int conteudoId)
        {
            var conteudo = new Conteudo
            {
                ID = conteudoId,
                Titulo = "Vídeo Tutorial",
                Tipo = "Educação",
                Descricao = "Descrição do vídeo tutorial",
                ClassificacaoIndicativa = "Livre",
                VideoPath = "C:\\Users\\UserName\\Videos\\exemplo.mp4"
            };

            TituloEntry.Text = conteudo.Titulo;
            TipoEntry.Text = conteudo.Tipo;
            DescricaoEditor.Text = conteudo.Descricao;
            ClassificacaoEntry.Text = conteudo.ClassificacaoIndicativa;
            SelectedVideo.Text = conteudo.VideoPath;
        }
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var updatedConteudo = new Conteudo
            {
                ID = _conteudoId,
                Titulo = TituloEntry.Text,
                Tipo = TipoEntry.Text,
                Descricao = DescricaoEditor.Text,
                ClassificacaoIndicativa = ClassificacaoEntry.Text
            };

            await DisplayAlert("Sucesso!", "Conteúdo atualizado.", "OK");

            await Navigation.PopAsync();
        }
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}