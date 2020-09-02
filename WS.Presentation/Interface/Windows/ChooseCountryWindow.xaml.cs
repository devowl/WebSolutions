using System;
using System.Windows;

using WS.Presentation.Interface.ViewModels;

namespace WS.Presentation.Interface.Windows
{
    /// <summary>
    /// Interaction logic for ChooseCountryWindow.xaml
    /// </summary>
    public partial class ChooseCountryWindow
    {
        /// <summary>
        /// Constructor for <see cref="ChooseCountryWindow"/>.
        /// </summary>
        public ChooseCountryWindow(Func<Action, ChooseCountryWindowViewModel> viewModelFactory)
        {
            DataContext = viewModelFactory(() => { DialogResult = true; });
            InitializeComponent();
        }
    }
}