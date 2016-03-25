using DannysTestApp.Commands;
using Windows.ApplicationModel;
using Windows.UI.Popups;
using System;

namespace DannysTestApp.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userId;
        private string _password;
        private ButtonCommand _loginCommand;

        public string UserId
        {
            get { return this._userId; }
            set
            {
                this._userId = value;
                this.NotifyPropertyChanged();
            }
        }

        public string Password
        {
            get { return this._password; }
            set
            {
                this._password = value;
                this.NotifyPropertyChanged();
            }
        }

        public ButtonCommand LoginCommand
        {
            get { return this._loginCommand; }
            set
            {
                this._loginCommand = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Designer Support
        /// </summary>
        public LoginViewModel()
        {
            this.LoadDesignData();
            this.InitCommands();
        }

        private void InitCommands()
        {
            this.LoginCommand = new ButtonCommand(this.Login);
        }

        private void LoadDesignData()
        {
            if (!DesignMode.DesignModeEnabled)
                return;

            this.UserId = "Bewp";
            this.Password = "Password123";
        }

        private async void Login()
        {
            var dialog = new MessageDialog("Some fool is trying to log in!", "Login");
            await dialog.ShowAsync();
        }
    }
}
