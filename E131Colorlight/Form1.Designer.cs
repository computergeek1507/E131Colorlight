namespace E131Colorlight
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.outputComboBox = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startUniversNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.panelHeightNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.panelWidthNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.inputComboBox = new System.Windows.Forms.ComboBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.endUniversNumUpDwn = new System.Windows.Forms.NumericUpDown();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.universeSizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.refreshNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startUniversNumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeightNumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelWidthNumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.endUniversNumUpDwn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.universeSizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // outputComboBox
            // 
            this.outputComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputComboBox.FormattingEnabled = true;
            this.outputComboBox.Location = new System.Drawing.Point(95, 39);
            this.outputComboBox.Name = "outputComboBox";
            this.outputComboBox.Size = new System.Drawing.Size(324, 21);
            this.outputComboBox.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 258);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(407, 199);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Output:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start Universe:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Panel Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Panel Width:";
            // 
            // startUniversNumUpDwn
            // 
            this.startUniversNumUpDwn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startUniversNumUpDwn.Location = new System.Drawing.Point(95, 66);
            this.startUniversNumUpDwn.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.startUniversNumUpDwn.Name = "startUniversNumUpDwn";
            this.startUniversNumUpDwn.Size = new System.Drawing.Size(324, 20);
            this.startUniversNumUpDwn.TabIndex = 8;
            this.startUniversNumUpDwn.ValueChanged += new System.EventHandler(this.startUniversNumUpDwn_ValueChanged);
            // 
            // panelHeightNumUpDwn
            // 
            this.panelHeightNumUpDwn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeightNumUpDwn.Location = new System.Drawing.Point(95, 145);
            this.panelHeightNumUpDwn.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.panelHeightNumUpDwn.Name = "panelHeightNumUpDwn";
            this.panelHeightNumUpDwn.Size = new System.Drawing.Size(324, 20);
            this.panelHeightNumUpDwn.TabIndex = 9;
            this.panelHeightNumUpDwn.ValueChanged += new System.EventHandler(this.panelHeightNumUpDwn_ValueChanged);
            // 
            // panelWidthNumUpDwn
            // 
            this.panelWidthNumUpDwn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWidthNumUpDwn.Location = new System.Drawing.Point(95, 171);
            this.panelWidthNumUpDwn.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.panelWidthNumUpDwn.Name = "panelWidthNumUpDwn";
            this.panelWidthNumUpDwn.Size = new System.Drawing.Size(324, 20);
            this.panelWidthNumUpDwn.TabIndex = 10;
            this.panelWidthNumUpDwn.ValueChanged += new System.EventHandler(this.panelWidthNumUpDwn_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Input:";
            // 
            // inputComboBox
            // 
            this.inputComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputComboBox.FormattingEnabled = true;
            this.inputComboBox.Location = new System.Drawing.Point(95, 12);
            this.inputComboBox.Name = "inputComboBox";
            this.inputComboBox.Size = new System.Drawing.Size(324, 21);
            this.inputComboBox.TabIndex = 13;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(344, 223);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "End Universe:";
            // 
            // endUniversNumUpDwn
            // 
            this.endUniversNumUpDwn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.endUniversNumUpDwn.Enabled = false;
            this.endUniversNumUpDwn.Location = new System.Drawing.Point(95, 93);
            this.endUniversNumUpDwn.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.endUniversNumUpDwn.Name = "endUniversNumUpDwn";
            this.endUniversNumUpDwn.ReadOnly = true;
            this.endUniversNumUpDwn.Size = new System.Drawing.Size(324, 20);
            this.endUniversNumUpDwn.TabIndex = 16;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Universe Size:";
            // 
            // universeSizeNumericUpDown
            // 
            this.universeSizeNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.universeSizeNumericUpDown.Location = new System.Drawing.Point(95, 119);
            this.universeSizeNumericUpDown.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.universeSizeNumericUpDown.Minimum = new decimal(new int[] {
            510,
            0,
            0,
            0});
            this.universeSizeNumericUpDown.Name = "universeSizeNumericUpDown";
            this.universeSizeNumericUpDown.Size = new System.Drawing.Size(324, 20);
            this.universeSizeNumericUpDown.TabIndex = 18;
            this.universeSizeNumericUpDown.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            // 
            // refreshNumericUpDown
            // 
            this.refreshNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshNumericUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.refreshNumericUpDown.Location = new System.Drawing.Point(95, 197);
            this.refreshNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.refreshNumericUpDown.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.refreshNumericUpDown.Name = "refreshNumericUpDown";
            this.refreshNumericUpDown.Size = new System.Drawing.Size(324, 20);
            this.refreshNumericUpDown.TabIndex = 19;
            this.refreshNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Data Refresh:";
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(209, 223);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 21;
            this.buttonClear.Text = "Clear Log";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOutput.Location = new System.Drawing.Point(12, 226);
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ReadOnly = true;
            this.textBoxOutput.Size = new System.Drawing.Size(191, 20);
            this.textBoxOutput.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(290, 223);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 480);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.refreshNumericUpDown);
            this.Controls.Add(this.universeSizeNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.endUniversNumUpDwn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.inputComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panelWidthNumUpDwn);
            this.Controls.Add(this.panelHeightNumUpDwn);
            this.Controls.Add(this.startUniversNumUpDwn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.outputComboBox);
            this.Name = "Form1";
            this.Text = "E131toColorLight";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.startUniversNumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeightNumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelWidthNumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.endUniversNumUpDwn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.universeSizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refreshNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox outputComboBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown startUniversNumUpDwn;
        private System.Windows.Forms.NumericUpDown panelHeightNumUpDwn;
        private System.Windows.Forms.NumericUpDown panelWidthNumUpDwn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox inputComboBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown endUniversNumUpDwn;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown universeSizeNumericUpDown;
        private System.Windows.Forms.NumericUpDown refreshNumericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button button1;
    }
}

