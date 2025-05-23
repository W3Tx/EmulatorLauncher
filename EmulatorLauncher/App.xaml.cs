using System.Windows;

namespace EmulatorLauncher
{
    public partial class App : Application
    {
        // Wird beim Start der Anwendung aufgerufen
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Globale Fehlerbehandlung: zeigt alle unbehandelten Fehler in einem MessageBox-Fenster an
            AppDomain.CurrentDomain.UnhandledException += (s, args) =>
            {
                MessageBox.Show($"Fehler: {args.ExceptionObject}");
            };
        }
    }
}
