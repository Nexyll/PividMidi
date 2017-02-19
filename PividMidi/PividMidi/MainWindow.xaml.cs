using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using PividMidi.Model;
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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
            InputDevice id = new InputDevice(10); //Mathis : 10
            _apcMiniController = new APCMiniController(id, new OutputDevice(11), new OutputDevice(2)); //Mathis 11 - 1
            ApcMiniControllerView.Bind(_apcMiniController);
        }

        protected override void OnClosed(EventArgs e)
        {
            //Trouver qqch de plus propre
            Process self = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcesses().Where(p => p.Id == self.Id))
            {
                p.Kill();
            }
            base.OnClosed(e);
        }
    }
}
