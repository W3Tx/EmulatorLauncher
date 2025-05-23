using EmulatorLauncher.Models;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace EmulatorLauncher.Services
{
    public class ConfigService
    {
        private const string EmulatorFilePath = "Config/emulators.json";
        private const string GameFilePath = "Config/games.json";

        // Json Optionen (fuer bessere Lesbarkeit und Sonderzeichen
        private readonly JsonSerializerOptions _options = new()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
        };

        // Emulatoren laden
        public async Task<List<Emulator>> LoadEmulatorsAsync()
        {
            try
            {
                if (!File.Exists(EmulatorFilePath))
                    return new();

                string json = await File.ReadAllTextAsync(EmulatorFilePath);
                var list = JsonSerializer.Deserialize<List<Emulator>>(json, _options);
                return list ?? new();
            }
            catch (Exception ex)
            {
                // Logging möglich
                MessageBox.Show($"Fehler beim Laden der Emulatoren: {ex.Message}");
                return new();
            }
        }

        // Emulatoren speichern
        public async Task SaveEmulatorsAsync(List<Emulator> emulators)
        {
            try
            {
                string json = JsonSerializer.Serialize(emulators, _options);
                await File.WriteAllTextAsync(EmulatorFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Emulatoren: {ex.Message}");
            }
        }

        // Spiele laden
        public async Task<List<Game>> LoadGamesAsync()
        {
            try
            {
                if (!File.Exists(GameFilePath))
                    return new();

                string json = await File.ReadAllTextAsync(GameFilePath);
                var list = JsonSerializer.Deserialize<List<Game>>(json, _options);
                return list ?? new();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Spiele: {ex.Message}");
                return new();
            }
        }

        // Spiele speichern
        public async Task SaveGamesAsync(List<Game> games)
        {
            try
            {
                string json = JsonSerializer.Serialize(games, _options);
                await File.WriteAllTextAsync(GameFilePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Speichern der Spiele: {ex.Message}");
            }
        }
    }
}
