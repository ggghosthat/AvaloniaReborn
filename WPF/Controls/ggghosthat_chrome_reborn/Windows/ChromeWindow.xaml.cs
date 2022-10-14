using System.Windows;
using System.Windows.Input;
//using Shared.ViewModels;

namespace ggghosthat_chrome_reborn
{ 
    public partial class ChromeWindow
    {
        #region DependencyProperties
        public static readonly DependencyProperty CloseCommandProperty = DependencyProperty.RegisterAttached(
        "IsActive", typeof(ICommand), typeof(ChromeWindow), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty ExpandCommandProperty = DependencyProperty.RegisterAttached(
        "IsActive", typeof(ICommand), typeof(ChromeWindow), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty HideCommandProperty = DependencyProperty.RegisterAttached(
        "IsActive", typeof(ICommand), typeof(ChromeWindow), new PropertyMetadata(default(ICommand)));
        public ICommand CloseCommand 
        {
            get { return (ICommand)GetValue(CloseCommandProperty); }
            set { SetValue(CloseCommandProperty, value); } 
        }

        public ICommand ExpandCommand
        {
            get { return (ICommand)GetValue(ExpandCommandProperty); }
            set { SetValue(ExpandCommandProperty, value); }
        }

        public ICommand HideCommand
        {
            get { return (ICommand)GetValue(HideCommandProperty); }
            set { SetValue(HideCommandProperty, value); }
        }
        #endregion

        #region Static Constructor
        static ChromeWindow() 
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ChromeWindow),
                new FrameworkPropertyMetadata(typeof(ChromeWindow)));
        }
        #endregion
        public ChromeWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            OnClosing();
        }

        protected virtual void OnClosing()
        {
            Application.Current.Shutdown();
        }

        private void HideButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExpandButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
        }
    }
}
