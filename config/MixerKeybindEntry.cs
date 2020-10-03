using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyboardMixer.config
{
    public class MixerKeybindEntry
    {
        public Keys[] KeyList { get; set; }
        public string ProcessName { get; set; }

        public override string ToString()
        {
            return FromKeyArray(this.KeyList);
        }

        public static string FromKey(Keys key)
        {
            switch (key)
            {
                case Keys.LControlKey:
                    return "Ctrl";
                case Keys.LShiftKey:
                    return "Shift";
                case Keys.LMenu:
                    return "Alt";
                case Keys.LWin:
                    return "Win";
                case Keys.D1:
                    return "1";
                case Keys.D2:
                    return "2";
                case Keys.D3:
                    return "3";
                case Keys.D4:
                    return "4";
                case Keys.D5:
                    return "5";
                case Keys.D6:
                    return "6";
                case Keys.D7:
                    return "7";
                case Keys.D8:
                    return "8";
                case Keys.D9:
                    return "9";
                case Keys.D0:
                    return "0";
                default:
                    return key.ToString();
            }
        }

        public static string FromKeyArray(Keys[] keys)
        {
            var sortedKeys = keys.ToList()
                .OrderBy(key => {
                        switch (key)
                        {
                            //rank special keys higher, then revert to enum value
                            case Keys.LControlKey:
                                return 0;
                            case Keys.LShiftKey:
                                return 1;
                            case Keys.LMenu:
                                return 2;
                            case Keys.LWin:
                                return 3;
                            default:
                                return (int)key + 1000;
                        }
                    }
                );
            return String.Join("+", sortedKeys.Select(key => FromKey(key))) + "+Vol";
        }
    }
}
