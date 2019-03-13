using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelViewSample.ViewModels
{
	public class LeftPanelPageViewModel : ViewModelBase
    {
        public LeftPanelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Left Panel";
        }
	}
}
