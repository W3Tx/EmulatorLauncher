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
            if (!File.Exists(emulator.Path))
            {
                MessageBox.Show($"Emulator-Datei nicht gefunden:\n{emulator.Path}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!File.Exists(game.RomPath))
            {
                MessageBox.Show($"ROM-Datei nicht gefunden:\n{game.RomPath}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                var startInfo = new ProcessStartInfo
                {
                    FileName = emulator.Path,
                    Arguments = $"\"{game.RomPath}\"",
                    UseShellExecute = true
                };

                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Start:\n{ex.Message}", "Startfehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
