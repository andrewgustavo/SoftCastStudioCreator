﻿using Microsoft.Maui.Controls;
using System.Net.Http;
using SoftCastStudioCreator.Models;

namespace SoftCastStudioCreator.Views
{
    public partial class AllContentPage : ContentPage
    {
        public AllContentPage()
        {
            InitializeComponent();
            ConteudosCollectionView.ItemsSource = new List<Conteudo>
            {
                new Conteudo { ID = 1, Titulo = "Vídeo 1", Tipo = "Tutorial", Descricao = "Descrição do vídeo 1", ClassificacaoIndicativa = "Livre", VideoPath = "C:\\Users\\UserName\\Videos\\exemplo_1.mp4" },
                new Conteudo { ID = 2, Titulo = "Vídeo 2", Tipo = "Entretenimento", Descricao = "Descrição do vídeo 2", ClassificacaoIndicativa = "16",VideoPath = "C:\\Users\\UserName\\Videos\\exemplo_2.mp4" },
                new Conteudo { ID = 3, Titulo = "Vídeo 3", Tipo = "Ação", Descricao = "Descrição do vídeo 3", ClassificacaoIndicativa = "18",VideoPath = "C:\\Users\\UserName\\Videos\\exemplo_3.mp4" }
            };
        }
        private async void OnVoltarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DashboardPage("Andrew Silva"));
        }
        private async void OnNovoConteudoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewContentPage());
        }
        private async void OnEditarConteudoClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int conteudoId = (int)button.CommandParameter; 
            await Navigation.PushAsync(new EditContentPage(conteudoId));
        }
        private async void OnDeletarConteudoClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int conteudoId = (int)button.CommandParameter;
            await DisplayAlert("","Conteúdo deletado com sucesso!", "OK");
            await Navigation.PopAsync();
        }

    }
}
