﻿/*************************************************************** 
 * Copyright notice 
 * 
 * (c) 2015-2016 Chi Hoang (rebrobates@gmail.com) 
 *  All rights reserved 
 * 
 ***************************************************************/
#define DEBUG

using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using IP2Location;
using System.Data.SQLite;
//using HtmlAgilityPack;
using mshtml;
using SetProxy;
using Microsoft.Win32;
using System.Diagnostics;
using System.Timers;
//using System.Net.Mail;
using System.Configuration;
using ConfigurationSettings = System.Configuration.ConfigurationManager;

namespace BingRewardsBot
{
    public partial class Form1 : Form
    {
        private BetterControl.RangeSlider rs1;
        private BetterControl.RangeSlider rs2;
        private BetterControl.RangeSlider rs3;
        private BetterControl.RangeSlider rs4;
        IntPtr pControl;
        //IntPtr pControl2;
        mshtml.IHTMLDocument2 htmlDoc;
        HtmlElement documentElement;
        const string VERSION = "28.04.2017";
        const string ASSEMBLY = "37";
        const int POLL_DELAY = 300;
        private static bool toriddone = false;
        private const string TORSOCKSPORT = "8118";
        private const int TORCONTROLPORT = 9050;
        //private const string TORSOCKSPORT = "8118";
        private const string TORSERVER = "127.0.0.1";
        private int dxloops = 0;
        private int mxloops = 0;
        private const int MAXLOOPS = 2;
        private string clicklink = "";
        private bool clicklist = false;
        private string clickref = "";
        private string siguid = "";
        private bool dashboardta = false;
        private bool ldashboardta = false;
        private int dashboardtaalt = 0;
        private int numdashboardta = 0;
        private bool iniSearch = false;
        private System.Timers.Timer timer_dashboardta;
        //private string altUrl = "";
        //public System.Windows.Forms.WebBrowser loaded;
        private System.Globalization.CultureInfo culture;

        //https://login.live.com/ppsecure/post.srf?wa=wsignin1.0&rpsnv=13&ct=1476457420&rver=6.7.6636.0&wp=MBI_SSL&wreply=https:%2f%2faccount.microsoft.com%2fauth%2fcomplete-signin%3fru%3dhttps%253a%252f%252faccount.microsoft.com%252frewards%252fdashboard%253frefd%253dwww.bing.com&id=292666&lw=1&fl=easi2&pcexp=true&lc=1033&contextid=2E5B88D95E5844C8&bk=1492510428&uaid=111f70fcb93e4d64a0e9d584fe08070b&pid=0
        //https://account.microsoft.com/rewards/dashboard?refd=www.bing.com->https://account.microsoft.com/?lang=en-US
        //https://account.microsoft.com/account/Account?refd=login.live.com&destrt=home-index
        //https://account.microsoft.com/languages
        //https://account.microsoft.com/?lang=en-US
        //https://account.live.com/tou/accrue?ru=https://login.live.com/login.srf%3flc%3d1033%26sf%3d1%26id%3d292666%26tw%3d18000%26fs%3d0%26ts%3d-14400%26sec%3d%26mspp_shared%3d1%26seclog%3d10%26claims%3d%26wa%3dwsignin1.0%26wp%3dMBI_SSL%26lw%3d1%26fl%3deasi2%26ru%3dhttps://account.microsoft.com/auth/complete-signin%253fru%253dhttps%25253a%25252f%25252faccount.microsoft.com%25252frewards%25252fdashboard%25253frefd%25253dwww.bing.com%26contextid%3dFECFCA9008397185&mkt=EN-US&uiflavor=web&id=292666&uaid=ed4f2a6ee2e4451d8d8ed1d19b3df590
        //edge:Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.246
        //https://login.live.com/ppsecure/post.srf?bk=1457379059&uaid=14f83b3f66814e63bd793486717f5dc0&pid=0
        //https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing
        //https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1456257304&rver=6.5.6510.0&wp=SAPI&wreply=https:%2F%2Faccount.live.com%2F%3Fmkt%3DEN-US%26lc%3D1033%26id%3D38936&lc=1033&id=38936&mkt=en-US&uaid=
        //https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1456042569&rver=6.5.6510.0&wp=SAPI&wreply=https:%2F%2Faccount.live.com%2F%3Fmkt%3DEN-US%26lc%3D1033%26id%3D38936&lc=1033&id=38936&mkt=en-US&uaid=
        //https://login.live.com/ppsecure/post.srf?bk=
        ///news?q=us+news&amp;FORM=ML11Z9&amp;CREA=ML11Z9&amp;rnoreward=1" id="srch1-2-15-NOT_T1T3_Control-Exist" class="tile rel blk tile-height" target="_blank" h="ID=rewards,5027.1
        ///explore/rewards-mobile?FORM=ML10NS&amp;CREA=ML10NS&amp;rnoreward=1" id="mobsrch1-2-10-NOT_T1T3_Control-Exist" class="tile rel blk tile-height" target="_blank" h="ID=rewards,5028.1
        //https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us&FORM=W5WA&uid=FC9008F2&sid=
        //https://www.bing.com/account/general
        //https://www.bing.com/
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https%3a%2f%2fwww.bing.com%2f%3fwlsso%3d1%26wlexpsignin%3d1&src=EXPLICIT&sig=
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https%3a%2f%2fwww.bing.com%2frewards%2fsignin%3fFORM%3dMI0GMI%26PUBL%3dMUIDTrial%26CREA%3dMI0GMI%26wlsso%3d1%26wlexpsignin%3d1&src=EXPLICIT&sig=

        //https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=12&ct=1457790406&rver=6.7.6631.0&wp=MBI&wreply=https:%2f%2fwww.bing.com%2fsecure%2fPassport.aspx%3frequrl%3dhttps%253a%252f%252fwww.bing.com%252frewards%252fdashboard&lc=1033&id=264960
        //https://account.live.com/identity/confirm?ru=https://login.live.com/login.srf%3flc%3d1033%26sf%3d1%26id%3d38936%26ru%3dhttps://account.live.com%253fmkt%253dEN-US%2526lc%253d1033%2526id%253d38936%26tw%3d20%26fs%3d0%26ts%3d0%26sec%3d%26mspp_share
        //https://login.live.com/login.srf?wa=wsignin1.0&amp;rpsnv=12&amp;ct=1451077233&amp;rver=6.5.6509.0&amp;wp=MBI_SSL&amp;wreply=https:%2F%2Faccount.microsoft.com%2Fauth%2Fcomplete-signin%3Fru%3Dhttps%253a%252f%252faccount.microsoft.com%252f%253frefd%253dlogin.live.com&amp;lc=1033&amp;id=292666"
        //private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https%3a%2f%2fwww.bing.com%2frewards%2fdashboard%3fwlexpsignin%3d1&src=EXPLICIT&sig=";
        ///fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&sig=05116B5A81F46BD83CAA63D280186ADD&return_url=https://www.bing.com\rewards\dashboard&Token=1
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&sig=27BCFAE69AA86D76381CF26E9B2F6CB6&return_url=https%3a%2f%2fwww.bing.com%3a443%2frewards%2fsignin%3fFORM%3dMI0GMI%26PUBL%3dMUIDTrial%26CREA%3dMI0GMI&Token=1
        //private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com&Token=1&sig=";
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&sig=217B4DD1E3E46AEB169A4558E2086B86&return_url=https%3a%2f%2fwww.bing.com%3a443%2frewards%2fdashboard&Token=1
        //1A3B48739046-4833-982A-65FAE59682B8,'ClientId': '1A3B4873-9046-4833-982A-65FAE59682B8',
        private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com/rewards/dashboard&Token=1&sig=";
        //private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https://www.bing.com/rewards/signin?FORM=MI0GMI&PUBL=MUIDTrial&CREA=MI0GMI&wlsso=1&wlexpsignin=1&src=EXPLICIT&sig=";
        //private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com&Token=1&sig=";
        private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https://www.bing.com/?wlsso=1%26wlexpsignin=1%26src=EXPLICIT&sig=";
        private const string BRI18NUS = "https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us&FORM=W5WA&uid=FC9008F2&sid=";
        private const string BRI18NIN = "https://bing.com/account/action?scope=web&setmkt=en-IN&setplang=en-in&setlang=en-in&FORM=W5WA&uid=8AF0AD82&sid=";
        private const string BRSOUT = "https://login.live.com/logout.srf?ct=1476458234&rver=6.7.6636.0&lc=1033&id=292666&ru=https:%2F%2Faccount.microsoft.com%2Fauth%2Fcomplete-signout%3Fru%3Dhttps%253a%252f%252faccount.microsoft.com%252frewards%252fdashboard&uictx=me&flowtoken=";
        private const string BRSIN2 = "https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1476457420&rver=6.7.6636.0&wp=MBI_SSL&wreply=https:%2f%2faccount.microsoft.com%2fauth%2fcomplete-signin%3fru%3dhttps%253a%252f%252faccount.microsoft.com%252frewards%252fdashboard%253frefd%253dwww.bing.com&id=292666&lw=1&fl=easi2&pcexp=true&lc=1033";
        //https://login.live.com/login.srf?wa=wsignin1.0&rpsnv=13&ct=1492340664&rver=6.7.6643.0&wp=MBI_SSL&wreply=https:%2f%2faccount.microsoft.com%2fauth%2fcomplete-signin%3fru%3dhttps%253a%252f%252faccount.microsoft.com%252f%253frefd%253daccount.microsoft.com%2526refp%253dhome-about-index&lc=1031&id=292666&lw=1&fl=easi2
        //http://bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us&FORM=W5WA&uid=62F05741&sid=1AFD3E6DD50B61FA0F973796D4CB60B8

        private long pccounter = 0;
        private int WDCounter = 0;
        private string[] rlink = new string[40];
        private const string MAXACCOUNTSPERIPLIMIT = "Not a valid IP. Maximum number of accounts per IP limit reached!";

        private int startbtn = 0;
        private const int MSPOINTS = 250;
        private string country = "";
        private string ip = "";
        private const int TORTRIES = 10;
        private int prevpts = 0;
        private int pts = 0;
        //private const string APPLEMOBILEUA = "User-Agent: Mozilla/5.0 (iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3";
        private const string APPLEMOBILEUA = "Mozilla / 5.0(iPhone; CPU iPhone OS 6_1_4 like Mac OS X) AppleWebKit/536.26 (KHTML, like Gecko) Version/6.0 Mobile/10B350 Safari/8536.25";
        private const string CHROMEDESKTOPUA = "Mozilla / 5.0(Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.93 Safari/537.36";
        private const string IEDESKTOPUA = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; Win64; x64; Trident/8.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; GWX:QUALIFIED)";
        private const string IE11UA = "Mozilla/5.0 (Windows NT 6.4; WOW64; Trident/7.0; .NET4.0E; .NET4.0C; rv:11.0) like Gecko";
        //private const string EDGEUA = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/0000.0.2311.135 Safari/537.36 Edge/12.10240";
        //Browser Agent to "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10136"
        private const string EDGEUA = "Mozilla/5.0 (Windows NT 10.0) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10136";
        private bool Csearch = false;
        private int qpage = 0;
        private const int SLEEPTOR = 8 * 1000;
        private const int SLEEPPTS = 4 * 1000;
        private const int SLEEPDP = 12 * 1000;
        private const int SLEEPDASHBOARD = 18 * 1000;
        private const int SLEEPMAIN = 5 * 1000;
        private const int WATCHDOG = 11;
        private const int AUTHSHORT = 24 * 1000;
        private int vrndnum = 0;
        private int accountVisitedX = 0;
        private List<bool> accountVisited;
        private const string TRIALOVER = "Too bad the trial period is over. If my program is helpful please consider to donate!";
        private const string TITLE = "Better Bing Rewards Bot";
        private const string MYIP = "My IP address: ";
        private bool trialstopped = false;
        private bool checkaccount = false;
        private string trialRegKey;
        private const int FREEX = 9999999; //15500000;  //25500000
        private const int FREEA = 3;
        private const int DIVIDE = 50;
        private int trialCountUp = 0;
        private int trialCountDownReg = -1;
        private string query;
        private int timer_auth;
        private System.Timers.Timer timer_searches;
        private System.Timers.Timer timer_tor;
        private int countDownDesktop;
        private int countDownMobile;
        private int counterMx;
        private int counterDx;
        private bool authLock = false;
        private string username;
        private string password;
        private int accountNum = -1;
        private string accountsFile;
        private string wordsFile;
        private const bool SUPPORTER = false;
        private List<string> accounts = new List<string>();
        private List<string> words = new List<string>();
        Thread mainThread;
        const UInt32 WM_KEYDOWN = 0x0100;
        const int WM_CHAR = 0x0102;

        //http://codecentrix.blogspot.fr/2008/02/when-ihtmlwindow2document-throws.html
        // This is the COM IServiceProvider interface, not System.IServiceProvider .Net interface!
        [ComImport(), ComVisible(true), Guid("6D5140C1-7436-11CE-8034-00AA006009FA"),
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryService(ref Guid guidService, ref Guid riid, [MarshalAs(UnmanagedType.Interface)] out object ppvObject);
        }

        //http://stackoverflow.com/questions/10280000/how-to-create-lparam-of-sendmessage-wm-keydown
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern uint MapVirtualKey(uint uCode, uint uMapType);

        //http://stackoverflow.com/questions/904478/how-to-fix-the-memory-leak-in-ie-webbrowser-control
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();

        //http://stackoverflow.com/questions/9770522/how-to-handle-message-boxes-while-using-webbrowser-in-c
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        //http://stackoverflow.com/questions/820909/get-applications-window-handles
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        //http://mdb-blog.blogspot.fr/2013/02/c-winforms-webbrowser-clear-all-cookies.html
        [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public static extern bool InternetSetOption(int hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);

        //http://stackoverflow.com/questions/937573/changing-the-user-agent-of-the-webbrowser-control
        [DllImport("urlmon.dll", CharSet = CharSet.Ansi)]
        private static extern int UrlMkSetSessionOption(int dwOption, string pBuffer, int dwBufferLength, int dwReserved);

        const int URLMON_OPTION_USERAGENT = 0x10000001;
        const int URLMON_OPTION_USERAGENT_REFRESH = 0x10000002;

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        // http://stackoverflow.com/questions/11402643/sendkey-send-not-working
        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        //http://stackoverflow.com/questions/2738982/how-can-i-tell-if-a-given-hwnd-is-still-valid
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindow(IntPtr hWnd);

        public static void PressKey(Keys key, bool up)
        {
            const int KEYEVENTF_EXTENDEDKEY = 0x1;
            const int KEYEVENTF_KEYUP = 0x2;
            if (up)
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
            }
            else
            {
                keybd_event((byte)key, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
            }
        }

        //Als externe Methode deklarieren...
        [DllImport("User32.dll")]
        static extern long SetForegroundWindow(int hwnd);

        //http://www.nullskull.com/q/10387873/clear-temporary-internet-files-via-c-winforms.aspx
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 0;
        public struct Struct_INTERNET_PROXY_INFO
        {
            public int dwAccessType;
            public IntPtr proxy;
            public IntPtr proxyBypass;
        };

        //http://stackoverflow.com/questions/3047375/simulating-key-press-c-sharp
        [DllImport("user32.dll")]
        static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);


