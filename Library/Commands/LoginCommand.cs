using Library.ViewModels;
using Library.Views;
using LibraryCore.Domain.Entities;
using LibraryCore.Factories;
using LibraryCore.Utils;
using System.Windows;
using System.Windows.Controls;

namespace Library.Commands
{

    public class LoginCommand : BaseCommand
    {
        private readonly LoginViewModel loginVm;
        public LoginCommand(LoginViewModel loginVm)
        {
            this.loginVm = loginVm;
        }
        
        public override bool CanExecute(object parameter)
        {
            // here LoginCommand do his own implementation for CanExecute
            return true;
        }

        public override void Execute(object parameter)
        {
            PasswordBox passwordBox = (PasswordBox)parameter;
            string password = passwordBox.Password;

            bool loginSuccess = true;

            User user = DB.UserRepository.FindByUsername(loginVm.LoginModel.Username);
            if(user == null)
            {
                loginSuccess = false;
            }
            else
            {
                string passwordHash = SecurityUtil.ComputeSha256Hash(password);
                if(user.PasswordHash != passwordHash)
                {
                    loginSuccess = false;
                }
            }

            if (loginSuccess)
            {
                Kernel.AuthenticatedUser = user;
                // go to main page
                MainPageViewModel viewModel = new MainPageViewModel();
                MainPage mainPage = new MainPage();
                viewModel.Grid = mainPage.grdCenter;
                viewModel.Window = mainPage;
                mainPage.DataContext = viewModel;
                mainPage.Show();
                loginVm.Window.Close();
            }
            else
            {
                // set error visibility to Visible
                loginVm.ErrorVisibility = Visibility.Visible;
            }
        }

    }
}
