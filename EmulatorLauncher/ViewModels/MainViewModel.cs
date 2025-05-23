using EmulatorLauncher.Models;
using EmulatorLauncher.Services;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;

namespace EmulatorLauncher.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ConfigService _configService = new();

        public ObservableCollection<Emulator> Emulators { get; set; } = new();
        public ObservableCollection<Game> Games { get; set; } = new();

        private Emulator? _selectedEmulator;
        public Emulator? SelectedEmulator
        {
            get => _selectedEmulator;
            set
            {
                _selectedEmulator = value;
                OnPropertyChanged();
                LoadGamesForEmulator();
            }
        }

        public MainViewModel()
        {
            LoadAsync();
        }

        private async void LoadAsync()
        {
            var emulators = await _configService.LoadEmulatorsAsync();
            Emulators = new ObservableCollection<Emulator>(emulators);
            OnPropertyChanged(nameof(Emulators)); // UI aktualisieren
        }

        private async void LoadGamesForEmulator()
        {
            if (SelectedEmulator == null)
                return;

            var allGames = await _configService.LoadGamesAsync();
            var filtered = allGames
                .Where(g => g.EmulatorName == SelectedEmulator.Name)
                .ToList();

            Games = new ObservableCollection<Game>(filtered);
            OnPropertyChanged(nameof(Games));
        }

        private Game? _selectedGame;
        public Game? SelectedGame
        {
            get => _selectedGame;
            set { _selectedGame = value; OnPropertyChanged(); }
        }
    }
}
