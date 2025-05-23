namespace EmulatorLauncher.Models
{
    public class Emulator
    {
        // Anzeigename des Emulators (z. B. "RetroArch", "PCSX2")
        public string Name { get; set; } = string.Empty;

        // Unterstützte Plattform (z. B. "PS1", "NES")
        public string Platform { get; set; } = string.Empty;

        // Pfad zur ausführbaren Datei (.exe) des Emulators
        public string Path { get; set; } = string.Empty;
    }
}
