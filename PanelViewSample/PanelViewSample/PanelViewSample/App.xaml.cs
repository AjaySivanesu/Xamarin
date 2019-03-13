using Prism;
using Prism.Ioc;
using PanelViewSample.ViewModels;
using PanelViewSample.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PanelViewSample
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LeftPanelPage, LeftPanelPageViewModel>();
            containerRegistry.RegisterForNavigation<TopPanelPage, TopPanelPageViewModel>();
            containerRegistry.RegisterForNavigation<RightPanelPage, RightPanelPageViewModel>();
            containerRegistry.RegisterForNavigation<BottomPanelPage, BottomPanelPageViewModel>();
            containerRegistry.RegisterForNavigation<MultiDirectionalPanelPage, MultiDirectionalPanelPageViewModel>();
            containerRegistry.RegisterForNavigation<MultiDirectionalSingleActivePanelPage, MultiDirectionalSingleActivePanelPageViewModel>();
            containerRegistry.RegisterForNavigation<MultiDirectionalFullPanelsPage, MultiDirectionalFullPanelsPageViewModel>();
        }
    }
}
