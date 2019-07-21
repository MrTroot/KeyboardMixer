using System;

namespace KeyboardMixer
{
    public enum PopupScreen { Primary, Left, Right }
    public enum PopupSide { Left, Right }
    public class SerializableSettings
    {
        public String ctrlShiftProgram;
        public String ctrlAltProgram;
        public int volumeStep;
        public Boolean startMinimized;
        public PopupScreen popupScreen;
        public PopupSide popupSide;

        public static SerializableSettings GetDefaults()
        {
            SerializableSettings settings = new SerializableSettings
            {
                ctrlShiftProgram = "Discord.exe",
                ctrlAltProgram = "firefox.exe",
                volumeStep = 2,
                startMinimized = false,
                popupScreen = PopupScreen.Primary,
                popupSide = PopupSide.Right
            };
            return settings;
        }
    }
}
