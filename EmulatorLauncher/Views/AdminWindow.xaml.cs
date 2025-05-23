using Microsoft.Win32;
using System.Windows;
using EmulatorLauncher.ViewModels;

namespace EmulatorLauncher.Views
{
    public partial class AdminWindow : Window
    {
        // ViewModel für das Admin-Fenster
        private readonly AdminViewModel _viewModel;

        public AdminWindow()
        {
            InitializeComponent();
            _viewModel = new AdminViewModel();
            DataContext = _viewModel; // Bindet die UI an das ViewModel
        }

        // Öffnet Datei-Dialog zum Auswählen einer Emulator-EXE
        private void BrowseExe_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Emulator EXE (*.exe)|*.exe",
                Title = "Emulator-Datei wählen"
            };

            if (dialog.ShowDialog() == true)
            {
                _viewModel.EmuPath = dialog.FileName;
            }
        }

        // Öffnet Datei-Dialog zum Auswählen einer ROM-Datei
        private void BrowseRom_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "ROM-Dateien (*.iso;*.bin;*.gba;*.z64)|*.iso;*.bin;*.gba;*.z64|Alle Dateien (*.*)|*.*",
                Title = "ROM-Datei wählen"
            };

            if (dialog.ShowDialog() == true)
            {
                _viewModel.GameRomPath = dialog.FileName;
            }
        }
    }
}
