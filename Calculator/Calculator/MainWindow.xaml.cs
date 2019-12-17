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
        selectedOperators selectedOperator;
        public MainWindow()
        {
            
            InitializeComponent();
            ResultLabel.Content = "0";
            ACButton.Click += ACButton_Click;
            NegativeButton.Click += NegativeButton_Click;
            PersentButton.Click += PersentButton_Click;
            EqualButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out  newNumber))
            {
                switch (selectedOperator)
                {
                    case selectedOperators.Plus: result = SimpleMath.Plus(lastNumber, newNumber);
                        break;
                    case selectedOperators.Minus: result = SimpleMath.Minus(lastNumber, newNumber);
                        break;
                    case selectedOperators.Divide: result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                    case selectedOperators.Multiplacate: result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    default:
                        break;
                }
            }
            ResultLabel.Content = result.ToString();
        }

        private void PersentButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(ResultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if (lastNumber != 0)
                    tempNumber *= lastNumber;
                ResultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * (-1);
                ResultLabel.Content = lastNumber.ToString(); 
            }
            
        }

        private void ACButton_Click(object sender, RoutedEventArgs e)
        {
            ResultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }

        private void operatorbuttonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(ResultLabel.Content.ToString(), out lastNumber))
            {
                ResultLabel.Content = "0";
            }
            if (sender == MinusButton)
                selectedOperator = selectedOperators.Minus;
            if (sender == PlusButton)
                selectedOperator = selectedOperators.Plus;
            if (sender == DivideButton)
                selectedOperator = selectedOperators.Divide;
            if (sender == MultipleButton)
                selectedOperator = selectedOperators.Multiplacate;
        }

        private void DotButton_Click(object sender, RoutedEventArgs e)
        {
            if (ResultLabel.Content.ToString().Contains("."))
            {
                // do nothing
            }
            else { ResultLabel.Content = $"{ResultLabel.Content}."; }
        }

        private void numberbuttonClick(object sender, RoutedEventArgs e)
        {
            int selectedNumber = 0;
           if(sender == ZeroButton)
                selectedNumber = 0;
            if (sender == OneButton)
                selectedNumber = 1;
            if (sender == TwoButton)
                selectedNumber = 2;
            if (sender == ThreeButton)
                selectedNumber = 3;
            if (sender == FourButton)
                selectedNumber = 4;
            if (sender == FiveButton)
                selectedNumber = 5;
            if (sender == SixButton)
                selectedNumber = 6;
            if (sender == SevenButton)
                selectedNumber = 7;
            if (sender == EightButton)
                selectedNumber = 8;
            if (sender == NineButton)
                selectedNumber = 9;

            if (ResultLabel.Content.ToString() == "0")
            {
                ResultLabel.Content = $"{selectedNumber}";
            }
            else
            {
                ResultLabel.Content = $"{ ResultLabel.Content}{selectedNumber}";
            }
        }
    }
    public enum selectedOperators
    {
        Plus, Minus, Divide, Multiplacate
    }
    public class SimpleMath
    {
        public static double Plus(double n1 , double n2)
        {
            return (n1 + n2);
        }
        public static double Minus(double n1, double n2)
        {
            return (n1 - n2);
        }
        public static double Multiply(double n1, double n2)
        {
            return (n1 * n2);
        }
        public static double Divide(double n1, double n2)
        {
            if( n2 == 0)
            {
                MessageBox.Show("Divide to 0 is abonded", "Wrong operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return (n1 / n2);
        }
    }
}
