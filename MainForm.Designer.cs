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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.NumericUpDownVolumeIncrement = new System.Windows.Forms.NumericUpDown();
            this.checkBoxStartMinimized = new System.Windows.Forms.CheckBox();
            this.comboBoxPopupScreen = new System.Windows.Forms.ComboBox();
            this.comboBoxPopupSide = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewKeybinds = new System.Windows.Forms.DataGridView();
            this.Keybind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Process = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBoxKeybinds = new System.Windows.Forms.GroupBox();
            this.buttonAddKeybind = new System.Windows.Forms.Button();
            this.textBoxAddProcess = new System.Windows.Forms.TextBox();
            this.textBoxAddKeybind = new System.Windows.Forms.TextBox();
            this.labelAddKeybind = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownVolumeIncrement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeybinds)).BeginInit();
            this.groupBoxKeybinds.SuspendLayout();
            this.SuspendLayout();
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
            this.label2.Location = new System.Drawing.Point(13, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Volume Increment:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumericUpDownVolumeIncrement
            // 
            this.NumericUpDownVolumeIncrement.Location = new System.Drawing.Point(108, 252);
            this.NumericUpDownVolumeIncrement.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.NumericUpDownVolumeIncrement.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDownVolumeIncrement.Name = "NumericUpDownVolumeIncrement";
            this.NumericUpDownVolumeIncrement.Size = new System.Drawing.Size(36, 20);
            this.NumericUpDownVolumeIncrement.TabIndex = 7;
            this.NumericUpDownVolumeIncrement.TabStop = false;
            this.NumericUpDownVolumeIncrement.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NumericUpDownVolumeIncrement.ValueChanged += new System.EventHandler(this.NumericUpDownVolumeIncrement_ValueChanged);
            // 
            // checkBoxStartMinimized
            // 
            this.checkBoxStartMinimized.AutoSize = true;
            this.checkBoxStartMinimized.Location = new System.Drawing.Point(160, 254);
            this.checkBoxStartMinimized.Name = "checkBoxStartMinimized";
            this.checkBoxStartMinimized.Size = new System.Drawing.Size(97, 17);
            this.checkBoxStartMinimized.TabIndex = 8;
            this.checkBoxStartMinimized.Text = "Start Minimized";
            this.checkBoxStartMinimized.UseVisualStyleBackColor = true;
            this.checkBoxStartMinimized.CheckedChanged += new System.EventHandler(this.CheckBoxStartMinimized_CheckedChanged);
            // 
            // comboBoxPopupScreen
            // 
            this.comboBoxPopupScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPopupScreen.FormattingEnabled = true;
            this.comboBoxPopupScreen.Location = new System.Drawing.Point(108, 198);
            this.comboBoxPopupScreen.Name = "comboBoxPopupScreen";
            this.comboBoxPopupScreen.Size = new System.Drawing.Size(139, 21);
            this.comboBoxPopupScreen.TabIndex = 9;
            this.comboBoxPopupScreen.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxPopupScreen_SelectionChangeCommitted);
            // 
            // comboBoxPopupSide
            // 
            this.comboBoxPopupSide.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPopupSide.FormattingEnabled = true;
            this.comboBoxPopupSide.Location = new System.Drawing.Point(108, 225);
            this.comboBoxPopupSide.Name = "comboBoxPopupSide";
            this.comboBoxPopupSide.Size = new System.Drawing.Size(139, 21);
            this.comboBoxPopupSide.TabIndex = 10;
            this.comboBoxPopupSide.SelectionChangeCommitted += new System.EventHandler(this.ComboBoxPopupSide_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Popup Screen:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Popup Side:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridViewKeybinds
            // 
            this.dataGridViewKeybinds.AllowUserToAddRows = false;
            this.dataGridViewKeybinds.AllowUserToDeleteRows = false;
            this.dataGridViewKeybinds.AllowUserToResizeColumns = false;
            this.dataGridViewKeybinds.AllowUserToResizeRows = false;
            this.dataGridViewKeybinds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKeybinds.ColumnHeadersVisible = false;
            this.dataGridViewKeybinds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Keybind,
            this.Process,
            this.Delete});
            this.dataGridViewKeybinds.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewKeybinds.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewKeybinds.MultiSelect = false;
            this.dataGridViewKeybinds.Name = "dataGridViewKeybinds";
            this.dataGridViewKeybinds.RowHeadersVisible = false;
            this.dataGridViewKeybinds.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewKeybinds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewKeybinds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewKeybinds.Size = new System.Drawing.Size(357, 125);
            this.dataGridViewKeybinds.TabIndex = 13;
            this.dataGridViewKeybinds.TabStop = false;
            this.dataGridViewKeybinds.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewKeybinds_CellContentClick);
            this.dataGridViewKeybinds.SelectionChanged += new System.EventHandler(this.dataGridViewKeybinds_SelectionChanged);
            // 
            // Keybind
            // 
            dataGridViewCellStyle2.NullValue = "New Keybind";
            this.Keybind.DefaultCellStyle = dataGridViewCellStyle2;
            this.Keybind.HeaderText = "Keybind";
            this.Keybind.Name = "Keybind";
            this.Keybind.ReadOnly = true;
            this.Keybind.Width = 156;
            // 
            // Process
            // 
            this.Process.HeaderText = "Process";
            this.Process.Name = "Process";
            this.Process.ReadOnly = true;
            this.Process.Width = 156;
            // 
            // Delete
            // 
            this.Delete.HeaderText = "X";
            this.Delete.MinimumWidth = 25;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Text = "X";
            this.Delete.ToolTipText = "Delete this keybind.";
            this.Delete.UseColumnTextForButtonValue = true;
            this.Delete.Width = 25;
            // 
            // groupBoxKeybinds
            // 
            this.groupBoxKeybinds.Controls.Add(this.buttonAddKeybind);
            this.groupBoxKeybinds.Controls.Add(this.textBoxAddProcess);
            this.groupBoxKeybinds.Controls.Add(this.textBoxAddKeybind);
            this.groupBoxKeybinds.Controls.Add(this.labelAddKeybind);
            this.groupBoxKeybinds.Controls.Add(this.dataGridViewKeybinds);
            this.groupBoxKeybinds.Location = new System.Drawing.Point(12, 12);
            this.groupBoxKeybinds.Name = "groupBoxKeybinds";
            this.groupBoxKeybinds.Size = new System.Drawing.Size(369, 178);
            this.groupBoxKeybinds.TabIndex = 14;
            this.groupBoxKeybinds.TabStop = false;
            this.groupBoxKeybinds.Text = "Keybinds";
            // 
            // buttonAddKeybind
            // 
            this.buttonAddKeybind.Location = new System.Drawing.Point(332, 148);
            this.buttonAddKeybind.Name = "buttonAddKeybind";
            this.buttonAddKeybind.Size = new System.Drawing.Size(28, 23);
            this.buttonAddKeybind.TabIndex = 17;
            this.buttonAddKeybind.Text = "+";
            this.buttonAddKeybind.UseVisualStyleBackColor = true;
            this.buttonAddKeybind.Click += new System.EventHandler(this.buttonAddKeybind_Click);
            // 
            // textBoxAddProcess
            // 
            this.textBoxAddProcess.Location = new System.Drawing.Point(199, 150);
            this.textBoxAddProcess.Name = "textBoxAddProcess";
            this.textBoxAddProcess.Size = new System.Drawing.Size(127, 20);
            this.textBoxAddProcess.TabIndex = 16;
            this.textBoxAddProcess.Text = "ProcessName.exe";
            // 
            // textBoxAddKeybind
            // 
            this.textBoxAddKeybind.Location = new System.Drawing.Point(79, 150);
            this.textBoxAddKeybind.Name = "textBoxAddKeybind";
            this.textBoxAddKeybind.Size = new System.Drawing.Size(114, 20);
            this.textBoxAddKeybind.TabIndex = 15;
            this.textBoxAddKeybind.Text = "Enter Modifier...";
            this.textBoxAddKeybind.TextChanged += new System.EventHandler(this.textBoxAddKeybind_TextChanged);
            this.textBoxAddKeybind.Enter += new System.EventHandler(this.textBoxAddKeybind_Enter);
            this.textBoxAddKeybind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddKeybind_KeyPress);
            this.textBoxAddKeybind.Leave += new System.EventHandler(this.textBoxAddKeybind_Leave);
            // 
            // labelAddKeybind
            // 
            this.labelAddKeybind.AutoSize = true;
            this.labelAddKeybind.Location = new System.Drawing.Point(3, 153);
            this.labelAddKeybind.Name = "labelAddKeybind";
            this.labelAddKeybind.Size = new System.Drawing.Size(70, 13);
            this.labelAddKeybind.TabIndex = 14;
            this.labelAddKeybind.Text = "Add Keybind:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 301);
            this.Controls.Add(this.groupBoxKeybinds);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPopupSide);
            this.Controls.Add(this.comboBoxPopupScreen);
            this.Controls.Add(this.checkBoxStartMinimized);
            this.Controls.Add(this.NumericUpDownVolumeIncrement);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 340);
            this.MinimumSize = new System.Drawing.Size(410, 340);
            this.Name = "MainForm";
            this.Text = "KeyboardMixer";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.Deactivate += new System.EventHandler(this.MainForm_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDownVolumeIncrement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKeybinds)).EndInit();
            this.groupBoxKeybinds.ResumeLayout(false);
            this.groupBoxKeybinds.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NumericUpDown NumericUpDownVolumeIncrement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBoxStartMinimized;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private System.Windows.Forms.ComboBox comboBoxPopupScreen;
        private System.Windows.Forms.ComboBox comboBoxPopupSide;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dataGridViewKeybinds;
        private System.Windows.Forms.GroupBox groupBoxKeybinds;
        private System.Windows.Forms.Button buttonAddKeybind;
        private System.Windows.Forms.TextBox textBoxAddProcess;
        private System.Windows.Forms.TextBox textBoxAddKeybind;
        private System.Windows.Forms.Label labelAddKeybind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keybind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Process;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}

