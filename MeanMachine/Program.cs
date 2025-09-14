using System;
using System.Globalization;
using System.Linq;

namespace MeanMachine
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("=== Mean Machine - Mittelwert Rechner ===");
            Console.WriteLine("Dieses Programm berechnet verschiedene Mittelwerte.");
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Geben Sie Zahlen getrennt durch Kommas ein (z.B.: 1,2,3,4,5):");
                Console.WriteLine("Oder geben Sie 'exit' ein, um das Programm zu beenden.");
                Console.Write("> ");

                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bitte geben Sie gültige Zahlen ein.\n");
                    continue;
                }

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Auf Wiedersehen!");
                    break;
                }

                try
                {
                    // Parse input numbers
                    string[] inputStrings = input.Split(',');
                    double[] numbers = new double[inputStrings.Length];

                    for (int i = 0; i < inputStrings.Length; i++)
                    {
                        if (!double.TryParse(inputStrings[i].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out numbers[i]))
                        {
                            throw new ArgumentException($"'{inputStrings[i].Trim()}' ist keine gültige Zahl.");
                        }
                    }

                    if (numbers.Length == 0)
                    {
                        Console.WriteLine("Keine gültigen Zahlen gefunden.\n");
                        continue;
                    }

                    // Calculate and display results
                    Console.WriteLine("\n=== Ergebnisse ===");
                    Console.WriteLine($"Eingabe: [{string.Join(", ", numbers)}]");
                    Console.WriteLine($"Anzahl Werte: {numbers.Length}");
                    Console.WriteLine();

                    // Arithmetic mean
                    double arithmeticMean = CalculateArithmeticMean(numbers);
                    Console.WriteLine($"Arithmetisches Mittel: {arithmeticMean:F6}");

                    // Geometric mean
                    try
                    {
                        double geometricMean = CalculateGeometricMean(numbers);
                        Console.WriteLine($"Geometrisches Mittel:  {geometricMean:F6}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Geometrisches Mittel:  Fehler - {ex.Message}");
                    }

                    // Harmonic mean
                    try
                    {
                        double harmonicMean = CalculateHarmonicMean(numbers);
                        Console.WriteLine($"Harmonisches Mittel:   {harmonicMean:F6}");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Harmonisches Mittel:   Fehler - {ex.Message}");
                    }

                    // Quadratic mean (RMS)
                    double quadraticMean = CalculateQuadraticMean(numbers);
                    Console.WriteLine($"Quadratisches Mittel:  {quadraticMean:F6}");

                    Console.WriteLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fehler bei der Berechnung: {ex.Message}\n");
                }
            }
        }

        // Arithmetic Mean: (x1 + x2 + ... + xn) / n
        private static double CalculateArithmeticMean(double[] numbers)
        {
            return numbers.Average();
        }

        // Geometric Mean: (x1 * x2 * ... * xn)^(1/n)
        private static double CalculateGeometricMean(double[] numbers)
        {
            if (numbers.Any(x => x <= 0))
            {
                throw new ArgumentException("Geometrisches Mittel kann nur für positive Zahlen berechnet werden.");
            }

            double product = 1.0;
            foreach (double number in numbers)
            {
                product *= number;
            }

            return Math.Pow(product, 1.0 / numbers.Length);
        }

        // Harmonic Mean: n / (1/x1 + 1/x2 + ... + 1/xn)
        private static double CalculateHarmonicMean(double[] numbers)
        {
            if (numbers.Any(x => x == 0))
            {
                throw new ArgumentException("Harmonisches Mittel kann nicht berechnet werden, wenn eine Zahl 0 ist.");
            }

            double sumOfReciprocals = 0.0;
            foreach (double number in numbers)
            {
                sumOfReciprocals += 1.0 / number;
            }

            return numbers.Length / sumOfReciprocals;
        }

        // Quadratic Mean (RMS): √((x1² + x2² + ... + xn²) / n)
        private static double CalculateQuadraticMean(double[] numbers)
        {
            double sumOfSquares = numbers.Sum(x => x * x);
            return Math.Sqrt(sumOfSquares / numbers.Length);
        }
    }
}
