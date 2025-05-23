using EmulatorLauncher.ViewModels;
using EmulatorLauncher.Views;
using System.Windows;
using System.Windows.Input;
using EmulatorLauncher.Services;

namespace EmulatorLauncher.Views
{
    public partial class MainWindow : Window
    {
        private readonly LauncherService _launcherService = new();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(); // MVVM Verbindung
        }

        private void OpenAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow();
            adminWindow.ShowDialog();
        }

        private void GameListBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is MainViewModel vm &&
                vm.SelectedEmulator != null &&
                vm.SelectedGame != null)
            {
                _launcherService.StartGame(vm.SelectedGame, vm.SelectedEmulator);
            }
        }
    }
}