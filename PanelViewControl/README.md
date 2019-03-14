# Multi-Directional Sliding Panel Control 

This is a bindable sliding panel control for Xamarin.Forms using .NET Standard 2.0

### Setup
1. Download NuGet PanelViewControl
2. Include header on page: xmlns:panelControl="clr-namespace:PanelViewControl;assembly=PanelViewControl"
3. Use the control APIs to modify the UI/UX.
```
      <panelControl:PanelViewControl BottomPanelFloatSpacing="50"
                                   BottomPanelRatio="0.6"
                                   IsBottomPanelOverlayed="True">
        <panelControl:PanelViewControl.MainView>
            <ContentView BackgroundColor="Black" />
        </panelControl:PanelViewControl.MainView>

        <panelControl:PanelViewControl.BottomView>
            <ContentView BackgroundColor="OrangeRed"
                         Margin="10,0"
                         Opacity="0.7">
            </ContentView>
        </panelControl:PanelViewControl.BottomView>
    </panelControl:PanelViewControl>
```
    
    

### API
* MainView - [ContentView][Default null][Required] -  This is the main background view for the page.
* LeftView - [ContentView][Default null] - This is view used to render the Left Panel.
* TopView - [ContentView][Default null] - This is view used to render the Top Panel.
* RightView - [ContentView][Default null] -This is view used to render the Right Panel.
* BottomView - [ContentView][Default null] - This is view used to render the Left Panel.

* HasOneActivePanel - [Bool][Default True] - Allows only one panel to be active at a time.
* IsSwipeGesturesEnabled - [Bool][Default True] - Enable Swipe gesture.
* IsTapToOpenEnabled - [Bool][Default True] - Enable Tap gesture.
* ActivePanel - [Panel][Default Panel.None] - Get or Set the current active panel. 

* LeftPanelRatio - [Double][Default 1] - Defines the ratio width of the view relative to the screen.
* TopPanelRatio - [Double][Default 1]  - Defines the ratio height of the view relative to the screen.
* RightPanelRatio - [Double][Default 1]  -Defines the ratio width of the view relative to the screen.
* BottomPanelRatio - [Double][Default 1] - Defines the ratio height of the view relative to the screen.

* LeftPanelFloatSpacing - [Int][Default 0]  - Defines the spacing from the edge of the screen to dock.
* TopPanelFloatSpacing - [Int][Default 0] - Defines the spacing from the edge of the screen to dock.
* RightPanelFloatSpacing - [Int][Default 0] - Defines the spacing from the edge of the screen to dock.
* BottomPanelFloatSpacing - [Int][Default 0] - Defines the spacing from the edge of the screen to dock.

* IsLeftPanelOverlayed - [Bool][Default False] - Define if the panel is overlayed on top of MainView.
* IsTopPanelOverlayed - [Bool][Default False] - Define if the panel is overlayed on top of MainView.
* IsRightPanelOverlayed - [Bool][Default False] - Define if the panel is overlayed on top of MainView.
* IsBottomPanelOverlayed - [Bool][Default False] - Define if the panel is overlayed on top of MainView.
