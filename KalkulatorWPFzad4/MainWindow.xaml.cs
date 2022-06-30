using System;
using System.Windows;
using System.Windows.Controls;


namespace KalkulatorWPFzad4
{
    
    public partial class MainWindow : Window
    {
        double n1;
        double n2;
        char operation;
        double outcome = 0;
        string lastOperation = "";
        double v;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ClickButton(object sender, RoutedEventArgs e)
        {
            if (outcome == 0)
            {
                Button button = (Button)sender;
                valueTextBox.Text += button.Content.ToString();
                n2 = Double.Parse(valueTextBox.Text);
            }
            else
            {
                outcome = 0;
                valueTextBox.Clear();
            }
        }

        public void MultiplyButton(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                n1 = Convert.ToDouble(valueTextBox.Text);
                operation = '*';
                valueTextBox.Clear();
                string labeText = n1.ToString() + " " + operation;
                firstLabel.Content = labeText;
            }
        }

        public void DivideClick(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                n1 = Convert.ToDouble(valueTextBox.Text);
                operation = '/';
                valueTextBox.Clear();
                string labeText = n1.ToString() + " " + operation;
                firstLabel.Content = labeText;
            }
        }

       
        public void SubstractButton(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                n1 = Convert.ToDouble(valueTextBox.Text);
                operation = '-';
                valueTextBox.Clear();
                string labeText = n1.ToString() + " " + operation;
                firstLabel.Content = labeText;
            }
        }

        public void ClickSumButton(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                n1 = Convert.ToDouble(valueTextBox.Text);
                operation = '+';
                valueTextBox.Clear();
                string labeText = n1.ToString() + " " + operation;
                firstLabel.Content = labeText;
            }
        }

        public void FirstVarClean(object sender, RoutedEventArgs e)
        {
            n2 = 0;
            outcome = 0;
            valueTextBox.Clear();
        }

        public void CleanAll(object sender, RoutedEventArgs e)
        {
            n1 = 0;
            n2 = 0;
            outcome = 0;
            firstLabel.Content = "";
            valueTextBox.Clear();
        }

        private void ResetADigit(object sender, RoutedEventArgs e)
        {
            string flag = valueTextBox.Text.ToString();
            flag = flag.Substring(0, flag.Length - 1);
            valueTextBox.Text = flag;
        }

        private void Percentage(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                double temp;
                if (n2 != 0)
                {
                    temp = n2 / 100.0;
                    n2 = temp;
                }
                else if (n1 != 0)
                {
                    temp = n1 / 100.0;
                    n1 = temp;
                }
                else
                {
                    temp = 0;
                }
                v = temp;
                valueTextBox.Text = v.ToString();
            }

        }

        private void ButtonDirectionSign(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                double var = Convert.ToDouble(valueTextBox.Text);
                var *= -1;
                valueTextBox.Text = var.ToString();
            }
        }

        private void RootButton(object sender, RoutedEventArgs e)
        {

            if (valueTextBox.Text != "")
            {
                long var = Convert.ToInt64(valueTextBox.Text);
                double value = Math.Sqrt(var);
                valueTextBox.Text = value.ToString();
            }
        }

        private void ExpButton(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                double value = Convert.ToDouble(valueTextBox.Text);
                value *= value;
                valueTextBox.Text = value.ToString();
            }
        }

        private void ModButton(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                n1 = Convert.ToDouble(valueTextBox.Text);
                operation = '%';
                valueTextBox.Clear();
                string tempLabel = n1.ToString() + " " + operation;
                firstLabel.Content = tempLabel;
            }
        }

        private void InvButton(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                double val = Convert.ToDouble(valueTextBox.Text);
                val = 1 / val;
                valueTextBox.Text = val.ToString();
            }
        }

        private void RoudingButtonUp(object sender, RoutedEventArgs e)
        {


            if (valueTextBox.Text != "")
            {
                double val = Convert.ToDouble(valueTextBox.Text);
                val = Math.Ceiling(val);
                valueTextBox.Text = val.ToString();
            }
        }

        private void RoundingButtonDown(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                double val = Convert.ToDouble(valueTextBox.Text);
                val = Math.Floor(val);
                valueTextBox.Text = val.ToString();
            }
        }

        private void LogarithmsButton(object sender, RoutedEventArgs e)
        {

            double val = Convert.ToDouble(valueTextBox.Text);
            if (valueTextBox.Text != "")
            {
                int counter = 0;
                for (int i = 10; i < 1000000; i *= 10)
                {
                    counter++;
                    if (i == Convert.ToInt32(val))
                    {
                        valueTextBox.Text = counter.ToString();
                    }
                }
            }
        }

        public void EqualsClick(object sender, RoutedEventArgs e)
        {
            if (valueTextBox.Text != "")
            {
                switch (operation)
                {
                    case '%':
                        outcome = n1 % n2;
                        lastOperation = n1.ToString() + " " + operation + " " + n2.ToString();
                        break;

                    case '/':
                        outcome = n1 / n2;
                        lastOperation = n1.ToString() + " " + operation + " " + n2.ToString();
                        break;
                    case '*':
                        outcome = n1 * n2;
                        lastOperation = n1.ToString() + " " + operation + " " + n2.ToString();
                        break;
                    case '-':
                        outcome = n1 - n2;
                        lastOperation = n1.ToString() + " " + operation + " " + n2.ToString();
                        break;

                    case '+':
                        outcome = n1 + n2;
                        lastOperation = n1.ToString() + " " + operation + " " + n2.ToString();
                        break;
                    default:
                        valueTextBox.Clear();
                        break;
                }
                lastLabel.Content = lastOperation.ToString();
                n1 = outcome;
                firstLabel.Content = "";
                valueTextBox.Text = outcome.ToString();
            }
        }
    }
}
