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
                switch (control.Type)
                {
                    case ControlType.Fader:
                        StackPanelFaders.Children.Add(new FaderView(control as Fader));
                        break;
                    case ControlType.MatrixButton:
                        
                        MatrixButtonView button = new MatrixButtonView(control as MatrixButton);
                        
                        GridMatrixButtons.Children.Add(button);
                        Grid.SetColumn(button, control.ChannelID%8);
                        Grid.SetRow(button, 7-(control.ChannelID/8));
                        
                        break;
                    case ControlType.BottomButton:
                        StackPanelBottomButtons.Children.Add(new BottomButtonView(control as BottomButton));
                        break;
                    case ControlType.RightButton:
                        StackPanelRigttButtons.Children.Add(new RightButtonView(control as RightButton));
                        break;
                    case ControlType.ShiftButton:
                        StackPanelShiftButton.Children.Add(new ShiftButtonView(control as ShiftButton));
                        break;
                }
            }
        }
    }
}
