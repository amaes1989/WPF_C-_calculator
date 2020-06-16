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
        double lastNumber, result;

        public SelectedOperator SelectedOperator { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            //lblResult.Content = "5";

            btnAC.Click += BtnAC_Click;
            btnNegative.Click += BtnNegative_Click;
            btnPercentage.Click += BtnPercentage_Click;
            btnCalculate.Click += BtnCalculate_Click;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {

            double newNumber;
            if (double.TryParse(lblResult.Content.ToString(), out newNumber))
            {
                switch (SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substraction(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }
                lblResult.Content = result.ToString();
            }

        }

        private void BtnPercentage_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;

            if (double.TryParse(lblResult.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                lblResult.Content = tempNumber.ToString();
            }
        }

        private void BtnNegative_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                lblResult.Content = lastNumber.ToString();
            }

        }

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            lblResult.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void btnOperation_Click(Object sender, RoutedEventArgs e)
        {
            if (double.TryParse(lblResult.Content.ToString(), out lastNumber))
            {
                lblResult.Content = "0";
            }

            if (sender == btnMultiply)
                SelectedOperator = SelectedOperator.Multiplication;
            if (sender == btnDevide)
                SelectedOperator = SelectedOperator.Division;
            if (sender == btnMinus)
                SelectedOperator = SelectedOperator.Substraction;
            if (sender == btnPlus)
                SelectedOperator = SelectedOperator.Addition;
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (lblResult.Content.ToString().Contains("."))
            {

            }
            else
            {
                lblResult.Content = $"{lblResult.Content}.";
            }
            
        }

        private void btnNumber_Click(object sender, RoutedEventArgs e)
        {

            int selectedValue = 0;

            if (sender == btn0)
                selectedValue = 0;
            if (sender == btn1)
                selectedValue = 1;
            if (sender == btn2)
                selectedValue = 2;
            if (sender == btn3)
                selectedValue = 3;
            if (sender == btn4)
                selectedValue = 4;
            if (sender == btn5)
                selectedValue = 5;
            if (sender == btn6)
                selectedValue = 6;
            if (sender == btn7)
                selectedValue = 7;
            if (sender == btn8)
                selectedValue = 8;
            if (sender == btn9)
                selectedValue = 9;

            if (lblResult.Content.ToString() == "0")
            {
                lblResult.Content = $"{selectedValue}";
            }
            else
            {
                lblResult.Content = $"{lblResult.Content}{selectedValue}";
            }

        }
    }

    public enum SelectedOperator
    {
        Addition, 
        Substraction,
        Multiplication,
        Division
    }

    public class SimpleMath
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }

        public static double Substraction(double n1, double n2)
        {
            return n1 - n2;
        }

        public static double Multiply(double n1, double n2)
        {
            return n1 * n2;
        }

        public static double Divide(double n1, double n2)
        {
            if(n2 == 0)
            {
                MessageBox.Show("Je kan niet delen door 0!", "Verkeerde berekening", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
                return n1 / n2;            
        }
    }
}
