# Mean Machine - Mittelwert Rechner

Mean Machine ist ein C# Programm zur Berechnung verschiedener Mittelwerte (arithmetisch, geometrisch, harmonisch und quadratisch).

## Verfügbare Versionen

### 1. Konsolen-Version (MeanMachine/)
Die Konsolen-Version läuft auf allen Plattformen (Windows, Linux, macOS) und bietet eine einfache Kommandozeilen-Schnittstelle.

#### Starten der Konsolen-Version:
```bash
cd MeanMachine
dotnet run
```

#### Verwendung:
- Geben Sie Zahlen getrennt durch Kommas ein (z.B.: 1,2,3,4,5)
- Das Programm berechnet automatisch alle vier Mittelwerte
- Geben Sie 'exit' ein, um das Programm zu beenden

### 2. WinForms-Version (WinFormsVersion/)
Die WinForms-Version bietet eine grafische Benutzeroberfläche und läuft nur auf Windows.

#### Starten der WinForms-Version (nur Windows):
```bash
cd WinFormsVersion
dotnet run
```

## Berechnete Mittelwerte

### 1. Arithmetisches Mittel
**Formel:** (x₁ + x₂ + ... + xₙ) / n
- Der klassische Durchschnitt
- Summe aller Werte geteilt durch Anzahl der Werte

### 2. Geometrisches Mittel
**Formel:** ⁿ√(x₁ × x₂ × ... × xₙ)
- Nur für positive Zahlen berechenbar
- Geeignet für Wachstumsraten und prozentuale Änderungen

### 3. Harmonisches Mittel
**Formel:** n / (1/x₁ + 1/x₂ + ... + 1/xₙ)
- Nicht berechenbar wenn eine Zahl 0 ist
- Geeignet für Geschwindigkeiten und Raten

### 4. Quadratisches Mittel (RMS)
**Formel:** √((x₁² + x₂² + ... + xₙ²) / n)
- Root Mean Square (Effektivwert)
- Wichtig in der Physik und Elektrotechnik

## Beispiele

### Eingabe: 1,2,3,4,5
- Arithmetisches Mittel: 3.000000
- Geometrisches Mittel: 2.605171
- Harmonisches Mittel: 2.189781
- Quadratisches Mittel: 3.316625

### Eingabe: 10,20,30
- Arithmetisches Mittel: 20.000000
- Geometrisches Mittel: 18.171206
- Harmonisches Mittel: 16.363636
- Quadratisches Mittel: 21.602469

## Systemvoraussetzungen

- .NET 8.0 oder höher
- Für WinForms-Version: Windows-Betriebssystem

## Installation und Ausführung

1. Repository klonen oder herunterladen
2. In das gewünschte Verzeichnis wechseln (MeanMachine/ oder WinFormsVersion/)
3. `dotnet run` ausführen

## Technische Details

- Programmiersprache: C# (.NET 8.0)
- Konsolen-Version: Plattformunabhängig
- WinForms-Version: Windows-spezifisch
- Eingabevalidierung und Fehlerbehandlung implementiert
- Deutsche Benutzeroberfläche
