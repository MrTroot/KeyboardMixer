namespace KeyboardMixer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelCtrlShift = new System.Windows.Forms.Label();
            this.textBoxCtrlShiftProgram = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxCtrlAltProgram = new System.Windows.Forms.TextBox();
            this.labelCtrlAlt = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.checkBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.comboBoxPopupScreen = new System.Windows.Forms.ComboBox();
            this.comboBoxPopupSide = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCtrlShift
            // 
            this.labelCtrlShift.AutoSize = true;
            this.labelCtrlShift.Location = new System.Drawing.Point(20, 35);
            this.labelCtrlShift.Name = "labelCtrlShift";
            this.labelCtrlShift.Size = new System.Drawing.Size(105, 13);
            this.labelCtrlShift.TabIndex = 0;
            this.labelCtrlShift.Text = "Ctrl + Shift + Volume:";
            this.labelCtrlShift.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCtrlShiftProgram
            // 
            this.textBoxCtrlShiftProgram.Location = new System.Drawing.Point(131, 32);
            this.textBoxCtrlShiftProgram.Name = "textBoxCtrlShiftProgram";
            this.textBoxCtrlShiftProgram.Size = new System.Drawing.Size(139, 20);
            this.textBoxCtrlShiftProgram.TabIndex = 1;
            this.textBoxCtrlShiftProgram.TabStop = false;
            this.textBoxCtrlShiftProgram.Text = "Discord.exe";
            this.textBoxCtrlShiftProgram.TextChanged += new System.EventHandler(this.TextBoxCtrlShiftProgram_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ctrl + Volume:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Current Application";
            // 
            // textBoxCtrlAltProgram
            // 
            this.textBoxCtrlAltProgram.Location = new System.Drawing.Point(131, 58);
            this.textBoxCtrlAltProgram.Name = "textBoxCtrlAltProgram";
            this.textBoxCtrlAltProgram.Size = new System.Drawing.Size(139, 20);
            this.textBoxCtrlAltProgram.TabIndex = 5;
            this.textBoxCtrlAltProgram.TabStop = false;
            this.textBoxCtrlAltProgram.Text = "firefox.exe";
            this.textBoxCtrlAltProgram.TextChanged += new System.EventHandler(this.TextBoxCtrlAltProgram_TextChanged);
            // 
            // labelCtrlAlt
            // 
            this.labelCtrlAlt.AutoSize = true;
            this.labelCtrlAlt.Location = new System.Drawing.Point(29, 61);
            this.labelCtrlAlt.Name = "labelCtrlAlt";
            this.labelCtrlAlt.Size = new System.Drawing.Size(96, 13);
            this.labelCtrlAlt.TabIndex = 4;
            this.labelCtrlAlt.Text = "Ctrl + Alt + Volume:";
            this.labelCtrlAlt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "KeyboardMixer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(94, 26);
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(93, 22);
            this.toolStripMenuItemExit.Text = "Exit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.ToolStripMenuItemExit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Volume Increment:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(131, 143);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.TabStop = false;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // checkBoxStartMinimized
            // 
            this.checkBoxStartMinimized.AutoSize = true;
            this.checkBoxStartMinimized.Location = new System.Drawing.Point(173, 145);
            this.checkBoxStartMinimized.Name = "checkBoxStartMinimized";
            this.checkBoxStartMinimized.Size = new System.Drawing.Size(97, 17);
            this.checkBoxStartMinimized.TabIndex = 8;
            this.checkBoxStartMinimized.Text = "Start Minimized";
            this.checkBoxStartMinimized.UseVisualStyleBackColor = true;
            this.checkBoxStartMinimized.CheckedChanged += new System.EventHandler(this.CheckBoxStartMinimized_CheckedChanged);
            // 
            // comboBoxPopupScreen
            // 
            this.comboBoxPopupScreen.FormattingEnabled = true;
            this.comboBoxPopupScreen.Location = new System.Drawing.Point(131, 84);
            this.comboBoxPopupScreen.Name = "comboBoxPopupScreen";
            this.comboBoxPopupScreen.Size = new System.Drawing.Size(139, 21);
            this.comboBoxPopupScreen.TabIndex = 9;
            this.comboBoxPopupScreen.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxPopupScreen_SelectionChangeCommitted);
            // 
            // comboBoxPopupSide
            // 
            this.comboBoxPopupSide.FormattingEnabled = true;
            this.comboBoxPopupSide.Location = new System.Drawing.Point(131, 110);
            this.comboBoxPopupSide.Name = "comboBoxPopupSide";
            this.comboBoxPopupSide.Size = new System.Drawing.Size(139, 21);
            this.comboBoxPopupSide.TabIndex = 10;
            this.comboBoxPopupSide.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxPopupSide_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Popup Screen:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Popup Side:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPopupSide);
            this.Controls.Add(this.comboBoxPopupScreen);
            this.Controls.Add(this.checkBoxStartMinimized);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxCtrlAltProgram);
            this.Controls.Add(this.labelCtrlAlt);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxCtrlShiftProgram);
            this.Controls.Add(this.labelCtrlShift);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 210);
            this.MinimumSize = new System.Drawing.Size(300, 210);
            this.Name = "MainForm";
            this.Text = "KeyboardMixer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCtrlShift;
        private System.Windows.Forms.TextBox textBoxCtrlShiftProgram;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxCtrlAltProgram;
        private System.Windows.Forms.Label labelCtrlAlt;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxStartMinimized;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ComboBox comboBoxPopupScreen;
        private System.Windows.Forms.ComboBox comboBoxPopupSide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

