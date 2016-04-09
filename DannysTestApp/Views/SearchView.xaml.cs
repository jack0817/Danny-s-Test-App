using DannysTestApp.Services;
using DannysTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace DannysTestApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SearchView : Page
    {
        private SearchViewModel _viewModel = new SearchViewModel();

        public SearchViewModel ViewModel
        {
            get { return this._viewModel; }
        }

        public SearchView()
        {
            this.InitializeComponent();
            this.DataContext = this.ViewModel;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var settingsService = new AppSettingsService();
            var apiKey = settingsService.GetValue(AppSettingsService.Keys.API_KEY);
            if (!string.IsNullOrEmpty(apiKey))
                return;

            this.IsEnabled = false;

            var authService = new AuthenticationService();
            var token = await authService.GetTokenAsync();
            if(token != null)
            {
                settingsService.SetValue(AppSettingsService.Keys.API_KEY, token.Token);
            }

            this.IsEnabled = true;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            this.ViewModel.SearchText = textbox.Text;
            this.ViewModel.SearchCommand.FireCanExecuteChanged();
        }
    }
}
