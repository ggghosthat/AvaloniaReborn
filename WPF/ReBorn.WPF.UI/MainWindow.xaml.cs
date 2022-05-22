using System.Windows;
using Shared.ViewModels;

namespace ReBorn.WPF.UI
{
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();

            mainViewModel= new MainViewModel();

            DataContext = mainViewModel;
           
        }

        private void CloseButton_OnClick(object sender, RoutedEventArgs e)
        {
            mainViewModel.AppClosing();

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
