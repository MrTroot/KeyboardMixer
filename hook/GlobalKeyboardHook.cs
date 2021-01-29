using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KeyboardMixer.config;

namespace KeyboardMixer
{
    /// <summary>
    /// A class that manages a global low level keyboard hook
    /// </summary>
    class GlobalKeyboardHook
    {

        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);

        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;

        IntPtr hhook = IntPtr.Zero;
        private keyboardHookProc hookProcDelegate;

        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;

        public GlobalKeyboardHook()
        {
            hookProcDelegate = hookProc;
            hook();
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="GlobalKeyboardHook"/> is reclaimed by garbage collection and uninstalls the keyboard hook.
        /// </summary>
        ~GlobalKeyboardHook()
        {
            unhook();
        }

        #region Public Methods
        /// <summary>
        /// Installs the global hook
        /// </summary>
        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, hookProcDelegate, hInstance, 0);
        }

        /// <summary>
        /// Uninstalls the global hook
        /// </summary>
        public void unhook()
        {
            UnhookWindowsHookEx(hhook);
        }

        private Dictionary<Keys, bool> m_keyTable = new Dictionary<Keys, bool>();
        public Dictionary<Keys, bool> KeyTable
        {
            get { return m_keyTable; }
            private set { m_keyTable = value; }
        }

        public bool IsKeyPressed(Keys k)
        {
            bool pressed = false;
            if (KeyTable.TryGetValue(k, out pressed))
            {
                return pressed;
            }
            return false;
        }

        /// <summary>
        /// The callback for the keyboard hook
        /// </summary>
        /// <param name="code">The hook code, if it isn't >= 0, the function shouldn't do anyting</param>
        /// <param name="wParam">The event type</param>
        /// <param name="lParam">The keyhook event information</param>
        /// <returns></returns>
        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {

            if (code >= 0)
            {
                Keys key = filterModifier((Keys)lParam.vkCode);
                KeyEventArgs keyEventArgs = new KeyEventArgs(key);
                if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                {
                    KeyTable[key] = true;
                    KeyDown(this, keyEventArgs);
                }
                else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                {
                    KeyTable[key] = false;
                    KeyUp(this, keyEventArgs);
                }

                if (keyEventArgs.Handled)
                    return 1;
            }

            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }

        //Turns all right-side key modifers to their left counterpart for easier comparison
        private Keys filterModifier(Keys key)
        {
            switch (key)
            {
                case Keys.RShiftKey:
                    return Keys.LShiftKey;
                case Keys.RControlKey:
                    return Keys.LControlKey;
                case Keys.RMenu:
                    return Keys.LMenu;
                case Keys.RWin:
                    return Keys.LWin;
                default:
                    return key;
            }
        }

        #endregion
    }
}
