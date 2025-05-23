## **EmulatorLauncher**

> Ein modularer, manuell gepflegter Retro-Game-Launcher in **C# / WPF / MVVM**

---

### Projektziel

Der **EmulatorLauncher** bietet eine moderne und wartbare Desktop-Oberfläche zur **Verwaltung und Ausführung von Emulatoren und ROMs**.
Im Gegensatz zu automatischen Tools (z. B. LaunchBox) liegt hier der Fokus auf **voller Kontrolle durch manuelle Pflege** via integrierter Admin-Oberfläche.

---

### Features

| Bereich                | Funktion                                                        |
| ---------------------- | --------------------------------------------------------------- |
| Emulator-Verwaltung | Emulatoren (Name, Plattform, EXE-Pfad) manuell pflegen          |
| Spiel-Verwaltung    | ROMs zu Emulatoren zuordnen, Titel & Plattform eintragen        |
| ROM-Start           | Spiel startet direkt per Doppelklick mit zugewiesenem Emulator  |
| Admin-Zugang        | Verwaltung über Zahnrad-Button im Hauptfenster                  |
| Datenhaltung        | Speicherung in **lokalen JSON-Dateien** (keine DB nötig)        |
| UI-Design           | Material Design in XAML Toolkit – modernes, aufgeräumtes Layout |
| Architektur         | Saubere **MVVM-Struktur**, testbar & wartbar                    |

---

### 🛠 Verwendete Technologien

* **C# / .NET 8**
* **WPF** mit **MVVM**
* **Material Design in XAML Toolkit**
* **JSON-Datenhaltung** (`System.Text.Json`)
* Optional: `OpenFileDialog`, `Process.Start`
