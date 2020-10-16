using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace KeyboardMixer
{
    public partial class PopupForm : Form
    {
        //Reference to the mixer managger
        private MixerManager mixerManager;

        //Timer to remove the popup after a couple of seconds
        Timer timer = new Timer();
        int counter = 0;

        //Cache the current process when are changing the volume of
        //This way we dont have multiple calls to get the name and icon when the volume is changed
        int currentPID;
        int currentVolume;

        /// From MSDN <see cref="https://docs.microsoft.com/en-us/windows/win32/winmsg/extended-window-styles"/>
        /// A top-level window created with this style does not become the 
        /// foreground window when the user clicks it. The system does not 
        /// bring this window to the foreground when the user minimizes or 
        /// closes the foreground window. The window should not be activated 
        /// through programmatic access or via keyboard navigation by accessible 
        /// technology, such as Narrator. To activate the window, use the 
        /// SetActiveWindow or SetForegroundWindow function. The window does not 
        /// appear on the taskbar by default. To force the window to appear on 
        /// the taskbar, use the WS_EX_APPWINDOW style.
        private const int WS_EX_NOACTIVATE = 0x08000000;

        public PopupForm(MixerManager mixerManager)
        {
            this.mixerManager = mixerManager;
            InitializeComponent();
            PlaceWindow();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;

            timer.Interval = 500;
            timer.Tick += new EventHandler(Timer_Tick);
            
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;

                createParams.ExStyle |= WS_EX_NOACTIVATE;
                return createParams;
            }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                counter++;
                if(counter >= 4) //2 seconds
                {
                    this.Hide();
                }
            }
            else
            {
                counter = 0;
                timer.Stop();
            }
        }

        public void PlaceWindow()
        {
            
            SerializableSettings settings = mixerManager.settings;

            Screen correctScreen = Screen.AllScreens[0];

            //Determine correct screen
            if (settings.popupScreen == PopupScreen.Primary)
            {
                correctScreen = Screen.PrimaryScreen;
            }
            else if(settings.popupScreen == PopupScreen.Left)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Left < correctScreen.WorkingArea.Left)
                        correctScreen = screen;
                }
            }
            else if (settings.popupScreen == PopupScreen.Right)
            {
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.WorkingArea.Right > correctScreen.WorkingArea.Right)
                        correctScreen = screen;
                }
            }

            //Place in correct location
            if (settings.popupSide == PopupSide.Left)
            {
                this.Left = correctScreen.WorkingArea.Left;
                this.Top = correctScreen.WorkingArea.Bottom - this.Height;
            }
            else if (settings.popupSide == PopupSide.Right)
            {
                this.Left = correctScreen.WorkingArea.Right - 76; //width hardcoded since this.Width was wrong sometimes?
                this.Top = correctScreen.WorkingArea.Bottom - this.Height;
            }
            
        }

        private void PopupForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                timer.Start();
            }
        }

        private void ResetTimer()
        {
            counter = 0;
            timer.Stop();
            timer.Start();
        }

        public void ShowSlider(int volume, int pid)
        {
            //only update icon and name if it has changed
            if(this.currentPID != pid)
            {
                this.currentPID = pid;

                Bitmap icon = ProcessHook.GetIconByPID(pid).ToBitmap();
                pictureBox.Image = icon;

                this.labelAppName.Text = FirstLetterToUpper(ProcessHook.GetProcessNameByPID(pid));
            }

            //this.volumeSlider.Value = volume;
            this.currentVolume = volume;

            if (!this.Visible)
            {
                this.Show();
            }
            ResetTimer();

            labelBoxSlider.Invalidate();

        }

        public static string FirstLetterToUpper(String str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }

        private void labelBoxSlider_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush brushWhite = new System.Drawing.SolidBrush(Color.White);
            SolidBrush brushBlue = new System.Drawing.SolidBrush(Color.FromArgb(0, 118, 215));
            

            float yScaled = 1 - (currentVolume / 100F);
            yScaled *= labelBoxSlider.Height;
            int yPos = Math.Min(labelBoxSlider.Height - labelBoxSlider.Width, (int)yScaled);

            Rectangle rectWhite = new Rectangle(0, yPos, labelBoxSlider.Width, labelBoxSlider.Width);
            Rectangle rectBlue = new Rectangle(0, yPos, labelBoxSlider.Width, labelBoxSlider.Height - yPos);

            e.Graphics.FillRectangle(brushBlue, rectBlue);
            e.Graphics.FillRectangle(brushWhite, rectWhite);


            brushWhite.Dispose();
            brushBlue.Dispose();
        }
    }

    
}
