using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sanford.Multimedia.Midi;
using InputDevice = Sanford.Multimedia.Midi.InputDevice;

namespace PividMidi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private APCMiniController _apcMiniController;
        public Fader Test { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InputDevice id = new InputDevice(0);
            _apcMiniController = new APCMiniController(id, new OutputDevice(0));
            Test = _apcMiniController.Controls.First(x => x.Name == "Fader 1") as Fader;
            
        }
    }
}
