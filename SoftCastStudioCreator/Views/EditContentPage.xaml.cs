using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Views
{
    public partial class EditContentPage : ContentPage
    {
        private int _conteudoId;

        // Construtor da página, recebe o ID do conteúdo a ser editado
        public EditContentPage(int conteudoId)
        {
            InitializeComponent();
            _conteudoId = conteudoId;
            LoadConteudo(conteudoId);  // Carrega os dados simulados para edição
        }

        // Função para carregar o conteúdo a ser editado
        private void LoadConteudo(int conteudoId)
        {
            // Aqui vamos simular a carga do conteúdo com dados fictícios
            var conteudo = new Conteudo
            {
                ID = conteudoId,
                Titulo = "Vídeo Tutorial",
                Tipo = "Educação",
                Descricao = "Descrição do vídeo tutorial",
                ClassificacaoIndicativa = "Livre"
            };

            // Preenche os campos da UI com os dados simulados
            TituloEntry.Text = conteudo.Titulo;
            TipoEntry.Text = conteudo.Tipo;
            DescricaoEditor.Text = conteudo.Descricao;
            ClassificacaoEntry.Text = conteudo.ClassificacaoIndicativa;
        }

        // Função para salvar as alterações do conteúdo
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Simulando a criação de um novo conteúdo com os dados editados
            var updatedConteudo = new Conteudo
            {
                ID = _conteudoId,
                Titulo = TituloEntry.Text,
                Tipo = TipoEntry.Text,
                Descricao = DescricaoEditor.Text,
                ClassificacaoIndicativa = ClassificacaoEntry.Text
            };

            // Simula o "salvamento" do conteúdo. Aqui você só deve validar e mostrar um feedback para o usuário.
            await DisplayAlert("Sucesso", "Conteúdo atualizado com sucesso (simulado)!", "OK");

            // Volta para a página anterior (onde o conteúdo foi listado)
            await Navigation.PopAsync();
        }

        // Função para voltar à página anterior sem salvar
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            // Volta para a página anterior
            await Navigation.PopAsync();
        }
    }
}
