namespace EmulatorLauncher.Models
{
    public class Game
    {
        // string.Empty C# 10 Standart wegen Null
        public string Title { get; set; } = string.Empty;
        public string RomPath { get; set; } = string.Empty;
        public string Platform {  get; set; } = string.Empty;
        public string EmulatorName { get; set; } = string.Empty;
    }
}
