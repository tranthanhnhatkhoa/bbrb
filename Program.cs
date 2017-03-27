using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using SetProxy;
 
namespace BingRewardsBot
{
    static class Program
    {
  
        private const string TORSOCKSPORT = "8118";

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode, SetLastError = true)]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        static extern bool SetDllDirectory(string lpPathName);

        ///
        /// 

        /*
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;

        static void setProxy(string proxyhost, bool proxyEnabled)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, "ProxyServer", proxyhost);
            Registry.SetValue(keyName, "ProxyEnable", proxyEnabled ? "1" : "0");

            // These lines implement the Interface in the beginning of program 
            // They cause the OS to refresh the settings, causing IP to realy update
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
        }
        */

        //http://stackoverflow.com/questions/571706/shortest-way-to-write-a-thread-safe-access-method-to-a-windows-forms-control
        public static void SafeInvoke(this Control control, Action handler)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(handler);
            }
            else
            {
                handler();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            int wsize = IntPtr.Size;
            string libdir = (wsize == 4) ? "x86" : "x64";
            string appPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            SetDllDirectory(System.IO.Path.Combine(appPath, libdir));

            if (BingRewardsBot.Properties.Settings.Default.set_tor == true)
            {
                if (BingRewardsBot.Properties.Settings.Default.set_proxy != "")
                {
                    WinInetInterop.SetConnectionProxy(Properties.Settings.Default.set_proxy.ToString());
                }
                else
                {
                    //setProxy("127.0.0.1:8118", true);
                    WinInetInterop.SetConnectionProxy("localhost:" + TORSOCKSPORT);
                }

            } else if (BingRewardsBot.Properties.Settings.Default.set_proxy != "")
            {
                WinInetInterop.SetConnectionProxy(Properties.Settings.Default.set_proxy.ToString());
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
