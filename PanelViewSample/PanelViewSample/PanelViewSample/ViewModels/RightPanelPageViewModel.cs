using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelViewSample.ViewModels
{
	public class RightPanelPageViewModel : ViewModelBase
    {
        public RightPanelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Right Panel";
        }
	}
}
