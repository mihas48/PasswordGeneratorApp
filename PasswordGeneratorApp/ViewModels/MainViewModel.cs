using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PasswordGeneratorApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isUpperCase = true;

        [ObservableProperty]
        private bool _isLowerCase = true;

        [ObservableProperty]
        private bool _isNumbers = true;

        [ObservableProperty]
        private bool _isSymbols = true;

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
        private void Generate()
        {

        }

        [RelayCommand]
        private void Copy()
        {

        }
    }
}
