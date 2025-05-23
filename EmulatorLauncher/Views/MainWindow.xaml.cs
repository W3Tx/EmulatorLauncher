using EmulatorLauncher.ViewModels;
using EmulatorLauncher.Views;
using System.Windows;
using System.Windows.Input;
using EmulatorLauncher.Services;

namespace EmulatorLauncher.Views
{
    public partial class MainWindow : Window
    {
        // Service zum Starten von Spielen
        private readonly LauncherService _launcherService = new();

        public MainWindow()
        {
            InitializeComponent();

            // Setzt das ViewModel als Datenkontext für DataBinding im XAML
            DataContext = new MainViewModel();
        }

        // Öffnet das Admin-Fenster (Dialog), wenn der Zahnrad-Button geklickt wird
        private void OpenAdmin_Click(object sender, RoutedEventArgs e)
        {
            var adminWindow = new AdminWindow();
            adminWindow.ShowDialog(); // blockiert bis Fenster geschlossen wird
        }

        // Wird ausgelöst, wenn ein Spiel doppelt angeklickt wird
        private void GameListBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Prüft, ob ViewModel, Emulator und Spiel ausgewählt sind
            if (DataContext is MainViewModel vm &&
                vm.SelectedEmulator != null &&
                vm.SelectedGame != null)
            {
                // Spiel starten über den Service
                _launcherService.StartGame(vm.SelectedGame, vm.SelectedEmulator);
            }
        }
    }
}