        // http://stackoverflow.com/questions/14844392/how-do-you-upgrade-all-settings-in-user-config-when-the-version-number-changes
        private static void copyLastUserConfig(Version currentVersion)
        {
            try
            {
                string userConfigFileName = "user.config";

                // Expected location of the current user config
                DirectoryInfo currentVersionConfigFileDir = new FileInfo(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath).Directory;
                if (currentVersionConfigFileDir == null)
                {
                    return;
                }

                // Location of the previous user config

                // grab the most recent folder from the list of user's settings folders, prior to the current version
                var previousSettingsDir = (from dir in currentVersionConfigFileDir.Parent.GetDirectories()
                                           let dirVer = new { Dir = dir, Ver = new Version(dir.Name) }
                                           where dirVer.Ver < currentVersion
                                           orderby dirVer.Ver descending
                                           select dir).FirstOrDefault();

                if (previousSettingsDir == null)
                {
                    // none found, nothing to do - first time app has run, let it build a new one
                    return;
                }

                string previousVersionConfigFile = string.Concat(previousSettingsDir.FullName, @"\", userConfigFileName);
                Console.WriteLine(previousVersionConfigFile);

                string currentVersionConfigFile = string.Concat(currentVersionConfigFileDir.FullName, @"\", userConfigFileName);
                Console.WriteLine(currentVersionConfigFile);

                if (!currentVersionConfigFileDir.Exists)
                {
                    Directory.CreateDirectory(currentVersionConfigFileDir.FullName);
                }

                File.Copy(previousVersionConfigFile, currentVersionConfigFile, true);

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to upgrade your user specific settings for the new version. The program will continue to run, however user preferences such as screen sizes, locations etc will need to be reset.", ex);
            }
        }

        // static constructor, runs first
        static Form1()
        {
            SetWebBrowserFeatures();
        }

        //***********************
        // Constructor
        //***********************
        public Form1()
        {            
            InitializeComponent();

            this.culture = System.Globalization.CultureInfo.CurrentCulture;
            Console.WriteLine(culture);
            
            log.Columns.Add("", 640);
            log.View = View.Details;
            log.GridLines = true;
            log.FullRowSelect = true;

            //DoLogin();

            this.ResizeColumnHeaders();

            //http://stackoverflow.com/questions/2921483/windows-forms-event-on-select-tab
            updatetab.SelectedIndexChanged += new EventHandler(this.log_Enter);

            // http://stackoverflow.com/questions/10441604/event-called-after-windows-maximized
            this.SizeChanged += new EventHandler(Form1_SizeChanged);
            FormMaximized += new EventHandler(Form1_FormMaximized);

            _CurrentWindowState = this.WindowState;
            if (_CurrentWindowState == FormWindowState.Maximized)
            {
                FireFormMaximized();
            }

            //http://stackoverflow.com/questions/204804/disable-image-loading-from-webbrowser-control-before-the-documentcompleted-event
            //RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            //RegKey.SetValue("Display Inline Images", "no");

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            RegKey.SetValue("Play_Animations", "no");

            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.ProgressChanged += new WebBrowserProgressChangedEventHandler(browser_ProgressChanged);

            browser.ScriptErrorsSuppressed = true;

            // stackoverflow.com/questions/14844392/how-do-you-upgrade-all-settings-in-user-config-when-the-version-number-changes
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version currentVersion = assembly.GetName().Version;
            Console.WriteLine(currentVersion.ToString());

            //if (Properties.Settings.Default.ApplicationVersion != null && version.ToString() != Properties.Settings.Default.ApplicationVersion)
            //{
            //    copyLastUserConfig(version);
            //}

            try
            {
                string userConfigFileName = "user.config";

                // Expected location of the current user config
                DirectoryInfo currentVersionConfigFileDir = new FileInfo(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal).FilePath).Directory;
                if (currentVersionConfigFileDir != null && !currentVersionConfigFileDir.Exists)
                {
                    // Location of the previous user config
                    // grab the most recent folder from the list of user's settings folders, prior to the current version
                    var previousSettingsDir = (from dir in currentVersionConfigFileDir.Parent.GetDirectories()
                                               let dirVer = new { Dir = dir, Ver = new Version(dir.Name) }
                                               where dirVer.Ver < currentVersion
                                               orderby dirVer.Ver descending
                                               select dir).FirstOrDefault();

                    string previousVersion = previousSettingsDir.ToString();

                    if (previousVersion != currentVersion.ToString())
                    {
                        Properties.Settings.Default.Upgrade();
                        Properties.Settings.Default.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while trying to upgrade your user specific settings for the new version. The program will continue to run, however user preferences such as screen sizes, locations etc will need to be reset.", ex);
            }

            //Trial
            if (Application.UserAppDataRegistry.GetValue("ConnXY") == null)
            {
                try
                {
                    Application.UserAppDataRegistry.SetValue("ConnXY", FREEX);
                }
                catch
                {
                    MessageBox.Show("Registry error!");
                    Application.Exit();
                }

                this.trialCountDownReg = FREEX;
            }
            else
            {
                this.trialCountDownReg = Convert.ToInt32(Application.UserAppDataRegistry.GetValue("ConnXY"));
                //copyLastUserConfig(version);

                // http://stackoverflow.com/questions/534261/how-do-you-keep-user-config-settings-across-different-assembly-versions-in-net?noredirect=1&lq=1
                //Properties.Settings.Default.Upgrade();
                //Properties.Settings.Default.Save();
            }
            
            if (this.trialCountDownReg > (FREEX * DIVIDE) && SUPPORTER == false)
            {
                this.trialstopped = true;
                MessageBox.Show(TRIALOVER);
                Application.Exit();
            }

            if (SUPPORTER == true)
            {
                this.Text = TITLE + " Version: Beta " + ASSEMBLY;
            }
            else
            {
                double z = (double)100 / FREEX * (this.trialCountDownReg - (this.trialCountUp * DIVIDE));
                this.Text = TITLE + " : " + Math.Round(z) + "% Shareware" + " Version: Beta " + ASSEMBLY; 
            }

            //RegKey
            if (Application.UserAppDataRegistry.GetValue("RegKey") != null)
            {
                this.regcode_txtbox.Text = this.trialRegKey = Convert.ToString(Application.UserAppDataRegistry.GetValue("RegKey"));
            }
            else
            {
                //http://stackoverflow.com/questions/134021/how-can-i-generate-random-alphanumeric-strings-in-c
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random(Guid.NewGuid().GetHashCode());
                var password = new string(
                    Enumerable.Repeat(chars, 40)
                                .Select(s => s[random.Next(s.Length)])
                                .ToArray());

                var salt = System.Text.Encoding.UTF8.GetBytes("vWhK3DZ8rsPydwZA177Q");
                var hmacSHA1 = new HMACSHA1(salt);
                this.regcode_txtbox.Text = this.trialRegKey = Convert.ToBase64String(hmacSHA1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }

            // Text files
            this.wordsFile = Application.StartupPath + Path.DirectorySeparatorChar + "words.txt";
            this.accountsFile = Application.StartupPath +
                Path.DirectorySeparatorChar + this.txtbox_customaccounts.Text;

            if (!File.Exists(this.accountsFile))
            {
                MessageBox.Show("File not found: " + this.accountsFile + "!");
                Application.Exit();
            }
            if (!File.Exists(wordsFile))
            {
                MessageBox.Show("File not found: " + this.wordsFile + "!");
                Application.Exit();
            }

            ReadFile(this.accountsFile, this.accounts, FREEA);
            ReadFile(this.wordsFile, this.words);

            this.accountNrTxtBox.Text = "1/" + this.accounts.Count;

            this.accountVisited = new List<bool>(this.accounts.Count());
            for (int i = 0, e = this.accounts.Count; i < e; i++)
            {
                this.accountVisited.Add(false);
            }

            string[] authstr = this.accounts[0].Split('/');
            this.accountNameTxtBox.Text = authstr[0];

            //http://stackoverflow.com/questions/5053501/put-wpf-control-into-a-windows-forms-form
            //http://stackoverflow.com/questions/14170165/how-can-i-add-this-wpf-control-into-my-winform

            rs1 = new BetterControl.RangeSlider();
            //rs1.LowerValue = 30;
            //rs1.UpperValue = 90;
            rs1.InitializeComponent();
            rs1.Minimum = 0;
            rs1.Maximum = 100;            
            this.elementHost1.Child = rs1;

            rs2 = new BetterControl.RangeSlider();
            rs2.InitializeComponent();
            rs2.Minimum = 1;
            rs2.Maximum = 100;            
            this.elementHost2.Child = rs2;           

            rs3 = new BetterControl.RangeSlider();
            rs3.InitializeComponent();
            rs3.Minimum = 1;
            rs3.Maximum = 100;            
            this.elementHost3.Child = rs3;

            rs4 = new BetterControl.RangeSlider();
            rs4.InitializeComponent();
            rs4.Minimum = 1;
            rs4.Maximum = 100;            
            this.elementHost4.Child = rs4;

            this.chkbox_as.Checked = BingRewardsBot.Properties.Settings.Default.set_chkbox_as == true ? true : false;
            this.chkbox_tor.Checked = BingRewardsBot.Properties.Settings.Default.set_tor == true ? true : false;
            this.chkbox_mobile.Checked = BingRewardsBot.Properties.Settings.Default.set_mobile == true ? true : false;
            this.chkbox_desktop.Checked = BingRewardsBot.Properties.Settings.Default.set_desktop == true ? true : false;
            this.chkbox_autorotate.Checked = BingRewardsBot.Properties.Settings.Default.set_autorotate == true ? true : false;

            string value = this.txtbox_counter.Text = BingRewardsBot.Properties.Settings.Default.set_counter;
            string[] arr = value.Split('-');
            rs1.LowerValue = Convert.ToDouble(arr[0]);
            rs1.UpperValue = Convert.ToDouble(arr[1]);

            value = this.txtbox_waitsearches.Text = BingRewardsBot.Properties.Settings.Default.set_waitsearches;
            arr = value.Split('-');
            rs2.LowerValue = Convert.ToDouble(arr[0]);
            rs2.UpperValue = Convert.ToDouble(arr[1]);
            
            value = this.txtbox_waitauth.Text = BingRewardsBot.Properties.Settings.Default.set_waitauth;
            arr = value.Split('-');
            rs3.LowerValue = Convert.ToDouble(arr[0]);
            rs3.UpperValue = Convert.ToDouble(arr[1]);

            //this.txtbox_autostart.Text = BingRewardsBot.Properties.Settings.Default.set_autostart;
            value = this.txtbox_autostart.Text = BingRewardsBot.Properties.Settings.Default.set_autostart.ToString();
            arr = value.Split('-');
            rs4.LowerValue = Convert.ToDouble(arr[0]);
            rs4.UpperValue = Convert.ToDouble(arr[1]);

            this.txtboxcustomdesktop.Text = BingRewardsBot.Properties.Settings.Default.set_uadesktop;
            this.txtboxcustommobile.Text = BingRewardsBot.Properties.Settings.Default.set_uamobile;
            this.txtbox_customaccounts.Text = BingRewardsBot.Properties.Settings.Default.set_accounts;
            this.txtbox_proxy.Text = BingRewardsBot.Properties.Settings.Default.set_proxy;
            this.txtbox_torsettings.Text = BingRewardsBot.Properties.Settings.Default.set_torsettings;
            this.listBox1.SelectedIndex = BingRewardsBot.Properties.Settings.Default.set_lang;
            this.randomo.Checked = BingRewardsBot.Properties.Settings.Default.set_randomo == true ? true : false;
            this.chkbox_ns.Checked = BingRewardsBot.Properties.Settings.Default.set_ns == true ? true : false;

            rs1.OnLowerSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs1_OnLowerSlider_ValueChanged);
            rs1.OnUpperSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs1_OnUpperSlider_ValueChanged);

            rs2.OnLowerSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs2_OnLowerSlider_ValueChanged);
            rs2.OnUpperSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs2_OnUpperSlider_ValueChanged);

            rs3.OnLowerSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs3_OnLowerSlider_ValueChanged);
            rs3.OnUpperSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs3_OnUpperSlider_ValueChanged);

            rs4.OnLowerSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs4_OnLowerSlider_ValueChanged);
            rs4.OnUpperSlider_ValueChanged += new BetterControl.RangeSlider.MyControlEventHandler(rs4_OnUpperSlider_ValueChanged);
            
            // Get IP
            this.subgetip();

            //DownloadAsync("https://tetramatrix.github.io/bbrb/").ContinueWith(
            //         (task) => this.statusDebug("Start:"),
            //            TaskScheduler.FromCurrentSynchronizationContext());

            browser.Navigate(new Uri("https://tetramatrix.github.io/bbrb/"));
            
            // Database exists?  
            if (!File.Exists(Application.StartupPath + Path.DirectorySeparatorChar + "points.sqlite"))
            {
                SQLiteConnection.CreateFile("points.sqlite");
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE searches (uid INTEGER PRIMARY KEY, date VARCHAR(20), ip VARCHAR(20),account VARCHAR(20),points INT)",
                    dbcon);
                command.ExecuteNonQuery();
                dbcon.Close();

            }
            else
            {
                // clean database
                try
                {
                    SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                    dbcon.Open();
                    DateTime dateTime = DateTime.UtcNow.Date;
                    SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip,date desc",
                        dbcon);
                    SQLiteDataReader reader = command.ExecuteReader();

                    int c = 0;
                    string curr = "";
                    int[] free = new int[40 * FREEA];

                    while (reader.Read())
                    {
                        if (curr == Convert.ToString(reader["ip"]) && c < FREEA)
                        {
                            free[c++] = Convert.ToInt32(reader["uid"]);
                        }
                        else if (curr == Convert.ToString(reader["ip"]) && c > (FREEA - 1))
                        {
                            free[c++] = Convert.ToInt32(reader["uid"]);
                        }
                        else if (c > (FREEA - 1))
                        {
                            for (int i = 0, e = (c - FREEA); i < e; i++)
                            {
                                command = new SQLiteCommand("delete from searches where uid=" + free[i], dbcon);
                                command.ExecuteNonQuery();
                            }
                            curr = Convert.ToString(reader["ip"]);
                            c = 0;
                        }
                        else
                        {
                            curr = Convert.ToString(reader["ip"]);
                            c = 0;
                        }
                    }
                    dbcon.Close();

                    // delete 
                    dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                    dbcon.Open();
                    command = new SQLiteCommand("delete from searches where account <> '' and (points=0 or points>350) and points<>4242;",
                        dbcon);
                    command.ExecuteNonQuery();
                    dbcon.Close();

                    // new us ip?
                    this.newUsIp();

                }
                catch
                {
                    try
                    {
                        System.IO.File.Delete(Application.StartupPath + Path.DirectorySeparatorChar + "points.sqlite");
                    }
                    catch { }
                    
                    try
                    {
                        SQLiteConnection.CreateFile("points.sqlite");
                        SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        dbcon.Open();
                        SQLiteCommand command = new SQLiteCommand("CREATE TABLE searches (uid INTEGER PRIMARY KEY, date VARCHAR(20), ip VARCHAR(20),account VARCHAR(20),points INT)",
                            dbcon);
                        command.ExecuteNonQuery();
                        dbcon.Close();
                    }
                    catch { }
                }
            }

            // Init main thread
            mainThread = new Thread(new ThreadStart(mainT));
            mainThread.IsBackground = true;
            mainThread.Start();

            // Autostart
            if (chkbox_as.Checked == true)
            {
                try
                {
                    string autostart = this.txtbox_autostart.Text = BingRewardsBot.Properties.Settings.Default.set_autostart.ToString();
                    string[] check = autostart.Split('-');

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;
                    this.checkaccount = false;

                    int z = randAuthTimer(Convert.ToInt32(check[0]), Convert.ToInt32(check[1]));
                    this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                    counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.";

                    this.authLock = false;
                    statusTxtBox.Text = "Autostart";
                    this.button1.Text = "Auto";
                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";
                }
                catch
                {
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;
                    this.authLock = false;
                }
            }
            else
            {
                statusTxtBox.Text = "Stop";
                counterTxtBox.Text = "0/0";
                this.dxloops = 0;
                this.mxloops = 0;
                this.vrndnum = 0;
                this.authLock = false;
            }
        }

        void rs1_OnLowerSlider_ValueChanged(object sender, double result)
        {
            txtbox_counter.Text = Convert.ToString(Math.Round(result)+"-" + Math.Round(this.rs1.UpperValue));
            //MessageBox.Show("L"+result.ToString());
        }

        void rs1_OnUpperSlider_ValueChanged(object sender, double result)
        {
            txtbox_counter.Text = Convert.ToString(Math.Round(this.rs1.LowerValue) + "-" + Math.Round(result));
            //MessageBox.Show("U" + result.ToString());
        }

        void rs2_OnLowerSlider_ValueChanged(object sender, double result)
        {
            txtbox_waitsearches.Text = Convert.ToString(Math.Round(result) + "-" + Math.Round(this.rs2.UpperValue));
        }

        void rs2_OnUpperSlider_ValueChanged(object sender, double result)
        {
            txtbox_waitsearches.Text = Convert.ToString(Math.Round(this.rs2.LowerValue) + "-" + Math.Round(result));
        }
        void rs3_OnLowerSlider_ValueChanged(object sender, double result)
        {
            this.txtbox_waitauth.Text = Convert.ToString(Math.Round(result) + "-" + Math.Round(this.rs3.UpperValue));
        }

        void rs3_OnUpperSlider_ValueChanged(object sender, double result)
        {
            this.txtbox_waitauth.Text = Convert.ToString(Math.Round(this.rs3.LowerValue) + "-" + Math.Round(result));
        }

        void rs4_OnLowerSlider_ValueChanged(object sender, double result)
        {
            txtbox_autostart.Text = Convert.ToString(Math.Round(result) + "-" + Math.Round(this.rs4.UpperValue));
        }

        void rs4_OnUpperSlider_ValueChanged(object sender, double result)
        {
            txtbox_autostart.Text = Convert.ToString(Math.Round(this.rs4.LowerValue) + "-" + Math.Round(result));
        }
        
        // http://stackoverflow.com/questions/18333459/c-sharp-webbrowser-ajax-call
        // set WebBrowser features, more info: http://stackoverflow.com/a/18333982/1768303
        static void SetWebBrowserFeatures()
        {
            // don't change the registry if running in-proc inside Visual Studio
            //if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
            //    return;

            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\";

            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, GetBrowserEmulationMode(), RegistryValueKind.DWord);

            // enable the features which are "On" for the full Internet Explorer browser

            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS",
                appName, 1, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_AJAX_CONNECTIONEVENTS",
                appName, 1, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_GPU_RENDERING",
                appName, 1, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_MAXCONNECTIONSPER1_0SERVER",
                appName, 100, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "MAXCONNECTIONSPERSERVER",
                appName, 100, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_SPELLCHECKING",
               appName, 0, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_STATUS_BAR_THROTTLING",
               appName, 1, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_WEBSOCKET_MAXCONNECTIONSPERSERVER",
                appName, 100, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_WEBOC_DOCUMENT_ZOOM",
                appName, 0, RegistryValueKind.DWord);

            Registry.SetValue(featureControlRegKey + "FEATURE_NINPUT_LEGACYMODE",
                appName, 0, RegistryValueKind.DWord);
        }

        static UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            if (browserVersion < 7)
            {
                throw new ApplicationException("Unsupported version of Microsoft Internet Explorer!");
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. 

            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. 
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. 
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.                    
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.
                    break;
            }

            return mode;
        }

        //***********************
        // onload&window max
        //***********************

        public event EventHandler FormMaximized;
        private void FireFormMaximized()
        {
            if (FormMaximized != null)
            {
                FormMaximized(this, EventArgs.Empty);
            }
        }

        private FormWindowState _CurrentWindowState;
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized && _CurrentWindowState != FormWindowState.Maximized)
            //{
            //    FireFormMaximized();
            //}
            _CurrentWindowState = this.WindowState;
        }

        void Form1_FormMaximized(object sender, EventArgs e)
        {
            //TODO Put you're code here
            //MessageBox.Show("1:Max!");
        }

        //***********************
        // onload&window resize
        //***********************

        private void onLoadApp(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
        
        // http://stackoverflow.com/questions/10441604/event-called-after-windows-maximized
        protected override void OnSizeChanged(EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //MessageBox.Show("2: Max!");
            //}
            base.OnSizeChanged(e);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //doublePost.Abort();
                mainThread.Abort();
            }

            this.ResizeColumnHeaders();
        }

        //https://msdn.microsoft.com/en-us/library/System.Timers.Timer.form.closing(v=vs.110).aspx
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //http://stackoverflow.com/questions/204804/disable-image-loading-from-webbrowser-control-before-the-documentcompleted-event
            //RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            //RegKey.SetValue("Display Inline Images", "yes");

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            RegKey.SetValue("Play_Animations", "yes");

            BingRewardsBot.Properties.Settings.Default.set_autorotate = chkbox_autorotate.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_tor = chkbox_tor.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_mobile = chkbox_mobile.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_desktop = chkbox_desktop.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_counter = txtbox_counter.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitsearches = txtbox_waitsearches.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitauth = txtbox_waitauth.Text;
            BingRewardsBot.Properties.Settings.Default.set_autostart = txtbox_autostart.Text;
            BingRewardsBot.Properties.Settings.Default.set_proxy = txtbox_proxy.Text;
            BingRewardsBot.Properties.Settings.Default.set_torsettings = this.txtbox_torsettings.Text;
            BingRewardsBot.Properties.Settings.Default.set_uadesktop = this.txtboxcustomdesktop.Text;
            BingRewardsBot.Properties.Settings.Default.set_uamobile = this.txtboxcustommobile.Text;
            BingRewardsBot.Properties.Settings.Default.set_accounts = this.txtbox_customaccounts.Text;
            BingRewardsBot.Properties.Settings.Default.set_lang = this.listBox1.SelectedIndex;
            BingRewardsBot.Properties.Settings.Default.set_randomo = randomo.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_ns = this.chkbox_ns.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_chkbox_as = this.chkbox_as.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.Save();
        }

        //*************************
        // Main webbrowser change
        //*************************

        private void browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            var progress = (WebBrowser)sender;
            if (progress.Url != null)
            {
                browserUrlTxtbox.Text = progress.Url.ToString();
            }
        }

        /*
        struct Void { }; // use an empty struct as parameter to generic TaskCompletionSource

        // http://stackoverflow.com/questions/18280487/flow-of-webbrowser-navigate-and-invokescript?noredirect=1&lq=1
        async Task DoUnsupportedMarket()
        {
            Void v;
            TaskCompletionSource<Void> tcs = null;
            WebBrowserDocumentCompletedEventHandler documentComplete = null;

            documentComplete = new WebBrowserDocumentCompletedEventHandler((s, e) =>
            {
                // more of DocumentCompleted can possibly be fired due to dynamic navigation inside the web page, we don't want them!
                this.browser.DocumentCompleted -= documentComplete;
                tcs.SetResult(v); // continue from where awaited
            });

            // navigate to www.bing.com
            tcs = new TaskCompletionSource<Void>();
            this.browser.DocumentCompleted += documentComplete;
            this.browser.Navigate("https://www.bing.com/account/general");
            await tcs.Task;
            // do whatever you want with this instance of WB.Document
            MessageBox.Show(this.browser.Document.Url.ToString());

            if (listBox1.SelectedIndex == 0)
            {
                //DownloadAsync(BRI18NUS + this.siguid).ContinueWith(
                //(task) => this.statusDebug("UM:"),
                //   TaskScheduler.FromCurrentSynchronizationContext());

                tcs = new TaskCompletionSource<Void>();
                this.browser.DocumentCompleted += documentComplete;
                this.browser.Navigate(BRI18NUS + this.siguid);
                await tcs.Task;
                // do whatever you want with this instance of WB.Document
                MessageBox.Show(this.browser.Document.Url.ToString());
            }
            else
            {
                //DownloadAsync(BRI18NIN + this.siguid).ContinueWith(
                //    (task) => this.statusDebug("UM:"),
                //        TaskScheduler.FromCurrentSynchronizationContext());

                tcs = new TaskCompletionSource<Void>();
                this.browser.DocumentCompleted += documentComplete;
                this.browser.Navigate(BRI18NIN + this.siguid);
                await tcs.Task;
                // do whatever you want with this instance of WB.Document
                MessageBox.Show(this.browser.Document.Url.ToString());
            }

            // navigate to www.bing.com
            tcs = new TaskCompletionSource<Void>();
            this.browser.DocumentCompleted += documentComplete;
            this.browser.Navigate("https://www.bing.com/");
            await tcs.Task;
            // do whatever you want with this instance of WB.Document
            //MessageBox.Show(this.browser.Document.Url.ToString());

            return;
        }
        */

        async Task DoUnsupportedMarket()
        {
            this.WDCounter = 0;

            //var htmlNow = await DownloadAsync("https://www.bing.com/account/general");
            //this.statusDebug("UM:");      
            //htmlNow = documentElement.OuterHtml;

            //await DownloadAsync("https://www.bing.com/account/general").ContinueWith(
            //   (task) => this.statusDebug("UM:"),
            //       TaskScheduler.FromCurrentSynchronizationContext());

            // do whatever you want with this instance of WB.Document
            //MessageBox.Show(this.browser.Document.Url.ToString());

            if (listBox1.SelectedIndex == 0)
            {
                //await DownloadAsync(BRI18NUS + this.siguid).ContinueWith(
                //    (task) => this.statusDebug("UM1:"),
                //    TaskScheduler.FromCurrentSynchronizationContext());

                this.WDCounter = 0;
                //htmlNow = await DownloadAsync(BRI18NUS + this.siguid);
                //this.statusDebug("UM1:");
                //htmlNow = documentElement.OuterHtml;

                await DownloadAsync(BRI18NUS + this.siguid).ContinueWith(
                    (task) => this.statusDebug("UM1:"),
                     TaskScheduler.FromCurrentSynchronizationContext());

                // do whatever you want with this instance of WB.Document
                //MessageBox.Show(this.browser.Document.Url.ToString());

                Thread.Sleep(500);

                this.WDCounter = 0;

                //htmlNow = await DownloadAsync("https://account.microsoft.com/?lang=en-US");
                //this.statusDebug("UM1.1:");
                //htmlNow = documentElement.OuterHtml;

                this.statusTxtBox.Text = "Connected";

                await DownloadAsync("https://account.microsoft.com/?lang=en-US").ContinueWith(
                (task) => this.statusDebug("UM1.1:"),
                     TaskScheduler.FromCurrentSynchronizationContext());
            }
            else
            {                

                this.WDCounter = 0;

                await DownloadAsync(BRI18NIN + this.siguid).ContinueWith(
                    (task) => this.statusDebug("UM2:"),
                        TaskScheduler.FromCurrentSynchronizationContext());

                //htmlNow = await DownloadAsync(BRI18NIN + this.siguid);
                //this.statusDebug("UM2:");
                //htmlNow = documentElement.OuterHtml;

                // do whatever you want with this instance of WB.Document
                //MessageBox.Show(this.browser.Document.Url.ToString());

                Thread.Sleep(500);

                this.WDCounter = 0;
                this.statusTxtBox.Text = "Connected";

                await DownloadAsync("https://account.microsoft.com/?lang=hi-IN").ContinueWith(
                    (task) => this.statusDebug("UM1.1:"),
                        TaskScheduler.FromCurrentSynchronizationContext());

                //htmlNow = await DownloadAsync("https://account.microsoft.com/?lang=hi-IN");
                //this.statusDebug("UM1.1:");
                //htmlNow = documentElement.OuterHtml;
                
            }

            // navigate to www.bing.com
            //await DownloadAsync("https://www.bing.com/").ContinueWith(
            //   (task) => this.statusDebug("UM3:"),
            //       TaskScheduler.FromCurrentSynchronizationContext());

            Thread.Sleep(500);

            this.WDCounter = 0;

            // first step after sign in (very important) navigate bing.com or bing.com/rewards
            await DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                (task) => this.statusDebug("UM2:"),
                   TaskScheduler.FromCurrentSynchronizationContext());

            try
            {
                HtmlElementCollection links = this.browser.Document.Links;
                foreach (HtmlElement ele in links)
                {
                    if ((ele.GetAttribute("href") != null)
                    && ele.GetAttribute("href").Contains(@"sig=")
                    )
                    {
                        string text = ele.GetAttribute("href");
                        string[] substring = text.Split('&');
                        foreach (string sig in substring)
                        {
                            if (sig.Contains(@"sig="))
                            {
                                this.siguid = sig.Replace("sig=", "");
                                break;
                            }
                        }
                    }
                }
            }
            catch { }

            if (this.dashboardta == false
                && this.ldashboardta == false
                )
            {
                statusTxtBox.Text = "Dashboard";
                this.Csearch = false;

                if (this.timer_tor != null)
                {
                    this.timer_tor.Enabled = false;
                }

                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.Csearch = false;
                }

                string[] authstr = this.accounts[this.accountNum].Split('/');
                this.username = authstr[0];
                this.password = authstr[1];
                string[] paddr = authstr[1].Split(' ');
                if (paddr.Length >= 2 && paddr[1] != null)
                {
                    this.password = paddr[0];
                    string proxy = paddr[1];
                }

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                this.dashboardta = true;

                if (this.siguid != "")
                {
                    DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                        (task) => this.statusDebug("Finalize UM:"),
                           TaskScheduler.FromCurrentSynchronizationContext());
                } else
                {
                    DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                   (task) => this.statusDebug("DB:"),
                      TaskScheduler.FromCurrentSynchronizationContext());
                }
            }
           
            //htmlNow = await DownloadAsync("https://www.bing.com/rewards/dashboard");
            //this.statusDebug("UM2:");
            //htmlNow = documentElement.OuterHtml;

            //htmlNow = await DownloadAsync("https://www.bing.com/rewards/dashboard");
            //this.statusDebug("UM2:");
            //htmlNow = documentElement.OuterHtml;

            // do whatever you want with this instance of WB.Document
            //MessageBox.Show(this.browser.Document.Url.ToString());
            //return;
        }

        async Task DoLogin()
        {           
            await DownloadAsync(BRSOUT).ContinueWith(
                               (task) => this.statusDebug("PC1:"),
                                   TaskScheduler.FromCurrentSynchronizationContext());

            if (this.country == "US" || this.country == "IN" || this.country == "AU" || chkbox_tor.Checked == false)
            {
                this.authLock = true;
                this.iniSearch = false;
                this.Csearch = false;

                this.ClearCache();

                // first step before sign-in
                await NewLoginAsync(BRSIN2).ContinueWith(
                    (task) => this.statusDebug("S2:"),
                        TaskScheduler.FromCurrentSynchronizationContext());
            }
            else if (chkbox_autorotate.Checked == true)
            {
                statusTxtBox.Text = "Authenticate";

                string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');

                int z = randAuthTimer(Convert.ToInt32(auth[0]), Convert.ToInt32(auth[1]));
                this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.";

                this.authLock = false;
                this.iniSearch = false;

                this.statusDebug("Auth2:");
            }

            string url = this.browser.Document.Url.ToString();

            if (url == "https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing"
                || url == "https://account.microsoft.com/rewards/dashboard?refd=www.bing.com"
                || url == "https://account.microsoft.com/rewards/welcome?refd=www.bing.com"
                || url == "https://account.microsoft.com/"
                )
            {
                if (browser.Document.GetElementById("site - layout - config") != null)
                {
                    HtmlElement sig = browser.Document.GetElementById("site - layout - config");
                    MessageBox.Show(sig.InnerText);
                }    

                this.authLock = true;
              
                //prepare extraction & connection
                if (this.accountVisited[this.accountNum] == false
                    && chkbox_autorotate.Checked == true
                    && this.checkaccount == false
                )
                {
                    this.accountVisited[this.accountNum] = true;
                    ++this.accountVisitedX;

                    string[] authstr = this.accounts[this.accountNum].Split('/');
                    this.username = authstr[0];
                    this.password = authstr[1];
                    string proxy = "";
                    string[] paddr = authstr[1].Split(' ');
                    if (paddr.Length >= 2 && paddr[1] != null)
                    {
                        this.password = paddr[0];
                        proxy = paddr[1];
                    }

                    accountNameTxtBox.Text = this.username;
                    accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.authLock = true;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.WDCounter = 0;

                    statusTxtBox.Text = "Connected";
                    counterTxtBox.Text = "0/0";

                    this.initUserSQL();

                    // first step after user auth (very important) navigate bing.com or bing.com/rewards
                    await DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                        (task) => this.statusDebug("S4:"),
                           TaskScheduler.FromCurrentSynchronizationContext());

                    MessageBox.Show(this.browser.Document.Url.ToString());
                }
                else if ((chkbox_autorotate.Checked == false || this.checkaccount == true)
                    )
                {
                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = Convert.ToString(this.pts);

                    //http://stackoverflow.com/questions/13581182/split-index-was-outside-the-bounds-of-the-array
                    string[] authstr = this.accounts[this.accountNum].Split('/');
                    this.username = authstr[0];
                    this.password = authstr[1];
                    string[] paddr = authstr[1].Split(' ');
                    if(paddr.Length >= 2 && paddr[1] != null) {
                        this.password = paddr[0];
                        string proxy = paddr[1];
                    }                   

                    accountNameTxtBox.Text = this.username;
                    accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                    statusTxtBox.Text = "Connected";
                    counterTxtBox.Text = "0/0";
                    this.pts_txtbox.Text = "0";

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;
                    this.authLock = true;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.WDCounter = 0;

                    this.initUserSQL();

                    // first step after sign in (very important) navigate bing.com or bing.com/rewards
                    await DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                        (task) => this.statusDebug("S3:"),
                           TaskScheduler.FromCurrentSynchronizationContext());                    
                }
                else
                {
                    // very important
                    await DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                       (task) => this.statusDebug("S3:"),
                          TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

            url = this.browser.Document.Url.ToString();

            if ((url.Contains(@"https://www.bing.com/rewards/dashboard")
                || url.Contains(@"https://accounts.microsoft.com/rewards/dashboard"))
                && (String.IsNullOrEmpty(browser.Document.GetElementById("id_n").InnerText)
                    || String.IsNullOrWhiteSpace(browser.Document.GetElementById("id_n").InnerText)
                && String.IsNullOrEmpty(this.siguid) && String.IsNullOrWhiteSpace(this.siguid)
                && !url.Contains(@"login.live.com"))
                && this.dashboardta == false
                && statusTxtBox.Text != "Dashboard"
            )
            {
                if (browser.Document.GetElementById("site - layout - config") != null)
                {
                    HtmlElement sig = browser.Document.GetElementById("site - layout - config");
                    MessageBox.Show(sig.InnerText);
                }

                try
                {
                    HtmlElementCollection links = browser.Document.Links;
                    foreach (HtmlElement ele in links)
                    {
                        if ((ele.GetAttribute("href") != null)
                        && ele.GetAttribute("href").Contains(@"sig=")
                        )
                        {
                            string text = ele.GetAttribute("href");
                            string[] substring = text.Split('&');
                            foreach (string sig in substring)
                            {
                                if (sig.Contains(@"sig="))
                                {
                                    this.siguid = sig.Replace("sig=", "");
                                    MessageBox.Show(this.siguid);
                                    break;
                                }
                            }
                        }
                    }
                }
                catch { }

                if (this.timer_dashboardta != null)
                {
                    this.timer_dashboardta.Enabled = false;
                }

                if (this.timer_tor != null)
                {
                    this.timer_tor.Enabled = false;
                }

                if (this.timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                }

                string[] authstr = this.accounts[this.accountNum].Split('/');
                this.username = authstr[0];
                this.password = authstr[1];
                string[] paddr = authstr[1].Split(' ');
                if (paddr.Length >= 2 && paddr[1] != null)
                {
                    this.password = paddr[0];
                    string proxy = paddr[1];
                }

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                this.prevpts = 0;
                this.pts = 0;
                this.pts_txtbox.Text = "0";

                statusTxtBox.Text = "Connected";
                counterTxtBox.Text = "0/0";

                this.dxloops = 0;
                this.mxloops = 0;
                this.authLock = true;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;

                //this.statusDebug("Connected:");

                try
                {
                    //MessageBox.Show(BRSIGNIN + this.siguid);
                    await DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                       (task) => this.statusDebug("S5:"),
                          TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch
                {
                    await DownloadAsync("https://www.bing.com/").ContinueWith(
                          (task) => this.statusDebug("S5:"),
                             TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

            url = this.browser.Document.Url.ToString();

            if ((url.Contains(@"https://account.microsoft.com/rewards/dashboard")
                || browserUrlTxtbox.Text == "https://account.microsoft.com/rewards/dashboard")
                && !url.Contains(@"login.live.com")
                && !url.Contains(@"refd=www.bing.com")
                && chkbox_autorotate.Checked == true
                && this.dashboardta == false
                && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                && statusTxtBox.Text != "Dashboard"
            )
            {
                string[] authstr = this.accounts[this.accountNum].Split('/');
                this.username = authstr[0];
                this.password = authstr[1];
                string[] paddr = authstr[1].Split(' ');
                if (paddr.Length >= 2 && paddr[1] != null)
                {
                    this.password = paddr[0];
                    string proxy = paddr[1];
                }

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                this.prevpts = 0;
                this.pts = 0;
                this.pts_txtbox.Text = "0";

                statusTxtBox.Text = "Connected";
                counterTxtBox.Text = "0/0";

                this.dxloops = 0;
                this.mxloops = 0;
                this.authLock = true;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;
                this.statusDebug("Finalize:");

                try
                {
                    await DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                       (task) => this.statusDebug("S6:"),
                          TaskScheduler.FromCurrentSynchronizationContext());
                }
                catch
                {

                    await DownloadAsync("https://www.bing.com/").ContinueWith(
                           (task) => this.statusDebug("S6:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                }
            }

            url = this.browser.Document.Url.ToString();
            
            if (url.Contains(@"https://www.bing.com/rewards/unsupportedmarket"))
            {
                await DoUnsupportedMarket();
            }
        }

        //**********************
        // Main webbrowser loop
        //**********************
        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser wb = sender as WebBrowser;
            if (wb.ReadyState != WebBrowserReadyState.Complete)
                return;

            if (wb != null && wb.ReadyState == WebBrowserReadyState.Complete)
            {
                //this.loaded = (WebBrowser)sender;
                string url = wb.Url.ToString();

                //*********************
                // Update terms
                //*********************

                if (url.Contains(@"https://account.live.com/tou/accrue?ru=https://login.live.com/login.srf"))
                {
                    if (browser.Document.GetElementById("iNext") != null)
                    {
                        browser.Document.GetElementById("iNext").InvokeMember("click");
                    }
                }

                /*
                else 
               
                   //*********************
                    // Unsupported market
                    //*********************

                    if (url.Contains(@"https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us"))
                {
                    //browser.Navigate(new Uri("https://www.bing.com/"));

                     DownloadAsync("https://www.bing.com/").ContinueWith(
                       (task) => this.statusDebug("UM:"),
                          TaskScheduler.FromCurrentSynchronizationContext());

                    //*********************
                    // Unsupported market
                    //*********************
                }*/

                else if (url.Contains(@"https://www.bing.com/rewards/unsupportedmarket")
                         || browserUrlTxtbox.Text.Contains(@"https://www.bing.com/rewards/unsupportedmarket")

                          // && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                    )
                {                                   

                    DoUnsupportedMarket();

                    //var task = DoUnsupportedMarket();
                    //task.ContinueWith((t) =>
                    //{
                    //    
                    //}, TaskScheduler.FromCurrentSynchronizationContext());

                    //browser.Navigate(new Uri(BRM + this.siguid));
                    //DownloadAsync("https://www.bing.com/account/general").ContinueWith(
                    //       (task) => this.statusDebug("UM:"),
                    //          TaskScheduler.FromCurrentSynchronizationContext());

                    //*********************
                    // Unsupported market
                    //*********************
                }
                /*
                else if (url.Contains(@"https://www.bing.com/account/general")
                    && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                    )
                {
                    //browser.Navigate(new Uri(BRM + this.siguid));
                  
                    if (listBox1.SelectedIndex == 0)
                    {
                        DownloadAsync(BRI18NUS + this.siguid).ContinueWith(
                        (task) => this.statusDebug("UM:"),
                           TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        DownloadAsync(BRI18NIN + this.siguid).ContinueWith(
                            (task) => this.statusDebug("UM:"),
                                TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    //****************************************************
                    // surpress wb dialog box & double post problem
                    //****************************************************
                    // https://login.live.com/ppsecure/post.srf
                }
                */

                else if ((url.Contains(@"https://account.live.com/identity/confirm")
                        || url.Contains(@"https://account.live.com/recover")
                        || url.Contains(@"https://account.live.com/Abuse")
                        || url.Contains(@"https://account.microsoft.com/rewards/error")
                        || url.Contains(@"https://login.live.com/logout.srf?lc=1033&flowtoken")
                        || url.Contains(@"https://account.live.com/proofs/Verify")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/identity/confirm")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/recover")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/Abuse")
                        || browserUrlTxtbox.Text.Contains(@"https://login.live.com/logout.srf?lc=1033&flowtoken")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/proofs/Verify")
                        )
                        && chkbox_autorotate.Checked == true
                        )
                {
                    if (this.timer_tor != null)
                    {
                        this.timer_tor.Enabled = false;
                    }

                    this.accountVisited[this.accountNum] = true;
                    ++this.accountVisitedX;
                    this.updateUserPts(4242);
                    statusTxtBox.Text = "Authenticate";

                    this.timer_auth = 30 * 1000;
                    counterTxtBox.Text = "a few sec.";

                    this.authLock = false;
                    this.vrndnum = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;

                    this.statusDebug("PC4:");

                    //*********************
                    // Continue searches 
                    //*********************

                }
                else if (this.checkaccount == false
                 && (this.Csearch == true || this.clicklist == true)
                 && this.authLock == true
                 && (url.Contains(@"search?q=")
                         || wb.Document.GetElementById("sb_form_q") != null)
                 && this.statusTxtBox.Text != "Dashboard"
                 )
                {
                    bool autorotate = this.chkbox_autorotate.Checked == true ? true : false;

                    // callback search bot
                    if (this.pts >= MSPOINTS && autorotate == true)
                    {
                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        if (this.timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                        }

                        if (this.timer_dashboardta != null)
                        {
                            this.timer_dashboardta.Enabled = false;
                        }

                        statusTxtBox.Text = "Authenticate";
                        this.pts_txtbox.Text = "0";

                        this.authLock = false;
                        this.counterDx = 0;
                        this.counterMx = 0;
                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.vrndnum = 0;
                        
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.pts = 0;

                        this.statusDebug("Stop1:");
                    }
                    else if (this.pts >= MSPOINTS && autorotate == false)
                    {
                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        if (this.timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                        }

                        if (this.timer_dashboardta != null)
                        {
                            this.timer_dashboardta.Enabled = false;
                        }

                        this.button1.Text = "Start";
                        statusTxtBox.Text = "Stop";
                        counterTxtBox.Text = "0/0";
                        this.pts_txtbox.Text = "0";

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.authLock = false;                       

                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.statusDebug("Stop2:");
                    }
                    else
                    {
                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        if (this.timer_dashboardta != null)
                        {
                            this.timer_dashboardta.Enabled = false;
                        }

                        if (this.timer_searches == null)
                        {
                            this.timer_searches = new System.Timers.Timer();
                            this.timer_searches.AutoReset = false;
                            this.timer_searches.Elapsed += new ElapsedEventHandler(DoSearch);
                        }

                        string[] wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                        this.timer_searches.Interval = randNumTimer(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1])) * 1000;

                        this.timer_searches.Enabled = true;
                        this.Csearch = false;

                        this.statusDebug("Search:");
                    }

                    //*********************
                    // Count MS points 
                    //*********************

                    if (wb.Document.GetElementById("id_rc").InnerText != null)
                    {
                        //Thread.Sleep(1000);
                        int pts = Convert.ToInt32(wb.Document.GetElementById("id_rc").InnerText);

                        //MessageBox.Show(string.Format("Curr P. {0} pts", pts), "Results", MessageBoxButtons.OK);
                        //MessageBox.Show(string.Format("Prev P. {0} pts", this.prevpts), "Results", MessageBoxButtons.OK);

                        if (pts == 0 || this.pts_txtbox.Text == "-")
                        {
                            Thread.Sleep(SLEEPPTS);
                            pts = Convert.ToInt32(wb.Document.GetElementById("id_rc").InnerText);
                            if (pts > 0)
                            {
                                this.pts_txtbox.Text = Convert.ToString(pts);
                            }
                        }

                        //string[] str = this.pts_txtbox.Text.Split(' ');
                        //if (Convert.ToInt32(str[0]) == 0 || Convert.ToInt32(this.pts_txtbox.Text) == 0 || this.prevpts == 0)
                        int cpts = 0;
                        try
                        {
                            cpts = Convert.ToInt32(this.pts_txtbox.Text);
                        }
                        catch { }

                        if (cpts == 0 || this.prevpts == 0)
                        //if ((!this.pts_txtbox.Text.Contains(@"(") && !this.pts_txtbox.Text.Contains(@"-")) || this.prevpts == 0)
                        {
                            this.prevpts = pts;
                            //MessageBox.Show(string.Format("{0} Bing Points", this.prevpts), "Results", MessageBoxButtons.OK);
                            this.pts_txtbox.Text = "-";
                        }
                        else if (pts > this.prevpts)
                        {
                            int delta = pts - this.prevpts;
                            //MessageBox.Show(string.Format("Curr P. {0} delta", delta), "Results", MessageBoxButtons.OK);
                            this.prevpts = pts;
                            this.pts += delta;

                            if (delta >= 1 && delta < (4 * 5) && this.pts <= MSPOINTS)
                            {
                                int num = this.numIpDate();

                                if (num == 0)
                                {
                                    SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                    dbcon.Open();
                                    DateTime dateTime = DateTime.UtcNow.Date;
                                    SQLiteCommand command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                        dateTime.ToString("yyyyMMdd") +
                                        "','" +
                                        this.ip +
                                        "','" +
                                        this.username +
                                        "','0')",
                                        dbcon);
                                    command.ExecuteNonQuery();
                                    dbcon.Close();
                                }
                                else
                                {
                                    SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                    dbcon.Open();
                                    DateTime dateTime = DateTime.UtcNow.Date;
                                    SQLiteCommand command = new SQLiteCommand("update searches set points='" +
                                        Convert.ToString(this.pts) +
                                        "' WHERE ip='" +
                                        this.ip +
                                        "' and date='" +
                                        dateTime.ToString("yyyyMMdd") +
                                        "' and account='" +
                                        this.username +
                                        "'",
                                        dbcon);
                                    command.ExecuteNonQuery();
                                    dbcon.Close();
                                }
                            }

                            //this.pts_txtbox.Text = Convert.ToString(this.prevpts+this.pts)+" ("+ Convert.ToString(this.pts)+")";
                            //this.pts_txtbox.Text = Convert.ToString(this.pts) + " (" + Convert.ToString(this.prevpts + this.pts) + ")";
                            this.pts_txtbox.Text = Convert.ToString(this.pts);
                        }
                    }

 
                    //*************************
                    // Sign-in 6/6 Finalize
                    //**************************
                    //&& !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                }
                      
                else if ((url.Contains(@"https://account.microsoft.com/rewards/dashboard")
                        || browserUrlTxtbox.Text == "https://account.microsoft.com/rewards/dashboard")
                        && !url.Contains(@"login.live.com")
                        && !url.Contains(@"refd=www.bing.com")
                        && chkbox_autorotate.Checked == true
                        && this.dashboardta == false
                        && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                        //&& statusTxtBox.Text != "Dashboard"
                    )
                {
                    string[] authstr = this.accounts[this.accountNum].Split('/');
                    this.username = authstr[0];
                    this.password = authstr[1];
                    string[] paddr = authstr[1].Split(' ');
                    if (paddr.Length >= 2 && paddr[1] != null)
                    {
                        this.password = paddr[0];
                        string proxy = paddr[1];
                    }

                    accountNameTxtBox.Text = this.username;
                    accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";

                    statusTxtBox.Text = "Dashboard";
                    counterTxtBox.Text = "0/0";

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.authLock = true;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.WDCounter = 0;
                    this.statusDebug("Finalize:");

                    try
                    {
                        DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                           (task) => this.statusDebug("S6:"),
                              TaskScheduler.FromCurrentSynchronizationContext());

                        this.siguid = "";

                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        if (timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                            this.Csearch = false;
                        }

                        authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            string proxy = paddr[1];
                        }

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                        this.dashboardta = true;

                    }
                    catch
                    {

                        //DownloadAsync("https://www.bing.com").ContinueWith(
                        //       (task) => this.statusDebug("S6:"),
                        //          TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    //********************************
                    // Sign-in 6/5: Extract user sig
                    //********************************
                }
                else if (((url.Contains(@"https://www.bing.com/rewards/dashboard")
                         || url.Contains(@"https://accounts.microsoft.com/rewards/dashboard"))
                    && (String.IsNullOrEmpty(wb.Document.GetElementById("id_n").InnerText)
                        || String.IsNullOrWhiteSpace(wb.Document.GetElementById("id_n").InnerText)
                    && String.IsNullOrEmpty(this.siguid) && String.IsNullOrWhiteSpace(this.siguid)
                    && !url.Contains(@"login.live.com"))
                    && this.dashboardta == false
                    && statusTxtBox.Text != "Dashboard") || 
                    (url.Contains(@"https://www.bing.com/rewards/dashboard") && 
                    (String.IsNullOrEmpty(wb.Document.GetElementById("id_n").InnerText)
                        || String.IsNullOrWhiteSpace(wb.Document.GetElementById("id_n").InnerText))
                    && String.IsNullOrEmpty(this.siguid) && String.IsNullOrWhiteSpace(this.siguid)
                    && !url.Contains(@"login.live.com"))
                )
                {
                    try
                    {
                        HtmlElementCollection links = wb.Document.Links;
                        foreach (HtmlElement ele in links)
                        {
                            if ((ele.GetAttribute("href") != null)
                            && ele.GetAttribute("href").Contains(@"sig=")
                            )
                            {
                                string text = ele.GetAttribute("href");
                                string[] substring = text.Split('&');
                                foreach (string sig in substring)
                                {
                                    if (sig.Contains(@"sig="))
                                    {
                                        this.siguid = sig.Replace("sig=", "");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    if (this.timer_dashboardta != null)
                    {
                        this.timer_dashboardta.Enabled = false;
                    }

                    if (this.timer_tor != null)
                    {
                        this.timer_tor.Enabled = false;
                    }

                    if (this.timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                    }

                    string[] authstr = this.accounts[this.accountNum].Split('/');
                    this.username = authstr[0];
                    this.password = authstr[1];
                    string[] paddr = authstr[1].Split(' ');
                    if (paddr.Length >= 2 && paddr[1] != null)
                    {
                        this.password = paddr[0];
                        string proxy = paddr[1];
                    }

                    accountNameTxtBox.Text = this.username;
                    accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";

                    statusTxtBox.Text = "Connected";
                    counterTxtBox.Text = "0/0";

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.authLock = true;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;

                    //this.statusDebug("Connected:");

                    try
                    {
                        //MessageBox.Show(BRSIGNIN + this.siguid);
                        DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                           (task) => this.statusDebug("S5:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch
                    {
                        //DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                        //      (task) => this.statusDebug("S5:"),
                        //         TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    //********************************
                    // Initial dashboard & searches
                    //********************************
                    //(url != "https://account.microsoft.com/rewards"
                    //    || browserUrlTxtbox.Text != "https://account.microsoft.com/rewards"
                    //    || !url.Contains(@"https://bing.com/rewards") || this.dashboardta == true)
                    //&&
                }
                else if ((url.Contains(@"https://account.microsoft.com") || url.Contains(@"https://bing.com") || this.dashboardta == true)
                    && !url.Contains(@"search?q=")
                    && this.checkaccount == false
                    && this.authLock == true
                    && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                    && !url.Contains(@"https://account.microsoft.com/rewards/unsupportedmarket")
                    && !url.Contains(@"https://account.microsoft.com/account/general")
                    && (statusTxtBox.Text == "Connected" || this.dashboardta == true)
                    //&& !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                    )
                {
                    try
                    {
                        HtmlElementCollection links = wb.Document.Links;
                        foreach (HtmlElement ele in links)
                        {
                            if ((ele.GetAttribute("href") != null)
                            && ele.GetAttribute("href").Contains(@"sig=")
                            )
                            {
                                string text = ele.GetAttribute("href");
                                string[] substring = text.Split('&');
                                foreach (string sig in substring)
                                {
                                    if (sig.Contains(@"sig="))
                                    {
                                        this.siguid = sig.Replace("sig=", "");
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch { }

                    if (this.dashboardta == false
                        && !url.Contains(@"https://account.microsoft.com/rewards")
                        && (!url.Contains(@"https://account.microsoft.com") || !url.Contains(@"https://bing.com"))
                        && this.ldashboardta == false
                        )
                    {
                        statusTxtBox.Text = "Dashboard";
                        this.Csearch = false;

                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        if (timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                            this.Csearch = false;
                        }

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            string proxy = paddr[1];
                        }

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                        this.dashboardta = true;

                        DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                           (task) => this.statusDebug("DB:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else if (this.dashboardta == true && this.ldashboardta == false)
                    {
                        if (url.Contains(@"dashboard"))
                        {
                            this.WDCounter = 0;
                            statusTxtBox.Text = "Dashboard";
                            this.toolStripStatusLabel1.Text = "Scrap tasks:";

                            if (timer_searches != null)
                            {
                                this.timer_searches.Enabled = false;
                                this.Csearch = false;
                            }

                            this.numdashboardta = 0;
                            this.Csearch = false;

                            if (this.timer_tor != null)
                            {
                                this.timer_tor.Enabled = false;
                            }

                            try
                            {
                                HtmlElementCollection links = wb.Document.Links;
                                foreach (HtmlElement ele in links)
                                {
                                    if ((ele.GetAttribute("href") != null)
                                         && ele.GetAttribute("href").Contains(@"state=Active")
                                         )
                                    {
                                        this.toolStripStatusLabel1.Text = ele.GetAttribute("href");
                                        this.rlink[this.numdashboardta++] = ele.GetAttribute("href");
                                    }
                                }
                            }
                            catch { }

                            // search parameter
                            string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                            this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                                Convert.ToInt32(wait[1]));
                            this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                                Convert.ToInt32(wait[1]));

                            Thread.Sleep(SLEEPPTS);
                            try
                            {
                                if (wb.Document.GetElementById("srch1-2-15-NOT_T1T3_Control-Exist").InnerHtml.Contains(@"close-check"))
                                {
                                    this.dxloops = MAXLOOPS;
                                    this.counterDx = 0;
                                    this.toolStripStatusLabel1.Text += "No-Desktop";
                                }
                                else
                                {
                                    this.dxloops = 0;
                                }
                            }
                            catch { }

                            //Thread.Sleep(SLEEPPTS);
                            try
                            {
                                if (wb.Document.GetElementById("mobsrch1-2-10-NOT_T1T3_Control-Exist").InnerHtml.Contains(@"close-check"))
                                {
                                    this.mxloops = MAXLOOPS;
                                    this.counterMx = 0;
                                    this.toolStripStatusLabel1.Text += "|No-Mobile";
                                }
                                else
                                {
                                    this.mxloops = 0;
                                }
                            }
                            catch { }

                            if (this.mxloops == MAXLOOPS && this.dxloops == MAXLOOPS)
                            {
                                this.updateUserPts(MSPOINTS);
                            }

                            this.toolStripStatusLabel1.Text += "|No. Dashboard tasks (" +
                                Convert.ToString(this.numdashboardta) + ")";

                            if (this.timer_dashboardta == null)
                            {
                                this.timer_dashboardta = new System.Timers.Timer();
                                this.timer_dashboardta.AutoReset = true;
                                this.timer_dashboardta.Elapsed += new ElapsedEventHandler(earndashboardta);
                            }

                            this.timer_dashboardta.Interval = SLEEPDASHBOARD;   // Timer will tick every 10 seconds

                            statusTxtBox.Text = "Dashboard";
                            this.ldashboardta = true;
                            this.timer_dashboardta.Enabled = true;

                        }
                        else
                        {
                            statusTxtBox.Text = "Dashboard";
                            //this.statusDebug("Dashboard:");

                            this.dxloops = 0;
                            this.mxloops = 0;
                            this.authLock = true;
                            this.iniSearch = false;
                            this.dashboardta = false;
                            this.ldashboardta = false;
                            this.Csearch = false;

                            DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                            (task) => this.statusDebug("DB:"),
                               TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    }
                    else if (this.iniSearch == true)
                    {
                        if (this.timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                        }

                        if (this.timer_dashboardta != null)
                        {
                            this.timer_dashboardta.Enabled = false;
                        }

                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        // update account
                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            string proxy = paddr[1];
                        }

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.pts_txtbox.Text = "0";

                        // start search bot
                        if (this.timer_searches == null)
                        {
                            this.timer_searches = new System.Timers.Timer();
                            this.timer_searches.AutoReset = false;
                            this.timer_searches.Elapsed += new ElapsedEventHandler(DoSearch);
                        }

                        string[] wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                        this.timer_searches.Interval = randNumTimer(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1])) * 1000;

                        this.Csearch = false;
                        this.authLock = true;
                        this.timer_searches.Enabled = true;

                        this.statusDebug("Initial searches:");
                    }
                    //else if (!url.Contains(@"https://account.microsoft.com/account/general"))
                    //{
                    //    statusTxtBox.Text = "Connected";

                    //    if (this.timer_searches != null)
                    //    {
                    //        this.timer_searches.Enabled = false;
                    //    }

                    //    DownloadAsync("https://www.bing.com/").ContinueWith(
                    //         (task) => this.statusDebug("S6:"),
                    //            TaskScheduler.FromCurrentSynchronizationContext());

                    //}
                    //****************************************************
                    //  Sign-in Step 6/4
                    // @"https://account.microsoft.com/?lang=en-US"
                    // https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing
                    //****************************************************
                    // wb.Document.GetElementById("error-title").InnerHtml.Contains(@"close-check"))
                }
                else if ((url == "https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing"
                    || url == "https://account.microsoft.com/?lang=hi-IN&refd=account.live.com&refp=landing"
                    || url == "https://account.microsoft.com/rewards/dashboard?refd=www.bing.com"
                    || url == "https://account.microsoft.com/rewards/welcome?refd=www.bing.com"
                    || url == "https://account.microsoft.com/")
                    || url == "https://account.microsoft.com/rewards/dashboard"
                    && this.dashboardta == false && this.iniSearch == false
                   )
                {
                    this.authLock = true;
                 
                    //prepare extraction & connection
                    if (this.accountVisited[this.accountNum] == false
                        && chkbox_autorotate.Checked == true
                        && this.checkaccount == false
                    )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            string proxy = paddr[1];
                        }

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.prevpts = 0;
                        this.pts = 0;
                        this.pts_txtbox.Text = "0";

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.authLock = true;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.WDCounter = 0;
                        this.siguid = "";

                        statusTxtBox.Text = "Connected";
                        counterTxtBox.Text = "0/0";

                        this.initUserSQL();

                        string code = this.culture.ToString();

                        if (code == "en-US" || code == "hi-IN")
                        {
                            DownloadAsync("https://www.bing.com/rewards/unsupportedmarket").ContinueWith(
                                (task) => this.statusDebug("S3:"),
                                    TaskScheduler.FromCurrentSynchronizationContext());
                        }
                        else
                        {
                            //DoUnsupportedMarket();

                            DownloadAsync("https://www.bing.com/rewards/unsupportedmarket").ContinueWith(
                              (task) => this.statusDebug("S3:"),
                                  TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    }
                    else if ((chkbox_autorotate.Checked == false || this.checkaccount == true)
                        )
                    {
                        this.prevpts = 0;
                        this.pts = 0;
                        this.pts_txtbox.Text = Convert.ToString(this.pts);

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            string proxy = paddr[1];
                        }

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        statusTxtBox.Text = "Connected";
                        counterTxtBox.Text = "0/0";
                        this.pts_txtbox.Text = "0";

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.vrndnum = 0;
                        this.authLock = true;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.WDCounter = 0;
                        this.siguid = "";

                        this.initUserSQL();

                        // first step after sign in (very important) navigate bing.com or bing.com/rewards
                        string code = this.culture.ToString();

                        if (code == "en-US" || code == "in-Hin")
                        {
                            //DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                            //   (task) => this.statusDebug("S3:"),
                            //      TaskScheduler.FromCurrentSynchronizationContext());

                            DownloadAsync("https://www.bing.com/rewards/unsupportedmarket").ContinueWith(
                              (task) => this.statusDebug("S3:"),
                                  TaskScheduler.FromCurrentSynchronizationContext());
                        }
                        else
                        {
                            //DoUnsupportedMarket();

                            DownloadAsync("https://www.bing.com/rewards/unsupportedmarket").ContinueWith(
                              (task) => this.statusDebug("S3:"),
                                  TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    }
                    else
                    {

                        string code = this.culture.ToString();

                        if (code == "en-US" || code == "in-Hin")
                        {
                            //DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                            //   (task) => this.statusDebug("S3:"),
                            //      TaskScheduler.FromCurrentSynchronizationContext());

                            DownloadAsync("https://www.bing.com/rewards/unsupportedmarket").ContinueWith(
                                (task) => this.statusDebug("S3:"),
                                    TaskScheduler.FromCurrentSynchronizationContext());

                        } else
                        {
                            //DoUnsupportedMarket();

                            DownloadAsync("https://www.bing.com/rewards/unsupportedmarket").ContinueWith(
                              (task) => this.statusDebug("S3:"),
                                  TaskScheduler.FromCurrentSynchronizationContext());
                        }
                    }

                    //*********************
                    // Sign-in Step 6/3
                    //*********************
                }
                else if (url == "https://login.live.com/")
                {
                    this.toolStripStatusLabel1.Text = statusTxtBox.Text = "Working";

                    //*******************************
                    // Sign-in 6/1 clear cache
                    //*******************************
                    //https://account.microsoft.com/account/Account?destrt=home-index&refd=login.live.com
                    //https://account.microsoft.com/about?refd=login.live.com
                }
                else if (
                    url.Contains(@"http://www.msn.com")
                    || url.Contains(@"https://www.msn.com")
                    //|| url.Contains(@"https://login.live.com/logout.srf")
                    //|| url.Contains(@"http://login.live.com/logout.srf")
                    || url.Contains(@"https://account.microsoft.com/about")
                    || url.Contains(@"https://account.microsoft.com/rewards/welcome")
                    || url.Contains(@"https://account.microsoft.com/account")
                    || url.Contains(@"https://account.microsoft.com/account/ManageMyAccount")
                    && !url.Contains(@"refd=www.bing.com")
                    && !url.Contains(@"dashboard")
                    )
                {
                    if (this.country == "US" || this.country == "IN" || this.country == "AU" || chkbox_tor.Checked == false)
                    {
                        this.authLock = true;
                        this.iniSearch = false;
                        this.Csearch = false;
                        this.siguid = "";

                        this.ClearCache();

                        // first step before sign-in

                        //http://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                        var timeSpan = "ct=" + Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds, 0);
                        string login = BRSIN2.Replace("ct=1476457420", timeSpan);

                        NewLoginAsync(login).ContinueWith(
                            (task) => this.statusDebug("S2:"),
                                TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else if (chkbox_autorotate.Checked == true)
                    {
                        statusTxtBox.Text = "Authenticate";

                        string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');

                        int z = randAuthTimer(Convert.ToInt32(auth[0]),Convert.ToInt32(auth[1]));
                        this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                        counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.";

                        this.authLock = false;
                        this.iniSearch = false;
                        this.siguid = "";

                        this.statusDebug("Auth2:");
                    }                    
                }              

                ++this.pccounter;
                this.toolStripStatusLabel1.Text += "#";
                // Dispose the WebBrowser now that the task is complete. 
                //((WebBrowser)sender).Dispose();
            }
            return;
        }

        private void SubmitSearch()
        {
            try
            {
                if (browser.Document.GetElementById("sb_form_q") != null)
                {
                    browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);

                    if (browser.Document.GetElementById("sbBtn") != null)
                    {
                        browser.Document.GetElementById("sbBtn").InvokeMember("click");
                    }
                    else if (browser.Document.GetElementById("sb_form_go") != null)
                    {
                        browser.Document.GetElementById("sb_form_go").InvokeMember("click");
                    }
                    else
                    {
                        browser.Navigate("http://bing.com/search?q=" + this.query);

                        //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                        //     (task) => this.statusDebug("Search:"),
                        //     TaskScheduler.FromCurrentSynchronizationContext());
                    }
                }
            }
            catch
            {
                browser.Navigate("http://bing.com/search?q=" + this.query);

                //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                //           (task) => this.statusDebug("Search:"),
                //            TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        //http://stackoverflow.com/questions/18808990/get-current-webbrowser-dom-as-html
        async Task NewLoginAsync(string url)
        {       
            TaskCompletionSource<bool> onloadTcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = null;

            handler = delegate
            {
                this.browser.DocumentCompleted -= handler;

                // attach to subscribe to DOM onload event
                this.browser.Document.Window.AttachEventHandler("onload", delegate
                {
                    // each navigation has its own TaskCompletionSource
                    if (onloadTcs.Task.IsCompleted)
                        return; // this should not be happening
                                // signal the completion of the page loading
                    onloadTcs.SetResult(true);
                });
            };

            // register DocumentCompleted handler
            this.browser.DocumentCompleted += handler;

            // Navigate to url
            this.browser.Navigate(url);

            // continue upon onload
            await onloadTcs.Task;

            // artificial delay for AJAX
            await Task.Delay(POLL_DELAY * 2);

            /*
            // get the root element
            var documentElement = this.browser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(POLL_DELAY);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }
            */
            // get the root element
            Invoke((MethodInvoker)(() =>
            {
                documentElement = this.browser.Document.GetElementsByTagName("html")[0];

                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    var delay = Task.Run(async () => {
                        await Task.Delay(POLL_DELAY);
                    });

                    // continue polling if the WebBrowser is still busy
                    //if (this.browser.IsBusy)
                    //    continue;

                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop

                    html = htmlNow;
                }
            }));

            this.WDCounter = 0;

            // artificial delay for AJAX
            await Task.Delay(POLL_DELAY * 2);

            //http://stackoverflow.com/questions/11512373/findwindow-and-setforegroundwindow-alternatives
            //http://dotnet-snippets.de/snippet/form-in-den-windowsvordergrund-bringen/582 
            //int hwnd = this.Handle.ToInt32();
            //SetForegroundWindow(hwnd);
            //this.Activate();
            //IntPtr hWnd = (IntPtr)FindWindow("WindowsForms10.Window.8.app.0.bf7d44_r9_ad1", null);
            //SetForegroundWindow(hWnd.ToInt32());

            //this.toolStripStatusLabel1.Text += this.username + "/" + this.password;
            Invoke((MethodInvoker)(() =>
            {
                htmlDoc = ((dynamic)this.browser.Document.DomDocument) as mshtml.IHTMLDocument2;
            }));

            //htmlDoc.all.item("i0116").SetAttribute("value", this.username);
            //htmlDoc.all.item("i0118").SetAttribute("value", this.password);
            //htmlDoc.all.item("idSIButton9").click();

            try { 
                htmlDoc.all.item("i0116").Focus();
            } catch (Exception ex) {
                throw (ex);
            }

            //http://stackoverflow.com/questions/11368648/using-postmessage-sendmessage-to-send-keys-to-c-sharp-ie-webbrowser
            //IntPtr pControl;
            //IntPtr pControl2;
            Invoke((MethodInvoker)(() =>
            {
                pControl = FindWindowEx(browser.Handle, IntPtr.Zero, "Shell Embedding", null);
                pControl = FindWindowEx(pControl, IntPtr.Zero, "Shell DocObject View", null);
                pControl = FindWindowEx(pControl, IntPtr.Zero, "Internet Explorer_Server", null);
                //pControl2 = FindWindowEx(pControl, IntPtr.Zero, "MacromediaFlashPlayerActiveX", null);
                //if (pControl2 != IntPtr.Zero)
                //    pControl = pControl2;
            }));

            // artificial delay for AJAX
            await Task.Delay(randomNumber(100, 400));
            
            //http://stackoverflow.com/questions/6009955/use-sendkeys-with-string-in-c
            foreach (char c in this.username)
            {
                //SendKeys.SendWait(c.ToString());
                PostMessage(pControl, WM_CHAR, c, 0);
                await Task.Delay(randomNumber(50, 400));
            }
            
            try { 
                htmlDoc.all.item("idSIButton9").click();
            } catch (Exception ex) {
                throw (ex);
            }

            this.WDCounter = 0;

            // artificial delay for AJAX
            await Task.Delay(randomNumber(4000, 7000));

            /*
            // get the root element
            documentElement = this.browser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(POLL_DELAY);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }
            */

            // get the root element
            Invoke((MethodInvoker)(() =>
            {
                documentElement = this.browser.Document.GetElementsByTagName("html")[0];

                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    var delay = Task.Run(async () => {
                        await Task.Delay(POLL_DELAY);
                    });

                    // continue polling if the WebBrowser is still busy
                    //if (this.browser.IsBusy)
                    //    continue;

                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop

                    html = htmlNow;
                }
            }));

            this.WDCounter = 0;
             
            try {      
                htmlDoc.all.item("i0118").Focus();
            } catch (Exception ex) {
                throw (ex);
            }            
                
            //http://stackoverflow.com/questions/6009955/use-sendkeys-with-string-in-c
            foreach (char c in this.password)
            {
                //SendKeys.SendWait(c.ToString());
                PostMessage(pControl, WM_CHAR, c, 0);
                await Task.Delay(randomNumber(50, 400));
            }

            this.WDCounter = 0;
            try { 
                htmlDoc.all.item("idSIButton9").click();
            } catch (Exception ex) {
               throw (ex);
            }
    
            // artificial delay for AJAX
            await Task.Delay(randomNumber(2000, 5000));

            /*           
            // poll the current HTML for changes asynchronosly
            html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(POLL_DELAY);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }
            */

            Invoke((MethodInvoker)(() =>
            {
                documentElement = this.browser.Document.GetElementsByTagName("html")[0];

                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    //https://msdn.microsoft.com/en-us/library/hh194873(v=vs.110).aspx

                    // wait asynchronously, this will throw if cancellation requested
                    var delay = Task.Run(async () => {
                        await Task.Delay(POLL_DELAY);
                    });

                    // continue polling if the WebBrowser is still busy
                    //if (this.browser.IsBusy)
                    //    continue;

                    documentElement = this.browser.Document.GetElementsByTagName("html")[0];
                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop

                    html = htmlNow;
                }
            }));
            this.WDCounter = 0;

            // artificial delay for AJAX
            await Task.Delay(randomNumber(2000, 5000));

            /*
            // poll the current HTML for changes asynchronosly
            html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(POLL_DELAY);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }
            */

            Invoke((MethodInvoker)(() =>
            {
                documentElement = this.browser.Document.GetElementsByTagName("html")[0];

                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    var delay = Task.Run(async () => {
                        await Task.Delay(POLL_DELAY);
                    });

                    // continue polling if the WebBrowser is still busy
                    //if (this.browser.IsBusy)
                    //    continue;

                    documentElement = this.browser.Document.GetElementsByTagName("html")[0];
                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop

                    html = htmlNow;
                }
            }));
            this.WDCounter = 0;

            try
            {
                htmlDoc.all.item("idSIButton9").click();
            } catch (Exception ex) {
                throw (ex);
            }            

            //this.browser.Document.GetElementById("i0116").SetAttribute("value", this.username);
            //this.browser.Document.GetElementById("i0118").SetAttribute("value", this.password);
            //this.browser.Document.GetElementById("idSIButton9").InvokeMember("click");
            //this.browser.Document.GetElementById("i0116").Focus();

            ////http://stackoverflow.com/questions/6009955/use-sendkeys-with-string-in-c
            //foreach (char c in this.username)
            //    SendKeys.SendWait(c.ToString());

            //this.browser.Document.GetElementById("i0118").Focus();

            ////http://stackoverflow.com/questions/6009955/use-sendkeys-with-string-in-c
            //foreach (char c in this.password)
            //    SendKeys.SendWait(c.ToString());

            //this.browser.Document.GetElementById("idSIButton9").InvokeMember("click");

            //MessageBox.Show((((dynamic)this.browser.Document.DomDocument).documentElement.ou‌​terHTML));

            // the document has been fully loaded, can access DOM here
            //return ((dynamic)this.browser.Document);

            return;

        }

        void natural_search()
        {
            this.query = this.words[randomNumber(0, this.words.Count)];
            if (this.chkbox_ns.Checked == true)
            {
                if (randomNumber(0, 12) > (randomNumber(0, 6)))
                {
                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                }
                if (randomNumber(0, 12) > (randomNumber(0, 3)))
                {
                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                }
            }
        }

        //http://stackoverflow.com/questions/18303758/can-i-wait-for-a-webbrowser-to-finish-navigating-using-a-for-loop
        private void DoSearch(object sender, EventArgs e)
        {
            bool autorotate = BingRewardsBot.Properties.Settings.Default.set_autorotate;
            bool mobile = BingRewardsBot.Properties.Settings.Default.set_mobile;
            bool desktop = BingRewardsBot.Properties.Settings.Default.set_desktop;

            // trial version
            if ((this.trialCountDownReg - (this.trialCountUp * DIVIDE)) < 0 && this.trialstopped == false && SUPPORTER == false)
            {
                this.trialstopped = true;
                MessageBox.Show(TRIALOVER);

                // autorotate
            }
            else
            if ((this.counterDx <= 1 && this.counterMx <= 1 && autorotate == true && this.trialstopped == false)
                || (this.counterDx <= 1 && mobile == false && autorotate == true && this.trialstopped == false)
                || (this.counterMx <= 1 && desktop == false && autorotate == true && this.trialstopped == false)
                && (this.pts >= MSPOINTS || (this.dxloops == MAXLOOPS - 1) && (this.mxloops == MAXLOOPS - 1))
                )
            {
                this.Csearch = false;

                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                }

                if (this.timer_dashboardta != null)
                {
                    this.timer_dashboardta.Enabled = false;
                }

                // accounts visited
                int v = 0;
                for (int i = 0, b = this.accountVisited.Count; i < b; i++)
                {
                    if (this.accountVisited[i] == false)
                    {
                        ++v;
                    }
                }
                --v;

                if (v >= 0)
                {
                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = randAuthTimer(Convert.ToInt32(auth[0]),
                        Convert.ToInt32(auth[1]));

                    this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                    counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.";

                    this.accountVisited[this.accountNum] = true;
                    ++this.accountVisitedX;

                    this.qpage = 0;
                    this.dxloops = 0;
                    this.mxloops = 0;

                    this.vrndnum = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.authLock = false;
                    this.siguid = "";

                    this.statusTxtBox.Text = "Authenticate";

                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";

                    this.statusDebug("Visited:");
                }
                else
                {
                    int pts = 0;
                    try
                    {
                        pts = Convert.ToInt32(pts_txtbox.Text);
                    }
                    catch { }

                    if (pts >= MSPOINTS
                        || String.IsNullOrEmpty(pts_txtbox.Text)
                        || pts_txtbox.Text == "0"
                        || pts_txtbox.Text == "-")
                    {
                        SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        dbcon.Open();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        SQLiteCommand command = new SQLiteCommand("update searches set points='4242' WHERE ip='" +
                            this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") +
                            "' and account='" +
                            this.username +
                            "'",
                            dbcon);
                        command.ExecuteNonQuery();
                        dbcon.Close();
                    }

                    this.button1.Text = "Start";
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;

                    this.authLock = false;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.siguid = "";

                    if (this.timer_tor != null)
                    {
                        this.timer_tor.Enabled = false;
                    }

                    if (this.timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                    }

                    if (this.timer_dashboardta != null)
                    {
                        this.timer_dashboardta.Enabled = false;
                    }
                    this.statusDebug("Stop:");
                }

                // semi-automatic
            }
            else if (this.counterDx <= 1 && this.counterMx <= 1 && autorotate == false && this.trialstopped == false
                || (this.counterDx <= 1 && mobile == false && autorotate == false && this.trialstopped == false)
                || (this.counterMx <= 1 && desktop == false && autorotate == false && this.trialstopped == false)
                && (this.pts >= MSPOINTS || (this.dxloops == MAXLOOPS - 1) && (this.mxloops == MAXLOOPS - 1))
                )
            {
                this.qpage = 0;

                // full searches
                //this.checkaccount = false;

                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.Csearch = false;
                }

                if (this.timer_dashboardta != null)
                {
                    this.timer_dashboardta.Enabled = false;
                }

                this.button1.Text = "Start";
                statusTxtBox.Text = "Stop";
                counterTxtBox.Text = "0/0";
                this.dxloops = 0;
                this.mxloops = 0;
                this.vrndnum = 0;
  
                this.authLock = false;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;
                this.siguid = "";

                if (this.timer_tor != null)
                {
                    this.timer_tor.Enabled = false;
                }

                if (this.timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                }

                if (this.timer_dashboardta != null)
                {
                    this.timer_dashboardta.Enabled = false;
                }
            }
            else if (this.trialstopped == false)
            {
                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.Csearch = false;
                }

                // max out
                if (this.counterDx <= 1 && this.dxloops < MAXLOOPS)
                {
                    this.dxloops++;
                    string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                    this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));
                }

                if (this.counterMx <= 1 && this.mxloops < MAXLOOPS)
                {
                    this.mxloops++;
                    string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                    this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));
                }

                // searches loop
                ++this.trialCountUp;

                if (SUPPORTER == true)
                {
                    this.Text = TITLE + " Version: Beta " + ASSEMBLY;
                } else
                {
                    double x = (double)100 / FREEX;
                    double z = x * (this.trialCountDownReg - (this.trialCountUp * DIVIDE));
                    this.Text = TITLE + " : " + Math.Round(z) + "% Shareware" + " Version: Beta " + ASSEMBLY;
                }
                
                if (statusTxtBox.Text == "Mobilesearches")
                {
                    this.ChangeUserAgent(this.txtboxcustommobile.Text);
                }
                else
                {
                    this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                }

                //**************************
                // default search
                //**************************
                if (randomNumber(0, 11) > randomNumber(0, 3))
                {
                    this.qpage = 0;

                    natural_search();

                    // mobile searches
                    if ((randomNumber(0, 9) > (randomNumber(3, 7)) && this.counterMx >= 1 && mobile == true) ||
                        ((mobile == true && this.counterDx <= 1) || (mobile == true && desktop == false))
                        )
                    {
                        statusTxtBox.Text = "Mobilesearches";
                        --this.counterMx;
                        counterTxtBox.Text = (this.countDownMobile - this.counterMx) +
                            "/" + this.countDownMobile;
                        this.Csearch = true;

                        try
                        {
                            if (browser.Document.GetElementById("sb_form_q") != null)
                            {
                                this.ChangeUserAgent(this.txtboxcustommobile.Text);

                                if (browser.Document.GetElementById("sb_form_q") != null)
                                {
                                    browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);

                                    if (browser.Document.GetElementById("sbBtn") != null)
                                    {
                                        browser.Document.GetElementById("sbBtn").InvokeMember("click");
                                    }
                                    else if (browser.Document.GetElementById("sb_form_go") != null)
                                    {
                                        browser.Document.GetElementById("sb_form_go").InvokeMember("click");
                                    }
                                    else
                                    {
                                        browser.Navigate("http://bing.com/search?q=" + this.query);

                                        //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                        //    (task) => this.statusDebug("Search:"),
                                        //        TaskScheduler.FromCurrentSynchronizationContext());
                                    }
                                }
                            }
                            else if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);

                                //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                //         (task) => this.statusDebug("Search:"),
                                //             TaskScheduler.FromCurrentSynchronizationContext());
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);

                                //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                //       (task) => this.statusDebug("Search:"),
                                //        TaskScheduler.FromCurrentSynchronizationContext());
                            }

                        }
                        catch
                        {
                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);

                                //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                //        (task) => this.statusDebug("Search:"),
                                //            TaskScheduler.FromCurrentSynchronizationContext());
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);

                                //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                //       (task) => this.statusDebug("Search:"),
                                //       TaskScheduler.FromCurrentSynchronizationContext());
                            }
                        }

                        browser.Invoke(new Action(() =>
                        {
                            while (browser.ReadyState != WebBrowserReadyState.Complete)
                            {
                                Application.DoEvents();
                            }
                        }));

                        // desktop searches
                    }
                    else if (this.counterDx >= 1 && desktop == true)
                    {
                        statusTxtBox.Text = "Desktopsearches";
                        --this.counterDx;
                        counterTxtBox.Text = (this.countDownDesktop - this.counterDx) + "/"
                            + this.countDownDesktop;
                        this.Csearch = true;

                        try
                        {
                            if (browser.Document.GetElementById("sb_form_q") != null)
                            {
                                this.ChangeUserAgent(this.txtboxcustomdesktop.Text);

                                if (browser.Document.GetElementById("sb_form_q") != null)
                                {
                                    browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);

                                    if (browser.Document.GetElementById("sbBtn") != null)
                                    {
                                        browser.Document.GetElementById("sbBtn").InvokeMember("click");
                                    }
                                    else if (browser.Document.GetElementById("sb_form_go") != null)
                                    {
                                        browser.Document.GetElementById("sb_form_go").InvokeMember("click");
                                    }
                                    else
                                    {
                                        browser.Navigate("http://bing.com/search?q=" + this.query);

                                        //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                        //    (task) => this.statusDebug("Search:"),
                                        //           TaskScheduler.FromCurrentSynchronizationContext());
                                    }
                                }
                            }
                            else if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);

                                //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                //        (task) => this.statusDebug("Search:"),
                                //            TaskScheduler.FromCurrentSynchronizationContext());
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);

                                //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                //       (task) => this.statusDebug("Search:"),
                                //       TaskScheduler.FromCurrentSynchronizationContext());
                            }
                        }
                        catch
                        {
                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: " +
                                    this.clickref);

                                //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                //          (task) => this.statusDebug("Search:"),
                                //              TaskScheduler.FromCurrentSynchronizationContext());
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);

                                //SearchAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                //       (task) => this.statusDebug("Search:"),
                                //       TaskScheduler.FromCurrentSynchronizationContext());
                            }
                        }

                        browser.Invoke(new Action(() =>
                        {
                            while (browser.ReadyState != WebBrowserReadyState.Complete)
                            {
                                Application.DoEvents();
                            }
                        }));
                    }
                }
                else
                {

                    //**************************
                    // natural search (click)
                    //**************************
                    this.Csearch = true;

                    if (randomNumber(0, 7) > randomNumber(0, 9))
                    {
                        // Creates an HtmlDocument object from an URL
                        //HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        //doc.LoadHtml(browser.Document.All);

                        int c = 0;
                        string[] links = new string[10];

                        try
                        {
                            HtmlElementCollection elemColl = browser.Document.Links;
                            if (elemColl.Count > 0)
                            {
                                foreach (HtmlElement ele in elemColl)
                                {
                                    if (ele.Parent.TagName == "H2" && c < 10)
                                    {
                                        links[c++] = ele.GetAttribute("href");
                                    }
                                    //MessageBox.Show(ele.InnerText + ele.Parent.TagName);
                                }
                            }
                        }
                        catch { }

                        if (c == 0)
                        {
                            this.qpage = 0;

                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                this.Csearch = true;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);

                                //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                //        (task) => this.statusDebug("Search:"),
                                //            TaskScheduler.FromCurrentSynchronizationContext());

                                browser.Invoke(new Action(() =>
                                {
                                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                                    {
                                        Application.DoEvents();
                                    }
                                }));
                            }
                            else if (statusTxtBox.Text == "Mobilesearches")
                            {
                                // mobile
                                --this.counterMx;
                                counterTxtBox.Text = (this.countDownMobile - this.counterMx) + "/"
                                    + this.countDownMobile;
                                this.Csearch = true;
                                this.clicklist = false;

                                natural_search();
                                this.SubmitSearch();
                            }
                            else
                            {
                                // desktop
                                --this.counterDx;
                                counterTxtBox.Text = (this.countDownDesktop - this.counterDx)
                                    + "/" + this.countDownDesktop;
                                this.Csearch = true;
                                this.clicklist = false;

                                natural_search();
                                this.SubmitSearch();
                            }
                        }
                        else if (c == 1)
                        {
                            //this.clicklist = true;
                            this.clicklink = this.browserUrlTxtbox.Text;
                            try
                            {
                                this.clickref = links[0];
                                if (!String.IsNullOrEmpty(this.clicklink))
                                {
                                    this.Csearch = true;
                                    browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                        + this.clickref);

                                    //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                    //    (task) => this.statusDebug("Search:"),
                                    //        TaskScheduler.FromCurrentSynchronizationContext());

                                    browser.Invoke(new Action(() =>
                                    {
                                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                                        {
                                            Application.DoEvents();
                                        }
                                    }));
                                }
                            }
                            catch { }

                        }
                        else if (c > 1)
                        {
                            c = randomNumber(0, c - 1);
                            this.clicklink = this.browserUrlTxtbox.Text;

                            try
                            {
                                this.clickref = links[c];
                                if (!String.IsNullOrEmpty(this.clicklink))
                                {
                                    this.Csearch = true;
                                    browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                        + this.clickref);

                                    //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                    //    (task) => this.statusDebug("Search:"),
                                    //            TaskScheduler.FromCurrentSynchronizationContext());

                                    browser.Invoke(new Action(() =>
                                    {
                                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                                        {
                                            Application.DoEvents();
                                        }
                                    }));
                                }
                            }
                            catch { }
                        }
                    }
                    else

                    {   //****************
                        // pagination
                        //****************

                        int c = 0; int j = 0; string[] links = new string[4];

                        try
                        {
                            HtmlElementCollection elemColl = browser.Document.Links;
                            foreach (HtmlElement ele in elemColl)
                            {
                                if (ele.Parent.TagName == "LI" && Int32.TryParse(ele.InnerText, out j))
                                {
                                    //MessageBox.Show(ele.InnerText + ele.Parent.TagName);
                                    if (j >= 1 && j <= 10 && c < 4)
                                    {
                                        links[c++] = ele.GetAttribute("href");
                                    }
                                }
                            }
                        }
                        catch { }

                        if (c == 0)
                        {
                            this.qpage = 0;

                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                this.Csearch = true;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);

                                //SearchAsync(this.clicklink, "_self", this.clickref).ContinueWith(
                                //    (task) => this.statusDebug("Search:"),
                                //        TaskScheduler.FromCurrentSynchronizationContext());

                                browser.Invoke(new Action(() =>
                                {
                                    while (browser.ReadyState != WebBrowserReadyState.Complete)
                                    {
                                        Application.DoEvents();
                                    }
                                }));
                            }
                            else if (statusTxtBox.Text == "Mobilesearches")
                            {
                                // mobile
                                --this.counterMx;
                                counterTxtBox.Text = (this.countDownMobile - this.counterMx)
                                    + "/" + this.countDownMobile;
                                this.Csearch = true;
                                this.clicklist = false;

                                natural_search();
                                this.SubmitSearch();
                            }
                            else
                            {
                                // desktop
                                --this.counterDx;
                                counterTxtBox.Text = (this.countDownDesktop - this.counterDx)
                                    + "/" + this.countDownDesktop;
                                this.Csearch = true;
                                this.clicklist = false;

                                natural_search();
                                this.SubmitSearch();
                            }
                        }
                        else if (c > 0)
                        {
                            this.Csearch = true;
                            try
                            {
                                if (this.qpage == 0 && !String.IsNullOrEmpty(links[0]))
                                {
                                    this.qpage = 1;
                                    browser.Navigate(new Uri(links[0]));

                                    //SearchAsync(links[0]).ContinueWith(
                                    //       (task) => this.statusDebug("Search:"),
                                    //        TaskScheduler.FromCurrentSynchronizationContext());

                                    browser.Invoke(new Action(() =>
                                    {
                                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                                        {
                                            Application.DoEvents();
                                        }
                                    }));

                                }
                                else if (this.qpage == 1 && !String.IsNullOrEmpty(links[1]))
                                {
                                    this.qpage = 2;
                                    browser.Navigate(new Uri(links[1]));

                                    //SearchAsync(links[1]).ContinueWith(
                                    //     (task) => this.statusDebug("Search:"),
                                    //        TaskScheduler.FromCurrentSynchronizationContext());

                                    browser.Invoke(new Action(() =>
                                    {
                                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                                        {
                                            Application.DoEvents();
                                        }
                                    }));
                                }
                                else if (this.qpage == 2 && !String.IsNullOrEmpty(links[2]))
                                {
                                    this.qpage = 3;
                                    browser.Navigate(new Uri(links[2]));

                                    //SearchAsync(links[2]).ContinueWith(
                                    //    (task) => this.statusDebug("Search:"),
                                    //        TaskScheduler.FromCurrentSynchronizationContext());

                                    browser.Invoke(new Action(() =>
                                    {
                                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                                        {
                                            Application.DoEvents();
                                        }
                                    }));
                                }
                                else if (this.qpage == 3)
                                {
                                    this.qpage = 0;

                                    natural_search();

                                    if (statusTxtBox.Text == "Mobilesearches")
                                    {
                                        // mobile
                                        --this.counterMx;
                                        counterTxtBox.Text = (this.countDownMobile - this.counterMx)
                                            + "/" + this.countDownMobile;
                                        this.Csearch = true;
                                        this.SubmitSearch();
                                    }
                                    else
                                    {
                                        // desktop
                                        --this.counterDx;
                                        counterTxtBox.Text = (this.countDownDesktop - this.counterDx)
                                            + "/" + this.countDownDesktop;
                                        this.Csearch = true;
                                        this.SubmitSearch();
                                    }
                                }
                            }
                            catch { }
                        }
                    }
                }
            }
        }

        async Task<string> SearchAsync(string url, string target = "", string referrer = "")
        {
            TaskCompletionSource<bool> onloadTcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = null;

            handler = delegate
            {
                this.browser.DocumentCompleted -= handler;

                // attach to subscribe to DOM onload event
                this.browser.Document.Window.AttachEventHandler("onload", delegate
                {
                    // each navigation has its own TaskCompletionSource
                    if (onloadTcs.Task.IsCompleted)
                        return; // this should not be happening
                                // signal the completion of the page loading
                    onloadTcs.SetResult(true);
                });
            };

            // register DocumentCompleted handler
            this.browser.DocumentCompleted += handler;

            // Navigate to url
            if (target != "")
            {
                this.browser.Navigate(new Uri(url), target, null, "Referrer:" + referrer);
            }
            else
            {
                this.browser.Navigate(new Uri(url));
            }

            // continue upon onload
            await onloadTcs.Task;

            // artificial delay for AJAX
            await Task.Delay(POLL_DELAY*2);

            //// get the root element
            //var documentElement = this.browser.Document.GetElementsByTagName("html")[0];

            //// poll the current HTML for changes asynchronosly
            //var html = documentElement.OuterHtml;
            //while (true)
            //{
            //    // wait asynchronously, this will throw if cancellation requested
            //    await Task.Delay(500);

            //    // continue polling if the WebBrowser is still busy
            //    if (this.browser.IsBusy)
            //        continue;

            //    var htmlNow = documentElement.OuterHtml;
            //    if (html == htmlNow)
            //        break; // no changes detected, end the poll loop

            //    html = htmlNow;
            //}

            //mshtml.IHTMLDocument2 htmlDoc = ((dynamic)this.browser.Document.DomDocument) as mshtml.IHTMLDocument2;

            return ((dynamic)this.browser.Document);
        }
        async Task<object> DownloadAsync(string url)
        {
            TaskCompletionSource<bool> onloadTcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = null;

            handler = delegate
            {
                this.browser.DocumentCompleted -= handler;

                // attach to subscribe to DOM onload event
                this.browser.Document.Window.AttachEventHandler("onload", delegate
                {
                    // each navigation has its own TaskCompletionSource
                    if (onloadTcs.Task.IsCompleted)
                        return; // this should not be happening
                                // signal the completion of the page loading
                    onloadTcs.SetResult(true);
                });
            };

            // register DocumentCompleted handler
            this.browser.DocumentCompleted += handler;

            // Navigate to url
            this.browser.Navigate(url);

            // continue upon onload
            await onloadTcs.Task;

            // artificial delay for AJAX
            await Task.Delay(POLL_DELAY * 2);
                        
            // get the root element
            Invoke((MethodInvoker)(() =>
            {
                documentElement = this.browser.Document.GetElementsByTagName("html")[0];
                
                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (this.browser.IsBusy)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    var delay = Task.Run(async () => {
                        await Task.Delay(POLL_DELAY);
                    });

                    // continue polling if the WebBrowser is still busy
                    //if (this.browser.IsBusy)
                    //      continue;

                    documentElement = this.browser.Document.GetElementsByTagName("html")[0];
                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop

                    html = htmlNow;
                }
            }));

            // artificial delay for AJAX
            //await Task.Delay(POLL_DELAY*2);

            return documentElement;

            //return (dynamic)this.browser.Document;
           //return (dynamic)this.browser.Document.DomDocument;
        }

        // http://stackoverflow.com/questions/28526826/web-browser-control-emulation-issue-feature-browser-emulation
        //  dynamic document = await LoadDynamicPage("http://demos.dojotoolkit.org/demos/calendar/demo.html", CancellationToken.None)
        // navigate and download 
        async Task<object> LoadDynamicPage(string url, CancellationToken token)
        {
            
            // navigate and await DocumentCompleted
            var tcs = new TaskCompletionSource<bool>();
            WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                tcs.TrySetResult(true);

            using (token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false))
            {
                this.browser.DocumentCompleted += handler;
                try
                {
                    this.browser.Navigate(url);
                    await tcs.Task; // wait for DocumentCompleted
                }
                finally
                {
                    this.browser.DocumentCompleted -= handler;
                }
            }

            // get the root element
            var documentElement = this.browser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(POLL_DELAY, token);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }

            // consider the page fully rendered 
            token.ThrowIfCancellationRequested();

            return this.browser.Document.DomDocument;
        }

        //**********************
        // Earn dashboardta
        //***********************
        private void earndashboardta(object sender, EventArgs e)
        {
            //statusTxtBox.Text = "Dashboard";
            statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Dashboard");

            //this.toolStripStatusLabel1.Text = "No. Dashboard tasks (" + Convert.ToString(this.numdashboardta) + ")";
            Invoke(new SetToolStripDelegate(SetToolStrip2), "No. Dashboard tasks (" + Convert.ToString(this.numdashboardta) + ")");

            if (this.numdashboardta >= 0)
            {
                this.dashboardtaalt = this.dashboardtaalt ^ 1;
                //this.toolStripStatusLabel1.Text += " Switch:" + Convert.ToString(this.dashboardtaalt);
                Invoke(new SetToolStripDelegate(SetToolStrip), " Switch:" + Convert.ToString(this.dashboardtaalt));

                if (this.dashboardtaalt == 0 || this.numdashboardta == 0)
                {
                    browser.Navigate(new Uri(this.rlink[--this.numdashboardta]));
                    //string url = this.rlink[--this.numdashboardta];

                    //DownloadAsync(url).ContinueWith(
                    //   (task) => this.statusDebug("DB:", true),
                    //       TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

                    //DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                    //   (task) => this.statusDebug("DB:", true),
                    //       TaskScheduler.FromCurrentSynchronizationContext());
                }

                // Restart timer
                //this.timer_dashboardta.Enabled = true;
                //this.statusDebug(" Dashboard:", true);

            }
            else if (this.numdashboardta >= -1)
            {
                --this.numdashboardta;

                // Restart timer
                //this.timer_dashboardta.Enabled = true;
                //this.statusDebug(" Dashboard:", true);

                browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

                //DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                //            (task) => this.statusDebug("DB:",true),
                //                TaskScheduler.FromCurrentSynchronizationContext());

            }
            else
            {
                this.prevpts = 0;
                this.pts = 0;              // Convert.ToInt16(this.pts_txtbox.Text);
                this.pts_txtbox.Text = "0";

                //statusTxtBox.Text = "Connected";
                statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Connected");

                this.iniSearch = true;
                //this.statusDebug(" Dashboard:", true);
                this.timer_dashboardta.Enabled = false;

                browser.Navigate(new Uri("https://www.bing.com"));

                //DownloadAsync("https://www.bing.com").ContinueWith(
                //            (task) => this.statusDebug("DB:",true),
                //                 TaskScheduler.FromCurrentSynchronizationContext());
            }

            browser.Invoke(new Action(() =>
            {
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }));
        }

        //*********************
        // Main Thread
        //*********************

        private void mainT()
        {
            // if context is null, an exception of
            // The current SynchronizationContext may not be used as a TaskScheduler.
            // will be thrown
            if (SynchronizationContext.Current == null)
                SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            while (true)
            {
                iemessagebox();

                if (this.iniSearch == false
                    && this.authLock == false
                    &&  (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                    && !browserUrlTxtbox.Text.Contains(@"landing")
                    && !browserUrlTxtbox.Text.Contains(@"/rewards/dashboard")
                    )
                {
                    //individual time
                    Thread.Sleep(this.timer_auth);

                    // if context is null, an exception of
                    // The current SynchronizationContext may not be used as a TaskScheduler.
                    // will be thrown
                    //if (SynchronizationContext.Current == null)
                    //    SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

                    //var task = DoAuthAsync();
                    //task.ContinueWith((t) =>
                    //{
                    //    this.statusDebug("Auth:");

                    //}, TaskScheduler.FromCurrentSynchronizationContext());

                    string[] authstr = new string[4];
                    this.statusDebug("Initial:");

                    ++this.vrndnum;

                    int a = 0;
                    int[] v = new int[accountVisited.Count];
                    for (int i = 0, b = this.accountVisited.Count; i < b; i++)
                    {
                        if (this.accountVisited[i] == false)
                        {
                            v[a++] = i;
                        }
                    }
                    --a;

                    //********************
                    // random visited
                    //********************

                    if (this.vrndnum <= accounts.Count()
                        && this.checkaccount == false
                        && (this.authLock == false)
                        && a >= 0
                        )
                    {
                        this.subgetip();

                        if (randomo.Checked == true)
                        {
                            this.accountNum = v[this.randomNumber(0, a)];
                        } else
                        {
                            this.accountNum++;
                        }

                        if (a >= 0 && this.accountNum < this.accounts.Count())
                        {
                            Array.Clear(authstr, 0, authstr.Length);
                            authstr = this.accounts[this.accountNum].Split('/');
                            this.username = authstr[0];
                            this.password = authstr[1];
                            string proxy = "";
                            string[] paddr = authstr[1].Split(' ');
                            if (paddr.Length >= 2 && paddr[1] != null)
                            {
                                this.password = paddr[0];
                                proxy = paddr[1];
                            }

                            if (proxy != "")
                            {
                                RefreshIESettings(proxy);
                            }
                            
                            SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                            dbcon.Open();
                            DateTime dateTime = DateTime.UtcNow.Date;
                            SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                                this.username +
                                "' and date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "'",
                                dbcon);
                            SQLiteDataReader reader = command.ExecuteReader();

                            int num = 0;
                            while (reader.Read())
                            {
                                num = Convert.ToInt32(reader["count(*)"]);
                            }
                            dbcon.Close();

                            if (num > 0)
                            {
                                dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                dbcon.Open();
                                command = new SQLiteCommand("select * from searches where date='" +
                                    dateTime.ToString("yyyyMMdd") +
                                    "' and points<>4242" +
                                    " and account='" +
                                    this.username +
                                    "' order by ip,points",
                                    dbcon);
                                reader = command.ExecuteReader();

                                int pts = 0;
                                while (reader.Read())
                                {
                                    if (reader["points"] != null)
                                    {
                                        pts += Convert.ToInt32(reader["points"]);
                                    }
                                }
                                dbcon.Close();
                            }
                        }

                        if (a >= 0 && pts < MSPOINTS &&
                            this.accountNum < this.accounts.Count() &&
                            this.accountVisited[this.accountNum] == false &&
                            (this.country == "US" || this.country == "IN" || this.country == "AU" || chkbox_tor.Checked == false))
                        {
                            //http://stackoverflow.com/questions/904478/how-to-fix-the-memory-leak-in-ie-webbrowser-control
                            GC.Collect();

                            this.authLock = true;
                            this.vrndnum = 0;
                            this.dashboardta = false;
                            this.ldashboardta = false;
                            this.iniSearch = false;
                            this.pts = 0;
                            this.siguid = "";

                            string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                            this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                                Convert.ToInt32(wait[1]));
                            this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                                Convert.ToInt32(wait[1]));

                            this.ChangeUserAgent(this.txtboxcustomdesktop.Text);

                            //http://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                            var timeSpan = "ct=" + Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds,0);
                            string logout = BRSOUT.Replace("ct=1476458234", timeSpan);
                            //logout = logout.Replace("id=292666", "id="+randomNumber(100000, 900000));

                            DownloadAsync(logout).ContinueWith(
                                (task) => this.statusDebug("PC1:"),
                                    TaskScheduler.FromCurrentSynchronizationContext());

                            //DoLogin();

                        }
                        else if (a >= 0 && this.accountNum < this.accounts.Count())
                        {
                            ++this.accountVisitedX;
                            this.accountVisited[this.accountNum] = true;

                            if (randomNumber(0, 12) > (randomNumber(0, 6)))
                            {
                                this.toridswitcher();
                            }

                            this.dxloops = 0;
                            this.mxloops = 0;
                            this.iniSearch = false;
                            this.dashboardta = false;
                            this.ldashboardta = false;
                            this.Csearch = false;

                            try
                            {
                                int num = this.numIpDate();

                                if (num == 0)
                                {
                                    SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                    dbcon.Open();
                                    DateTime dateTime = DateTime.UtcNow.Date;
                                    SQLiteCommand command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                        dateTime.ToString("yyyyMMdd") +
                                        "','" +
                                        this.ip +
                                        "','" +
                                        this.username +
                                        "','4242')",
                                        dbcon);
                                    command.ExecuteNonQuery();
                                    dbcon.Close();
                                }
                            }
                            catch { }

                            if ((this.country != "US" || this.country != "IN") && chkbox_tor.Checked == true)
                            {
                                this.toridswitcher();
                            }

                            statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Authenticate");
                            string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                            int z = randAuthTimer(Convert.ToInt32(auth[0]),
                                Convert.ToInt32(auth[1]));

                            this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                            counterTxtBox.SafeInvoke(() => counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.");
                            
                            this.authLock = false;
                            this.statusDebug("PC3:");
                        }
                    }
                    /*
                    else if (this.checkaccount == false && a >= 0 && this.accountNum < this.accounts.Count())
                    {
                    ++this.accountVisitedX;
                    this.accountVisited[this.accountNum] = true;

                    statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Authenticate");

                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = randAuthTimer(Convert.ToInt32(auth[0]),
                    Convert.ToInt32(auth[1]));

                    this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                    counterTxtBox.SafeInvoke(() =>  counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec."); 

                    this.authLock = false;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.statusDebug("PC5:");
                }
                */
                else if (this.checkaccount == false && this.vrndnum > accounts.Count())
                    {
                        int pts = 0;
                        try
                        {
                            pts = Convert.ToInt32(pts_txtbox.Text);
                        }
                        catch { }

                        if (pts >= MSPOINTS
                            || String.IsNullOrEmpty(pts_txtbox.Text)
                            || pts_txtbox.Text == "0"
                            || pts_txtbox.Text == "-")
                        {
                            SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                            dbcon.Open();
                            DateTime dateTime = DateTime.UtcNow.Date;
                            SQLiteCommand command = new SQLiteCommand("update searches set points='4242' WHERE ip='" +
                                this.ip +
                                "' and date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='" +
                                this.username +
                                "'",
                                dbcon);
                            command.ExecuteNonQuery();
                            dbcon.Close();
                        }

                        button1.SafeInvoke(() => this.button1.Text = "Start");
                        statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Stop");
                        counterTxtBox.SafeInvoke(() => counterTxtBox.Text = "0/0");

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.vrndnum = 0;
                        this.authLock = false;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.siguid = "";

                        this.statusDebug("Stop:");

                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        if (this.timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                        }

                        if (this.timer_dashboardta != null)
                        {
                            this.timer_dashboardta.Enabled = false;
                        }
                    }                    
                    else if (this.checkaccount == true && this.accountNum < this.accounts.Count())
                    {
                        string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                        this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1]));
                        this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1]));

                        authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string proxy = "";
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            proxy = paddr[1];
                        }

                        if (proxy != "")
                        {
                            RefreshIESettings(proxy);
                        }

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.authLock = true;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.iniSearch = false;

                        this.ChangeUserAgent(this.txtboxcustomdesktop.Text);

                        //http://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                        var timeSpan = "ct=" + Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds, 0);
                        string logout = BRSOUT.Replace("ct=1476458234", timeSpan);
                        //logout = logout.Replace("id=292666", "id=" + randomNumber(100000, 900000));

                        DownloadAsync(logout).ContinueWith(
                          (task) => this.statusDebug("PC1:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                        
                        //DoLogin();
                    }
                }

                Thread.Sleep(SLEEPMAIN);
                ++this.pccounter;

                if (this.WDCounter > WATCHDOG)
                {
                    this.WDCounter = 0;
                   
                    if ((browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing")
                            || browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/?lang=hi-IN&refd=account.live.com&refp=landing")
                            || browserUrlTxtbox.Text == "https://account.microsoft.com/rewards/dashboard?refd=www.bing.com"
                            || browserUrlTxtbox.Text == "https://account.microsoft.com/rewards/welcome?refd=www.bing.com"
                            || browserUrlTxtbox.Text == "https://account.microsoft.com/")
                            || browserUrlTxtbox.Text == "https://account.microsoft.com/rewards/dashboard"
                            && this.dashboardta == false && this.iniSearch == false
                        )
                    {
                        if (chkbox_autorotate.Checked == true
                           )
                        {
                            this.accountVisited[this.accountNum] = true;
                            ++this.accountVisitedX;

                            string[] authstr = this.accounts[this.accountNum].Split('/');
                            this.username = authstr[0];
                            this.password = authstr[1];
                            string proxy = "";
                            string[] paddr = authstr[1].Split(' ');
                            if (paddr.Length >= 2 && paddr[1] != null)
                            {
                                this.password = paddr[0];
                                proxy = paddr[1];
                            }

                            accountNameTxtBox.SafeInvoke(() => accountNameTxtBox.Text = this.username);
                            accountNrTxtBox.SafeInvoke(() => accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count);

                            this.prevpts = 0;
                            this.pts = 0;
                            pts_txtbox.SafeInvoke(() => this.pts_txtbox.Text = "0");

                            statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Connected");
                            counterTxtBox.SafeInvoke(() => counterTxtBox.Text = "0/0");

                            this.dxloops = 0;
                            this.mxloops = 0;

                            this.authLock = true;
                            this.iniSearch = false;
                            this.dashboardta = false;
                            this.ldashboardta = false;
                            this.Csearch = false;

                            this.initUserSQL();

                           
                                // first step after user auth (very important) navigate bing.com or bing.com/rewards
                                //browser.Navigate(new Uri("https://www.bing.com/rewards"));
                                browser.Invoke(new Action(() =>
                                {
                                    browser.Navigate(new Uri("https://www.bing.com/rewards"));
                                }));
                       
                        }
                    }
                    //else if (browserUrlTxtbox.Text == "https://account.microsoft.com/rewards/dashboard"
                    // && this.statusTxtBox.Text == "Connected"
                    // && chkbox_autorotate.Checked == true
                    // && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                    // && this.iniSearch == false
                    // && this.dashboardta == false
                    // && this.ldashboardta == false
                    // )
                    //{
                    //    try
                    //    {
                    //        browser.Invoke(new Action(() =>
                    //        {
                    //            browser.Navigate(new Uri("https://www.bing.com"));
                    //        }));
                    //    }
                    //    catch { }
                    //}
                    else if (browserUrlTxtbox.Text.Contains(@"https://www.bing.com")
                     && this.statusTxtBox.Text == "Connected"
                     && chkbox_autorotate.Checked == true
                     && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                     && this.iniSearch == false
                     && this.dashboardta == false
                     && this.ldashboardta == false
                     //&& !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                     )
                    {
                        statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Dashboard");

                        if (timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                            this.Csearch = false;
                        }

                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string proxy = "";
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            proxy = paddr[1];
                        }

                        accountNameTxtBox.SafeInvoke(() => accountNameTxtBox.Text = this.username);
                        accountNrTxtBox.SafeInvoke(() => accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count);

                        //this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                        Invoke(new SetToolStripDelegate(SetToolStrip2), "Initial dashboard tasks!");
                        this.dashboardta = true;

                       
                            browser.Invoke(new Action(() =>
                            {
                                browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                            }));
            
                    }                   
                    else if (
                        (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                        && this.chkbox_autorotate.Checked == true
                        && this.authLock == true
                        && this.browserUrlTxtbox.Text.Contains(@"https://www.bing.com/rewards/unsupportedmarket")
                    )
                    {
                        DoUnsupportedMarket();
                    }
                    // else if (this.checkaccount == false
                    // && (this.Csearch == true || this.clicklist == true)
                    // && this.authLock == true
                    // && (url.Contains(@"search?q=")
                    //    || wb.Document.GetElementById("sb_form_q") != null)
                    //&& this.statusTxtBox.Text != "Dashboard"

                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                             && this.chkbox_autorotate.Checked == true
                             && this.authLock == false
                             && this.statusTxtBox.Text == "Authenticate"
                             && (this.browserUrlTxtbox.Text.Contains(@"https://www.bing.com/rewards/dashboard")
                             || this.browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/rewards/dashboard"))
                      )
                    {
                        DoUnsupportedMarket();
                    }
                    // else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                    //    && this.chkbox_autorotate.Checked == true
                    //    && this.authLock == true
                    //    && this.browserUrlTxtbox.Text == ("https://account.microsoft.com/account/general")
                    //    && this.statusTxtBox.Text == "Connected"
                    // )
                    // {
                    //     ++this.accountVisitedX;
                    //     this.restartAuth();
                    // }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                       && this.chkbox_autorotate.Checked == true
                       && this.authLock == true
                       && (this.browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/?lang") ||
                          this.browserUrlTxtbox.Text.Contains(@"https://bing.com"))
                       && (this.statusTxtBox.Text == "Authenticate" || this.statusTxtBox.Text == "Connected")
                    )
                    {                       
                            browser.Invoke(new Action(() =>
                            {
                                browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                            }));
                   }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                       && this.statusTxtBox.Text == "Authenticate"
                       && this.toolStripStatusLabel1.Text.Contains(@"PC")
                       && !this.toolStripStatusLabel1.Text.Contains(@"Init")
                       && !this.toolStripStatusLabel1.Text.Contains(@"Connected")
                       && this.chkbox_autorotate.Checked == true
                       && this.authLock == false
                       && !this.browserUrlTxtbox.Text.Contains(@"landing")
                       )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;
                        this.restartAuth();
                    }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                        && (this.statusTxtBox.Text == "Working" ||
                        (this.toolStripStatusLabel1.Text.Contains(@"Working##") && this.statusTxtBox.Text != "Connected"))
                        && this.chkbox_autorotate.Checked == true
                        && this.authLock == true
                        && !this.browserUrlTxtbox.Text.Contains(@"landing")
                        )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;
                        this.restartAuth();
                    }
                    //else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                    //        && this.chkbox_autorotate.Checked == true
                    //        && browserUrlTxtbox.Text.Contains(@"https://www.google")
                    //        && this.statusTxtBox.Text == "Authenticate"
                    //    )
                    //{
                    // first step before sign-in
                    //    NewLoginAsync(BRSIN2).ContinueWith(
                    //        (task) => this.statusDebug("S2:"),
                    //            TaskScheduler.FromCurrentSynchronizationContext());
                    //}

                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                          && this.authLock == true
                          && this.chkbox_autorotate.Checked == true
                          && (this.statusTxtBox.Text == "Dashboard"
                          || this.toolStripStatusLabel1.Text.Contains(@"Finalize")
                          || this.statusTxtBox.Text == "UMarket")
                          && !this.toolStripStatusLabel1.Text.Contains(@"Searching")
                          //&& !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                      )
                    {
                        statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Dashboard");

                        if (timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                            this.Csearch = false;
                        }

                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string proxy = "";
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            proxy = paddr[1];
                        }

                        accountNameTxtBox.SafeInvoke(() => accountNameTxtBox.Text = this.username);
                        accountNrTxtBox.SafeInvoke(() => accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count);

                        //this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                        Invoke(new SetToolStripDelegate(SetToolStrip2), "Initial dashboard tasks!");

                        this.dashboardta = true;

                        //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                       
                            browser.Invoke(new Action(() =>
                            {
                                browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                            }));


                    }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                        && this.statusTxtBox.Text == "Dashboard"
                        && this.chkbox_autorotate.Checked == true
                        && this.numdashboardta < -1
                        && !this.browserUrlTxtbox.Text.Contains(@"landing")
                         )
                    {
                        if (this.timer_dashboardta == null)
                        {
                            this.timer_dashboardta = new System.Timers.Timer();
                            this.timer_dashboardta.AutoReset = true;
                            this.timer_dashboardta.Elapsed += new ElapsedEventHandler(earndashboardta);
                        }

                        this.timer_dashboardta.Interval = SLEEPDASHBOARD;   // Timer will tick every 10 seconds
                        this.timer_dashboardta.Enabled = true;
                        this.statusDebug("Restart DBT:");
                    }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                        && this.statusTxtBox.Text == "Connected"
                        && this.chkbox_autorotate.Checked == true
                        && this.numdashboardta < -1
                        && this.iniSearch == true
                        && this.checkaccount == false
                    )
                    {
                       
                            browser.Invoke(new Action(() =>
                            {
                                browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                            }));

                    }
                    else if ((browserUrlTxtbox.Text.Contains(@"https://account.live.com/identity/confirm")
                     || browserUrlTxtbox.Text.Contains(@"https://account.live.com/recover")
                     || browserUrlTxtbox.Text.Contains(@"https://account.live.com/Abuse")
                     || browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/rewards/error")
                     || browserUrlTxtbox.Text.Contains(@"https://login.live.com/ppsecure/post.srf")
                     || browserUrlTxtbox.Text.Contains(@"https://account.live.com/tou/accrue?ru=https://login.live.com/login.srf")
                     || (browserUrlTxtbox.Text.Contains(@"https://www.bing.com")
                     && this.statusTxtBox.Text != "Connected"
                     && this.statusTxtBox.Text != "Working"
                     && this.statusTxtBox.Text != "Dashboard"
                     && this.statusTxtBox.Text != "Desktopsearches"
                     && this.statusTxtBox.Text != "Mobilesearches")
                     && !this.toolStripStatusLabel1.Text.Contains(@"Connected")
                     )
                     && chkbox_autorotate.Checked == true
                     && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                     )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;
                        this.restartAuth();
                    }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                      && this.chkbox_autorotate.Checked == true
                      && this.authLock == true
                      && !this.browserUrlTxtbox.Text.Contains("@https://login.live.com/ppsecure/post.srf?wa=wsignin")
                      && !this.browserUrlTxtbox.Text.Contains("@https://login.live.com/login.srf?wa=wsignin")
                      && !this.browserUrlTxtbox.Text.Contains("@https://login.live.com/logout.srf")
                      && this.statusTxtBox.Text == "Authenticate"
                 )
                    {
                        ++this.accountVisitedX;
                        this.restartAuth();
                    }
                    else if ((this.button1.Text == "Stop" || this.button1.Text == "Auto")
                      && this.statusTxtBox.Text != "Authenticate"
                      && this.statusTxtBox.Text != "Stop"
                      && this.authLock == true
                      && this.Csearch == true
                      && !this.browserUrlTxtbox.Text.Contains(@"landing")
                      && !this.browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/account/general")
                      )
                    {
                        this.statusDebug("Refresh:");

                        if (this.timer_searches == null)
                        {
                            this.timer_searches = new System.Timers.Timer();
                            this.timer_searches.AutoReset = false;
                            this.timer_searches.Elapsed += new ElapsedEventHandler(DoSearch);
                        }

                        string[] wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                        this.timer_searches.Interval = randNumTimer(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1])) * 1000;

                        this.Csearch = true;
                        this.timer_searches.Enabled = true;
                        //this.timer_searches.Start();

                        //https://login.live.com/ppsecure/post.srf
                        if (browserUrlTxtbox.Text.Contains(@"https://account.live.com/identity/confirm")
                            || browserUrlTxtbox.Text.Contains(@"https://account.live.com/recover")
                            || browserUrlTxtbox.Text.Contains(@"https://account.live.com/Abuse")
                            || browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/rewards/error")
                            || browserUrlTxtbox.Text.Contains(@"https://login.live.com/ppsecure/post.srf")
                            || browserUrlTxtbox.Text.Contains(@"https://account.live.com/tou/accrue?ru=https://login.live.com/login.srf")
                            && !this.browserUrlTxtbox.Text.Contains(@"landing")
                        )
                        {
                            //http://stackoverflow.com/questions/12386071/threading-and-webbrowser-control
                            try
                            {
                                //browser.Invoke(new Action(() =>
                                //{
                                //    browser.Navigate(new Uri("http://www.google.com"));
                                //}));

                                // first step before sign-in
                                //http://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                                var timeSpan = "ct=" + Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds, 0);
                                string logout = BRSOUT.Replace("ct=1476458234", timeSpan);
                                //logout = logout.Replace("id=292666", "id=" + randomNumber(100000, 900000));

                                DownloadAsync(logout).ContinueWith(
                                        (task) => this.statusDebug("PC1:"),
                                        TaskScheduler.FromCurrentSynchronizationContext());
                            }
                            catch { }
                        }
                        else
                        {
                          
                                browser.Invoke(new Action(() =>
                                {
                                    browser.Navigate(new Uri(browserUrlTxtbox.Text));
                                }));

                        }
                    }

                    if (this.checkaccount == false)
                    {
                       //browser.Navigate(new Uri(this.browserUrlTxtbox.Text));
                        //browser.Refresh(WebBrowserRefreshOption.Completely);
                        DownloadAsync(this.browserUrlTxtbox.Text).ContinueWith(
                          (task) => this.statusDebug("Refresh:"),
                           TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    browser.Invoke(new Action(() =>
                    {
                        while (browser.ReadyState != WebBrowserReadyState.Complete)
                        {
                            Application.DoEvents();
                        }
                    }));
                }
                else
                {
                    ++this.WDCounter;
                }
                
                //http://stackoverflow.com/questions/7181756/invoke-or-begininvoke-cannot-be-called-on-a-control-until-the-window-handle-has#
                //http://stackoverflow.com/questions/1127973/how-do-i-make-cross-threaded-calls-to-a-toolstripstatuslabel
                //https://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k(EHInvalidOperation.WinForms.IllegalCrossThreadCall);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5.2);k(DevLang-csharp)&rd=true
                if (this.toolStripStatusLabel1.Text.Length < 70)
                {
                    if (IsHandleCreated)
                    {
                        try
                        {
                            Invoke(new SetToolStripDelegate(SetToolStrip), "." + Convert.ToString(this.WDCounter));
                        }
                        catch { }
                    }
                }
                else if (this.authLock == true
                        && this.checkaccount == false
                        && (this.button1.Text == "Stop" || this.button1.Text == "Auto"))
                {
                    //this.authLock = false;
                    //this.dxloops = 0;
                    //this.mxloops = 0;
                    //this.vrndnum = 0;
                    //this.authLock = false;
                    //this.iniSearch = false;
                    //this.dashboardta = false;
                    //this.ldashboardta = false;
                    //this.Csearch = false;

                    this.statusDebug("PCR1:");
                    if (IsHandleCreated)
                    {
                       
                            Invoke(new SetToolStripDelegate(SetToolStrip), "." + Convert.ToString(this.WDCounter));
        
                    }
                }
                else
                {
                    this.statusDebug("PCR2:");

                    if (IsHandleCreated)
                    {
                       
                            Invoke(new SetToolStripDelegate(SetToolStrip), "." + Convert.ToString(this.WDCounter));
         
                    }
                }
            }
        }

        private delegate void SetToolStripDelegate(string text);

        private void SetToolStrip(string text)
        {
            this.toolStripStatusLabel1.Text += text;
        }

        private void SetToolStrip2(string text)
        {
            this.toolStripStatusLabel1.Text = text;
        }

        private void restartAuth()
        {
            int v = 0;
            for (int i = 0, b = this.accountVisited.Count; i < b; i++)
            {
                if (this.accountVisited[i] == false)
                {
                    ++v;
                }
            }
            --v;

            if (v < 0)
            {
                if (this.dxloops >= MAXLOOPS && this.mxloops >= MAXLOOPS)
                {

                    //this.button1.Text = "Start";
                    //statusTxtBox.Text = "Stop";
                    //counterTxtBox.Text = "0/0";

                    button1.SafeInvoke(() => this.button1.Text = "Start");
                    statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Stop");
                    counterTxtBox.SafeInvoke(() => statusTxtBox.Text = "0/0");

                    //this.dxloops = 0;
                    //this.mxloops = 0;
                    //this.logtries = 0;
                    //this.vrndnum = 0;
                    this.authLock = false;

                    //this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.siguid = "";

                    this.statusDebug("Stop:");

                    if (this.timer_tor != null)
                    {
                        this.timer_tor.Enabled = false;
                    }

                    if (this.timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                    }

                    if (this.timer_dashboardta != null)
                    {
                        this.timer_dashboardta.Enabled = false;
                    }
                }
            }
            else
            {
                this.accountVisited[this.accountNum] = true;
                ++this.accountVisitedX;

                string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                int z = randAuthTimer(Convert.ToInt32(auth[0]),
                    Convert.ToInt32(auth[1]));

                this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                counterTxtBox.SafeInvoke(() => counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.");

                string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                    Convert.ToInt32(wait[1]));
                this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                    Convert.ToInt32(wait[1]));

                this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                //this.ClearCache();

                this.authLock = false;
                this.vrndnum = 0;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;
                this.siguid = "";

                this.statusDebug("Restart:");
                //this.statusTxtBox.Text = "Authenticate";
                statusTxtBox.SafeInvoke(() => statusTxtBox.Text = "Authenticate");
            }
        }

        //**********************
        // Url bar
        //**********************

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string url = tb.Text;

            if (e.KeyCode == Keys.Enter)
            {
                //string target = "";
                //string authHeader = "User-Agent: Mozilla/5.0 (iPhone; U; CPU like Mac OS X; en) AppleWebKit/00+ (KHTML, like Gecko) Version/3.0 Mobile/1A543 Safari/419.3\r\n";
                //string authHeader = "User-Agent: Mozilla/5.0(iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit / 534.46.0(KHTML, like Gecko) CriOS / 19.0.1084.60 Mobile / 9B206 Safari/ 7534.48.3\r\n";
                //string authHeader = "User-Agent: Mozilla/5.0(Linux; U; Android 4.0.3; ko - kr; LG - L160L Build / IML74K) AppleWebkit / 534.30(KHTML, like Gecko) Version / 4.0 Mobile Safari/ 534.30\r\n";

                if (url.StartsWith("geoip"))
                {
                    browser.Navigate(new Uri("http://www.iplocation.net"));
                }
                else if (url.StartsWith("bingr"))
                {
                    browser.Navigate(new Uri("http://www.bing.com/rewards"));
                }
                else if (url.StartsWith("svenja"))
                {
                    var salt = System.Text.Encoding.UTF8.GetBytes("/Xp7P1TZevrkX+qzrILr0aGI4XM=");
                    var hmacSHA1 = new HMACSHA1(salt);
                    MessageBox.Show(Convert.ToBase64String(hmacSHA1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(this.passwd_txtbox.Text))));
                }
                else if (url.StartsWith("mobile"))
                {
                    this.ChangeUserAgent(this.txtboxcustommobile.Text);
                }
                else if (url.StartsWith("desktop"))
                {
                    this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                }
                else if (url.StartsWith("redeem"))
                {
                    this.ChangeUserAgent(this.txtboxcustommobile.Text);
                    browser.Navigate("https://www.bing.com/rewards/redeem/all");
                }
                else if (url.StartsWith("amazon"))
                {
                    this.ChangeUserAgent(this.txtboxcustommobile.Text);
                    browser.Navigate("https://www.bing.com/rewards/redeem/000100004");
                }
                else if (url.StartsWith("bing"))
                {
                    browser.Navigate(new Uri("http://www.bing.com"));
                }
                else if (url.StartsWith("login"))
                {
                    browser.Navigate(new Uri("https://login.live.com"));
                }
                else if (url.StartsWith("checktor") || url.StartsWith("tor"))
                {
                    browser.Navigate(new Uri("https://check.torproject.org/"));
                }
                else if (url.StartsWith("http://"))
                {
                    browser.Navigate(new Uri(url));
                }
                else if (url.StartsWith("https://"))
                {
                    browser.Navigate(new Uri(url));
                }
                else if (url.StartsWith("www"))
                {
                    browser.Navigate(new Uri("http://" + url));
                }
                else
                {
                    browser.Navigate(new Uri("http://www.bing.com/search?q=" + url));
                }

                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }
        }

        private void log_Enter(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 2:

                    log.Items.Clear();
                    ListViewItem itm;

                    itm = new ListViewItem("Settings:");
                    log.Items.Add(itm);

                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_tor == true ? "Tor:true" : "Tor:false");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_mobile == true ? "Mobile S:true" : "Mobile S:false");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_desktop == true ? "Desktop S:true" : "Desktop S:false");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_autorotate == true ? "Autorotate:true" : "Autorotate:false");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_chkbox_as == true ? "Autostart:true" : "Autostart:false");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Autostart delay time:" + BingRewardsBot.Properties.Settings.Default.set_autostart);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("S. counter:" + BingRewardsBot.Properties.Settings.Default.set_counter);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Wait time s.:" + BingRewardsBot.Properties.Settings.Default.set_waitsearches);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Wait time a.:" + BingRewardsBot.Properties.Settings.Default.set_waitauth);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_randomo == true ? "AR. random order:true" : "AR. random order:false");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Desktop browser agent:" + BingRewardsBot.Properties.Settings.Default.set_uadesktop);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Mobile browser agent:" + BingRewardsBot.Properties.Settings.Default.set_uamobile);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Account filename:" + BingRewardsBot.Properties.Settings.Default.set_accounts);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Number of accounts:" + this.accounts.Count);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Proxy settings:" + BingRewardsBot.Properties.Settings.Default.set_proxy);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem("Tor settings:" + BingRewardsBot.Properties.Settings.Default.set_torsettings);
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);
                    itm = new ListViewItem(BingRewardsBot.Properties.Settings.Default.set_lang == 0 ? "Lang: US" : "Lang: IN");
                    itm.Font = new Font(log.Font, FontStyle.Regular);
                    log.Items.Add(itm);

                    uint browserVersion = GetBrowserEmulationMode();

                    switch (browserVersion)
                    {
                        case 7:
                            //mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                            itm = new ListViewItem("IE settings: IE7 Standards mode");
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            break;
                        case 8:
                            //mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                            itm = new ListViewItem("IE settings: IE8 Standards mode");
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            break;
                        case 9:
                            //mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                            itm = new ListViewItem("IE settings: IE9 Standards mode");
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            break;
                        case 10:
                            //mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                            itm = new ListViewItem("IE settings: IE10 Standards mode");
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            break;
                        default:
                            // use IE11 mode by default
                            itm = new ListViewItem("IE settings: IE11 Standards mode");
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            break;
                    }


                    itm = new ListViewItem(" ");
                    log.Items.Add(itm);

                    // Accounts with current ip:

                    itm = new ListViewItem("Accounts with current IP:");
                    log.Items.Add(itm);

                    SQLiteConnection conn = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                    conn.Open();

                    string sql = "select * from searches where ip='" + this.ip + "' group by account,ip";
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();
                    string[] aarr = new string[FREEA];

                    int i = 0;
                    while (reader.Read() && i < FREEA)
                    {
                        aarr[i] = Convert.ToString(reader["account"]);
                        itm = new ListViewItem(aarr[i++]);
                        log.Items.Add(itm);
                    }

                    if (i == 0)
                    {
                        itm = new ListViewItem("-");
                        itm.Font = new Font(log.Font, FontStyle.Regular);
                        log.Items.Add(itm);
                    }

                    // IP addresses (from last user)

                    itm = new ListViewItem(" ");
                    log.Items.Add(itm);

                    itm = new ListViewItem("IP addresses used by current account:");
                    log.Items.Add(itm);
                                        
                    sql = "select * from searches where account='" +
                        this.username + "' group by account,ip";
                    command = new SQLiteCommand(sql, conn);
                    reader = command.ExecuteReader();

                    string[] iparr = new string[10];
                    i = 0;
                    while (reader.Read() && i < 10)
                    {
                        iparr[i] = Convert.ToString(reader["ip"]);

                        itm = new ListViewItem(iparr[i++]);
                        itm.Font = new Font(log.Font, FontStyle.Regular);
                        log.Items.Add(itm);

                    }
                    if (i == 0)
                    {
                        itm = new ListViewItem("-");
                        itm.Font = new Font(log.Font, FontStyle.Regular);
                        log.Items.Add(itm);
                    }


                    // Last searches: Score today

                    DateTime dateTime = DateTime.UtcNow.Date;
                    sql = "select * from searches where date='" +
                    dateTime.ToString("yyyyMMdd") + "' group by account";
                    command = new SQLiteCommand(sql, conn);
                    reader = command.ExecuteReader();

                    string[] uarr = new string[60];
                    i = 0;

                    while (reader.Read() && i < 60)
                    {
                        uarr[i++] = Convert.ToString(reader["account"]);
                    }

                    i = 0;
                    int[] parr = new int[60];

                    foreach (string ele in uarr)
                    {
                        if (ele != null && ele != "")
                        {
                            sql = "select * from searches where date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='"
                                + ele +
                                "' and points<>4242";
                            command = new SQLiteCommand(sql, conn);
                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                parr[i] += Convert.ToInt32(reader["points"]);
                            }
                            i++;
                        }
                    }

                    itm = new ListViewItem(" ");
                    log.Items.Add(itm);

                    itm = new ListViewItem("Score today:");
                    log.Items.Add(itm);

                    i = 0;

                    foreach (string ele in uarr)
                    {
                        if (ele != null && ele != "")
                        {
                            itm = new ListViewItem(uarr[i] + " " + Convert.ToString(parr[i]));
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            ++i;
                        }
                    }


                    // Last searches: Score yesterday
                    //http://stackoverflow.com/questions/8203900/how-get-yesterday-and-tomorrow-datetime-in-c-sharp

                    i = 0;
                    foreach (string ele in uarr)
                    {
                        uarr[i++] = "";
                    }

                    dateTime = DateTime.UtcNow.Date.AddDays(-1);
                    sql = "select * from searches where date='" +
                    dateTime.ToString("yyyyMMdd") + "' group by account";
                    command = new SQLiteCommand(sql, conn);
                    reader = command.ExecuteReader();

                    i = 0;
                    while (reader.Read() && i < 60)
                    {
                        uarr[i++] = Convert.ToString(reader["account"]);
                    }


                    i = 0;
                    foreach (int ele in parr)
                    {
                        parr[i++] = 0;
                    }
                    i = 0;

                    foreach (string ele in uarr)
                    {
                        if (ele != null && ele != "")
                        {
                            sql = "select * from searches where date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='"
                                + ele +
                                "' and points<>4242";
                            command = new SQLiteCommand(sql, conn);
                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                parr[i] += Convert.ToInt32(reader["points"]);
                            }
                            i++;
                        }
                    }

                    itm = new ListViewItem(" ");
                    log.Items.Add(itm);

                    itm = new ListViewItem("Score yesterday:");
                    log.Items.Add(itm);

                    i = 0;
                    foreach (string ele in uarr)
                    {
                        if (ele != null && ele != "")
                        {
                            itm = new ListViewItem(uarr[i] + " " + Convert.ToString(parr[i]));
                            itm.Font = new Font(log.Font, FontStyle.Regular);
                            log.Items.Add(itm);
                            ++i;
                        }
                    }

                    conn.Close();

                    break;
            }

            this.ResizeColumnHeaders();
        }

        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < this.log.Columns.Count - 1; i++) this.log.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.log.Columns[this.log.Columns.Count - 1].Width = -2;
        }

        //****************************************************
        // start button
        //****************************************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void onClickStart(object sender, EventArgs e)
        {
            BingRewardsBot.Properties.Settings.Default.Save();

            bool autorotate = chkbox_autorotate.Checked == true ? true : false;

            this.startbtn = this.startbtn ^ 1;
            if (this.startbtn == 0)
            {               
                this.dxloops = 0;
                this.mxloops = 0;
                this.button1.Text = "Start";
                this.checkaccount = false;
                this.authLock = false;
                this.vrndnum = 0;
                this.accountVisitedX = 0;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;
                this.counterDx = this.countDownDesktop = this.counterMx = this.countDownMobile = 0;

                if (this.timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                }
            }
            else
            {
                this.button1.Text = "Stop";

                if (this.randomo.Checked == false)
                {
                    this.accountNum = -1;

                } else {

                    this.accountNum = 0;
                }

                if (chkbox_autorotate.Checked == false)
                {
                    this.dxloops = 0;
                    this.mxloops = 0;

                    // start search bot
                    statusTxtBox.Text = "Searches";
                    this.checkaccount = false;
                    this.authLock = true;
                    this.vrndnum = 0;
                    this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;

                    string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                    this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));
                    this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));

                    if (this.timer_searches == null)
                    {
                        this.timer_searches = new System.Timers.Timer();
                        this.timer_searches.AutoReset = false;
                        this.timer_searches.Elapsed += new ElapsedEventHandler(DoSearch);
                    }

                    wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                    this.timer_searches.Interval = randNumTimer(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1])) * 1000;

                    this.Csearch = false;
                    this.authLock = true;
                    this.timer_searches.Enabled = true;

                    try
                    {
                        if (browser.Document.GetElementById("sb_form_q") != null)
                        {
                            bool mobile = BingRewardsBot.Properties.Settings.Default.set_mobile;
                            bool desktop = BingRewardsBot.Properties.Settings.Default.set_desktop;

                            natural_search();

                            statusTxtBox.Text = desktop == true ? "Desktopsearches" : "Mobilesearches";

                            if (mobile == true)
                            {
                                --this.counterMx;
                                counterTxtBox.Text = (this.countDownMobile - this.counterMx) +
                                    "/" + this.countDownMobile;
                                this.Csearch = true;

                                this.ChangeUserAgent(this.txtboxcustommobile.Text);

                                try
                                {
                                    if (browser.Document.GetElementById("sb_form_q") != null)
                                    {
                                        browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                        browser.Document.GetElementById("sbBtn").InvokeMember("click");
                                    }
                                }
                                catch
                                {
                                    //browser.Navigate("http://bing.com/search?q=" + this.query);

                                    await DownloadAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                         (task) => this.statusDebug("Search:"),
                                            TaskScheduler.FromCurrentSynchronizationContext());
                                }
                            }
                            else
                            {
                                --this.counterDx;
                                counterTxtBox.Text = (this.countDownDesktop - this.counterDx) + "/" + this.countDownDesktop;
                                this.Csearch = true;

                                this.ChangeUserAgent(this.txtboxcustomdesktop.Text);

                                try
                                {
                                    if (browser.Document.GetElementById("sb_form_q") != null)
                                    {
                                        browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                        browser.Document.GetElementById("sb_form_go").InvokeMember("click");
                                    }
                                }
                                catch
                                {
                                    //browser.Navigate("http://bing.com/search?q=" + this.query);

                                    await DownloadAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                        (task) => this.statusDebug("Search:"),
                                           TaskScheduler.FromCurrentSynchronizationContext());
                                }
                            }
                        }
                    }
                    catch  { }
                }
                else if (chkbox_autorotate.Checked == true)
                {
                    this.button1.Text = "Stop";

                    this.Csearch = false;
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;
                    this.siguid = "";

                    this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;

                    // reset visited
                    for (int i = 0, b = this.accountVisited.Count; i < b; i++)
                    {
                        this.accountVisited[i] = false;
                    }

                    statusTxtBox.Text = "Authenticate";
                    this.checkaccount = false;

                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = randomNumber(Convert.ToInt32(auth[0]), Convert.ToInt32(auth[1]));

                    this.timer_auth = z > 1 ? z * 1000 : AUTHSHORT;
                    counterTxtBox.Text = z > 1 ? decimal.Round(z / 60).ToString() + " min." : "a few sec.";

                    this.authLock = false;

                    this.statusDebug("Initial:");
                }
            }
        }

        private void settingsSaveBtn_Click(object sender, EventArgs e)
        {
            BingRewardsBot.Properties.Settings.Default.set_autorotate = chkbox_autorotate.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_tor = chkbox_tor.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_mobile = chkbox_mobile.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_desktop = chkbox_desktop.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_counter = txtbox_counter.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitsearches = txtbox_waitsearches.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitauth = txtbox_waitauth.Text;
            BingRewardsBot.Properties.Settings.Default.set_autostart = txtbox_autostart.Text;
            BingRewardsBot.Properties.Settings.Default.set_proxy = txtbox_proxy.Text;
            BingRewardsBot.Properties.Settings.Default.set_torsettings = this.txtbox_torsettings.Text;
            BingRewardsBot.Properties.Settings.Default.set_uadesktop = this.txtboxcustomdesktop.Text;
            BingRewardsBot.Properties.Settings.Default.set_uamobile = this.txtboxcustommobile.Text;
            BingRewardsBot.Properties.Settings.Default.set_accounts = this.txtbox_customaccounts.Text;
            BingRewardsBot.Properties.Settings.Default.set_lang = this.listBox1.SelectedIndex;
            BingRewardsBot.Properties.Settings.Default.set_randomo = randomo.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_ns = this.chkbox_ns.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_chkbox_as = this.chkbox_as.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.Save();

            if (BingRewardsBot.Properties.Settings.Default.set_tor == true)
            {
                if (BingRewardsBot.Properties.Settings.Default.set_proxy != "")
                {
                    WinInetInterop.SetConnectionProxy(Properties.Settings.Default.set_proxy.ToString());
                }
                else
                {
                    // default tor + privoxy
                    //setProxy("127.0.0.1:8118", true);
                    WinInetInterop.SetConnectionProxy("localhost:" + TORSOCKSPORT);
                }
            }
            else if (BingRewardsBot.Properties.Settings.Default.set_proxy != "")
            {
                WinInetInterop.SetConnectionProxy(Properties.Settings.Default.set_proxy.ToString());
            }

            updatetab.SelectedTab = btn_ip;
        }

        private void prev_button_Click(object sender, EventArgs e)
        {
            if (this.accountNum > 0)
            {
                --this.accountNum;
                string[] authstr = this.accounts[this.accountNum].Split('/');
                this.username = authstr[0];
                this.password = authstr[1];
                string proxy = "";
                string[] paddr = authstr[1].Split(' ');
                if (paddr.Length >= 2 && paddr[1] != null)
                {
                    this.password = paddr[0];
                    proxy = paddr[1];
                };

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;
            }
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if (this.accountNum < (this.accounts.Count - 1))
            {
                ++this.accountNum;
                string[] authstr = this.accounts[this.accountNum].Split('/');
                this.username = authstr[0];
                this.password = authstr[1];
                string proxy = "";
                string[] paddr = authstr[1].Split(' ');
                if (paddr.Length >= 2 && paddr[1] != null)
                {
                    this.password = paddr[0];
                    proxy = paddr[1];
                }

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;
            }
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            BingRewardsBot.Properties.Settings.Default.Save();

            if (this.accountNum < 0) this.accountNum = 0;
            this.checkaccount = true;
            this.authLock = false;
            this.button1.Text = "Stop";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var myForm = new Form2();
            //myForm.Show();

            BingRewardsBot.Properties.Settings.Default.set_autorotate = chkbox_autorotate.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_tor = chkbox_tor.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_mobile = chkbox_mobile.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_desktop = chkbox_desktop.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_counter = txtbox_counter.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitsearches = txtbox_waitsearches.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitauth = txtbox_waitauth.Text;
            BingRewardsBot.Properties.Settings.Default.set_autostart = txtbox_autostart.Text;
            BingRewardsBot.Properties.Settings.Default.set_proxy = txtbox_proxy.Text;
            BingRewardsBot.Properties.Settings.Default.set_torsettings = this.txtbox_torsettings.Text;
            BingRewardsBot.Properties.Settings.Default.set_uadesktop = this.txtboxcustomdesktop.Text;
            BingRewardsBot.Properties.Settings.Default.set_uamobile = this.txtboxcustommobile.Text;
            BingRewardsBot.Properties.Settings.Default.set_accounts = this.txtbox_customaccounts.Text;
            BingRewardsBot.Properties.Settings.Default.set_lang = this.listBox1.SelectedIndex;
            BingRewardsBot.Properties.Settings.Default.set_randomo = randomo.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_ns = this.chkbox_ns.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_chkbox_as = this.chkbox_as.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.Save();

            if (this.trialCountDownReg > 0 && this.trialCountUp > 0)
            {
                try
                {
                    Application.UserAppDataRegistry.SetValue("ConnXY",
                        this.trialCountDownReg - (this.trialCountUp * DIVIDE));
                }
                catch
                {
                    MessageBox.Show("Registry error!");
                }
            }
            else
            {
                if (Application.UserAppDataRegistry.GetValue("Injector") == null)
                {
                    try
                    {
                        Application.UserAppDataRegistry.SetValue("Injector", randomNumber(1000, 100000));
                    }
                    catch
                    {
                        MessageBox.Show("Registry error!");
                    }
                }
                if (Application.UserAppDataRegistry.GetValue("Codedll") == null)
                {
                    try
                    {
                        Application.UserAppDataRegistry.SetValue("Codedll", randomNumber(1000, 100000));
                    }
                    catch
                    {
                        MessageBox.Show("Registry error!");
                    }
                }
                if (Application.UserAppDataRegistry.GetValue("Vnumber") == null)
                {
                    try
                    {
                        Application.UserAppDataRegistry.SetValue("Vnumber", randomNumber(1000, 100000));
                    }
                    catch
                    {
                        MessageBox.Show("Registry error!");
                    }
                }
            }
            try
            {
                Application.UserAppDataRegistry.SetValue("RegKey", this.trialRegKey);
            }
            catch
            {
                MessageBox.Show("Registry error!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.toridswitcher();

            if (this.country != "US" || this.country != "IN")
            {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                SQLiteCommand command = new SQLiteCommand("select count(*) from searches where ip='" +
                    this.ip +
                    "," +
                    this.country +
                    "'", dbcon);
                SQLiteDataReader reader = command.ExecuteReader();
                int num = 0;
                while (reader.Read())
                {
                    num = Convert.ToInt32(reader["count(*)"]);
                }

                if (num == 0)
                {
                    command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('','" +
                        this.ip + ","
                        + this.country +
                        "','','')",
                        dbcon);
                    command.ExecuteNonQuery();
                }
                dbcon.Close();
            }
        }

        private void btn_cache_Click(object sender, EventArgs e)
        {
            this.ClearCache();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
            conn.Open();

            string sql = "select * from searches where ip='" + this.ip + "' group by account,ip";
            SQLiteCommand command = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            string[] aarr = new string[5];

            int i = 0;
            while (reader.Read() && i < 5)
            {
                aarr[i++] = Convert.ToString(reader["account"]);
            }

            string[] iparr = new string[10];
            sql = "select * from searches where account='" +
                this.username + "' group by account,ip";
            command = new SQLiteCommand(sql, conn);
            reader = command.ExecuteReader();

            i = 0;
            while (reader.Read() && i < 10)
            {
                iparr[i++] = Convert.ToString(reader["ip"]);
            }
            conn.Close();

            conn = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
            conn.Open();
            DateTime dateTime = DateTime.UtcNow.Date;
            sql = "select * from searches where date='" +
            dateTime.ToString("yyyyMMdd") + "' group by account";
            command = new SQLiteCommand(sql, conn);
            reader = command.ExecuteReader();
            string[] uarr = new string[40];

            i = 0;
            while (reader.Read() && i < 40)
            {
                uarr[i++] = Convert.ToString(reader["account"]);
            }

            i = 0;
            int[] parr = new int[40];

            foreach (string ele in uarr)
            {
                if (ele != null)
                {
                    sql = "select * from searches where date='" +
                        dateTime.ToString("yyyyMMdd") +
                        "' and account='"
                        + ele +
                        "' and points<>4242";
                    command = new SQLiteCommand(sql, conn);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        parr[i] += Convert.ToInt32(reader["points"]);
                    }
                    i++;
                }
            }

            i = 0;
            string score = "";
            foreach (string ele in uarr)
            {
                if (ele != null)
                {
                    score += Convert.ToString(uarr[i]) + " " + Convert.ToString(parr[i]) + "\r\n";
                    ++i;
                }
            }

            MessageBox.Show("Accounts:" + string.Join("\r\n", aarr) +
                "\r\nIPs:" + string.Join("\r\n", iparr) +
                string.Join("\r\n", score));
        }

        private void updateUserPts(int a)
        {
            int num = this.numIpDate();

            if (num == 0)
            {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                DateTime dateTime = DateTime.UtcNow.Date;
                SQLiteCommand command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                dateTime.ToString("yyyyMMdd") +
                "','" +
                this.ip +
                "','" +
                this.username +
                "','" +
                Convert.ToString(a) +
                "')",
                dbcon);
                command.ExecuteNonQuery();
                dbcon.Close();
            }
            else
            {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                DateTime dateTime = DateTime.UtcNow.Date;
                SQLiteCommand command = new SQLiteCommand("update searches set points='" +
                Convert.ToString(a) + "' WHERE ip='" +
                this.ip +
                "' and date='" +
                dateTime.ToString("yyyyMMdd") +
                "' and account='" +
                this.username +
                "'",
                dbcon);
                command.ExecuteNonQuery();
                dbcon.Close();
            }
        }
        private void initUserSQL()
        {
            int num = this.numIpDate();

            if (num == 0)
            {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                DateTime dateTime = DateTime.UtcNow.Date;
                SQLiteCommand command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                    dateTime.ToString("yyyyMMdd") +
                    "','" +
                    this.ip +
                    "','" +
                    this.username +
                    "','0')",
                    dbcon);
                command.ExecuteNonQuery();
                dbcon.Close();
            }
            else
            {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                DateTime dateTime = DateTime.UtcNow.Date;
                SQLiteCommand command = new SQLiteCommand("select * from searches where date='" +
                    dateTime.ToString("yyyyMMdd") +
                    "' and account='" +
                    this.username +
                    "' order by ip,points",
                    dbcon);
                SQLiteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader["points"] != null)
                    {
                        this.pts += Convert.ToInt32(reader["points"]);
                    }
                }
                this.pts_txtbox.Text = Convert.ToString(this.pts);
            }
        }
        private void newUsIp()
        {
            if (this.country == "US" || this.country == "IN" || this.country == "AU")
            {
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                SQLiteCommand command = new SQLiteCommand("select count(*) from searches where points='" +
                    this.ip +
                    "," +
                    this.country +
                    "'",
                    dbcon);
                SQLiteDataReader reader = command.ExecuteReader();

                int num = 0;
                while (reader.Read())
                {
                    num = Convert.ToInt32(reader["count(*)"]);
                }

                if (num == 0)
                {
                    command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('','" +
                        this.ip +
                        "," +
                        this.country +
                        "','','')",
                        dbcon);
                    command.ExecuteNonQuery();
                }
                dbcon.Close();
            }
        }

        private int numIpDate()
        {
            SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
            dbcon.Open();
            DateTime dateTime = DateTime.UtcNow.Date;
            SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                this.username +
                "' and ip='" +
                this.ip +
                "' and date='" +
                dateTime.ToString("yyyyMMdd") +
                "'",
                dbcon);
            SQLiteDataReader reader = command.ExecuteReader();

            int num = 0;
            while (reader.Read())
            {
                num = Convert.ToInt32(reader["count(*)"]);
            }
            dbcon.Close();
            return num;
        }

        //http://mdb-blog.blogspot.fr/2013/02/c-winforms-webbrowser-clear-all-cookies.html
        //private static unsafe void SuppressWininetBehavior()
        //{
        //    /* SOURCE: http://msdn.microsoft.com/en-us/library/windows/desktop/aa385328%28v=vs.85%29.aspx
        //        * INTERNET_OPTION_SUPPRESS_BEHAVIOR (81):
        //        *      A general purpose option that is used to suppress behaviors on a process-wide basis. 
        //        *      The lpBuffer parameter of the function must be a pointer to a DWORD containing the specific behavior to suppress. 
        //        *      This option cannot be queried with InternetQueryOption. 
        //        *      
        //        * INTERNET_SUPPRESS_COOKIE_PERSIST (3):
        //        *      Suppresses the persistence of cookies, even if the server has specified them as persistent.
        //        *      Version:  Requires Internet Explorer 8.0 or later.
        //        */

        //    int option = (int)3/* INTERNET_SUPPRESS_COOKIE_PERSIST*/;
        //    int* optionPtr = &option;

        //    bool success = InternetSetOption(0, 81/*INTERNET_OPTION_SUPPRESS_BEHAVIOR*/, new IntPtr(optionPtr), sizeof(int));
        //    if (!success)
        //    {
        //        MessageBox.Show("Something went wrong !>?");
        //    }
        //}

        private void waitbrowser()
        {
            while (this.browser.ReadyState != WebBrowserReadyState.Complete)
            {
                Application.DoEvents();
            }
        }
        private void subgetip()
        {
            try
            {
                this.GetIP();
            }
            catch { }

            try
            {
                this.country = this.QueryGeo(this.ip);
                this.toolStripStatusLabel1.Text = MYIP + this.ip + " My country:" + this.country;
            }
            catch
            {
                this.toolStripStatusLabel1.Text = MYIP + this.ip;
            }
        }

        private void toridswitcher()
        {
            if (chkbox_tor.Checked == true)
            {

                if (this.timer_tor == null)
                {
                    this.timer_tor = new System.Timers.Timer();
                    this.timer_tor.AutoReset = false;
                    this.timer_tor.Elapsed += new ElapsedEventHandler(RefreshTor);
                    this.timer_tor.Interval = SLEEPTOR;
                }

                this.timer_tor.Enabled = true;
                this.timer_tor.Start();

                this.toolStripStatusLabel1.Text = "New Identity:";

                try
                {
                    toriddone = false;
                    int c = 0;

                    while (toriddone == false && c < 10)
                    {
                        this.toolStripStatusLabel1.Text += c + ".";
                        Thread.Sleep(SLEEPTOR);
                        ++c;
                        this.timer_tor.Enabled = true;
                        this.timer_tor.Start();
                    }

                    this.timer_tor.Enabled = false;

                    subgetip();
                }
                catch (Exception e)
                {
                    this.timer_tor.Enabled = false;
                    MessageBox.Show(e.Message);
                }
            }
        }

        private async void ClearCache()
        {
            //browser.Document.ExecCommand("ClearAuthenticationCache", false, null);

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            //browser.Navigate(new Uri("https://www.google.com/"));

            // clear cache & cookies
            WebBrowserHelper.ClearCache();

            //http://www.experts-exchange.com/questions/28462189/How-can-I-clear-the-WebBrowser-Cache-from-C.html
            browser.Refresh(WebBrowserRefreshOption.Completely);

            //clearIECache();

            //https://github.com/erfg12/BingRewards
            try
            {
                string[] theCookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
                foreach (string currentFile in theCookies)
                {
                    System.IO.File.Delete(currentFile);
                }
            }
            catch
            {
                //happens sometimes on first bootup
                //MessageBox.Show("IE Cache error!");
            }

            //browser.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");

            //Temporary Internet Files
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8");
            //Cookies()
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
            //History()
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
            //Form(Data)
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16");
            //Passwords
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32");
            //Delete(All)
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
            //Delete All – Also delete files and settings stored by add-ons
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351")

            int ret = await RunProcessAsync("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8");
            ret = await RunProcessAsync("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
            ret = await RunProcessAsync("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
            ret = await RunProcessAsync("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16");
            ret = await RunProcessAsync("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32");
        }

        //http://stackoverflow.com/questions/10788982/is-there-any-async-equivalent-of-process-start/10789196#10789196
        public static async Task<int> RunProcessAsync(string fileName, string args)
        {
            using (var process = new Process
            {
                StartInfo =
        {
            FileName = fileName, Arguments = args,
            UseShellExecute = false, CreateNoWindow = true,
            RedirectStandardOutput = true, RedirectStandardError = true
        },
                EnableRaisingEvents = true
            })
            {
                return await RunProcessAsync(process).ConfigureAwait(false);
            }
        }
        private static Task<int> RunProcessAsync(Process process)
        {
            var tcs = new TaskCompletionSource<int>();

            process.Exited += (s, ea) => tcs.SetResult(process.ExitCode);
            process.OutputDataReceived += (s, ea) => Console.WriteLine(ea.Data);
            process.ErrorDataReceived += (s, ea) => Console.WriteLine("ERR: " + ea.Data);

            bool started = process.Start();
            if (!started)
            {
                //you may allow for the process to be re-used (started = false) 
                //but I'm not sure about the guarantees of the Exited event in such a case
                throw new InvalidOperationException("Could not start process: " + process);
            }

            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            return tcs.Task;
        }
        //http://stackoverflow.com/questions/937573/changing-the-user-agent-of-the-webbrowser-control
        private void ChangeUserAgent(string ua)
        {
            //UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, Agent, Agent.Length, 0);
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT_REFRESH, null, 0, 0);
            UrlMkSetSessionOption(URLMON_OPTION_USERAGENT, ua, ua.Length, 0);
        }

        private void statusDebug(string a, bool b = false)
        {
            try
            {
                int v = 0;
                for (int i = 0, c = this.accountVisited.Count; i < c; i++)
                {
                    if (this.accountVisited[i] == false)
                    {
                        v++;
                    }
                }
                --v;

                if (b)
                {
                    this.toolStripStatusLabel1.Text += a + Convert.ToString(this.authLock) +
                        "|" + Convert.ToString(this.checkaccount) +
                        "|" + Convert.ToString(this.iniSearch) +
                        "|" + Convert.ToString(this.accountVisitedX) +
                        "|" + Convert.ToString(v + 1) +
                        "|" + Convert.ToString(this.vrndnum) +
                        "|" + Convert.ToString(this.accounts.Count) +
                        "|" + Convert.ToString(this.accountNum) +
                        "|" + this.country +
                        "|" + this.username +
                        "|" + Convert.ToString(this.pts) +
                        "|" + Convert.ToString(this.timer_auth) +
                        "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches") +
                        "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Interval) : "-") +
                        "| PC:" + Convert.ToString(this.pccounter);
                }
                else
                {
                    this.toolStripStatusLabel1.Text = a + Convert.ToString(this.authLock) +
                      "|" + Convert.ToString(this.checkaccount) +
                      "|" + Convert.ToString(this.iniSearch) +
                      "|" + Convert.ToString(this.accountVisitedX) +
                      "|" + Convert.ToString(v + 1) +
                      "|" + Convert.ToString(this.vrndnum) +
                      "|" + Convert.ToString(this.accounts.Count) +
                      "|" + Convert.ToString(this.accountNum) +
                      "|" + this.country +
                      "|" + this.username +
                      "|" + Convert.ToString(this.pts) +
                      "|" + Convert.ToString(this.timer_auth) +
                      "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches") +
                      "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Interval) : "-") +
                      "| PC:" + Convert.ToString(this.pccounter);
                }
            }
            catch { }
        }

        //http://stackoverflow.com/questions/9770522/how-to-handle-message-boxes-while-using-webbrowser-in-c

        //****************************************************
        //#32770, "Web Browser", "Button", "Retry"
        //****************************************************
        //****************************************************
        //#32770, "Message from webpage", "Button", "Cancel"
        //****************************************************

        private void iemessagebox ()
        {
            // double post error
            IntPtr hwnd = FindWindow("#32770", "Web Browser");
            if (IsWindow(hwnd) && this.checkaccount == false)
            {
                this.accountVisited[this.accountNum] = true;
                ++this.accountVisitedX;
                this.updateUserPts(4242);

                int a = 0;

                int[] v = new int[accountVisited.Count];

                for (int i = 0, b = this.accountVisited.Count; i < b; i++)
                {
                    if (this.accountVisited[i] == false)
                    {
                        v[a++] = i;
                    }
                }
                --a;

                if (a >= 0)
                {
                    if (this.randomo.Checked == true)
                    {
                        this.accountNum = v[this.randomNumber(0, a)];
                    }

                    // update account
                    string[] authstr = this.accounts[this.accountNum].Split('/');
                    this.username = authstr[0];
                    this.password = authstr[1];
                    string proxy = "";
                    string[] paddr = authstr[1].Split(' ');
                    if (paddr.Length >= 2 && paddr[1] != null)
                    {
                        this.password = paddr[0];
                        proxy = paddr[1];
                    }

                    accountNameTxtBox.Text = this.username;
                    accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                    this.authLock = true;
                    this.vrndnum = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.siguid = "";

                    this.statusDebug("Restart:");
                    this.statusTxtBox.Text = "Authenticate";

                    //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Retry");                
                    hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                    uint message = 0xf5;
                    SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);

                    //http://stackoverflow.com/questions/12386071/threading-and-webbrowser-control
                    //browser.Navigate(new Uri(BRSOUT));

                    //browser.Invoke(new Action(() => {
                    //    browser.Navigate(new Uri(BRSOUT)); 
                    //}));

                    //http://stackoverflow.com/questions/9048922/c-sharp-invalidcastexception-when-trying-to-access-webbrowser-control-from-tim
                    //this.Invoke(new Action(() => {
                    //    browser.Navigate(new Uri(BRSOUT));
                    //    }));

                    try
                    {
                        //browser.Navigate(new Uri(BRSOUT));
                        this.Invoke(new Action(() =>
                        {
                            //http://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                            var timeSpan = "ct=" + Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds, 0);
                            string logout = BRSOUT.Replace("ct=1476458234", timeSpan);
                            //logout = logout.Replace("id=292666", "id=" + randomNumber(100000, 900000));

                            browser.Navigate(new Uri(logout));
                        }));
                    }

                    catch { }

                }
                else
                {
                    int pts = 0;
                    try
                    {
                        pts = Convert.ToInt32(pts_txtbox.Text);

                    }
                    catch { }

                    if (pts >= MSPOINTS
                        || String.IsNullOrEmpty(pts_txtbox.Text)
                        || pts_txtbox.Text == "0"
                        || pts_txtbox.Text == "-")
                    {
                        try
                        {
                            SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                            dbcon.Open();
                            DateTime dateTime = DateTime.UtcNow.Date;
                            SQLiteCommand command = new SQLiteCommand("update searches set points='4242' WHERE ip='" +
                                this.ip +
                                "' and date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='" +
                                this.username +
                                "'",
                                dbcon);
                            command.ExecuteNonQuery();
                            dbcon.Close();
                        }
                        catch { }
                    }

                    if (this.timer_tor != null)
                    {
                        this.timer_tor.Enabled = false;
                    }

                    if (this.timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                    }

                    if (this.timer_dashboardta != null)
                    {
                        this.timer_dashboardta.Enabled = false;
                    }

                    this.button1.Text = "Start";
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;
                    this.authLock = false;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.siguid = "";

                    this.statusDebug("Stop:");

                    //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Retry");                
                    hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                    uint message = 0xf5;
                    SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
                }
            }

            // gps location
            hwnd = FindWindow("#32770", "Message from webpage");
            if (IsWindow(hwnd))
            {
                hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                uint message = 0xf5;
                SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
            }
        }

        //http://stackoverflow.com/questions/9770522/how-to-handle-message-boxes-while-using-webbrowser-in-c

        //****************************************************
        //#32770, "Web Browser", "Button", "Retry"
        //****************************************************
        //****************************************************
        //#32770, "Message from webpage", "Button", "Cancel"
        //****************************************************
        private void ClickOKButton()
        {
            while (true)
            {
                Thread.Sleep(SLEEPDP);

                // double post error
                IntPtr hwnd = FindWindow("#32770", "Web Browser");
                if (IsWindow(hwnd))
                {
                    this.accountVisited[this.accountNum] = true;
                    ++this.accountVisitedX;
                    this.updateUserPts(4242);

                    int a = 0;

                    int[] v = new int[accountVisited.Count];

                    for (int i = 0, b = this.accountVisited.Count; i < b; i++)
                    {
                        if (this.accountVisited[i] == false)
                        {
                            v[a++] = i;
                        }
                    }
                    --a;

                    if (a >= 0)
                    {
                        //this.accountNum = v[this.randomNumber(0, a)];
                        this.accountNum++;

                        // update account
                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];
                        string proxy = "";
                        string[] paddr = authstr[1].Split(' ');
                        if (paddr.Length >= 2 && paddr[1] != null)
                        {
                            this.password = paddr[0];
                            proxy = paddr[1];
                        }

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.authLock = true;
                        this.vrndnum = 0;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;

                        this.statusDebug("Restart:");
                        this.statusTxtBox.Text = "Authenticate";

                        //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Retry");                
                        hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                        uint message = 0xf5;
                        SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);

                        //http://stackoverflow.com/questions/12386071/threading-and-webbrowser-control
                        //browser.Navigate(new Uri(BRSOUT));

                        //browser.Invoke(new Action(() => {
                        //    browser.Navigate(new Uri(BRSOUT)); 
                        //}));

                        //http://stackoverflow.com/questions/9048922/c-sharp-invalidcastexception-when-trying-to-access-webbrowser-control-from-tim
                        //this.Invoke(new Action(() => {
                        //    browser.Navigate(new Uri(BRSOUT));
                        //    }));

                        try
                        {
                            //browser.Navigate(new Uri(BRSOUT));
                            this.Invoke(new Action(() =>
                            {
                                //http://stackoverflow.com/questions/17632584/how-to-get-the-unix-timestamp-in-c-sharp
                                var timeSpan = "ct=" + Math.Round((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()).TotalSeconds, 0);
                                string logout = BRSOUT.Replace("ct=1476458234", timeSpan);
                                //logout = logout.Replace("id=292666", "id=" + randomNumber(100000, 900000));

                                browser.Navigate(new Uri(logout));
                            }));
                        }

                        catch { }

                    }
                    else
                    {
                        int pts = 0;
                        try
                        {
                            pts = Convert.ToInt32(pts_txtbox.Text);

                        }
                        catch { }

                        if (pts >= MSPOINTS
                            || String.IsNullOrEmpty(pts_txtbox.Text)
                            || pts_txtbox.Text == "0"
                            || pts_txtbox.Text == "-")
                        {
                            try
                            {
                                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                dbcon.Open();
                                DateTime dateTime = DateTime.UtcNow.Date;
                                SQLiteCommand command = new SQLiteCommand("update searches set points='4242' WHERE ip='" +
                                    this.ip +
                                    "' and date='" +
                                    dateTime.ToString("yyyyMMdd") +
                                    "' and account='" +
                                    this.username +
                                    "'",
                                    dbcon);
                                command.ExecuteNonQuery();
                                dbcon.Close();
                            }
                            catch { }
                        }

                        this.button1.Text = "Start";
                        statusTxtBox.Text = "Stop";
                        counterTxtBox.Text = "0/0";
                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.vrndnum = 0;
                        this.authLock = false;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.siguid = "";

                        this.statusDebug("Stop:");

                        //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Retry");                
                        hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                        uint message = 0xf5;
                        SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
                    }
                }

                // gps location
                hwnd = FindWindow("#32770", "Message from webpage");
                if (IsWindow(hwnd))
                {
                    hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                    uint message = 0xf5;
                    SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
                }
            }
        }

        //to activate use like this strProxy="85.45.66.25:3633"
        //to deactivate use like this strProxy=":"
        public static void RefreshIESettings(string strProxy)
        {
            try
            {
                const int INTERNET_OPTION_PROXY = 38;
                const int INTERNET_OPEN_TYPE_PROXY = 3;

                Struct_INTERNET_PROXY_INFO struct_IPI;

                // Filling in structure 
                struct_IPI.dwAccessType = INTERNET_OPEN_TYPE_PROXY;
                struct_IPI.proxy = Marshal.StringToHGlobalAnsi(strProxy);
                struct_IPI.proxyBypass = Marshal.StringToHGlobalAnsi("local");

                // Allocating memory 
                IntPtr intptrStruct = Marshal.AllocCoTaskMem(Marshal.SizeOf(struct_IPI));

                // Converting structure to IntPtr 
                Marshal.StructureToPtr(struct_IPI, intptrStruct, true);

                bool iReturn = InternetSetOption(IntPtr.Zero,
                    INTERNET_OPTION_PROXY, intptrStruct, Marshal.SizeOf(struct_IPI));
            }
            catch (Exception ex)
            {
                //TB.ErrorLog(ex);
            }
        }

        // http://stackoverflow.com/questions/2745268/how-to-use-tor-control-protocol-in-c
        private void RefreshTor(object sender, EventArgs e)
        {
            IPEndPoint ip;
            if (txtbox_torsettings.Text != "")
            {
                string[] temp = txtbox_torsettings.Text.Split(':');
                ip = new IPEndPoint(IPAddress.Parse(Convert.ToString(temp[0])),
                   Convert.ToInt32(temp[1]));
            }
            else
            {
                ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), TORCONTROLPORT);
            }

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ip);
            }
            catch 
            {
                //Console.WriteLine("Unable to connect to server.");
                //System.Threading.Thread.Sleep(SLEEPTOR);
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }

            //server.Send(Encoding.ASCII.GetBytes("AUTHENTICATE \"butt\"\r\n"));
            server.Send(Encoding.ASCII.GetBytes("AUTHENTICATE\r\n"));
            byte[] data = new byte[1024];
            int receivedDataLength = server.Receive(data);
            string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);

            if (stringData.Contains("250"))
            {
                //this.toolStripStatusLabel1.Text = "AUTHENTICATE";

                //server.Send(Encoding.ASCII.GetBytes("SETCONF ExitNodes = {us}"));
                //server.Send(Encoding.ASCII.GetBytes("SETCONF StrictNodes = 1"));
                server.Send(Encoding.ASCII.GetBytes("SIGNAL NEWNYM\r\n"));
                data = new byte[1024];
                receivedDataLength = server.Receive(data);
                stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                if (stringData.Contains("250"))
                {
                    toriddone = true;
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();

                }
                else
                {
                    //this.toolStripStatusLabel1.Text = "WAIT (Unable to signal new user to server.)";
                    //Console.WriteLine("Unable to signal new user to server.");
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
                }
            }
            else
            {
                //this.toolStripStatusLabel1.Text = "WAIT (Unable to authenticate to server.)";
                //Console.WriteLine("Unable to authenticate to server.");
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            return;
        }

        //http://sharp-coders.com/microsoft-net/c-sharp/calculate-md5-hash-in-c-sharp
        private string GetMd5Hash(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0, e = data.Length; i < e; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private int randNumTimer(int min, int max)
        {
            ++max;
            if (min == 0) min++;
            if (max == 0) max = ++min;

            if (min > max)
            {
                int bak = max;
                max = min;
                min = bak;
            }

            DateTime dateTime = DateTime.UtcNow.Date;
            Random random = new Random(dateTime.Millisecond + Guid.NewGuid().GetHashCode());

            int rand = 0;
            try
            {
                rand = random.Next(min, max);
            }
            catch
            {
            }

            return rand;
        }

        private int randAuthTimer(int min, int max)
        {
            //++max;
            if (min == 0) min++;
            if (max == 0) max = ++min;

            if (min > max)
            {
                int bak = max;
                max = min;
                min = bak;
            }
            max *= 60;

            DateTime dateTime = DateTime.UtcNow.Date;
            Random random = new Random(dateTime.Millisecond + Guid.NewGuid().GetHashCode());

            int rand = 0;
            try
            {
                rand = random.Next(min, max);
            }
            catch  { }

            return rand;
        }

        private int randomNumber(int min, int max)
        {
            ++max;
            if (min > max)
            {
                int bak = max;
                max = min;
                min = bak;
            }

            DateTime dateTime = DateTime.UtcNow.Date;
            Random random = new Random(dateTime.Millisecond + Guid.NewGuid().GetHashCode());

            int rand = 0;
            try
            {
                rand = random.Next(min, max);
            }
            catch
            {
            }

            return rand;
        }

        private void ReadFile(string name, List<string> list, int count = 100000000)
        {
            try
            {
                using (StreamReader r = new StreamReader(name))
                {
                    string rLine;
                    int i = 0;
                    while ((rLine = r.ReadLine()) != null && count > 0)
                    {
                        list.Add(rLine);
                        ++i;
                        --count;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Read error!");
                Application.Exit();
            }
        }

        //http://matijabozicevic.com/blog/wpf-winforms-development/csharp-get-computer-ip-address-lan-and-internet
        private void GetIP()
        {
            //var htmlNow = DownloadAsync("http://checkip.dyndns.org");

            //var htmlNow = DownloadAsync("https://api.ipify.org");
            

            //DownloadAsync("https://api.ipify.org").ContinueWith(
            //   (task) => this.statusDebug("GETIP:"),
            //       TaskScheduler.FromCurrentSynchronizationContext());

            try
            {
                browser.Invoke(new Action(() =>
                {
                    browser.Navigate(new Uri("https://api.ipify.org"));
                }));
            }
            catch { }

            browser.Invoke(new Action(() =>
            {
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
            }));

            string html = browser.DocumentText;
            //this.ip = html.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).Replace("</body></html>", string.Empty).Replace("\r\n", string.Empty);
            this.ip = html.Replace("<!DOCTYPE HTML>\r\n<!DOCTYPE html PUBLIC \"\" \"\"><HTML><HEAD>\r\n<META http-equiv=\"Content-Type\" \r\ncontent=\"text/html; charset=windows-1252\"></HEAD>\r\n<BODY>\r\n<PRE>", string.Empty).Replace("</PRE></BODY></HTML>\r\n", string.Empty);
        }

        //http://www.csharphelp.com/2007/08/redirect-web-visitors-by-country-using-net-framework-in-c/
        private string QueryGeo(string strIPAddress)
        {
            IPResult oIPResult = new IP2Location.IPResult();
            IP2Location.Component oIP2Location = new IP2Location.Component();
            try
            {
                //strIPAddress = "18.243.0.29";
                //strIPAddress = "90.243.0.29";
                if (strIPAddress != "")
                {
                    oIP2Location.IPDatabasePath = "IP2LOCATION-LITE-DB11.BIN";

                    //Set License Path
                    //oIP2Location.IPLicensePath = @"C:\Program Files\IP2Location\License.key";

                    oIPResult = oIP2Location.IPQuery(strIPAddress);
                    switch (oIPResult.Status.ToString())
                    {
                        case "OK":
                            return oIPResult.CountryShort;
                            /*
                            if (oIPResult.CountryShort == "US")
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            */
                            break;
                        case "EMPTY_IP_ADDRESS":
                            //Response.Write("IP Address cannot be blank.");
                            break;
                        case "INVALID_IP_ADDRESS":
                            //Response.Write("Invalid IP Address.");
                            break;
                        case "MISSING_FILE":
                            //Response.Write("Invalid Database Path.");
                            break;
                    }
                }
                else
                {
                    //Response.Write("IP Address cannot be blank.");
                }
            }
            catch
            {
                //Response.Write(ex.Message);
            }
            finally
            {
                oIPResult = null;
            }
            return null;
        }

        private async Task update()
        {
            try
            {
                await DownloadAsync("https://bbrb.codeplex.com/releases/");

                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                };

                Invoke((MethodInvoker)(() =>
                {
                    if (browser.Document.GetElementById("ReleaseDateLiteral").GetAttribute("title") != null)
                    {
                        string[] release = browser.Document.GetElementById("ReleaseDateLiteral").GetAttribute("title").Split(' ');
                        string[] convert1 = release[0].Split('.');

                        // http://stackoverflow.com/questions/919244/converting-a-string-to-datetime
                        DateTime timer = new DateTime(Convert.ToInt32(convert1[2]), Convert.ToInt32(convert1[1]), Convert.ToInt32(convert1[0]));
                        //Console.WriteLine(timer.ToString());

                        string[] convert2 = VERSION.Split('.');
                        DateTime thisversion = new DateTime(Convert.ToInt32(convert2[2]), Convert.ToInt32(convert2[1]), Convert.ToInt32(convert2[0]));

                        // http://stackoverflow.com/questions/22564846/c-sharp-compare-two-datetimes
                        TimeSpan difference = timer - thisversion;
                        if (difference.TotalDays >= 3)
                        {
                            // Bingo!
                            MessageBox.Show("Congrats, a new update is available! Please go to https://bbrb.codeplex.com/ for downloads! If you are a supporter you can ask the support!");
                        }
                        else
                        {
                            MessageBox.Show("Sorry, no updates! You can come back later! If you are a supporter you can ask the support! Thanks!");
                        }
                    }

                }));

                } catch {
                //checkupdate();
            }          
        }
  
        private void checkupdate () { 
              // 24.11.2016 09:00:00
            if (browser.Document.GetElementById("ReleaseDateLiteral").GetAttribute("title") != null)
            {
                string[] release = browser.Document.GetElementById("ReleaseDateLiteral").GetAttribute("title").Split(' ');
                string[] convert1 = release[0].Split('.');

                // http://stackoverflow.com/questions/919244/converting-a-string-to-datetime
                DateTime timer = new DateTime(Convert.ToInt32(convert1[2]), Convert.ToInt32(convert1[1]), Convert.ToInt32(convert1[0]));
                //Console.WriteLine(timer.ToString());

                string[] convert2 = VERSION.Split('.');
                DateTime thisversion = new DateTime(Convert.ToInt32(convert2[2]), Convert.ToInt32(convert2[1]), Convert.ToInt32(convert2[0]));

                // http://stackoverflow.com/questions/22564846/c-sharp-compare-two-datetimes
                TimeSpan difference = timer - thisversion;
                if (difference.TotalDays >= 6)
                {
                    // Bingo!
                    MessageBox.Show("Congrats, there is a new version available! Please go to https://bbrb.codeplex.com/ for more informations! If you are a supporter you can ask the support!");
                } else
                {
                    MessageBox.Show("Sorry, no updates! You can come back later! If you are a supporter you can ask the support!");
                }                            
            }
         }

        //http://stackoverflow.com/questions/21466488/async-method-throws-exception
        private void button4_Click_1(object sender, EventArgs e)
        {
   
            update();

            while (this.browser.ReadyState != WebBrowserReadyState.Complete) {
                Application.DoEvents();
            };
            
        }

        /*
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.TopMost = false;
            var si = new ProcessStartInfo("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=BBWLBNCPKP7AW");
            Process.Start(si);
            linkLabel1.LinkVisited = true;            
        }
        */
    }

    //http://stackoverflow.com/questions/2475435/c-sharp-timer-wont-tick
    //public class BetterTimer : System.Timers.Timer.Timer
    //{
    //    public BetterTimer() : base()
    //    { base.Enabled = true; }

    //    public BetterTimer(System.ComponentModel.IContainer container) : base(container)
    //    { base.Enabled = true; }

    //    private bool _Enabled;
    //    public override bool Enabled
    //    {
    //        get { return _Enabled; }
    //        set { _Enabled = value; }
    //    }

    //    protected override void OnTick(System.EventArgs e)
    //    { if (this.Enabled) base.OnTick(e); }
    //}

    //http://www.waytocoding.com/2014/08/how-to-clear-cache-in-web-browser.html
    public class WebBrowserHelper
    {
        #region Definitions/DLL Imports
        /// 

        /// For PInvoke: Contains information about an entry in the Internet cache
        /// 

        [StructLayout(LayoutKind.Explicit)]
        public struct ExemptDeltaOrReserverd
        {
            [FieldOffset(0)]
            public UInt32 dwReserved;
            [FieldOffset(0)]
            public UInt32 dwExemptDelta;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INTERNET_CACHE_ENTRY_INFOA
        {
            public UInt32 dwStructSize;
            public IntPtr lpszSourceUrlName;
            public IntPtr lpszLocalFileName;
            public UInt32 CacheEntryType;
            public UInt32 dwUseCount;
            public UInt32 dwHitRate;
            public UInt32 dwSizeLow;
            public UInt32 dwSizeHigh;
            public FILETIME LastModifiedTime;
            public FILETIME ExpireTime;
            public FILETIME LastAccessTime;
            public FILETIME LastSyncTime;
            public IntPtr lpHeaderInfo;
            public UInt32 dwHeaderInfoSize;
            public IntPtr lpszFileExtension;
            public ExemptDeltaOrReserverd dwExemptDeltaOrReserved;
        }

        // For PInvoke: Initiates the enumeration of the cache groups in the Internet cache
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "FindFirstUrlCacheGroup",
            CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstUrlCacheGroup(
            int dwFlags,
            int dwFilter,
            IntPtr lpSearchCondition,
        int dwSearchCondition,
        ref long lpGroupId,
        IntPtr lpReserved);

        // For PInvoke: Retrieves the next cache group in a cache group enumeration
        [DllImport(@"wininet",
        SetLastError = true,
            CharSet = CharSet.Auto,
        EntryPoint = "FindNextUrlCacheGroup",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindNextUrlCacheGroup(
            IntPtr hFind,
            ref long lpGroupId,
            IntPtr lpReserved);

        // For PInvoke: Releases the specified GROUPID and any associated state in the cache index file
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "DeleteUrlCacheGroup",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool DeleteUrlCacheGroup(
            long GroupId,
            int dwFlags,
            IntPtr lpReserved);

        // For PInvoke: Begins the enumeration of the Internet cache
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "FindFirstUrlCacheEntryA",
            CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr FindFirstUrlCacheEntry(
            [MarshalAs(UnmanagedType.LPTStr)] string lpszUrlSearchPattern,
            IntPtr lpFirstCacheEntryInfo,
            ref int lpdwFirstCacheEntryInfoBufferSize);

        // For PInvoke: Retrieves the next entry in the Internet cache
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "FindNextUrlCacheEntryA",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool FindNextUrlCacheEntry(
            IntPtr hFind,
            IntPtr lpNextCacheEntryInfo,
            ref int lpdwNextCacheEntryInfoBufferSize);

        // For PInvoke: Removes the file that is associated with the source name from the cache, if the file exists
        [DllImport(@"wininet",
            SetLastError = true,
            CharSet = CharSet.Auto,
            EntryPoint = "DeleteUrlCacheEntryA",
            CallingConvention = CallingConvention.StdCall)]
        public static extern bool DeleteUrlCacheEntry(
            IntPtr lpszUrlName);
        #endregion

        /// 

        /// Clears the cache of the web browser
        /// 

        public static void ClearCache()
        {
            // Indicates that all of the cache groups in the user's system should be enumerated
            const int CACHEGROUP_SEARCH_ALL = 0x0;
            // Indicates that all the cache entries that are associated with the cache group
            // should be deleted, unless the entry belongs to another cache group.
            const int CACHEGROUP_FLAG_FLUSHURL_ONDELETE = 0x2;
            const int ERROR_INSUFFICIENT_BUFFER = 0x7A;

            // Delete the groups first.
            // Groups may not always exist on the system.
            // For more information, visit the following Microsoft Web site:
            // http://msdn.microsoft.com/library/?url=/workshop/networking/wininet/overview/cache.asp            
            // By default, a URL does not belong to any group. Therefore, that cache may become
            // empty even when the CacheGroup APIs are not used because the existing URL does not belong to any group.            
            long groupId = 0;
            IntPtr enumHandle = FindFirstUrlCacheGroup(0, CACHEGROUP_SEARCH_ALL, IntPtr.Zero, 0, ref groupId, IntPtr.Zero);
            if (enumHandle != IntPtr.Zero)
            {
                bool more;
                do
                {
                    // Delete a particular Cache Group.
                    DeleteUrlCacheGroup(groupId, CACHEGROUP_FLAG_FLUSHURL_ONDELETE, IntPtr.Zero);
                    more = FindNextUrlCacheGroup(enumHandle, ref groupId, IntPtr.Zero);
                } while (more);
            }

            // Start to delete URLs that do not belong to any group.
            int cacheEntryInfoBufferSizeInitial = 0;
            FindFirstUrlCacheEntry(null, IntPtr.Zero, ref cacheEntryInfoBufferSizeInitial);  // should always fail because buffer is too small
            if (Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
            {
                int cacheEntryInfoBufferSize = cacheEntryInfoBufferSizeInitial;
                IntPtr cacheEntryInfoBuffer = Marshal.AllocHGlobal(cacheEntryInfoBufferSize);
                enumHandle = FindFirstUrlCacheEntry(null, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
                if (enumHandle != IntPtr.Zero)
                {
                    bool more;
                    do
                    {
                        INTERNET_CACHE_ENTRY_INFOA internetCacheEntry = (INTERNET_CACHE_ENTRY_INFOA)Marshal.PtrToStructure(cacheEntryInfoBuffer, typeof(INTERNET_CACHE_ENTRY_INFOA));
                        cacheEntryInfoBufferSizeInitial = cacheEntryInfoBufferSize;
                        DeleteUrlCacheEntry(internetCacheEntry.lpszSourceUrlName);
                        more = FindNextUrlCacheEntry(enumHandle, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
                        if (!more && Marshal.GetLastWin32Error() == ERROR_INSUFFICIENT_BUFFER)
                        {
                            cacheEntryInfoBufferSize = cacheEntryInfoBufferSizeInitial;
                            cacheEntryInfoBuffer = Marshal.ReAllocHGlobal(cacheEntryInfoBuffer, (IntPtr)cacheEntryInfoBufferSize);
                            more = FindNextUrlCacheEntry(enumHandle, cacheEntryInfoBuffer, ref cacheEntryInfoBufferSizeInitial);
                        }
                    } while (more);
                }
                Marshal.FreeHGlobal(cacheEntryInfoBuffer);
            }
        }
    }
}
