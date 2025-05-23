namespace EmulatorLauncher.Models
{
    public class Game
    {
        // Titel des Spiels
        public string Title { get; set; } = string.Empty;

        // Pfad zur ROM-Datei (z. B. .iso, .gba, .z64 etc.)
        public string RomPath { get; set; } = string.Empty;

        // Plattform, z. B. "SNES", "PS1"
        public string Platform { get; set; } = string.Empty;

        // Verknüpfung mit dem Namen des zugehörigen Emulators
        public string EmulatorName { get; set; } = string.Empty;
    }
}
