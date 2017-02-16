using System.Windows.Controls;
using PividMidi.Model;
using Control = PividMidi.Model.Control;

namespace PividMidi.View
{
    /// <summary>
    /// Logique d'interaction pour APCMiniControllerView.xaml
    /// </summary>
    public partial class APCMiniControllerView : UserControl
    {
        public APCMiniController APCMiniController { get; set; }
        public APCMiniControllerView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void Bind(APCMiniController apcMiniController)
        {
            APCMiniController = apcMiniController;
            InitializeControlsView();
        }

        private void InitializeControlsView()
        {
            foreach (Control control in APCMiniController.Controls)
            {
                if (control.Type == ControlType.Fader)
                {
                    StackPanelFaders.Children.Add(new FaderView(control as Fader));
                }
            }
        }
    }
}
