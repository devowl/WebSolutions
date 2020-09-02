using System.Windows.Controls;

using WS.Presentation.Interface.ViewModels;

namespace WS.Presentation.Interface.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView
    {
        /// <summary>
        /// Constructor for <see cref="LoginView"/>.
        /// </summary>
        public LoginView(LoginViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}