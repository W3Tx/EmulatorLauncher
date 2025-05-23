using EmulatorLauncher.Models;
using EmulatorLauncher.Services;
using System.Collections.ObjectModel;

namespace EmulatorLauncher.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ConfigService _configService = new();

        // Liste aller Emulatoren (z. B. für die linke Seite im Hauptfenster)
        public ObservableCollection<Emulator> Emulators { get; set; } = new();

        // Liste der Spiele, gefiltert nach ausgewähltem Emulator
        public ObservableCollection<Game> Games { get; set; } = new();

        private Emulator? _selectedEmulator;
        public Emulator? SelectedEmulator
        {
            get => _selectedEmulator;
            set
            {
                _selectedEmulator = value;
                OnPropertyChanged();
                LoadGamesForEmulator(); // Spiele passend zum Emulator laden
            }
        }

        // Wird beim Start des ViewModels ausgeführt
        public MainViewModel()
        {
            LoadAsync(); // Emulatoren laden
        }

        // Lädt alle Emulatoren asynchron
        private async void LoadAsync()
        {
            var emulators = await _configService.LoadEmulatorsAsync();
            Emulators = new ObservableCollection<Emulator>(emulators);
            OnPropertyChanged(nameof(Emulators)); // UI über neue Liste informieren
        }

        // Lädt Spiele, die zum aktuell ausgewählten Emulator gehören
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
            set
            {
                _selectedGame = value;
                OnPropertyChanged(); // Damit z. B. ein Doppelklick im UI funktioniert
            }
        }
    }
}
