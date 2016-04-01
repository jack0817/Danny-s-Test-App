using DannysTestApp.Services;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DannysTestApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DannyView : Page
    {
        private LogService LogService { get; set; }

        public DannyView()
        {
            this.InitializeComponent();
            this.LogService = new LogService(typeof(DannyView));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var authService = new AuthenticationService();
            var token = await authService.GetTokenAsync();
            if (token == null)
                return;

            if(token.Error != null)
            {
                this.LogService.Error(string.Format("Unable to retrieve authentication token, msg:{0}", token.Error));
                return;
            }

            Debug.Write(string.Format("TOKEN:{0}", token.Token));
        }
    }
}