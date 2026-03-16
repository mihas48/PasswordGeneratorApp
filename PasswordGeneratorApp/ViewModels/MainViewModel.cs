using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Security.Cryptography;


namespace PasswordGeneratorApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isUpperCase = false;

        [ObservableProperty]
        private bool _isLowerCase = false;

        [ObservableProperty]
        private bool _isNumbers = false;

        [ObservableProperty]
        private bool _isSymbols = false;

        [ObservableProperty]
        private int _passwordLength = 8;

        [ObservableProperty]
        private string _passwordLengthText = "8";

        [ObservableProperty]
        private string _generatedPassword = "";

        partial void OnPasswordLengthTextChanged(string value)
        {
            if (int.TryParse(value, out int length))
            {
                PasswordLength = length;
            }
        }

        partial void OnPasswordLengthChanged(int value)
        {
            PasswordLengthText = value.ToString();
        }

        public MainViewModel()
        {
        }

        [RelayCommand]
        private void ToCheckToggleButton(object parameter)
        {
            if (parameter is string value)
            {
                switch (value)
                {
                    case "Верхний регистр":
                        IsUpperCase = true;
                        break;
                    case "Нижний регистр":
                        IsLowerCase = true;
                        break;
                    case "Цифры":
                        IsNumbers = true;
                        break;
                    case "Символы":
                        IsSymbols = true;
                        break;
                    default:
                        break;
                }
            }
        }

        [RelayCommand]
        private void Generate()
        {
            string chars = "";

            if (IsUpperCase)
                chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (IsLowerCase)
                chars += "abcdefghijklmnopqrstuvwxyz";

            if (IsNumbers)
                chars += "0123456789";

            if (IsSymbols)
                chars += "!@#$%^&*()_-+=";

            char[] result = new char[PasswordLength];
            byte[] randomBytes = new byte[PasswordLength];
            RandomNumberGenerator.Fill(randomBytes);

            for (int i = 0; i < PasswordLength; i++)
            {
                result[i] = chars[randomBytes[i] % chars.Length];
            }

            GeneratedPassword = new string(result);
        }

        [RelayCommand]
        private void Copy()
        {

        }
    }
}
