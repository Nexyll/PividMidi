using System.Windows.Controls;
using PividMidi.Model;

namespace PividMidi.View
{
    /// <summary>
    /// Logique d'interaction pour FaderView.xaml
    /// </summary>
    public partial class FaderView : UserControl
    {
        public Fader Fader { get; set; }
        public FaderView(Fader fader)
        {
            InitializeComponent();
            DataContext = this;
            Fader = fader;
        }
    }
}
