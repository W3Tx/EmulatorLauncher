using System;
using System.Windows.Input;

public class RelayCommand : ICommand
{
    private readonly Action<object?> _execute;                 // Aktion, die ausgeführt wird
    private readonly Predicate<object?>? _canExecute;          // Optionale Bedingung, ob ausgeführt werden darf

    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    // Gibt zurück, ob der Befehl aktuell ausgeführt werden darf
    public bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

    // Führt die übergebene Aktion aus
    public void Execute(object? parameter) => _execute(parameter);

    // Dieses Event könnte genutzt werden, um die UI über Änderungen der Ausführbarkeit zu informieren
    // Ist hier leer, weil keine dynamische Änderung vorgesehen ist
    public event EventHandler? CanExecuteChanged { add { } remove { } }
}
