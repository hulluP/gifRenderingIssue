using System;
using System.IO;
using System.Net;
using Xamarin.Forms;

namespace animatedGifRendering
{
    public class LocalImages : ContentPage
    {
        private string secondImageSource { get; set; }
        private WebClient _webClientBlobDownload = null;
        private Button button;
        private Image image;
        private TestButtonModel buttonModel;
        public LocalImages()
        {
            buttonModel = new TestButtonModel();
            buttonModel.ButtonText = "Break Me";
            button = new Button { Text = "DownloadFile" };
            button.Clicked += DownloadFile;
            Button button1 = new Button { Text = "Animate" };

            button1.Clicked += Animate;
            image = new Image { Source = "" };
            Content = new StackLayout
            {
                Padding = new Thickness(20, 35, 20, 20),
                Children =
                {
                    button,
                    image,
                    button1
                }
            };
            if (File.Exists(Path.Combine(GetCurrentImagePath(), "Dmg.gif")))
            {
                secondImageSource = Path.Combine(GetCurrentImagePath(), "Dmg.gif");
                image.Source = secondImageSource;
                OnPropertyChanged(nameof(secondImageSource));
            }
        }

        private void ChangeText(object sender, EventArgs e)
        {
            buttonModel.ButtonText = "new Text";
        }

        private void Animate(object sender, EventArgs e)
        {
            image.IsAnimationPlaying = true;
        }

        private void DownloadFile(object sender, EventArgs e)
        {


            if (_webClientBlobDownload == null)
            {
                _webClientBlobDownload = new WebClient();
                _webClientBlobDownload.DownloadDataCompleted += new DownloadDataCompletedEventHandler(image_DownloadDataCompleted);
            }
            string nextURL = "https://media1.giphy.com/media/CmUgU6I0VdZEQ/200.gif";


            _webClientBlobDownload.DownloadDataAsync(new Uri(nextURL), secondImageSource);
        }

        private void image_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {


                if (e.Cancelled == true)
                {

                    return;
                }

                if (e.Error != null)
                {
                    return;
                }
                // some websides give a 200 when the image is not there and than the client downlaods the HTML
                // therefore check if the content type is a image before saving

                byte[] bytes = new byte[e.Result.Length]; // get the downloaded data
                bytes = e.Result;
                secondImageSource = Path.Combine(GetCurrentImagePath(), "Dmg.gif");
                File.WriteAllBytes(secondImageSource, bytes); // writes to local storage


            }
            catch (Exception ex)
            {
                return;
            }
            image.Source = secondImageSource;
            OnPropertyChanged(nameof(secondImageSource));
        }
        private static string GetCurrentImagePath()
        {
            String imagePath = "imagePath";
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + "/" + imagePath;
            if (!System.IO.Directory.Exists(path))
            {

                System.IO.Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
