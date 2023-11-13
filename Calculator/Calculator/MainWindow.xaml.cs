using Calculator.UserControls;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string output = "";
        private string operation = "";
        double temp = 0;
        public MainWindow()
        {
            InitializeComponent();
            for(int i = 0; i <= 15; i++)
            {
                string btn = "btn" + i.ToString();
                CustomButton? actualBtn = FindName(btn) as CustomButton;

                if(actualBtn == null) { return; }

                if(i <= 9)
                    actualBtn.DataClicked += clickedData;
                else
                    actualBtn.DataClicked += clickedOperation;
            }
        }

        private void clickedData(object? sender, DataEventArgs e)
        {
            output += e.PressedButton;
            outputTxt.Text = output;
        }
        private void clickedOperation(object? sender, DataEventArgs e)
        {
            if(e.PressedButton == "CE")
            {              
                output = "";
                outputTxt.Text = output;
                temp = 0;  
            }
            if(output == "") { return; }

            switch(e.PressedButton)
            {
                case "+":
                    operation = "+";
                    temp = double.Parse(outputTxt.Text);
                    output = "";
                    break;
                case "-":
                    operation = "-";
                    temp = double.Parse(outputTxt.Text);
                    output = "";
                    break;
                case "/":
                    operation = "/";
                    temp = double.Parse(outputTxt.Text);
                    output = "";
                    break;
                case "*":
                    operation = "*";
                    temp = double.Parse(outputTxt.Text);
                    output = "";
                    break;
            }
            //Calculate
            if(e.PressedButton == "=")
            {
                var tempResult = "";
                switch(operation)
                {
                    case "+":
                        tempResult = (temp + double.Parse(output)).ToString();
                        break;
                    case "-":
                        tempResult = (temp - double.Parse(output)).ToString();
                        break;
                    case "/":
                        tempResult = (temp / double.Parse(output)).ToString();
                        break;
                    case "*":
                        tempResult = (temp * double.Parse(output)).ToString();
                        break;

                    default:
                        return;
                }
                temp = double.Parse(tempResult);
                outputTxt.Text = tempResult;
  
            }
        }
    }
    public class DataEventArgs : EventArgs
    {
        public string PressedButton;
        public int PressedButtonInt;
        public DataEventArgs(string pressedButton, int pressedButtonInt)
        {
            PressedButton = pressedButton;
            PressedButtonInt = pressedButtonInt;
        }
    }
}
