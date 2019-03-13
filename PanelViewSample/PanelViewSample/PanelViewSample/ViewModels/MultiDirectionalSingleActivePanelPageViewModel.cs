using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PanelViewSample.ViewModels
{
	public class MultiDirectionalSingleActivePanelPageViewModel : ViewModelBase
    {
        private ObservableCollection<string> _items;

        public ObservableCollection<string> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private string _labelText;
        public string LabelText
        {
            get => _labelText;
            set => SetProperty(ref _labelText, value);
        }

        public MultiDirectionalSingleActivePanelPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Multi-Directional Single Active Panel";

            LabelText = "I am a sample label Binded from the View Model";

            Items = new ObservableCollection<string>();

            for(int i = 0; i < 20; i++)
            {
                Items.Add("Sample ITEM " + i);
            }
            
        }


	}
}
