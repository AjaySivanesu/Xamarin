using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelViewSample.ViewModels
{
    public class TopPanelPageViewModel : ViewModelBase
    {
        public TopPanelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Top Panel";
        }
    }
}
