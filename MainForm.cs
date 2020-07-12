using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace KeyboardMixer
{
    public partial class MainForm : Form
    {

        //The popup slider when the volume is changed
        private PopupForm popupForm;
        //Keep cache of sessions and their volumes, as calling for them repeatedly creates a lot of overhead
        private List<AppVolume> appVolumeCache;
        private int ticksRenewedCacheAt;
        //Application settings
        public SerializableSettings settings;
        //Keyboard hook
        private GlobalKeyboardHook globalKeyboardHook;

        public MainForm()
        {
            //Load settings
            settings = ConfigManager.ReadConfig();

            //Init UI
            InitializeComponent();
            popupForm = new PopupForm(this);
            comboBoxPopupScreen.DataSource = Enum.GetValues(typeof(PopupScreen));
            comboBoxPopupSide.DataSource = Enum.GetValues(typeof(PopupSide));

            //Change controls to match the settings
            textBoxCtrlShiftProgram.Text = settings.ctrlShiftProgram;
            textBoxCtrlAltProgram.Text = settings.ctrlAltProgram;
            numericUpDown1.Value = settings.volumeStep;
            checkBoxStartMinimized.Checked = settings.startMinimized;
            comboBoxPopupScreen.SelectedItem = settings.popupScreen;
            comboBoxPopupSide.SelectedItem = settings.popupSide;

            //Start Minimized if selected
            if (settings.startMinimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }

            //Init volume app cache
            RenewCachedValues();

            //Init hotkeys
            globalKeyboardHook = new GlobalKeyboardHook();
            globalKeyboardHook.HookedKeys.Add(Keys.VolumeUp);
            globalKeyboardHook.HookedKeys.Add(Keys.VolumeDown);
            globalKeyboardHook.HookedKeys.Add(Keys.LControlKey);
            globalKeyboardHook.HookedKeys.Add(Keys.RControlKey);
            globalKeyboardHook.HookedKeys.Add(Keys.LShiftKey);
            globalKeyboardHook.HookedKeys.Add(Keys.RShiftKey);
            globalKeyboardHook.HookedKeys.Add(Keys.LMenu);
            globalKeyboardHook.HookedKeys.Add(Keys.RMenu);
            globalKeyboardHook.KeyDown += new KeyEventHandler(OnKeyDown);
            globalKeyboardHook.KeyUp += new KeyEventHandler(OnKeyUp);
        }

        //Keep track of our keyboard modifiers
        bool lControl, rControl, lShift, rShift, lAlt, rAlt = false;

        void OnKeyDown(object sender, KeyEventArgs e)
        {

            //Check for modifiers
            if (e.KeyCode == Keys.LControlKey)
            {
                lControl = true;
            }
            else if (e.KeyCode == Keys.RControlKey)
            {
                rControl = true;
            }
            else if (e.KeyCode == Keys.LShiftKey)
            {
                lShift = true;
            }
            else if (e.KeyCode == Keys.RShiftKey)
            {
                rShift = true;
            }
            else if (e.KeyCode == Keys.LMenu)
            {
                lAlt = true;
            }
            else if (e.KeyCode == Keys.RMenu)
            {
                rAlt = true;
            }
            //Check for volume keys
            else if (e.KeyCode == Keys.VolumeUp)
            {
                if (CtrlDown() && !AltDown() && !ShiftDown()) //Ctrl VolUp
                {
                    TryStepApplicationVolume(ProcessHook.GetActiveProcessFileName(), settings.volumeStep);
                    e.Handled = true;
                }
                else if (CtrlDown() && !AltDown() && ShiftDown()) //Ctrl Shift VolUp
                {
                    if (settings.ctrlShiftProgram != "")
                    {
                        TryStepApplicationVolume(settings.ctrlShiftProgram, settings.volumeStep);
                        e.Handled = true;
                    }
                }
                else if (CtrlDown() && AltDown() && !ShiftDown()) //Ctrl Alt VolUp
                {
                    if (settings.ctrlAltProgram != "")
                    {
                        TryStepApplicationVolume(settings.ctrlAltProgram, settings.volumeStep);
                        e.Handled = true;
                    }
                }


            }
            else if (e.KeyCode == Keys.VolumeDown)
            {
                if (CtrlDown() && !AltDown() && !ShiftDown()) //Ctrl VolDown
                {
                    TryStepApplicationVolume(ProcessHook.GetActiveProcessFileName(), -settings.volumeStep);
                    e.Handled = true;
                }
                else if (CtrlDown() && !AltDown() && ShiftDown()) //Ctrl Shift VolDown
                {
                    if (settings.ctrlShiftProgram != "")
                    {
                        TryStepApplicationVolume(settings.ctrlShiftProgram, -settings.volumeStep);
                        e.Handled = true;
                    }
                }
                else if (CtrlDown() && AltDown() && !ShiftDown()) //Ctrl Alt VolDown
                {
                    if (settings.ctrlAltProgram != "")
                    {
                        TryStepApplicationVolume(settings.ctrlAltProgram, -settings.volumeStep);
                        e.Handled = true;
                    }
                }
            }

        }

        void OnKeyUp(object sender, KeyEventArgs e)
        {
            //Check for modifiers
            if (e.KeyCode == Keys.LControlKey)
            {
                lControl = false;
            }
            else if (e.KeyCode == Keys.RControlKey)
            {
                rControl = false;
            }
            else if (e.KeyCode == Keys.LShiftKey)
            {
                lShift = false;
            }
            else if (e.KeyCode == Keys.RShiftKey)
            {
                rShift = false;
            }
            else if (e.KeyCode == Keys.LMenu)
            {
                lAlt = false;
            }
            else if (e.KeyCode == Keys.RMenu)
            {
                rAlt = false;
            }
        }

        bool CtrlDown()
        {
            return lControl || rControl;
        }
        bool AltDown()
        {
            return lAlt || rAlt;
        }
        bool ShiftDown()
        {
            return lShift || rShift;
        }

        private void TryStepApplicationVolume(String configuredIdentifier, float stepAmount)
        {
            //Renew volume cache if it is at least 4 seconds old
            if (Environment.TickCount - ticksRenewedCacheAt > 4000)
            {
                RenewCachedValues();
            }

            //get sessions whose identifier match the given one
            var matchingApps = appVolumeCache.Where(app => app.Identifier.IndexOf(configuredIdentifier, System.StringComparison.CurrentCultureIgnoreCase) >= 0).ToList();

            if (matchingApps.Any())
            {
                float newVolume = matchingApps.First().Volume + stepAmount;
                newVolume = Math.Min(100, newVolume);
                newVolume = Math.Max(0, newVolume);
                //adjust cached volumes to the new volume
                matchingApps.ForEach(app => app.Volume = newVolume);
                //set volume for all matching groups
                matchingApps.Select(app => app.Guid).Distinct().ToList().ForEach(guid =>
                    VolumeHook.SetApplicationVolumeByGroup(guid, newVolume)
                );

                popupForm.ShowSlider((int)newVolume, matchingApps.First().Pid);
            }

        }

        //Renews the application and volume cache
        private void RenewCachedValues()
        {
            appVolumeCache = VolumeHook.getVolumes();
            ticksRenewedCacheAt = Environment.TickCount;
        }

        #region Control Events

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            //Close the program when exit is clicked.
            Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Write config on application exit
            ConfigManager.WriteConfig(settings);
        }

        private void TextBoxCtrlShiftProgram_TextChanged(object sender, EventArgs e)
        {
            RenewCachedValues();
            settings.ctrlShiftProgram = textBoxCtrlShiftProgram.Text;
            ConfigManager.WriteConfig(settings);
        }

        private void TextBoxCtrlAltProgram_TextChanged(object sender, EventArgs e)
        {
            RenewCachedValues();
            settings.ctrlAltProgram = textBoxCtrlAltProgram.Text;
            ConfigManager.WriteConfig(settings);
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
            ConfigManager.WriteConfig(settings);
        }
        private void ComboBoxPopupSide_SelectionChangeCommitted(object sender, EventArgs e)
        {
            settings.popupSide = (PopupSide)comboBoxPopupSide.SelectedItem;
            popupForm.PlaceWindow();
            ConfigManager.WriteConfig(settings);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            settings.volumeStep = (int)numericUpDown1.Value;
            ConfigManager.WriteConfig(settings);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //When the taskbar icon is double clicked, show the form
            Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            this.Focus();
        }

        #endregion

    }

}
