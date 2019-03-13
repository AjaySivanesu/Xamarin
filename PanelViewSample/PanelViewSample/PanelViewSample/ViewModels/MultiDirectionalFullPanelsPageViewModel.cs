using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelViewSample.ViewModels
{
	public class MultiDirectionalFullPanelsPageViewModel : ViewModelBase
    {
        public MultiDirectionalFullPanelsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Multi-Directional Full Panels";
        }
	}
}
