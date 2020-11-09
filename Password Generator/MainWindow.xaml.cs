using Password_Generator.Tools;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PasswordGenerator PasswordGen = new PasswordGenerator();
        private readonly SerialKeyGenerator SerialKeyGen = new SerialKeyGenerator();

        public MainWindow()
        {
            InitializeComponent();

            PasswordGenerator.IsChecked = true;

            PasswordLengthBox.Text = "12";
        }

        private void BigLetterBox_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordGenerator.IsChecked)
            {
                PasswordGen.UseBigLetters = BigLetterBox.IsChecked ?? false;
            }
            else if (SerialKeyGenerator.IsChecked)
            {
                SerialKeyGen.UseBigLetters = BigLetterBox.IsChecked ?? false;
            }
        }

        private void DigitBox_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordGenerator.IsChecked)
            {
                PasswordGen.UseDigits = DigitBox.IsChecked ?? false;
            }
            else if (SerialKeyGenerator.IsChecked)
            {
                SerialKeyGen.UseDigits = DigitBox.IsChecked ?? false;
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordGenerator.IsChecked)
            {
                PasswordBox.Text = PasswordGen.Generate();
            }
            else if (SerialKeyGenerator.IsChecked)
            {
                PasswordBox.Text = SerialKeyGen.Generate();
            }
        }

        private void LetterBox_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordGenerator.IsChecked)
            {
                PasswordGen.UseLetters = LetterBox.IsChecked ?? false;
            }
            else if (SerialKeyGenerator.IsChecked)
            {
                SerialKeyGen.UseLetters = LetterBox.IsChecked ?? false;
            }
        }
        private void MainWin_Closing(object sender, CancelEventArgs e)
        {
            PasswordGen?.Dispose();

            SerialKeyGen?.Dispose();
        }

        private void PasswordGenerator_Click(object sender, RoutedEventArgs e)
        {
            if (!PasswordGenerator.IsChecked)
            {
                PasswordGenerator.IsChecked = true;
            }

            if (SerialKeyGenerator.IsChecked)
            {
                SerialKeyGenerator.IsChecked = false;

                LetterBox.IsChecked = PasswordGen.UseLetters;

                DigitBox.IsChecked = PasswordGen.UseDigits;

                BigLetterBox.IsChecked = PasswordGen.UseBigLetters;

                SymbolBox.IsChecked = PasswordGen.UseSymbols;

                SpaceBox.IsChecked = PasswordGen.UseSpace;
            }
        }

        private void PasswordLengthBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void PasswordLengthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(PasswordLengthBox.Text, out PasswordGen.Length))
            {
                PasswordGen.Length = 0;
            }
        }

        private void SerialKeyGenerator_Click(object sender, RoutedEventArgs e)
        {
            if (!SerialKeyGenerator.IsChecked)
            {
                SerialKeyGenerator.IsChecked = true;
            }

            if (PasswordGenerator.IsChecked)
            {
                PasswordGenerator.IsChecked = false;

                LetterBox.IsChecked = SerialKeyGen.UseLetters;

                DigitBox.IsChecked = SerialKeyGen.UseDigits;

                BigLetterBox.IsChecked = SerialKeyGen.UseBigLetters;

                SymbolBox.IsChecked = SerialKeyGen.UseSymbols;

                SpaceBox.IsChecked = SerialKeyGen.UseSpace;
            }
        }

        private void SerialKeyLengthBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit((char)KeyInterop.VirtualKeyFromKey(e.Key)) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void SerialKeyLengthBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(SerialKeyLengthBox.Text, out SerialKeyGen.Length))
            {
                SerialKeyGen.Length = 0;
            }
        }

        private void SerialKeySizeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsDigit(e.Key.ConvertToChar()) && e.Key != Key.Back)
            {
                e.Handled = true;
            }
        }

        private void SerialKeySizeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(SerialKeySizeBox.Text, out SerialKeyGen.Size))
            {
                SerialKeyGen.Size = 0;
            }
        }

        private void SpaceBox_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordGenerator.IsChecked)
            {
                PasswordGen.UseSpace = SpaceBox.IsChecked ?? false;
            }
            else if (SerialKeyGenerator.IsChecked)
            {
                SerialKeyGen.UseSpace = SpaceBox.IsChecked ?? false;
            }
        }

        private void SymbolBox_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordGenerator.IsChecked)
            {
                PasswordGen.UseSymbols = SymbolBox.IsChecked ?? false;
            }
            else if (SerialKeyGenerator.IsChecked)
            {
                SerialKeyGen.UseSymbols = SymbolBox.IsChecked ?? false;
            }
        }
    }
}