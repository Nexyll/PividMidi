using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using PividMidi.Model;

namespace PividMidi.View
{
    /// <summary>
    /// Logique d'interaction pour MatrixButtonView.xaml
    /// </summary>
    public partial class MatrixButtonView : UserControl
    {
        public MatrixButton MatrixButton { get; set; }

        public MatrixButtonView(MatrixButton matrixButton)
        {
            InitializeComponent();
            DataContext = this;
            MatrixButton = matrixButton;
            
        }

        private void ButtonMatrixButton_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MatrixButton.Value = 127;
        }

        private void ButtonMatrixButton_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            MatrixButton.Value = 0;    
        }
    }

    public class ValueToBrushConverterMatrix : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int _value = int.Parse(string.Format("{0}", value));

            if (_value == 127)
            {
                return Brushes.DarkOrange;
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
