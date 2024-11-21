using MediaManager;
using Microsoft.Maui.Controls;

namespace SoftCastStudioCreator.Views
{
    public partial class VideoPage : ContentPage
    {
        private readonly IMediaManager _mediaManager;

        public VideoPage()
        {
            InitializeComponent();
            _mediaManager = CrossMediaManager.Current;
        }

        private async void OnPlayVideoClicked(object sender, EventArgs e)
        {
            string videoPath = "https://www.youtube.com/watch?v=HmZKgaHa3Fg"; // Caminho do seu vídeo
            await _mediaManager.Play(videoPath);
        }
    }
}
