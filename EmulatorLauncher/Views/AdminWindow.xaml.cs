using Microsoft.Win32;
using System.Windows;
using EmulatorLauncher.ViewModels;

namespace EmulatorLauncher.Views
{
    public partial class AdminWindow : Window
    {
        private readonly AdminViewModel _viewModel;

        public AdminWindow()
        {
            InitializeComponent();
            _viewModel = new AdminViewModel();
            DataContext = _viewModel;
        }

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