using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Converter
{
    public partial class FormMain : Form
    {

        Dictionary<string, double> measures = new Dictionary<string, double>()
{
            {"Millimeter",  1000},
            {"Centimeter", 100},
            {"Meter", 1},
            {"Kilometer", 0.001 }
};
        public FormMain()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (var measure in measures)
            {
                comboBoxInitiallyMeasure.Items.Add(measure.Key);
                comboBoxFinalMeasure.Items.Add(measure.Key);
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            var num = textBoxInput.Text;
            if (num.Length == 0)
            {
                MessageBox.Show("Строка ввода пуста");
            }
            else if (comboBoxInitiallyMeasure.Text.Length == 0)
            {
                MessageBox.Show("Введите размерность числа");
            }
            else if (comboBoxFinalMeasure.Text.Length == 0)
            {
                MessageBox.Show("Введите размерность перевода");
            }
            else
            {
                try
                {
                    textBoxOutput.Text = Convert.ToString(Convert.ToDouble(num) * measures[comboBoxFinalMeasure.Text] / measures[comboBoxInitiallyMeasure.Text]);
                }
                catch
                {
                    MessageBox.Show("Введите число!");
                }
            }
        }
    }
}
