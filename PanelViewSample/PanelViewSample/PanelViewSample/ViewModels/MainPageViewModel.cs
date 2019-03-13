using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PanelViewSample.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private ObservableCollection<int> _items;

        public ObservableCollection<int> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ICommand NavigateToLeftPanelPageCommand { get; set; }
        public ICommand NavigateToTopPanelPageCommand { get; set; }
        public ICommand NavigateToRightPanelPageCommand { get; set; }
        public ICommand NavigateToBottomPanelPageCommand { get; set; }
        public ICommand NavigateToMultiDirectionalPanelPageCommand { get; set; }
        public ICommand NavigateToMultiDirectionalSingleActivePanelPageCommand { get; set; }
        public ICommand NavigateToMultiDirectionalFullPanelPageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
                    : base(navigationService)
        {
            Title = "Main Hub";

            NavigateToLeftPanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("LeftPanelPage");
            });

            NavigateToTopPanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("TopPanelPage");
            });

            NavigateToRightPanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("RightPanelPage");
            });

            NavigateToBottomPanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("BottomPanelPage");
            });

            NavigateToMultiDirectionalPanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("MultiDirectionalPanelPage");
            });

            NavigateToMultiDirectionalSingleActivePanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("MultiDirectionalSingleActivePanelPage");
            });

            NavigateToMultiDirectionalFullPanelPageCommand = new DelegateCommand(() =>
            {
                navigationService.NavigateAsync("MultiDirectionalFullPanelsPage");
            });


            Items = new ObservableCollection<int>();
            Items.Add(1);
        }
    }
}
