using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace PividMidi.View
{
    /// <summary>
    /// Logique d'interaction pour ShiftButtonView.xaml
    /// </summary>
    public partial class ShiftButtonView : UserControl
    {
        public ShiftButton ShiftButton { get; set; }
        public ShiftButtonView(ShiftButton shiftButton)
        {
            InitializeComponent();
            DataContext = this;
            ShiftButton = shiftButton;
        }

        private void ButtonShiftButton_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShiftButton.Value = 127;

        }

        private void ButtonShiftButton_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ShiftButton.Value = 0;
        }
    }

    public class ValueToBrushConverterShift : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int _value = int.Parse(string.Format("{0}", value));

            if (_value == 127)
            {
                return Brushes.DarkGray;
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
