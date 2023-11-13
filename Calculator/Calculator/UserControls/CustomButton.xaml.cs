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

namespace Calculator.UserControls
{
    /// <summary>
    /// Interaction logic for CustomButton.xaml
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public EventHandler<DataEventArgs> DataClicked;
        private string number;

        public string Number
        {
            get { return btnName.Text; }
            set 
            { 
                number = value; 
                btnName.Text = number;
            }
        }
        private string color;
        private BrushConverter bc = new BrushConverter();
        public string Color
        {
            get { return color; }
            set 
            { 
                color = value;
                if((Brush)bc.ConvertFrom(color) != null)
                    Background = (Brush)bc.ConvertFrom(color);
            }
        }

        public CustomButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(Number, out int buttonIntValue);

            DataClicked?.Invoke(this, new DataEventArgs(Number, buttonIntValue));
        }
    }
}
