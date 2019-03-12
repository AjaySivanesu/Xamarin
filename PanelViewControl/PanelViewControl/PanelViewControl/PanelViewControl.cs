using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PanelViewControl.Control
{
    public enum Panel
    {
        Left,
        Top,
        Right,
        Bottom,
        None
    }

    public class PanelViewControl : ContentView
    {
        private AbsoluteLayout MainLayout;
        private bool IsSliding;

        #region Bindable Properties
        public static readonly BindableProperty MainViewProperty =
            BindableProperty.Create(nameof(MainView),
                typeof(ContentView),
                typeof(PanelViewControl),
                default(ContentView),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    if (newValue != null)
                    {
                        var control = (PanelViewControl)bindable;
                        control.SetMainView((ContentView)newValue);
                    }
                });

        public static readonly BindableProperty LeftViewProperty =
            BindableProperty.Create(nameof(LeftView),
                typeof(ContentView),
                typeof(PanelViewControl),
                default(ContentView),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    if (newValue != null)
                    {
                        var control = (PanelViewControl)bindable;
                        control.SetLeftView((ContentView)newValue);
                    }
                });

        public static readonly BindableProperty RightViewProperty =
            BindableProperty.Create(nameof(RightView),
                typeof(ContentView),
                typeof(PanelViewControl),
                default(ContentView),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    if (newValue != null)
                    {
                        var control = (PanelViewControl)bindable;
                        control.SetRightView((ContentView)newValue);
                    }
                });

        public static readonly BindableProperty TopViewProperty =
           BindableProperty.Create(nameof(TopView),
               typeof(ContentView),
               typeof(PanelViewControl),
               default(ContentView),
               propertyChanged: (bindable, oldValue, newValue) =>
               {
                   if (newValue != null)
                   {
                       var control = (PanelViewControl)bindable;
                       control.SetTopView((ContentView)newValue);
                   }
               });

        public static readonly BindableProperty BottomViewProperty =
            BindableProperty.Create(nameof(BottomView),
                typeof(ContentView),
                typeof(PanelViewControl),
                default(ContentView),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    if (newValue != null)
                    {
                        var control = (PanelViewControl)bindable;
                        control.SetBottomView((ContentView)newValue);
                    }
                });
        #endregion

        public ContentView MainView
        {
            get => (ContentView)GetValue(MainViewProperty);
            set => SetValue(MainViewProperty, value);
        }

        public ContentView LeftView
        {
            get => (ContentView)GetValue(LeftViewProperty);
            set => SetValue(LeftViewProperty, value);
        }

        public ContentView RightView
        {
            get => (ContentView)GetValue(RightViewProperty);
            set => SetValue(RightViewProperty, value);
        }

        public ContentView TopView
        {
            get => (ContentView)GetValue(TopViewProperty);
            set => SetValue(TopViewProperty, value);
        }

        public ContentView BottomView
        {
            get => (ContentView)GetValue(BottomViewProperty);
            set => SetValue(BottomViewProperty, value);
        }

        public Panel ActivePanel { get; set; } = Panel.None;
        public int SwipeSensitivity { get; set; } = 40;
        public bool HasOneActivePanel { get; set; } = true;


        public double LeftPanelRatio { get; set; } = 1;
        public double RightPanelRatio { get; set; } = 1;
        public double TopPanelRatio { get; set; } = 1;
        public double BottomPanelRatio { get; set; } = 1;

        public int LeftPanelFloatSpacing { get; set; }
        public int RightPanelFloatSpacing { get; set; }
        public int TopPanelFloatSpacing { get; set; }
        public int BottomPanelFloatSpacing { get; set; }

        public bool IsLeftPannelOverlayed { get; set; } = false;
        public bool IsRightPannelOverlayed { get; set; } = false;
        public bool IsTopPannelOverlayed { get; set; } = false;
        public bool IsBottomPannelOverlayed { get; set; } = false;

        public PanelViewControl()
        {
            SetLayout();

            this.SizeChanged += (sender, e) =>
            {
                var visualElement = sender as VisualElement;

                if (ActivePanel == Panel.None)
                {
                    LeftView.TranslationX = LeftPanelFloatSpacing - LeftView.Width;
                    RightView.TranslationX = MainLayout.Width - RightPanelFloatSpacing;
                    TopView.TranslationY = TopPanelFloatSpacing - TopView.Height;
                    BottomView.TranslationY = visualElement.Height - BottomPanelFloatSpacing;
                }

                MainView.Margin = new Thickness(IsLeftPannelOverlayed ? 0 : LeftPanelFloatSpacing,
                                IsTopPannelOverlayed ? 0 : TopPanelFloatSpacing,
                                IsRightPannelOverlayed ? 0 : RightPanelFloatSpacing,
                                IsBottomPannelOverlayed ? 0 : BottomPanelFloatSpacing);

            };
        }

        private void ActivateOnePanel(Panel activePanel)
        {
            ActivePanel = activePanel;

            if (activePanel == Panel.Left)
            {
                LeftViewSlideToEnd();

                RightViewSlideToEnd();
                TopViewSlideUp();
                BottomViewSlideDown();

            }
            else if (activePanel == Panel.Right)
            {
                RightViewSlideToStart();

                LeftViewSlideToStart();
                TopViewSlideUp();
                BottomViewSlideDown();
            }
            else if (activePanel == Panel.Top)
            {
                TopViewSlideDown();

                LeftViewSlideToStart();
                RightViewSlideToEnd();
                BottomViewSlideDown();
            }
            else if (activePanel == Panel.Bottom)
            {
                BottomViewSlideUp();

                LeftViewSlideToStart();
                RightViewSlideToEnd();
                TopViewSlideUp();
            }
            else
            {
                LeftViewSlideToStart();
                RightViewSlideToEnd();
                TopViewSlideUp();
                BottomViewSlideDown();
            }
        }

        #region View Renderes 
        private void SetLayout()
        {
            MainLayout = new AbsoluteLayout();
            MainLayout.VerticalOptions = LayoutOptions.FillAndExpand;
            MainLayout.HorizontalOptions = LayoutOptions.FillAndExpand;

            this.Content = MainLayout;
        }

        private void SetMainView(ContentView view)
        {
            if (MainView != null)
                MainLayout.Children.Remove(MainView);

            MainView = view;

            AbsoluteLayout.SetLayoutBounds(MainView, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(MainView, AbsoluteLayoutFlags.All);
            MainView.VerticalOptions = LayoutOptions.FillAndExpand;
            MainView.HorizontalOptions = LayoutOptions.FillAndExpand;

            MainView.Margin = new Thickness(IsLeftPannelOverlayed ? 0 : LeftPanelFloatSpacing,
                                            IsRightPannelOverlayed ? 0 : RightPanelFloatSpacing,
                                            IsTopPannelOverlayed ? 0 : TopPanelFloatSpacing,
                                            IsBottomPannelOverlayed ? 0 : BottomPanelFloatSpacing);



            var MainViewLeftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            MainViewLeftSwipeGesture.Swiped += OnMainViewSwiped;

            var MainViewRightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            MainViewRightSwipeGesture.Swiped += OnMainViewSwiped;

            var MainViewUpSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Up };
            MainViewUpSwipeGesture.Swiped += OnMainViewSwiped;

            var MainViewDownSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Down };
            MainViewDownSwipeGesture.Swiped += OnMainViewSwiped;

            MainView.GestureRecognizers.Add(MainViewLeftSwipeGesture);
            MainView.GestureRecognizers.Add(MainViewRightSwipeGesture);
            MainView.GestureRecognizers.Add(MainViewUpSwipeGesture);
            MainView.GestureRecognizers.Add(MainViewDownSwipeGesture);

            MainLayout.Children.Add(MainView);
            MainLayout.LowerChild(MainView);
        }

        private void SetLeftView(ContentView view)
        {
            if (LeftView != null)
                MainLayout.Children.Remove(LeftView);

            LeftView = view;
            AbsoluteLayout.SetLayoutBounds(LeftView, new Rectangle(0, 0, LeftPanelRatio, 1));
            AbsoluteLayout.SetLayoutFlags(LeftView, AbsoluteLayoutFlags.All);
            LeftView.VerticalOptions = LayoutOptions.FillAndExpand;

            LeftView.Margin = new Thickness(0, IsTopPannelOverlayed ? 0 : TopPanelFloatSpacing,
                                            0, IsBottomPannelOverlayed ? 0 : BottomPanelFloatSpacing);

            var leftViewRightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            leftViewRightSwipeGesture.Swiped += OnLeftViewSwiped;
            LeftView.GestureRecognizers.Add(leftViewRightSwipeGesture);

            var leftViewLeftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            leftViewLeftSwipeGesture.Swiped += OnLeftViewSwiped;
            LeftView.GestureRecognizers.Add(leftViewLeftSwipeGesture);

            var leftViewTapGesture = new TapGestureRecognizer();
            leftViewTapGesture.Tapped += (s, o) =>
            {
                if (ActivePanel == Panel.Left) return;

                if (HasOneActivePanel)
                {
                    ActivateOnePanel(Panel.Left);
                }
            };
            LeftView.GestureRecognizers.Add(leftViewTapGesture);

            MainLayout.Children.Add(LeftView);
        }

        private void SetRightView(ContentView view)
        {
            if (RightView != null)
                MainLayout.Children.Remove(RightView);

            RightView = view;
            AbsoluteLayout.SetLayoutBounds(RightView, new Rectangle(0, 0, RightPanelRatio, 1));
            AbsoluteLayout.SetLayoutFlags(RightView, AbsoluteLayoutFlags.All);
            RightView.VerticalOptions = LayoutOptions.FillAndExpand;
            RightView.HorizontalOptions = LayoutOptions.FillAndExpand;

            RightView.Margin = new Thickness(0, IsTopPannelOverlayed ? 0 : TopPanelFloatSpacing,
                                             0, IsBottomPannelOverlayed ? 0 : BottomPanelFloatSpacing);

            var rightViewRightSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            rightViewRightSwipeGesture.Swiped += OnRightViewSwiped;
            RightView.GestureRecognizers.Add(rightViewRightSwipeGesture);

            var rightViewLeftSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            rightViewLeftSwipeGesture.Swiped += OnRightViewSwiped;
            RightView.GestureRecognizers.Add(rightViewLeftSwipeGesture);

            var rightViewTapGesture = new TapGestureRecognizer();
            rightViewTapGesture.Tapped += (s, o) =>
            {
                if (ActivePanel == Panel.Right) return;

                if (HasOneActivePanel)
                {
                    ActivateOnePanel(Panel.Right);
                }
            };
            RightView.GestureRecognizers.Add(rightViewTapGesture);

            MainLayout.Children.Add(RightView);
        }

        private void SetTopView(ContentView view)
        {
            if (TopView != null)
                MainLayout.Children.Remove(TopView);

            TopView = view;
            AbsoluteLayout.SetLayoutBounds(TopView, new Rectangle(0, 0, 1, TopPanelRatio));
            AbsoluteLayout.SetLayoutFlags(TopView, AbsoluteLayoutFlags.All);
            TopView.VerticalOptions = LayoutOptions.FillAndExpand;

            var topViewUpSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Up };
            topViewUpSwipeGesture.Swiped += OnTopViewSwiped;
            TopView.GestureRecognizers.Add(topViewUpSwipeGesture);

            var topViewDownSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Down };
            topViewDownSwipeGesture.Swiped += OnTopViewSwiped;
            TopView.GestureRecognizers.Add(topViewDownSwipeGesture);

            var topViewTapGesture = new TapGestureRecognizer();
            topViewTapGesture.Tapped += (s, o) =>
            {
                if (ActivePanel == Panel.Top) return;

                if (HasOneActivePanel)
                {
                    ActivateOnePanel(Panel.Top);
                }
            };
            TopView.GestureRecognizers.Add(topViewTapGesture);

            MainLayout.Children.Add(TopView);
        }

        private void SetBottomView(ContentView view)
        {
            if (BottomView != null)
                MainLayout.Children.Remove(BottomView);

            BottomView = view;
            AbsoluteLayout.SetLayoutBounds(BottomView, new Rectangle(0, 0, 1, BottomPanelRatio));
            AbsoluteLayout.SetLayoutFlags(BottomView, AbsoluteLayoutFlags.All);
            BottomView.VerticalOptions = LayoutOptions.FillAndExpand;


            var bottomViewUpSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Up };
            bottomViewUpSwipeGesture.Swiped += OnBottomViewSwiped;
            BottomView.GestureRecognizers.Add(bottomViewUpSwipeGesture);

            var bottomViewDownSwipeGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Down };
            bottomViewDownSwipeGesture.Swiped += OnBottomViewSwiped;
            BottomView.GestureRecognizers.Add(bottomViewDownSwipeGesture);

            var bottomViewTapGesture = new TapGestureRecognizer();
            bottomViewTapGesture.Tapped += (s, o) =>
            {
                if (ActivePanel == Panel.Bottom) return;

                if (HasOneActivePanel)
                {
                    ActivateOnePanel(Panel.Bottom);
                }
            };
            BottomView.GestureRecognizers.Add(bottomViewTapGesture);

            MainLayout.Children.Add(BottomView);
        }
        #endregion

        #region Pan Gesture Handlers
        //TODO
        protected SwipeDirection? GetSwipeDirectionFromPan(double x, double y, int swipeSensitivity)
        {
            if (Math.Abs(x) > Math.Abs(y))
            {
                if (x > swipeSensitivity) return SwipeDirection.Right;
                else if (x < swipeSensitivity) return SwipeDirection.Left;
                else return null;
            }
            else
            {
                if (y > swipeSensitivity) return SwipeDirection.Down;
                else if (y < swipeSensitivity) return SwipeDirection.Up;
                else return null;
            }
        }

        void OnBottomViewPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    if (IsSliding) return;

                    var direction = GetSwipeDirectionFromPan(e.TotalX, e.TotalY, SwipeSensitivity);

                    if (direction == SwipeDirection.Down)
                        BottomViewSlideDown();
                    else if (direction == SwipeDirection.Up)
                        BottomViewSlideUp();
                    break;
            }
        }

        void OnMainiewPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:

                    break;

                case GestureStatus.Running:

                    if (e.TotalY > 20)
                        BottomViewSlideDown();

                    break;

                case GestureStatus.Completed:

                    break;
            }
        }
        #endregion

        #region Swipe Gesture Handlers
        protected virtual void OnMainViewSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Right) return;
                        else if (ActivePanel == Panel.Left) ActivateOnePanel(Panel.None);
                        else ActivateOnePanel(Panel.Right);
                    }
                    else
                    {
                        LeftViewSlideToStart();
                        RightViewSlideToStart();
                    }

                    break;

                case SwipeDirection.Right:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Left) return;
                        else if (ActivePanel == Panel.Right) ActivateOnePanel(Panel.None);
                        else ActivateOnePanel(Panel.Left);
                    }
                    else
                    {
                        LeftViewSlideToEnd();
                        RightViewSlideToEnd();
                    }

                    break;

                case SwipeDirection.Up:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Bottom) return;
                        else if (ActivePanel == Panel.Top) ActivateOnePanel(Panel.None);
                        else ActivateOnePanel(Panel.Bottom);
                    }
                    else
                    {
                        BottomViewSlideUp();
                        TopViewSlideUp();
                    }


                    break;

                case SwipeDirection.Down:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Top) return;
                        else if (ActivePanel == Panel.Bottom) ActivateOnePanel(Panel.None);
                        else ActivateOnePanel(Panel.Top);
                    }
                    else
                    {
                        BottomViewSlideDown();
                        TopViewSlideDown();
                    }

                    break;

            }
        }

        protected virtual void OnTopViewSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Down:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Top) return;
                        else ActivateOnePanel(Panel.Top);
                    }
                    else
                    {
                        TopViewSlideDown();
                    }

                    break;

                case SwipeDirection.Up:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.None) return;
                        else ActivateOnePanel(Panel.None);
                    }
                    else
                    {
                        TopViewSlideUp();
                    }

                    break;
            }
        }

        protected virtual void OnBottomViewSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Down:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.None) return;
                        else ActivateOnePanel(Panel.None);
                    }
                    else
                    {
                        BottomViewSlideDown();
                    }

                    break;

                case SwipeDirection.Up:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Bottom) return;
                        else ActivateOnePanel(Panel.Bottom);
                    }
                    else
                    {
                        BottomViewSlideUp();
                    }

                    break;
            }
        }

        protected virtual void OnLeftViewSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.None) return;
                        else ActivateOnePanel(Panel.None);
                    }
                    else
                    {
                        LeftViewSlideToStart();
                    }

                    break;

                case SwipeDirection.Right:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Left) return;
                        else ActivateOnePanel(Panel.Left);
                    }
                    else
                    {
                        LeftViewSlideToEnd();
                    }

                    break;

            }
        }

        protected virtual void OnRightViewSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.Right) return;
                        else ActivateOnePanel(Panel.Right);
                    }
                    else
                    {
                        RightViewSlideToStart();
                    }

                    break;

                case SwipeDirection.Right:

                    if (HasOneActivePanel)
                    {
                        if (ActivePanel == Panel.None) return;
                        else ActivateOnePanel(Panel.None);
                    }
                    else
                    {
                        RightViewSlideToEnd();
                    }

                    break;

            }
        }
        #endregion

        #region Animations
        protected virtual async void TopViewSlideUp()
        {

            if (TopView == null) return;

            IsSliding = true;

            await TopView.TranslateTo(0, TopPanelFloatSpacing - TopView.Height, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void TopViewSlideDown()
        {
            if (TopView == null) return;

            IsSliding = true;

            await TopView.TranslateTo(0, 0, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void BottomViewSlideUp()
        {
            if (BottomView == null) return;

            IsSliding = true;

            await BottomView.TranslateTo(0, MainLayout.Height - BottomView.Height, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void BottomViewSlideDown()
        {
            if (BottomView == null) return;

            IsSliding = true;

            await BottomView.TranslateTo(0, MainLayout.Height - BottomPanelFloatSpacing, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void LeftViewSlideToEnd()
        {
            if (LeftView == null) return;

            IsSliding = true;

            await LeftView.TranslateTo(0, 0, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void LeftViewSlideToStart()
        {
            if (LeftView == null) return;

            IsSliding = true;

            await LeftView.TranslateTo(LeftPanelFloatSpacing - LeftView.Width, 0, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void RightViewSlideToEnd()
        {
            if (RightView == null) return;

            IsSliding = true;

            await RightView.TranslateTo(MainLayout.Width - RightPanelFloatSpacing, 0, 300, Easing.SinOut);

            IsSliding = false;
        }

        protected virtual async void RightViewSlideToStart()
        {
            if (RightView == null) return;

            IsSliding = true;

            await RightView.TranslateTo(MainLayout.Width - RightView.Width, 0, 300, Easing.SinOut);

            IsSliding = false;
        }
        #endregion

    }
}