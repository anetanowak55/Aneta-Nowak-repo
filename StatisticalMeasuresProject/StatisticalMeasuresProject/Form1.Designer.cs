
namespace StatisticalMeasuresProject
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.calculateButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cSharpRadioButton = new System.Windows.Forms.RadioButton();
            this.assemblyRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.sampleNoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.randSampleRadioButton = new System.Windows.Forms.RadioButton();
            this.csvFileRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.threadNoNumerpicUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleNoNumericUpDown)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadNoNumerpicUpDown)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(332, 325);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(103, 44);
            this.calculateButton.TabIndex = 0;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "1. standard deviation";
            // 
            // cSharpRadioButton
            // 
            this.cSharpRadioButton.AutoSize = true;
            this.cSharpRadioButton.Location = new System.Drawing.Point(21, 32);
            this.cSharpRadioButton.Name = "cSharpRadioButton";
            this.cSharpRadioButton.Size = new System.Drawing.Size(46, 21);
            this.cSharpRadioButton.TabIndex = 5;
            this.cSharpRadioButton.TabStop = true;
            this.cSharpRadioButton.Text = "C#";
            this.cSharpRadioButton.UseVisualStyleBackColor = true;
            this.cSharpRadioButton.CheckedChanged += new System.EventHandler(this.cSharpRadioButton_CheckedChanged);
            // 
            // assemblyRadioButton
            // 
            this.assemblyRadioButton.AutoSize = true;
            this.assemblyRadioButton.Location = new System.Drawing.Point(21, 59);
            this.assemblyRadioButton.Name = "assemblyRadioButton";
            this.assemblyRadioButton.Size = new System.Drawing.Size(89, 21);
            this.assemblyRadioButton.TabIndex = 6;
            this.assemblyRadioButton.TabStop = true;
            this.assemblyRadioButton.Text = "Assembly";
            this.assemblyRadioButton.UseVisualStyleBackColor = true;
            this.assemblyRadioButton.CheckedChanged += new System.EventHandler(this.assemblyRadioButton_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cSharpRadioButton);
            this.groupBox1.Controls.Add(this.assemblyRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(295, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 173);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose the library:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.sampleNoNumericUpDown);
            this.groupBox2.Controls.Add(this.chooseFileButton);
            this.groupBox2.Controls.Add(this.randSampleRadioButton);
            this.groupBox2.Controls.Add(this.csvFileRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(60, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 173);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose the souce of data:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "(choose number of records)";
            // 
            // sampleNoNumericUpDown
            // 
            this.sampleNoNumericUpDown.Location = new System.Drawing.Point(62, 132);
            this.sampleNoNumericUpDown.Name = "sampleNoNumericUpDown";
            this.sampleNoNumericUpDown.Size = new System.Drawing.Size(59, 22);
            this.sampleNoNumericUpDown.TabIndex = 13;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(48, 59);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(101, 23);
            this.chooseFileButton.TabIndex = 2;
            this.chooseFileButton.Text = "Choose file";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            // 
            // randSampleRadioButton
            // 
            this.randSampleRadioButton.AutoSize = true;
            this.randSampleRadioButton.Location = new System.Drawing.Point(23, 90);
            this.randSampleRadioButton.Name = "randSampleRadioButton";
            this.randSampleRadioButton.Size = new System.Drawing.Size(126, 21);
            this.randSampleRadioButton.TabIndex = 1;
            this.randSampleRadioButton.TabStop = true;
            this.randSampleRadioButton.Text = "random sample";
            this.randSampleRadioButton.UseVisualStyleBackColor = true;
            this.randSampleRadioButton.CheckedChanged += new System.EventHandler(this.randSampleRadioButton_CheckedChanged);
            // 
            // csvFileRadioButton
            // 
            this.csvFileRadioButton.AutoSize = true;
            this.csvFileRadioButton.Location = new System.Drawing.Point(23, 32);
            this.csvFileRadioButton.Name = "csvFileRadioButton";
            this.csvFileRadioButton.Size = new System.Drawing.Size(98, 21);
            this.csvFileRadioButton.TabIndex = 0;
            this.csvFileRadioButton.TabStop = true;
            this.csvFileRadioButton.Text = "my .csv file";
            this.csvFileRadioButton.UseVisualStyleBackColor = true;
            this.csvFileRadioButton.CheckedChanged += new System.EventHandler(this.csvFileRadioButton_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.threadNoNumerpicUpDown);
            this.groupBox3.Location = new System.Drawing.Point(533, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(199, 173);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Choose no. of threads:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "max value is 64";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "min value is 1";
            // 
            // threadNoNumerpicUpDown
            // 
            this.threadNoNumerpicUpDown.Location = new System.Drawing.Point(56, 89);
            this.threadNoNumerpicUpDown.Name = "threadNoNumerpicUpDown";
            this.threadNoNumerpicUpDown.Size = new System.Drawing.Size(59, 22);
            this.threadNoNumerpicUpDown.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(60, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(672, 90);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "This program calculates the following statistical measures:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "1. standard deviation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "1. standard deviation";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 387);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(672, 81);
            this.textBox1.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 494);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.calculateButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sampleNoNumericUpDown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadNoNumerpicUpDown)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton cSharpRadioButton;
        private System.Windows.Forms.RadioButton assemblyRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton randSampleRadioButton;
        private System.Windows.Forms.RadioButton csvFileRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown threadNoNumerpicUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown sampleNoNumericUpDown;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
    }
}

