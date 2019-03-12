#Multi-Directional Sliding Panel Control 

This is a bindable sliding panel control for Xamarin.Forms using .NET Standard 2.0

### API
*MainView - [ContentView][Default null][Required] -  This is the main background view for the page.
*LeftView - [ContentView][Default null] - 
*TopView - [ContentView][Default null] - 
*RightView - [ContentView][Default null] -
*BottomView - [ContentView][Default null] -

*HasOneActivePanel - [Bool][Default True] - Allows only one panel to be active at a time.

*LeftPanelRatio - [Double][Default 1] - Defines the ratio width of the view relative to the screen.
*TopPanelRatio - [Double][Default 1]  - Defines the ratio height of the view relative to the screen.
*RightPanelRatio - [Double][Default 1]  -
*BottomPanelRatio - [Double][Default 1]  -

*LeftPanelFloatSpacing - [Int][Default 0]  - Defines the spacing from the edge of the screen to dock.
*TopPanelFloatSpacing - [Int][Default 0] -
*RightPanelFloatSpacing - [Int][Default 0] -
*BottomPanelFloatSpacing - [Int][Default 0] -

*IsLeftPanelOverlayed - [Bool][Default False] - Define if the panel is overlayed on top of MainView.
*IsTopPanelOverlayed - [Bool][Default False] -
*IsRightPanelOverlayed - [Bool][Default False] -
*IsBottomPanelOverlayed - [Bool][Default False] -