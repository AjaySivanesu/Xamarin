using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelViewSample.ViewModels
{
	public class BottomPanelPageViewModel : ViewModelBase
    {
        public BottomPanelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Bottom Panel";
        }
	}
}
