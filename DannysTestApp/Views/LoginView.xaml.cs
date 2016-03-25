using DannysTestApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DannysTestApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginView : Page
    {
        private LoginViewModel _viewModel = new LoginViewModel();

        public LoginViewModel ViewModel
        {
            get { return this._viewModel; }
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public LoginView()
        {
            this.InitializeComponent();
            this.DataContext = this.ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
        }
    }
}
