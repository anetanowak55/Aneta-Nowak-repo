using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StatisticalMeasuresProject
{
    public partial class Form1 : Form
    {
        [DllImport(@"C:\Users\aneta\source\repos\AsmProjekt\x64\Debug\AsmStd.dll")]
        static extern int StdDevAsm(int a, int b);

        int dataSource = 9; // 0 - csv, 1 - random
        int libraryChoice = 9; // 0 - c#, 1 - asm
        int noThreads = 1;

        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
        }

        private void csvFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataSource = 0;
        }

        private void randSampleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            dataSource = 1;
        }

        private void cSharpRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            libraryChoice = 0;
        }

        private void assemblyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            libraryChoice = 1;
        }

        private void threadNoNumerpicUpDown_ValueChanged(object sender, EventArgs e)
        {
            noThreads = Decimal.ToInt32(threadNoNumerpicUpDown.Value);
        }

        private void displayOutputCs(double stdValue)
        {
            textBox1.Text += "Library: C#; Time: xx; Output: std=" + stdValue.ToString() + "\r\n";
        }

        private void displayOutputAsm(double stdValue)
        {
            textBox1.Text += "Library: Asm; Time: xx; Output: std=" + stdValue.ToString() + "\r\n";
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            StdDev std = new StdDev();

            if (dataSource == 1) // random sample
            {
                int sampleNo = Decimal.ToInt32(sampleNoNumericUpDown.Value);
                if (sampleNo > 0)
                {
                    if (libraryChoice == 0) // C#
                    {
                        double stdValue = std.calculateStdDevOfRandomSample(sampleNo, noThreads);
                        displayOutputCs(stdValue);
                    }
                    else if (libraryChoice == 1) // Asm
                    {
                        int x = 5, y = 3;
                        int retVal = StdDevAsm(x, y);
                        displayOutputAsm((double)retVal);
                    }
                    else
                    {
                        textBox1.Text += "No library was chosen." + "\r\n";
                    }
                }
                else
                {
                    textBox1.Text += "Sample size must be greater than 0." + "\r\n";
                }
            }
            else if (dataSource == 0) // data from a csv file
            {
                // TODO: data from csv file
            }
            else
            {
                textBox1.Text += "No source of data was chosen." + "\r\n";
            }
        }

        
    }
}
