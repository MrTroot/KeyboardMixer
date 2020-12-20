using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using KeyboardMixer.config;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace KeyboardMixer
{
    public partial class MainForm : Form
    {

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        //KeyboardMixer Manager
        private MixerManager mixerManager;
        //Reference to settings
        private SerializableSettings settings;
        //The popup slider when the volume is changed
        public PopupForm popupForm;
        //Set to true when exiting the application
        private bool appClosing = false;

        public MainForm()
        {
            //Init mixer manager
            mixerManager = new MixerManager(this);
            //reference to settings
            settings = mixerManager.settings;

            //Init UI
            InitializeComponent();
            popupForm = new PopupForm(mixerManager);
            comboBoxPopupScreen.DataSource = Enum.GetValues(typeof(PopupScreen));
            comboBoxPopupSide.DataSource = Enum.GetValues(typeof(PopupSide));

            //Change controls to match the settings
            NumericUpDownVolumeIncrement.Value = settings.volumeStep;
            checkBoxStartMinimized.Checked = settings.startMinimized;
            comboBoxPopupScreen.SelectedItem = settings.popupScreen;
            comboBoxPopupSide.SelectedItem = settings.popupSide;

            //Start Minimized if selected
            if (settings.startMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            resetDataGrid();
        }

        private void CheckBoxStartMinimized_CheckedChanged(object sender, EventArgs e)
        {
            settings.startMinimized = checkBoxStartMinimized.Checked;
            ConfigManager.WriteConfig(settings);
        }

        private void ComboBoxPopupScreen_SelectionChangeCommitted(object sender, EventArgs e)
        {
            settings.popupScreen = (PopupScreen)comboBoxPopupScreen.SelectedItem;
            popupForm.PlaceWindow();
        }
        private void ComboBoxPopupSide_SelectionChangeCommitted(object sender, EventArgs e)
        {
            settings.popupSide = (PopupSide)comboBoxPopupSide.SelectedItem;
            popupForm.PlaceWindow();
            ConfigManager.WriteConfig(settings);
        }

        private void NumericUpDownVolumeIncrement_ValueChanged(object sender, EventArgs e)
        {
            settings.volumeStep = (int)NumericUpDownVolumeIncrement.Value;
            ConfigManager.WriteConfig(settings);
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //When the taskbar icon is double clicked, show the form
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Focus();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            if (e.CloseReason == CloseReason.ApplicationExitCall) return;
            if (e.CloseReason == CloseReason.TaskManagerClosing) return;

            if (!appClosing)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
            }
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            //Write config on application exit
            ConfigManager.WriteConfig(settings);
            //Set to true so that the close event is not cancelled
            appClosing = true;
            //Close the program when exit is clicked.
            Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void dataGridViewKeybinds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridViewKeybinds.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex > 0)
            {
                string gridProcessName = dataGridViewKeybinds.Rows[e.RowIndex].Cells["Process"].Value.ToString();

                settings.keybinds.RemoveAll(keybind =>
                    string.Equals(keybind.ProcessName, gridProcessName, StringComparison.InvariantCultureIgnoreCase)
                );
                resetDataGrid();
                ConfigManager.WriteConfig(settings);
            }
        }

        private void dataGridViewKeybinds_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewKeybinds.ClearSelection();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            mixerManager.StopListeningKeybind();
            //Change active control away from the text box when focus is lost. Prevents focus issues when form is opened and closed
            this.ActiveControl = labelAddKeybind;
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            //Change active control away from the text box when an empty space is clicked
            this.ActiveControl = labelAddKeybind;
        }

        private void textBoxAddKeybind_Enter(object sender, EventArgs e)
        {
            mixerManager.detectedNewKeybind = null;
            mixerManager.StartListeningKeybind();
        }

        private void textBoxAddKeybind_Leave(object sender, EventArgs e)
        {
            mixerManager.StopListeningKeybind();
        }

        private void textBoxAddKeybind_KeyPress(object sender, KeyPressEventArgs e) 
        {
            e.Handled = true;
        }

        private void textBoxAddKeybind_TextChanged(object sender, EventArgs e)
        { 
            HideCaret(textBoxAddKeybind.Handle);
        }

        private void buttonAddKeybind_Click(object sender, EventArgs e)
        {
            //check contraints
            if (mixerManager.detectedNewKeybind == null)
            {
                return;
            }
            if (textBoxAddProcess.Text == "")
            {
                return;
            }

            //new keybind
            var newKeybind = new MixerKeybindEntry()
            {
                KeyList = mixerManager.detectedNewKeybind,
                ProcessName = textBoxAddProcess.Text,
            };

            //ensure that the keybind we are trying to add does not already exist
            if (settings.keybinds.Any(keybind => areKeybindsEqual(keybind.KeyList, newKeybind.KeyList)))
            {
                MessageBox.Show("Keybind already exists.", "KeyboardMixer");
                return;
            }
            else //add keybind to settings
            {
                settings.keybinds.Add(newKeybind);
            }

            resetDataGrid();

            ConfigManager.WriteConfig(settings);
        }

        public void resetDataGrid()
        {
            dataGridViewKeybinds.Rows.Clear();

            dataGridViewKeybinds.Rows.Add(new string[] { "Ctrl+Vol", "Current Application" });

            DataGridViewTextBoxCell textBoxCell = new DataGridViewTextBoxCell();
            this.dataGridViewKeybinds[2, 0] = textBoxCell;
            this.dataGridViewKeybinds[2, 0].Value = "";

            foreach (MixerKeybindEntry keybind in settings.keybinds)
            {
                dataGridViewKeybinds.Rows.Add(new string[] { keybind.ToString(), keybind.ProcessName });
            }
        }

        public void updateNewKeybindField(Keys[] newKeyBind)
        {
            textBoxAddKeybind.Text = MixerKeybindEntry.FromKeyArray(newKeyBind);
        }

        public void resetNewKeybindField()
        {
            textBoxAddKeybind.Text = "Enter Modifier...";
        }


        private static bool areKeybindsEqual(Keys[] binding1, Keys[] binding2)
        {
            return binding1.OrderBy(i => i).SequenceEqual(binding2.OrderBy(i => i));
        }
    }
}