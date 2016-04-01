using DannysTestApp.Services.Data;
using DannysTestApp.Views;
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace DannysTestApp
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
            await DataContext.Shared.InitAsync("Data");
            await DataContext.Shared.CreateModelAsync();

            var rootFrame = new Frame();
            //rootFrame.Navigate(typeof(LoginView), e.SplashScreen);
            rootFrame.Navigate(typeof(DannyView), e.SplashScreen);
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }
    }
}
