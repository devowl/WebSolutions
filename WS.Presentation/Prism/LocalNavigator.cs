using System;

using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

using WS.Presentation.Interface.Views;

namespace WS.Presentation.Prism
{
    /// <summary>
    /// Local pages navigator.
    /// </summary>
    public class LocalNavigator
    {
        private readonly IRegionManager _regionManager;

        private bool _isRegistred;

        /// <summary>
        /// Constructor for <see cref="LocalNavigator"/>.
        /// </summary>
        public LocalNavigator(IRegionManager regionManager, IServiceLocator serviceLocator)
        {
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
            _regionManager = regionManager;
        }

        /// <summary>
        /// Set default view.
        /// </summary>
        public void DefaultView()
        {
            RegionsRegistration();
        }

        /// <summary>
        /// Go to view.
        /// </summary>
        /// <param name="viewName">View name.</param>
        public void Goto(string viewName)
        {
            var dispatcher = System.Windows.Application.Current.Dispatcher;

            if (dispatcher.CheckAccess())
            {
                InternalGoto(viewName);
            }
            else
            {
                dispatcher.Invoke(() => { InternalGoto(viewName); });
            }
        }

        private void RegionsRegistration()
        {
            if (_isRegistred)
            {
                return;
            }

            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(LoginView));
            
            _isRegistred = true;
        }

        private void InternalGoto(string viewName)
        {
            var region = _regionManager.Regions[RegionNames.MainRegion];
            region.RequestNavigate(new Uri(viewName, UriKind.Relative));
        }
    }
}