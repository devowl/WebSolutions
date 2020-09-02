using System.Windows;

using Microsoft.Practices.ServiceLocation;

using WS.Presentation.Interface.ViewModels;
using WS.Presentation.Prism;

namespace WS.Presentation.Interface.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Constructor for <see cref="MainWindow"/>.
        /// </summary>
        public MainWindow(MainWindowViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
            Loaded += OnMainWindowLoaded;
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Loaded -= OnMainWindowLoaded;
            var navigator = ServiceLocator.Current.GetInstance<LocalNavigator>();
            navigator.DefaultView();
        }
    }
}