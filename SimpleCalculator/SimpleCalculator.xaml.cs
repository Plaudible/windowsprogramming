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

namespace Simple_View_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        double val1;
        double val2;
        char op;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Operand.Content = "ADD";
            op = 'a';
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Operand.Content = "SUB";
            op = 's';
        }

        private void ButtonTimes_Click(object sender, RoutedEventArgs e)
        {
            Operand.Content = "MUL";
            op = 'm';
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            Operand.Content = "DIV";
            op = 'd';
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (op == 'a')
                Output.Text = (val1 + val2).ToString();
            if (op == 's')
                Output.Text = (val1 - val2).ToString();
            if (op == 'm')
                Output.Text = (val1 * val2).ToString();
            if (op == 'd')
                Output.Text = (val1 / val2).ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {


            if (!double.TryParse(Operand1.Text, out val1))
            {
                Error.Content = "Not a number!";
            }
            else
            {
                Error.Content = "";
                val1 = double.Parse(Operand1.Text);
            }

        }
        private void Operand2_TextChanged(object sender, TextChangedEventArgs e)
        {


            if(!double.TryParse(Operand1.Text, out val2)) //could be done with try/catch block!
            {
                Error.Content = "Not a number!";
            }
            else
            {
                Error.Content = "";
                val2 = double.Parse(Operand2.Text);
            }

        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }


    }   
}
