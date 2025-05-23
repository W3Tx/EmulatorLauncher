using System.Diagnostics;
using System.IO;
using System.Windows;
using EmulatorLauncher.Models;

namespace EmulatorLauncher.Services
{
    public class LauncherService
    {
        public void StartGame(Game game, Emulator emulator)
        {
            // Prüft, ob die Emulator-EXE vorhanden ist
            if (!File.Exists(emulator.Path))
            {
                MessageBox.Show($"Emulator-Datei nicht gefunden:\n{emulator.Path}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Prüft, ob die ROM-Datei vorhanden ist
            if (!File.Exists(game.RomPath))
            {
                MessageBox.Show($"ROM-Datei nicht gefunden:\n{game.RomPath}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                // Erstellt die Startinfo für den Emulator mit ROM als Argument
                var startInfo = new ProcessStartInfo
                {
                    FileName = emulator.Path,                     // Pfad zur Emulator-EXE
                    Arguments = $"\"{game.RomPath}\"",           // ROM-Datei als Argument
                    UseShellExecute = true                       // Nutzt das Betriebssystem zum Ausführen
                };

                Process.Start(startInfo); // Startet den Emulator
            }
            catch (Exception ex)
            {
                // Fehlerbehandlung, z. B. bei Zugriffsproblemen oder ungültigen Pfaden
                MessageBox.Show($"Fehler beim Start:\n{ex.Message}", "Startfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
