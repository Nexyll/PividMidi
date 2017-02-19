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
    /// Logique d'interaction pour BottomButtonView.xaml
    /// </summary>
    public partial class BottomButtonView : UserControl
    {
        public BottomButton BottomButton { get; set; }
        public BottomButtonView(BottomButton bottomButton)
        {
            InitializeComponent();
            DataContext = this;
            BottomButton = bottomButton;
        }

        private void ButtonBottomButton_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BottomButton.Value = 127;
        }

        private void ButtonBottomButton_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            BottomButton.Value = 0;
        }
    }

    public class ValueToBrushConverterBottom : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int _value = int.Parse(string.Format("{0}", value));

            if (_value == 127)
            {
                return Brushes.Red;
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
