using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorPers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double result= 0;
        private string operation = "";
        private bool isOperation = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "C")
            {
                result = 0;
                operation = "";
                isOperation = false;
                Display.Text = "0";
            }
            else if ((sender as Button).Content.ToString() == "CE")
            {
                Display.Text = "0";
            }
            else if ((sender as Button).Content.ToString() == "_")
            {
                if (Display.Text.Length > 0)
                {
                    Display.Text = Display.Text.Remove(Display.Text.Length - 1, 1);
                }
            }
            else if ((sender as Button).Content.ToString() == "=")
            {
                PerformCalculation();
                operation = "";
                isOperation = false;
            }
            else if (IsOperation((sender as Button).Content.ToString()))
            {
                if (!isOperation)
                {
                    PerformCalculation();
                }
                operation = (sender as Button).Content.ToString();
                isOperation = true;
            }
            else
            {
                if (Display.Text == "0" || isOperation)
                {
                    Display.Text = "";
                }
                Display.Text += (sender as Button).Content.ToString();
                isOperation = false;
            }
        }
        private void PerformCalculation()
        {
            double currentNumber = double.Parse(Display.Text);
            if (operation == "+")
            {
                result += currentNumber;
            }
            else if (operation == "-")
            {
                result -= currentNumber;
            }
            else if (operation == "*")
            {
                result *= currentNumber;
            }
            else if (operation == "/")
            {
                result /= currentNumber;
            }
            else
            {
                result = currentNumber;
            }
            Display.Text = result.ToString();
        }
        private bool IsOperation(string operation)
        {
            return operation == "+" || operation == "-" || operation == "*" || operation == "/";
        }
    }
}