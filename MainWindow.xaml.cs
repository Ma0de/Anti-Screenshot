using System;
using System.Windows;
using System.Runtime.InteropServices;

namespace AntiScreenshot
{
    public partial class MainWindow : Window
    {
        private ScreenShotProtect screenProtect = new ScreenShotProtect();

        public MainWindow()
        {
            InitializeComponent();

            // Protect the window when it's loaded
            this.Loaded += MainWindow_Loaded;
            // Unprotect when closing (optional)
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Get the window handle and enable protection
            var windowHandle = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            screenProtect.Protect(windowHandle);
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            // Optional: Disable protection when window closes
            var windowHandle = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            screenProtect.UnProtect(windowHandle);
        }

        public class ScreenShotProtect
        {
            [DllImport("user32.dll")]
            private static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

            public bool HasProtect
            {
                get { return isProtect; }
            }

            private bool isProtect = false;

            public void Protect(IntPtr handle)
            {
                SetWindowDisplayAffinity(handle, 0x11);  // WDA_MONITOR = 0x01 or WDA_EXCLUDEFROMCAPTURE = 0x11
                isProtect = true;
            }

            public void UnProtect(IntPtr handle)
            {
                if (isProtect)
                {
                    SetWindowDisplayAffinity(handle, 0);  // WDA_NONE = 0
                    isProtect = false;
                }
            }
        }
    }
}