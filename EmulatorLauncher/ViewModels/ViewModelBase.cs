using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmulatorLauncher.ViewModels
{
    // Basisklasse für ViewModels mit Unterstützung für PropertyChanged-Benachrichtigungen
    public class ViewModelBase : INotifyPropertyChanged
    {
        // Event, das ausgelöst wird, wenn sich eine Property ändert (für UI-Bindings notwendig)
        public event PropertyChangedEventHandler? PropertyChanged;

        // Hilfsmethode zum Auslösen des PropertyChanged-Events
        // CallerMemberName sorgt dafür, dass man den Property-Namen nicht manuell übergeben muss
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
