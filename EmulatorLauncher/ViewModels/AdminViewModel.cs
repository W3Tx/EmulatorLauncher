using EmulatorLauncher.Models;
using EmulatorLauncher.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace EmulatorLauncher.ViewModels
{
    public class AdminViewModel : ViewModelBase
    {
        private readonly ConfigService _configService = new();

        // Datenquellen für die UI
        public ObservableCollection<Emulator> Emulators { get; set; } = new();
        public ObservableCollection<Game> Games { get; set; } = new();

        // Eingabefelder für Emulator
        public string EmuName { get => _emuName; set { _emuName = value; OnPropertyChanged(); } }
        public string EmuPlatform { get => _emuPlatform; set { _emuPlatform = value; OnPropertyChanged(); } }
        public string EmuPath { get => _emuPath; set { _emuPath = value; OnPropertyChanged(); } }

        // Eingabefelder für Spiel
        public string GameTitle { get => _gameTitle; set { _gameTitle = value; OnPropertyChanged(); } }
        public string GamePlatform { get => _gamePlatform; set { _gamePlatform = value; OnPropertyChanged(); } }
        public string GameRomPath { get => _gameRomPath; set { _gameRomPath = value; OnPropertyChanged(); } }

        // Auswahl für zugeordneten Emulator
        public Emulator? SelectedEmulator { get => _selectedEmulator; set { _selectedEmulator = value; OnPropertyChanged(); } }

        // Befehle für Buttons
        public ICommand SaveEmulatorCommand { get; }
        public ICommand SaveGameCommand { get; }

        // Private Felder
        private string _emuName = string.Empty;
        private string _emuPlatform = string.Empty;
        private string _emuPath = string.Empty;
        private string _gameTitle = string.Empty;
        private string _gamePlatform = string.Empty;
        private string _gameRomPath = string.Empty;
        private Emulator? _selectedEmulator;

        public AdminViewModel()
        {
            SaveEmulatorCommand = new RelayCommand(async _ => await SaveEmulatorAsync());
            SaveGameCommand = new RelayCommand(async _ => await SaveGameAsync());

            _ = LoadDataAsync(); // Lädt vorhandene Daten beim Start
        }

        // Emulatoren und Spiele aus Konfig laden
        private async Task LoadDataAsync()
        {
            Emulators = new ObservableCollection<Emulator>(await _configService.LoadEmulatorsAsync());
            Games = new ObservableCollection<Game>(await _configService.LoadGamesAsync());
            OnPropertyChanged(nameof(Emulators));
            OnPropertyChanged(nameof(Games));
        }

        // Neuen Emulator speichern
        private async Task SaveEmulatorAsync()
        {
            if (string.IsNullOrWhiteSpace(EmuName) || string.IsNullOrWhiteSpace(EmuPlatform) || string.IsNullOrWhiteSpace(EmuPath))
            {
                MessageBox.Show("Bitte alle Emulatorfelder ausfüllen.");
                return;
            }

            var emulator = new Emulator { Name = EmuName, Platform = EmuPlatform, Path = EmuPath };
            Emulators.Add(emulator);
            await _configService.SaveEmulatorsAsync(Emulators.ToList());

            EmuName = EmuPlatform = EmuPath = string.Empty;
        }

        // Neues Spiel speichern
        private async Task SaveGameAsync()
        {
            if (string.IsNullOrWhiteSpace(GameTitle) || string.IsNullOrWhiteSpace(GamePlatform) || string.IsNullOrWhiteSpace(GameRomPath) || SelectedEmulator == null)
            {
                MessageBox.Show("Bitte alle Spielfelder ausfüllen und Emulator wählen.");
                return;
            }

            var game = new Game
            {
                Title = GameTitle,
                Platform = GamePlatform,
                RomPath = GameRomPath,
                EmulatorName = SelectedEmulator.Name
            };

            Games.Add(game);
            await _configService.SaveGamesAsync(Games.ToList());

            GameTitle = GamePlatform = GameRomPath = string.Empty;
            SelectedEmulator = null;
        }
    }
}
