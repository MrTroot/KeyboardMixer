using KeyboardMixer.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardMixer
{
    public class MixerManager
    {
        //Reference to the main form
        private MainForm mainForm;
        //Application settings
        public SerializableSettings settings;
        //Keyboard hook
        private GlobalKeyboardHook globalKeyboardHook;
        //Keep cache of sessions and their volumes, as calling for them repeatedly creates a lot of overhead
        private List<AppVolume> appVolumeCache;
        private int ticksRenewedCacheAt;
        private bool listeningForKeybind = false;
        public Keys[] detectedNewKeybind;

        public MixerManager(MainForm mainForm)
        {
            this.mainForm = mainForm;

            //Load settings
            settings = ConfigManager.ReadConfig();

            //Init volume app cache
            RenewCachedValues();

            globalKeyboardHook = new GlobalKeyboardHook();

            globalKeyboardHook.KeyDown += new KeyEventHandler(OnKeyDown);
            globalKeyboardHook.KeyUp += new KeyEventHandler(OnKeyUp);
        }

        //Renews the application and volume cache
        public void RenewCachedValues()
        {
            appVolumeCache = VolumeHook.getVolumes();
            ticksRenewedCacheAt = Environment.TickCount;
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (listeningForKeybind)
            {
                //Set key entry as handled
                e.Handled = true;
                //suppress listening for volume keys
                if (e.KeyCode == Keys.VolumeDown || e.KeyCode == Keys.VolumeUp) return;
                //Update currently held keys
                DetectNewKeybind(e);

                return;
            }
            
            //Check for volume keys
            if (e.KeyCode == Keys.VolumeUp || e.KeyCode == Keys.VolumeDown)
            {
                //Process keybinds
                OnVolumePressed(e);
                //If none found, try the current application (Ctrl + Vol)
                if (!e.Handled)
                {
                    if (CtrlDown()) //Ctrl Vol
                    {
                        TryStepApplicationVolume(ProcessHook.GetActiveProcessFileName(), e.KeyCode == Keys.VolumeUp ? settings.volumeStep : -settings.volumeStep);
                        e.Handled = true;
                    }
                }
                
            }
        }

        void OnKeyUp(object sender, KeyEventArgs e)
        {
            
        }

        private void OnVolumePressed(KeyEventArgs e)
        {
            foreach (MixerKeybindEntry keybind in settings.keybinds)
            {
                bool allMatch = true;
                foreach (Keys requiredKey in keybind.KeyList)
                {
                    if (!globalKeyboardHook.IsKeyPressed(requiredKey))
                    {
                        allMatch = false;
                        break;
                    }
                }
                if (allMatch)//Keybind is pressed
                {
                    TryStepApplicationVolume(keybind.ProcessName, e.KeyCode == Keys.VolumeUp ? settings.volumeStep : -settings.volumeStep);
                    e.Handled = true;
                    break;
                }
            }
        }

        public void StartListening()
        {
            listeningForKeybind = true;
            mainForm.resetNewKeybindField();
        }

        public void StopListening()
        {
            listeningForKeybind = false;
        }

        private void DetectNewKeybind(KeyEventArgs e)
        {
            detectedNewKeybind = globalKeyboardHook.KeyTable
                .Where(pair => pair.Value == true)
                .Select(pair => pair.Key)
                .ToArray();
            mainForm.updateNewKeybindField(detectedNewKeybind);
        }

        bool CtrlDown()
        {
            return globalKeyboardHook.IsKeyPressed(Keys.LControlKey) || globalKeyboardHook.IsKeyPressed(Keys.RControlKey);
        }

        private void TryStepApplicationVolume(String configuredIdentifier, float stepAmount)
        {
            if (configuredIdentifier == "") return;

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

                mainForm.popupForm.ShowSlider((int)newVolume, matchingApps.First().Pid);
            }

        }
    }
}
