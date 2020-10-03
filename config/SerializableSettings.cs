using KeyboardMixer.config;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyboardMixer
{
    public enum PopupScreen { Primary, Left, Right }
    public enum PopupSide { Left, Right }
    public class SerializableSettings
    {
        public List<MixerKeybindEntry> keybinds;
        public int volumeStep;
        public Boolean startMinimized;
        public PopupScreen popupScreen;
        public PopupSide popupSide;

        public static SerializableSettings GetDefaults()
        {
            SerializableSettings settings = new SerializableSettings
            {
                keybinds = new List<MixerKeybindEntry> {
                    new MixerKeybindEntry
                    {
                        KeyList = new Keys[]{Keys.LControlKey, Keys.LShiftKey},
                        ProcessName = "discord.exe"
                    },
                    new MixerKeybindEntry
                    {
                        KeyList = new Keys[]{Keys.LControlKey, Keys.LMenu},
                        ProcessName = "firefox.exe"
                    },
                    new MixerKeybindEntry
                    {
                        KeyList = new Keys[]{Keys.LControlKey, Keys.LWin},
                        ProcessName = "spotify.exe"
                    }
                },
                volumeStep = 2,
                startMinimized = false,
                popupScreen = PopupScreen.Primary,
                popupSide = PopupSide.Right
            };
            return settings;
        }
    }
}
