using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Input;
using Avalonia.Media;
using System.Drawing;

namespace SimpleUIApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Attach event handlers programmatically
            TextBox1.GotFocus += TextBox_GotFocus;
            TextBox1.LostFocus += TextBox_LostFocus;
            TextBox2.GotFocus += TextBox_GotFocus;
            TextBox2.LostFocus += TextBox_LostFocus;
        }

        private void TextBox_GotFocus(object sender, GotFocusEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "Enter number of hours" || textBox.Text == "Enter number of  miles")
            {
                
                textBox.Text = textBox.Name == "TextBox1" ? "Enter number of hours" : "Enter number of miles";
                textBox.Text = string.Empty;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = textBox.Name == "TextBox1" ? "Enter number of hours" : "Enter number of miles";
                textBox.Text = string.Empty;
            }
        }

        private void OnCalculateButtonClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBox1.Text, out double value1) && double.TryParse(TextBox2.Text, out double value2))
            {   
                   int hours = (int)value1;
        int miles = (int)value2;

        // Define the constants for the fee calculation
            const int BASE_RATE = 200;
            const int RATE_PER_HOUR = 150;
            const int RATE_PER_MILE = 2;

        // Calculate the moving fee
            double result = BASE_RATE + (RATE_PER_HOUR * hours) + (RATE_PER_MILE * miles);

                ResultLabel.Text = $"Result: {result}";
                ResultLabel.Background = new SolidColorBrush(Colors.GreenYellow);
            }
            else
            {
                ResultLabel.Text = "Please enter valid numbers.";
            }
        }

        private void OnCheckBoxToggled(object sender, RoutedEventArgs e)
        {
            if (OptionCheckBox.IsChecked == true)
            {
                ResultLabel.Text = "Special Calculation Enabled";
            }
            else
            {
                ResultLabel.Text = "Special Calculation Disabled";
            }
        }
    }
}
