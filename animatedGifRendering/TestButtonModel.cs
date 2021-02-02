using System.ComponentModel;
using Xamarin.Forms;

namespace animatedGifRendering
{
    public class TestButtonModel : INotifyPropertyChanged
    {
        private string myButtonImagePath;
        private bool myIsCorrectAnswer;
        private Color myButtonBorderColor;
        private string myButtonText;

        public event PropertyChangedEventHandler PropertyChanged = delegate
        {
        };

        public string ButtonText
        {
            get { return myButtonText; }
            set
            {
                if (value != myButtonText)
                {
                    myButtonText = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ButtonText"));
                }
            }
        }
        public Color BorderColor
        {
            get { return myButtonBorderColor; }
            set
            {
                if (value != myButtonBorderColor)
                {
                    myButtonBorderColor = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("BorderColor"));
                }
            }
        }
    }
}