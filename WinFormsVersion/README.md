# Mean Machine - WinForms Version

Diese Version von Mean Machine bietet eine grafische Benutzeroberfläche für Windows.

## Systemvoraussetzungen

- Windows-Betriebssystem
- .NET 8.0 oder höher
- Windows Desktop Runtime

## Installation und Ausführung

1. Stellen Sie sicher, dass .NET 8.0 oder höher installiert ist
2. Öffnen Sie eine Eingabeaufforderung oder PowerShell
3. Navigieren Sie zu diesem Verzeichnis
4. Führen Sie den folgenden Befehl aus:

```bash
dotnet run
```

## Verwendung

1. Geben Sie Zahlen getrennt durch Kommas in das Eingabefeld ein (z.B.: 1,2,3,4,5)
2. Klicken Sie auf "Berechnen"
3. Die Ergebnisse werden in den vier Ausgabefeldern angezeigt:
   - Arithmetisches Mittel
   - Geometrisches Mittel
   - Harmonisches Mittel
   - Quadratisches Mittel
4. Verwenden Sie "Löschen" um alle Felder zu leeren

## Besonderheiten

- **Geometrisches Mittel**: Kann nur für positive Zahlen berechnet werden
- **Harmonisches Mittel**: Kann nicht berechnet werden, wenn eine Zahl 0 ist
- **Eingabevalidierung**: Das Programm prüft automatisch die Gültigkeit der eingegebenen Zahlen
- **Fehlerbehandlung**: Fehlermeldungen werden in Dialogfenstern angezeigt

## UI-Layout

- **Eingabefeld**: Für die Zahlen (durch Kommas getrennt)
- **Berechnen-Button**: Startet die Berechnung
- **Löschen-Button**: Löscht alle Ein- und Ausgabefelder
- **Vier Ausgabefelder**: Zeigen die berechneten Mittelwerte an

## Technische Details

- **Framework**: .NET 8.0 Windows Desktop
- **UI-Technologie**: Windows Forms
- **Eingabeformat**: Zahlen getrennt durch Kommas
- **Ausgabeformat**: 6 Dezimalstellen
- **Sprache**: Deutsch