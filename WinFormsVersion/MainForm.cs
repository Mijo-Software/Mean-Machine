using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MeanMachine.WinForms
{
    public partial class MainForm : Form
    {
        private TextBox textBoxInput;
        private Button buttonCalculate;
        private Button buttonClear;
        private Label labelArithmetic;
        private Label labelGeometric;
        private Label labelHarmonic;
        private Label labelQuadratic;
        private TextBox textBoxArithmetic;
        private TextBox textBoxGeometric;
        private TextBox textBoxHarmonic;
        private TextBox textBoxQuadratic;
        private Label labelInstructions;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            // Form properties
            this.Text = "Mean Machine - Mittelwert Rechner";
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Instructions label
            this.labelInstructions = new Label();
            this.labelInstructions.Text = "Geben Sie Zahlen getrennt durch Kommas ein (z.B.: 1,2,3,4,5):";
            this.labelInstructions.Location = new System.Drawing.Point(20, 20);
            this.labelInstructions.Size = new System.Drawing.Size(450, 20);
            this.Controls.Add(this.labelInstructions);

            // Input textbox
            this.textBoxInput = new TextBox();
            this.textBoxInput.Location = new System.Drawing.Point(20, 50);
            this.textBoxInput.Size = new System.Drawing.Size(350, 23);
            this.textBoxInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Controls.Add(this.textBoxInput);

            // Calculate button
            this.buttonCalculate = new Button();
            this.buttonCalculate.Text = "Berechnen";
            this.buttonCalculate.Location = new System.Drawing.Point(380, 50);
            this.buttonCalculate.Size = new System.Drawing.Size(80, 23);
            this.buttonCalculate.Click += ButtonCalculate_Click;
            this.Controls.Add(this.buttonCalculate);

            // Clear button
            this.buttonClear = new Button();
            this.buttonClear.Text = "Löschen";
            this.buttonClear.Location = new System.Drawing.Point(380, 80);
            this.buttonClear.Size = new System.Drawing.Size(80, 23);
            this.buttonClear.Click += ButtonClear_Click;
            this.Controls.Add(this.buttonClear);

            // Results section
            int yPos = 120;
            int spacing = 40;

            // Arithmetic mean
            this.labelArithmetic = new Label();
            this.labelArithmetic.Text = "Arithmetisches Mittel:";
            this.labelArithmetic.Location = new System.Drawing.Point(20, yPos);
            this.labelArithmetic.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.labelArithmetic);

            this.textBoxArithmetic = new TextBox();
            this.textBoxArithmetic.Location = new System.Drawing.Point(180, yPos);
            this.textBoxArithmetic.Size = new System.Drawing.Size(280, 23);
            this.textBoxArithmetic.ReadOnly = true;
            this.textBoxArithmetic.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBoxArithmetic);

            yPos += spacing;

            // Geometric mean
            this.labelGeometric = new Label();
            this.labelGeometric.Text = "Geometrisches Mittel:";
            this.labelGeometric.Location = new System.Drawing.Point(20, yPos);
            this.labelGeometric.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.labelGeometric);

            this.textBoxGeometric = new TextBox();
            this.textBoxGeometric.Location = new System.Drawing.Point(180, yPos);
            this.textBoxGeometric.Size = new System.Drawing.Size(280, 23);
            this.textBoxGeometric.ReadOnly = true;
            this.textBoxGeometric.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBoxGeometric);

            yPos += spacing;

            // Harmonic mean
            this.labelHarmonic = new Label();
            this.labelHarmonic.Text = "Harmonisches Mittel:";
            this.labelHarmonic.Location = new System.Drawing.Point(20, yPos);
            this.labelHarmonic.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.labelHarmonic);

            this.textBoxHarmonic = new TextBox();
            this.textBoxHarmonic.Location = new System.Drawing.Point(180, yPos);
            this.textBoxHarmonic.Size = new System.Drawing.Size(280, 23);
            this.textBoxHarmonic.ReadOnly = true;
            this.textBoxHarmonic.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBoxHarmonic);

            yPos += spacing;

            // Quadratic mean (RMS)
            this.labelQuadratic = new Label();
            this.labelQuadratic.Text = "Quadratisches Mittel:";
            this.labelQuadratic.Location = new System.Drawing.Point(20, yPos);
            this.labelQuadratic.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.labelQuadratic);

            this.textBoxQuadratic = new TextBox();
            this.textBoxQuadratic.Location = new System.Drawing.Point(180, yPos);
            this.textBoxQuadratic.Size = new System.Drawing.Size(280, 23);
            this.textBoxQuadratic.ReadOnly = true;
            this.textBoxQuadratic.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.textBoxQuadratic);

            this.ResumeLayout(false);
        }

        private void ButtonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                ClearResults();

                if (string.IsNullOrWhiteSpace(textBoxInput.Text))
                {
                    MessageBox.Show("Bitte geben Sie Zahlen ein.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Parse input numbers
                string[] inputStrings = textBoxInput.Text.Split(',');
                double[] numbers = new double[inputStrings.Length];

                for (int i = 0; i < inputStrings.Length; i++)
                {
                    if (!double.TryParse(inputStrings[i].Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out numbers[i]))
                    {
                        MessageBox.Show($"'{inputStrings[i].Trim()}' ist keine gültige Zahl.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (numbers.Length == 0)
                {
                    MessageBox.Show("Keine gültigen Zahlen gefunden.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate means
                double arithmeticMean = CalculateArithmeticMean(numbers);
                double geometricMean = CalculateGeometricMean(numbers);
                double harmonicMean = CalculateHarmonicMean(numbers);
                double quadraticMean = CalculateQuadraticMean(numbers);

                // Display results
                textBoxArithmetic.Text = arithmeticMean.ToString("F6", CultureInfo.InvariantCulture);
                textBoxGeometric.Text = geometricMean.ToString("F6", CultureInfo.InvariantCulture);
                textBoxHarmonic.Text = harmonicMean.ToString("F6", CultureInfo.InvariantCulture);
                textBoxQuadratic.Text = quadraticMean.ToString("F6", CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler bei der Berechnung: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxInput.Clear();
            ClearResults();
            textBoxInput.Focus();
        }

        private void ClearResults()
        {
            textBoxArithmetic.Clear();
            textBoxGeometric.Clear();
            textBoxHarmonic.Clear();
            textBoxQuadratic.Clear();
        }

        // Arithmetic Mean: (x1 + x2 + ... + xn) / n
        private double CalculateArithmeticMean(double[] numbers)
        {
            return numbers.Average();
        }

        // Geometric Mean: (x1 * x2 * ... * xn)^(1/n)
        private double CalculateGeometricMean(double[] numbers)
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
        private double CalculateHarmonicMean(double[] numbers)
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
        private double CalculateQuadraticMean(double[] numbers)
        {
            double sumOfSquares = numbers.Sum(x => x * x);
            return Math.Sqrt(sumOfSquares / numbers.Length);
        }
    }
}