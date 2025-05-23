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

        // Observable Collections (für ListBox + ComboBox)
        public ObservableCollection<Emulator> Emulators { get; set; } = new();
        public ObservableCollection<Game> Games { get; set; } = new();

        // Emulator-Eingabe
        private string _emuName = string.Empty;
        public string EmuName
        {
            get => _emuName;
            set { _emuName = value; OnPropertyChanged(); }
        }

        private string _emuPlatform = string.Empty;
        public string EmuPlatform
        {
            get => _emuPlatform;
            set { _emuPlatform = value; OnPropertyChanged(); }
        }

        private string _emuPath = string.Empty;
        public string EmuPath
        {
            get => _emuPath;
            set { _emuPath = value; OnPropertyChanged(); }
        }

        // Spiel-Eingabe
        private string _gameTitle = string.Empty;
        public string GameTitle
        {
            get => _gameTitle;
            set { _gameTitle = value; OnPropertyChanged(); }
        }

        private string _gamePlatform = string.Empty;
        public string GamePlatform
        {
            get => _gamePlatform;
            set { _gamePlatform = value; OnPropertyChanged(); }
        }

        private string _gameRomPath = string.Empty;
        public string GameRomPath
        {
            get => _gameRomPath;
            set { _gameRomPath = value; OnPropertyChanged(); }
        }

        private Emulator? _selectedEmulator;
        public Emulator? SelectedEmulator
        {
            get => _selectedEmulator;
            set { _selectedEmulator = value; OnPropertyChanged(); }
        }

        // Commands
        public ICommand SaveEmulatorCommand { get; }
        public ICommand SaveGameCommand { get; }

        public AdminViewModel()
        {
            SaveEmulatorCommand = new RelayCommand(async _ => await SaveEmulatorAsync());
            SaveGameCommand = new RelayCommand(async _ => await SaveGameAsync());

            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            Emulators = new ObservableCollection<Emulator>(await _configService.LoadEmulatorsAsync());
            Games = new ObservableCollection<Game>(await _configService.LoadGamesAsync());
            OnPropertyChanged(nameof(Emulators));
            OnPropertyChanged(nameof(Games));
        }

        private async Task SaveEmulatorAsync()
        {
            if (string.IsNullOrWhiteSpace(EmuName) ||
                string.IsNullOrWhiteSpace(EmuPlatform) ||
                string.IsNullOrWhiteSpace(EmuPath))
            {
                MessageBox.Show("Bitte alle Emulatorfelder ausfüllen.");
                return;
            }

            var emulator = new Emulator
            {
                Name = EmuName,
                Platform = EmuPlatform,
                Path = EmuPath
            };

            Emulators.Add(emulator);
            await _configService.SaveEmulatorsAsync(Emulators.ToList());

            // Felder leeren
            EmuName = string.Empty;
            EmuPlatform = string.Empty;
            EmuPath = string.Empty;
        }

        private async Task SaveGameAsync()
        {
            if (string.IsNullOrWhiteSpace(GameTitle) ||
                string.IsNullOrWhiteSpace(GamePlatform) ||
                string.IsNullOrWhiteSpace(GameRomPath) ||
                SelectedEmulator == null)
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

            // Felder leeren
            GameTitle = string.Empty;
            GamePlatform = string.Empty;
            GameRomPath = string.Empty;
            SelectedEmulator = null;
        }
    }
}