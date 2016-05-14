/*************************************************************** 
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

namespace BingRewardsBot
{
    public partial class Form1 : Form
    {
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
        private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com/rewards/dashboard&Token=1&sig=";
        //private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https://www.bing.com/rewards/signin?FORM=MI0GMI&PUBL=MUIDTrial&CREA=MI0GMI&wlsso=1&wlexpsignin=1&src=EXPLICIT&sig=";
        //private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com&Token=1&sig=";
        private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https://www.bing.com/?wlsso=1%26wlexpsignin=1%26src=EXPLICIT&sig=";
        private const string BRM = "https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us&FORM=W5WA&uid=FC9008F2&sid=";

        private long pccounter = 0;
        private int refcounter = 0;
        private string[] rlink = new string[40];
        private const string MAXACCOUNTSPERIPLIMIT = "Not a valid IP. Maximum number of accounts per IP limit reached!";

        private int startbtn = 0;
        private const int MAXACCOUNTPERIP = 5;
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
        private const string EDGEUA = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/0000.0.2311.135 Safari/537.36 Edge/12.10240";
        private bool Csearch = false;
        private int qpage = 0;
        private const int SLEEPTOR = 8 * 1000;
        private const int SLEEPPTS = 5 * 1000;
        private const int SLEEPDP = 20 * 1000;
        private const int SLEEPDASHBOARD = 30 * 1000;
        private const int SLEEPMAIN = 10 * 1000;
        private const int REFRESH = 10;
        private const int AUTHSHORT = 25 * 1000;
        private int vrndnum = 0;
        private int accountVisitedX = 0;
        private List<bool> accountVisited;
        private const string TRIALOVER = "Too bad the trial period is over. If my program is helpful please consider to donate!";
        private const string TITLE = "Better Bing Rewards Bot by Elephant7 : ";
        private const string MYIP = "My IP address: ";
        private bool trialstopped = false;
        private bool checkaccount = false;
        private string trialRegKey;
        private const int FREEX = 5500000;
        private const int FREEA = 5;
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
        private int accountNum = 0;
        private string accountsFile;
        private string wordsFile;
        private List<string> accounts = new List<string>();
        private List<string> words = new List<string>();
        Thread doublePost;
        Thread mainThread;

        //http://stackoverflow.com/questions/904478/how-to-fix-the-memory-leak-in-ie-webbrowser-control
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();

        //http://stackoverflow.com/questions/9770522/how-to-handle-message-boxes-while-using-webbrowser-in-c
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

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

        //***********************
        // Constructor
        //***********************
        public Form1()
        {
            InitializeComponent();

            doublePost = new Thread(new ThreadStart(ClickOKButton));
            doublePost.IsBackground = true;
            doublePost.Start();
            
            mainThread = new Thread(new ThreadStart(mainT));
            mainThread.IsBackground = true;
            mainThread.Start();

            //http://stackoverflow.com/questions/204804/disable-image-loading-from-webbrowser-control-before-the-documentcompleted-event
            //RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            //RegKey.SetValue("Display Inline Images", "no");

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            RegKey.SetValue("Play_Animations", "no");

            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.ProgressChanged += new WebBrowserProgressChangedEventHandler(browser_ProgressChanged);

            browser.ScriptErrorsSuppressed = true;                              

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
            }

            if (this.trialCountDownReg > (FREEX * DIVIDE))
            {
                this.trialstopped = true;
                MessageBox.Show(TRIALOVER);
                Application.Exit();
            }

            double z = (double)100 / FREEX * (this.trialCountDownReg - (this.trialCountUp * DIVIDE));
            this.Text = TITLE + Math.Round(z) + "% Shareware";

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

            ReadFile(this.accountsFile, this.accounts,FREEA);
            ReadFile(this.wordsFile, this.words);

            this.accountNrTxtBox.Text = "1/" + this.accounts.Count;

            this.accountVisited = new List<bool>(this.accounts.Count());
            for (int i = 0,e =this.accounts.Count; i < e; i++)
            {
                this.accountVisited.Add(false);
            }

            string[] authstr = this.accounts[0].Split('/');
            this.accountNameTxtBox.Text = authstr[0];

            this.chkbox_tor.Checked = BingRewardsBot.Properties.Settings.Default.set_tor == true ? true : false;
            this.chkbox_mobile.Checked = BingRewardsBot.Properties.Settings.Default.set_mobile == true ? true : false;
            this.chkbox_desktop.Checked = BingRewardsBot.Properties.Settings.Default.set_desktop == true ? true : false;
            this.chkbox_autorotate.Checked = BingRewardsBot.Properties.Settings.Default.set_autorotate == true ? true : false;
            this.txtbox_autostart.Text = BingRewardsBot.Properties.Settings.Default.set_autostart;
            this.txtbox_counter.Text = BingRewardsBot.Properties.Settings.Default.set_counter;
            this.txtbox_waitsearches.Text = BingRewardsBot.Properties.Settings.Default.set_waitsearches;
            this.txtbox_waitauth.Text = BingRewardsBot.Properties.Settings.Default.set_waitauth;
            this.txtboxcustomdesktop.Text = BingRewardsBot.Properties.Settings.Default.set_uadesktop;
            this.txtboxcustommobile.Text = BingRewardsBot.Properties.Settings.Default.set_uamobile;
            this.txtbox_customaccounts.Text = BingRewardsBot.Properties.Settings.Default.set_accounts;
            this.txtbox_proxy.Text = BingRewardsBot.Properties.Settings.Default.set_proxy;
            this.txtbox_torsettings.Text = BingRewardsBot.Properties.Settings.Default.set_torsettings;

            // Get IP
            this.subgetip();
           
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

            } else {

                // clean database
                SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                DateTime dateTime = DateTime.UtcNow.Date;
                SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip,date desc",
                    dbcon);
                SQLiteDataReader reader = command.ExecuteReader();

                int c = 0;
                string curr = "";
                int[] arr = new int [40];

                while (reader.Read())
                {
                    if (curr == Convert.ToString(reader["ip"]) && c<5 )
                    {
                        arr[c++] = Convert.ToInt32(reader["uid"]);
                    }
                    else if (curr == Convert.ToString(reader["ip"]) && c>4)
                    {
                        arr[c++] = Convert.ToInt32(reader["uid"]);

                    } else if (c>4)
                    {
                        for (int i = 0, e = (c - 5); i < e;i++)
                        { 
                            command = new SQLiteCommand("delete from searches where uid=" + arr[i], dbcon);
                            command.ExecuteNonQuery();
                        }
                        curr = Convert.ToString(reader["ip"]);
                        c = 0;
                    } else
                    {
                        curr = Convert.ToString(reader["ip"]);
                        c = 0;
                    }
                }
                dbcon.Close();

                // delete 
                dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                dbcon.Open();
                command = new SQLiteCommand("delete from searches where account <> '' and (points=0 or points>28) and points<>4242;", 
                    dbcon);
                command.ExecuteNonQuery();
                dbcon.Close();

                // new us ip?
                this.newUsIp();
            }

            // Autostart
            string autostart = this.txtbox_autostart.Text = BingRewardsBot.Properties.Settings.Default.set_autostart.ToString();
            string[] check = autostart.Split('-');

            try
            {
                if (Convert.ToInt32(check[1]) > 0 && Convert.ToInt32(check[1]) > Convert.ToInt32(check[0]))
                {
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;

                    this.checkaccount = false;
                    
                    int x = randomNumber(Convert.ToInt32(check[0]), Convert.ToInt32(check[1]));
                    counterTxtBox.Text = x.ToString() + " min.";

                    this.authLock = false;
                    
                    statusTxtBox.Text = "Autostart";
                    this.button1.Text = "Auto";                  
                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";
     
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

        //***********************
        // onload&window resize
        //***********************

        private void onLoadApp(object sender, EventArgs e)
        {
            this.TopMost = false;
        }

        //https://msdn.microsoft.com/en-us/library/System.Timers.Timer.form.closing(v=vs.110).aspx
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //http://stackoverflow.com/questions/204804/disable-image-loading-from-webbrowser-control-before-the-documentcompleted-event
            //RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            //RegKey.SetValue("Display Inline Images", "yes");

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            RegKey.SetValue("Play_Animations", "yes");

            BingRewardsBot.Properties.Settings.Default.set_autorotate = chkbox_tor.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_tor = chkbox_autorotate.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_mobile = chkbox_mobile.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_desktop = chkbox_desktop.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_counter = txtbox_counter.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitsearches = txtbox_waitsearches.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitauth = txtbox_waitauth.Text;
            BingRewardsBot.Properties.Settings.Default.set_autostart = txtbox_autostart.Text;
            BingRewardsBot.Properties.Settings.Default.set_proxy = txtbox_proxy.Text;
            BingRewardsBot.Properties.Settings.Default.set_uadesktop = txtboxcustomdesktop.Text;
            BingRewardsBot.Properties.Settings.Default.set_uamobile = txtboxcustommobile.Text;
            BingRewardsBot.Properties.Settings.Default.set_accounts = txtbox_customaccounts.Text;
            BingRewardsBot.Properties.Settings.Default.set_proxy = this.txtbox_proxy.Text;
            BingRewardsBot.Properties.Settings.Default.set_torsettings = this.txtbox_torsettings.Text;
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
                //string url = e.Url.ToString();
                //this.loaded = (WebBrowser)sender;
                string url = wb.Url.ToString();

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
                }
                else if (url.Contains(@"https://www.bing.com/rewards/unsupportedmarket")
                     && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                    )
                {
                    //browser.Navigate(new Uri(BRM + this.siguid));
                    DownloadAsync("https://www.bing.com/account/general").ContinueWith(
                           (task) => this.statusDebug("UM:"),
                              TaskScheduler.FromCurrentSynchronizationContext());

                    //*********************
                    // Unsupported market
                    //*********************
                }
                else if (url.Contains(@"https://www.bing.com/account/general")
                    && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                    )
                {
                    //browser.Navigate(new Uri(BRM + this.siguid));

                    DownloadAsync(BRM + this.siguid).ContinueWith(
                          (task) => this.statusDebug("UM:"),
                             TaskScheduler.FromCurrentSynchronizationContext());

                    //****************************************************
                    // surpress wb dialog box & double post problem
                    //****************************************************
                    // https://login.live.com/ppsecure/post.srf
                }
                else if ((url.Contains(@"https://account.live.com/identity/confirm")
                        || url.Contains(@"https://account.live.com/recover")
                        || url.Contains(@"https://account.live.com/Abuse")
                        || url.Contains(@"https://login.live.com/logout.srf?lc=1033&flowtoken")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/identity/confirm")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/recover")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/Abuse")
                        || browserUrlTxtbox.Text.Contains(@"https://login.live.com/logout.srf?lc=1033&flowtoken")
                        )
                        && chkbox_autorotate.Checked == true
                        )
                {
                    if (this.accountVisited[this.accountNum] == false)
                    {
                        if (this.timer_tor != null)
                        {
                            this.timer_tor.Enabled = false;
                        }

                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;

                        this.updateUserPts(4242);

                        statusTxtBox.Text = "Authenticate";

                        string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');

                        int z = randomNumber(Convert.ToInt32(auth[0]),
                            Convert.ToInt32(auth[1]));

                        this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                        counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";

                        this.authLock = false;
                        this.vrndnum = 0;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.statusDebug("PC4:");

                        //browser.Navigate(new Uri("https://www.google.com"));
                        //browser.Navigate(new Uri("https://login.live.com/logout.srf"));

                        DownloadAsync("https://login.live.com/logout.srf").ContinueWith(
                          (task) => this.statusDebug("PC4:"),
                             TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    //*********************
                    // Continue searches 
                    //*********************

                } else if (this.checkaccount == false
                   && (this.Csearch == true || this.clicklist == true)
                   && this.authLock == true
                   && (url.Contains(@"search?q=")
                           || wb.Document.GetElementById("sb_form_q") != null)
                   && this.statusTxtBox.Text != "Dashboard"
                   )
                {

                    bool autorotate = this.chkbox_autorotate.Checked == true ? true : false;

                    // callback search bot
                    if (this.pts >= 25 && autorotate == true)
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
                    else if (this.pts >= 25 && autorotate == false)
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
                        this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]),
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
                        if ((Convert.ToInt32(this.pts_txtbox.Text) == 0 || this.prevpts == 0))
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

                            if (delta >= 1 && delta < 4 && this.pts <= 25)
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

                    //********************************
                    // Initial dashboard & searches
                    //********************************
                }
                else if ((!url.Contains(@"https://www.bing.com/rewards") || this.dashboardta == true)
                    && url.Contains(@"https://www.bing.com")
                    && !url.Contains(@"search?q=")
                    && this.checkaccount == false
                    && this.authLock == true
                    && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                    && !url.Contains(@"https://www.bing.com/rewards/unsupportedmarket")
                    && !url.Contains(@"https://www.bing.com/account/general")
                    )
                {
                    if (this.dashboardta == false
                        && !url.Contains(@"https://www.bing.com/rewards")
                        && !url.Contains(@"http://www.bing.com")
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

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                        this.dashboardta = true;

                        //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

                        DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                           (task) => this.statusDebug("DB:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else if (this.dashboardta == true && this.ldashboardta == false)
                    {
                        if (url.Contains(@"dashboard"))
                        {
                            statusTxtBox.Text = "Dashboard";
                            this.toolStripStatusLabel1.Text = "Scrap dashboard tasks:";

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
                            catch
                            {
                            }

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
                                this.updateUserPts(25);
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

                            //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

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
                        this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1])) * 1000;

                        this.Csearch = false;
                        this.authLock = true;

                        this.timer_searches.Enabled = true;

                        this.statusDebug("Initial searches:");
                    }
                    else
                    {
                        statusTxtBox.Text = "Dashboard";

                        if (this.timer_searches != null)
                        {
                            this.timer_searches.Enabled = false;
                        }
                        
                        this.statusDebug("DB:");
                        //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                        //browser.Navigate(new Uri("https://www.bing.com/"));

                        DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                            (task) => this.statusDebug("DB:"),
                               TaskScheduler.FromCurrentSynchronizationContext());

                    }
                    //*************************
                    // Sign-in 6/6 Finalize
                    //**************************
                    //&& !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                }
                else if ((url.Contains(@"https://www.bing.com/rewards/dashboard")
                        || browserUrlTxtbox.Text == "https://www.bing.com/rewards/dashboard")
                        && !url.Contains(@"login.live.com")
                        && chkbox_autorotate.Checked == true
                        && this.dashboardta == false
                        && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                    )
                {
                    string[] str = this.accounts[this.accountNum].Split('/');
                    this.username = str[0];
                    this.password = str[1];

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
                        //browser.Navigate(new Uri(BRSIGNIN + this.siguid));

                        //DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                        //   (task) => this.statusDebug("S6:"),
                        //      TaskScheduler.FromCurrentSynchronizationContext());

                        DownloadAsync("https://www.bing.com/").ContinueWith(
                             (task) => this.statusDebug("S6:"),
                                TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch
                    {
                        //browser.Navigate(new Uri("https://www.bing.com/rewards/"));
                        //browser.Navigate(new Uri("https://www.bing.com/"));

                        DownloadAsync("https://www.bing.com/").ContinueWith(
                               (task) => this.statusDebug("S6:"),
                                  TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    //********************************
                    // Sign-in 6/5: Extract user sig
                    //********************************
                }
                else if (url.Contains(@"https://www.bing.com/rewards/dashboard")
                    && (String.IsNullOrEmpty(wb.Document.GetElementById("id_n").InnerText)
                        || String.IsNullOrWhiteSpace(wb.Document.GetElementById("id_n").InnerText)
                    && String.IsNullOrEmpty(this.siguid) && String.IsNullOrWhiteSpace(this.siguid)
                    && !url.Contains(@"login.live.com"))
                    && this.dashboardta == false
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

                    string[] str = this.accounts[this.accountNum].Split('/');
                    this.username = str[0];
                    this.password = str[1];

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

                    //Thread.Sleep(SLEEPPTS);
                    //this.statusDebug("Connected:");

                    try
                    {
                        //MessageBox.Show(BRSIGNIN + this.siguid);
                        //browser.Navigate(new Uri(BRSIGNIN + this.siguid));
                        //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

                        DownloadAsync(BRSIGNIN + this.siguid).ContinueWith(
                           (task) => this.statusDebug("S5:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    catch
                    {
                        //browser.Navigate(new Uri("https://www.bing.com/"));
                        //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                        //browser.Navigate(new Uri("https://www.bing.com/rewards"));

                        DownloadAsync("https://www.bing.com/").ContinueWith(
                              (task) => this.statusDebug("S5:"),
                                 TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    //****************************************************
                    //  Sign-in Step 6/4
                    // @"https://account.microsoft.com/?lang=en-US"
                    // https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing
                    //****************************************************
                }
                else if (url == "https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing")
                {
                    this.authLock = true;
                    bool a = false;

                    try
                    {
                        // extract url       
                        HtmlElementCollection links = wb.Document.Links;
                        foreach (HtmlElement ele in links)
                        {
                            if ((ele.GetAttribute("href") != null)
                            && ele.GetAttribute("href").Contains(@"id=")
                            && ele.GetAttribute("href").Contains(@"login.live.com")
                            && !ele.GetAttribute("href").Contains(@"signup.live.com")
                            && !ele.GetAttribute("href").Contains(@"logout")
                            )
                            {
                                string text = ele.GetAttribute("href");
                                browser.Navigate(new Uri(text));
                                a = true;
                            }
                        }
                    }
                    catch { }

                    //prepare extraction & connection
                    if (this.accountVisited[this.accountNum] == false
                        && chkbox_autorotate.Checked == true
                        && this.checkaccount == false
                        && a == false
                    )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;

                        string[] str = this.accounts[this.accountNum].Split('/');
                        this.username = str[0];
                        this.password = str[1];

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

                        this.initUserSQL();

                        // first step after user auth (very important) navigate bing.com or bing.com/rewards
                        //browser.Navigate(new Uri("https://www.bing.com/rewards"));

                        DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                            (task) => this.statusDebug("S4:"),
                               TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else if ((chkbox_autorotate.Checked == false || this.checkaccount == true)
                         && a == false
                        )
                    {
                        this.prevpts = 0;
                        this.pts = 0;
                        this.pts_txtbox.Text = Convert.ToString(this.pts);

                        string[] str = this.accounts[this.accountNum].Split('/');
                        this.username = str[0];
                        this.password = str[1];

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

                        this.initUserSQL();

                        // first step after sign in (very important) navigate bing.com or bing.com/rewards
                        //browser.Navigate(new Uri("https://www.bing.com/rewards"));

                        DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                            (task) => this.statusDebug("S3:"),
                               TaskScheduler.FromCurrentSynchronizationContext());

                    }
                    else
                    {
                        // very important
                        //browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                        DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                           (task) => this.statusDebug("S3:"),
                              TaskScheduler.FromCurrentSynchronizationContext());
                    }

                    //*********************
                    // Sign-in Step 6/3
                    //*********************
                }
                else if (url == "https://login.live.com/")
                {
                    this.toolStripStatusLabel1.Text = statusTxtBox.Text = "Working";

                    //*********************
                    // Sign-in Step 6/2
                    //*********************
                }
                else if (url.Contains(@"https://www.google.com"))
                {
                    // first step before sign-in
                    //browser.Navigate(new Uri("https://login.live.com"));

                    NewLoginAsync("https://login.live.com").ContinueWith(
                        (task) => this.statusDebug("S2:"),
                            TaskScheduler.FromCurrentSynchronizationContext());

                    //*******************************
                    // Sign-in 6/1 clear cache
                    //*******************************
                }
                else if (!url.Contains(@"&")
                    && (url.Contains(@"http://login.live.com/logout.srf")
                    || url.Contains(@"http://www.msn.com")
                    || url.Contains(@"https://www.msn.com")
                    || url.Contains(@"https://login.live.com/logout.srf")
                    ))
                {
                    if (this.country == "US" || chkbox_tor.Checked == false)
                    {
                        this.authLock = true;
                        this.iniSearch = false;
                        this.Csearch = false;
                        this.ClearCache();

                        // first step before sign-in
                        //browser.Navigate(new Uri("https://www.google.com"));

                        DownloadAsync("https://www.google.com").ContinueWith(
                            (task) => this.statusDebug("S1:"),
                               TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        //SQLiteConnection dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        //dbcon.Open();
                        //SQLiteCommand command = new SQLiteCommand("select count(*) from searches where ip='" +
                        //    this.ip +
                        //    "," +
                        //    this.country +
                        //    "';",
                        //    dbcon);
                        //SQLiteDataReader reader = command.ExecuteReader();

                        //int num = 0;
                        //while (reader.Read())
                        //{
                        //    num = Convert.ToInt32(reader["count(*)"]);
                        //}
                        //if (num == 0)
                        //{
                        //    command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('','" +
                        //        this.ip +
                        //        "," +
                        //        this.country +
                        //        "','','')",
                        //        dbcon);
                        //    command.ExecuteNonQuery();
                        //}
                        //dbcon.Close();

                        if (chkbox_autorotate.Checked == true)
                        {
                            statusTxtBox.Text = "Authenticate";

                            string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');

                            int z = randomNumber(Convert.ToInt32(auth[0]),
                                Convert.ToInt32(auth[1]));

                            this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                            counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";

                            this.authLock = false;
                            this.iniSearch = false;

                            this.statusDebug("Auth2:");
                        }
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
        async Task<string> NewLoginAsync(string url)
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
            await Task.Delay(1000);

            // get the root element
            var documentElement = this.browser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(500);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }

            // artificial delay for AJAX
            await Task.Delay(1000);

            //http://stackoverflow.com/questions/11512373/findwindow-and-setforegroundwindow-alternatives
            //http://dotnet-snippets.de/snippet/form-in-den-windowsvordergrund-bringen/582 
            int hwnd = this.Handle.ToInt32();
            SetForegroundWindow(hwnd);

            mshtml.IHTMLDocument2 htmlDoc = ((dynamic)this.browser.Document.DomDocument) as mshtml.IHTMLDocument2;
            //htmlDoc.all.item("i0116").SetAttribute("value", this.username);
            //htmlDoc.all.item("i0118").SetAttribute("value", this.password);
            //htmlDoc.all.item("idSIButton9").click();

            htmlDoc.all.item("i0116").Focus();

            // artificial delay for AJAX
            await Task.Delay(100);

            ////http://stackoverflow.com/questions/6009955/use-sendkeys-with-string-in-c
            foreach (char c in this.username)
            {
                SendKeys.SendWait(c.ToString());
                await Task.Delay(50);
            }

            htmlDoc.all.item("i0118").Focus();

            // artificial delay for AJAX
            await Task.Delay(100);

            ////http://stackoverflow.com/questions/6009955/use-sendkeys-with-string-in-c
            foreach (char c in this.password)
            {
                SendKeys.SendWait(c.ToString());
                await Task.Delay(50);
            }

            await Task.Delay(100);

            //htmlDoc.all.item("i0116").SetAttribute("value", this.username);
            //htmlDoc.all.item("i0118").SetAttribute("value", this.password);

            htmlDoc.all.item("idSIButton9").click();

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
            return ((dynamic)this.browser.Document);
        }

        //http://stackoverflow.com/questions/18303758/can-i-wait-for-a-webbrowser-to-finish-navigating-using-a-for-loop
        private void DoSearch(object sender, EventArgs e)
        {
            bool autorotate = BingRewardsBot.Properties.Settings.Default.set_autorotate;
            bool mobile = BingRewardsBot.Properties.Settings.Default.set_mobile;
            bool desktop = BingRewardsBot.Properties.Settings.Default.set_desktop;

            // trial version
            if ((this.trialCountDownReg - (this.trialCountUp * DIVIDE)) < 0 && this.trialstopped == false)
            {
                this.trialstopped = true;
                MessageBox.Show(TRIALOVER);

                // autorotate
            }
            else if ((this.counterDx <= 1 && this.counterMx <= 1 && autorotate == true && this.trialstopped == false)
                || (this.counterDx <= 1 && mobile == false && autorotate == true && this.trialstopped == false)
                || (this.counterMx <= 1 && desktop == false && autorotate == true && this.trialstopped == false)
                && this.pts >= 25
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
                //foreach (bool ele in this.accountVisited)
                //{
                //    if (ele == false)
                //    {
                //        ++v;
                //    };
                //}

                if (v > 0)
                {
                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = randomNumber(Convert.ToInt32(auth[0]),
                        Convert.ToInt32(auth[1]));

                    this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";

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

                    this.statusTxtBox.Text = "Authenticate";

                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = "0";

                    this.statusDebug("Visited:");
                    this.ClearCache();

                    //browser.Navigate(new Uri("http://www.google.com"));
                    //browser.Navigate(new Uri("https://login.live.com/logout.srf"));

                    SearchAsync("https://login.live.com/logout.srf").ContinueWith(
                          (task) => this.statusDebug("Visited:"),
                                TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    if (Convert.ToInt16(pts_txtbox.Text) >= 25
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
                    this.statusDebug("Stop:");
                }

                // semi-automatic
            }
            else if (this.counterDx <= 1 && this.counterMx <= 1 && autorotate == false && this.trialstopped == false
                || (this.counterDx <= 1 && mobile == false && autorotate == false && this.trialstopped == false)
                || (this.counterMx <= 1 && desktop == false && autorotate == false && this.trialstopped == false)
                && this.pts >= 25
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
                double x = (double)100 / FREEX;
                double z = x * (this.trialCountDownReg - (this.trialCountUp * DIVIDE));
                this.Text = TITLE + Math.Round(z) + "% Shareware";

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

                    this.query = this.words[randomNumber(0, this.words.Count)];
                    if (randomNumber(0, 12) > (randomNumber(0, 6)))
                    {
                        this.query += " " + this.words[randomNumber(0, this.words.Count)];
                    }
                    if (randomNumber(0, 12) > (randomNumber(0, 3)))
                    {
                        this.query += " " + this.words[randomNumber(0, this.words.Count)];
                    }

                    // mobile searches
                    if ((randomNumber(0, 9) > (randomNumber(3, 7)) && this.counterMx >= 0 && mobile == true) ||
                        ((mobile == true && this.counterDx <= 0) || (mobile == true && desktop == false))
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

                        // desktop searches
                    }
                    else if (this.counterDx >= 0 && desktop == true)
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
                    }
                }
                else
                {

                    //**************************
                    // human search (click)
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
                            }
                            else if (statusTxtBox.Text == "Mobilesearches")
                            {
                                // mobile
                                --this.counterMx;
                                counterTxtBox.Text = (this.countDownMobile - this.counterMx) + "/"
                                    + this.countDownMobile;
                                this.Csearch = true;
                                this.clicklist = false;

                                this.query = this.words[randomNumber(0, this.words.Count)];
                                if (randomNumber(0, 12) > (randomNumber(0, 6)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }
                                if (randomNumber(0, 12) > (randomNumber(0, 3)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }

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

                                this.query = this.words[randomNumber(0, this.words.Count)];
                                if (randomNumber(0, 12) > (randomNumber(0, 6)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }
                                if (randomNumber(0, 12) > (randomNumber(0, 3)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }

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
                            }
                            else if (statusTxtBox.Text == "Mobilesearches")
                            {
                                // mobile
                                --this.counterMx;
                                counterTxtBox.Text = (this.countDownMobile - this.counterMx)
                                    + "/" + this.countDownMobile;
                                this.Csearch = true;
                                this.clicklist = false;

                                this.query = this.words[randomNumber(0, this.words.Count)];
                                if (randomNumber(0, 12) > (randomNumber(0, 6)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }
                                if (randomNumber(0, 12) > (randomNumber(0, 3)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }

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

                                this.query = this.words[randomNumber(0, this.words.Count)];
                                if (randomNumber(0, 12) > (randomNumber(0, 6)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }
                                if (randomNumber(0, 12) > (randomNumber(0, 3)))
                                {
                                    this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                }
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

                                }
                                else if (this.qpage == 1 && !String.IsNullOrEmpty(links[1]))
                                {
                                    this.qpage = 2;
                                    browser.Navigate(new Uri(links[1]));

                                    //SearchAsync(links[1]).ContinueWith(
                                    //     (task) => this.statusDebug("Search:"),
                                    //        TaskScheduler.FromCurrentSynchronizationContext());
                                }
                                else if (this.qpage == 2 && !String.IsNullOrEmpty(links[2]))
                                {
                                    this.qpage = 3;
                                    browser.Navigate(new Uri(links[2]));

                                    //SearchAsync(links[2]).ContinueWith(
                                    //    (task) => this.statusDebug("Search:"),
                                    //        TaskScheduler.FromCurrentSynchronizationContext());
                                }
                                else if (this.qpage == 3)
                                {
                                    this.qpage = 0;

                                    this.query = this.words[randomNumber(0, this.words.Count)];
                                    if (randomNumber(0, 12) > (randomNumber(0, 6)))
                                    {
                                        this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                    }
                                    if (randomNumber(0, 12) > (randomNumber(0, 3)))
                                    {
                                        this.query += " " + this.words[randomNumber(0, this.words.Count)];
                                    }

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

        async Task<string> SearchAsync (string url, string target ="", string referrer ="")
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
                this.browser.Navigate(new Uri(url),target,null,"Referrer:"+referrer);
            } else
            {
                this.browser.Navigate(new Uri(url));
            }            

            // continue upon onload
            await onloadTcs.Task;

            // artificial delay for AJAX
            await Task.Delay(1000);

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
        async Task<string> DownloadAsync(string url)
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
            await Task.Delay(1000);

            /*
            // get the root element
            var documentElement = this.browser.Document.GetElementsByTagName("html")[0];

            // poll the current HTML for changes asynchronosly
            var html = documentElement.OuterHtml;
            while (true)
            {
                // wait asynchronously, this will throw if cancellation requested
                await Task.Delay(500);

                // continue polling if the WebBrowser is still busy
                if (this.browser.IsBusy)
                    continue;

                var htmlNow = documentElement.OuterHtml;
                if (html == htmlNow)
                    break; // no changes detected, end the poll loop

                html = htmlNow;
            }

            // artificial delay for AJAX
            await Task.Delay(1000);
            */
            return ((dynamic)this.browser.Document);
        }

        //**********************
        // Earn dashboardta
        //***********************
        private void earndashboardta(object sender, EventArgs e)
        {
            statusTxtBox.Text = "Dashboard";
            this.toolStripStatusLabel1.Text = "No. Dashboard tasks (" + Convert.ToString(this.numdashboardta) + ")";
      
            if (this.numdashboardta >= 0)
            {
                this.dashboardtaalt = this.dashboardtaalt ^ 1;
                this.toolStripStatusLabel1.Text += " Switch:"+Convert.ToString(this.dashboardtaalt);
            
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

                statusTxtBox.Text = "Connected";
                this.iniSearch = true;
                //this.statusDebug(" Dashboard:", true);
                this.timer_dashboardta.Enabled = false;

                browser.Navigate(new Uri("https://www.bing.com"));

                //DownloadAsync("https://www.bing.com").ContinueWith(
                //            (task) => this.statusDebug("DB:",true),
                //                 TaskScheduler.FromCurrentSynchronizationContext());
            }
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
                if (this.iniSearch == false
                    && this.authLock == false
                    && this.button1.Text == "Stop"
                    && !browserUrlTxtbox.Text.Contains(@"landing")
                    && !browserUrlTxtbox.Text.Contains(@"dashboard")
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

                    //********************
                    // random visited
                    //********************

                    if (this.vrndnum < accounts.Count()
                        && this.checkaccount == false
                        && (this.authLock == false)
                        )
                    {
                        this.subgetip();

                        int a = 0;

                        int[] v = new int[accountVisited.Count];

                        for (int i = 0, b = this.accountVisited.Count; i < b; i++)
                        {
                            if (this.accountVisited[i] == false)
                            {
                                v[a++] = i;
                            }
                        }

                        //foreach (bool ele in this.accountVisited)
                        //{
                        //    if (ele == false)
                        //    {
                        //        v[a++] = i;
                        //    };
                        //    ++i;
                        //}

                        this.accountNum = v[this.randomNumber(0, a)];

                        Array.Clear(authstr, 0, authstr.Length);
                        authstr = this.accounts[this.accountNum].Split('/');

                        this.username = authstr[0];
                        this.password = authstr[1];

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

                        if (pts < 25 &&
                            this.accountVisited[this.accountNum] == false && this.country == "US")
                        {
                            //http://stackoverflow.com/questions/904478/how-to-fix-the-memory-leak-in-ie-webbrowser-control
                            IntPtr pHandle = GetCurrentProcess();
                            SetProcessWorkingSetSize(pHandle, -1, -1);

                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();

                            this.authLock = true;
                            this.vrndnum = 0;
                            this.dashboardta = false;
                            this.ldashboardta = false;
                            this.iniSearch = false;

                            string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                            this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                                Convert.ToInt32(wait[1]));
                            this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                                Convert.ToInt32(wait[1]));

                            this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                            this.ClearCache();

                            //this.statusDebug("PC1:");
                            this.toolStripStatusLabel1.Text += "|pts:" + pts;

                            // first step before sign-in
                            //browser.Navigate(new Uri("https://login.live.com/logout.srf"));

                            DownloadAsync("https://login.live.com/logout.srf").ContinueWith(
                                (task) => this.statusDebug("PC1:"),
                                    TaskScheduler.FromCurrentSynchronizationContext());
                        }
                        else
                        {
                            ++this.accountVisitedX;
                            this.accountVisited[this.accountNum] = false;

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
                                num = this.numIpDate();

                                if (num == 0)
                                {
                                    dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                    dbcon.Open();
                                    dateTime = DateTime.UtcNow.Date;
                                    command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
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
                                //else
                                //{
                                //    dbcon = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                //    dbcon.Open();
                                //    dateTime = DateTime.UtcNow.Date;
                                //    command = new SQLiteCommand("update searches set points=4242 WHERE ip='" +
                                //         this.ip +
                                //         "' and date='" +
                                //         dateTime.ToString("yyyyMMdd") +
                                //         "' and account='" +
                                //         this.username +
                                //         "';", dbcon);
                                //    command.ExecuteNonQuery();
                                //    dbcon.Close();
                                //}                        
                            }
                            catch { }

                            if ((this.country != "US"
                               && chkbox_tor.Checked == true))
                            {
                                this.toridswitcher();
                            }

                            statusTxtBox.Text = "Authenticate";
                            string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                            int z = randomNumber(Convert.ToInt32(auth[0]),
                                Convert.ToInt32(auth[1]));

                            this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                             counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";

                            this.authLock = false;
                            this.statusDebug("PC3:");
                        }
                    }
                    else if (this.checkaccount == false)
                    {
                        statusTxtBox.Text = "Authenticate";

                        string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                        int z = randomNumber(Convert.ToInt32(auth[0]),
                            Convert.ToInt32(auth[1]));

                        this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                        counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";

                        this.authLock = false;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;
                        this.statusDebug("PC5:");
                    }
                    else if (this.checkaccount == true)
                    {
                        string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                        this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1]));
                        this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1]));

                        authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.authLock = true;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.iniSearch = false;

                        this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                        this.ClearCache();

                        // first step before sign-in
                        this.browser.Navigate(new Uri("https://login.live.com/logout.srf"));

                        //DownloadAsync("https://login.live.com/logout.srf").ContinueWith(
                        //      (task) => this.statusDebug("PC1:"),
                        //      TaskScheduler.FromCurrentSynchronizationContext());
                    }
                }
                //else if ((browserUrlTxtbox.Text.Contains(@"https://www.bing.com/rewards") || this.dashboardta == true)
                //  && browserUrlTxtbox.Text.Contains(@"https://www.bing.com")
                //  && !browserUrlTxtbox.Text.Contains(@"search?q=")
                //  && this.checkaccount == false
                //  && this.authLock == true
                //  && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                //  && !browserUrlTxtbox.Text.Contains(@"https://www.bing.com/rewards/unsupportedmarket")
                //  && !browserUrlTxtbox.Text.Contains(@"https://www.bing.com/account/general")
                //  && this.iniSearch == false
                //  )
                //{
                //    browser.Navigate(new Uri("https://www.bing.com"));
                //}
                else if (browserUrlTxtbox.Text == "https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=land1ng")
                {
                    this.authLock = true;
                    bool a = false;
                    try
                    {
                        // extract url       
                        HtmlElementCollection links = browser.Document.Links;
                        foreach (HtmlElement ele in links)
                        {
                            if ((ele.GetAttribute("href") != null)
                            && ele.GetAttribute("href").Contains(@"id=")
                            && ele.GetAttribute("href").Contains(@"login.live.com")
                            && !ele.GetAttribute("href").Contains(@"signup.live.com")
                            && !ele.GetAttribute("href").Contains(@"logout")
                            )
                            {
                                string text = ele.GetAttribute("href");
                                browser.Navigate(new Uri(text));
                                a = true;
                            }
                        }
                    }
                    catch { }

                    //prepare extraction & connection
                    if (this.accountVisited[this.accountNum] == false
                        && chkbox_autorotate.Checked == true
                        && this.checkaccount == false
                        && a == false
                        )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];

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

                        this.initUserSQL();

                        // first step after user auth (very important) navigate bing.com or bing.com/rewards
                        browser.Navigate(new Uri("https://www.bing.com/rewards"));

                        //DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                        //      (task) => this.statusDebug("Connected:"),
                        //      TaskScheduler.FromCurrentSynchronizationContext());

                    }
                    else if ((chkbox_autorotate.Checked == false || this.checkaccount == true) && a == false)
                    {
                        this.prevpts = 0;
                        this.pts = 0;
                        this.pts_txtbox.Text = Convert.ToString(this.pts);

                        string[] authstr = this.accounts[this.accountNum].Split('/');
                        this.username = authstr[0];
                        this.password = authstr[1];

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
                        this.initUserSQL();

                        // first step after sign in (very important) navigate bing.com or bing.com/rewards
                        browser.Navigate(new Uri("https://www.bing.com/rewards"));

                        //DownloadAsync("https://www.bing.com/rewards").ContinueWith(
                        //     (task) => this.statusDebug("Connected:"),
                        //     TaskScheduler.FromCurrentSynchronizationContext());
                    }
                    else
                    {
                        // retry
                        browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

                        //DownloadAsync("https://www.bing.com/rewards/dashboard").ContinueWith(
                        //    (task) => this.statusDebug("Connected:"),
                        //    TaskScheduler.FromCurrentSynchronizationContext());

                    }
                }
                
                Thread.Sleep(SLEEPMAIN);
                
                ++this.pccounter;
                
                if (this.refcounter>REFRESH)
                {
                    this.refcounter = 0;
                    if (this.button1.Text == "Stop"
                        && this.statusTxtBox.Text != "Authenticate"
                        && this.statusTxtBox.Text != "Stop"
                        && this.authLock == true
                        && this.Csearch == true
                        && !this.browserUrlTxtbox.Text.Contains(@"landing")
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
                        this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1])) * 1000;

                        this.Csearch = true;

                        this.timer_searches.Enabled = true;
                        //this.timer_searches.Start();

                        //https://login.live.com/ppsecure/post.srf
                        if (browserUrlTxtbox.Text.Contains(@"https://account.live.com/identity/confirm")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/recover")
                        || browserUrlTxtbox.Text.Contains(@"https://account.live.com/Abuse")
                        || browserUrlTxtbox.Text.Contains(@"https://login.live.com/ppsecure/post.srf")
                          && !this.browserUrlTxtbox.Text.Contains(@"landing")
                        )
                        {
                            browser.Navigate(new Uri("http://www.google.com"));
                        }
                        else
                        {
                            browser.Navigate(new Uri(browserUrlTxtbox.Text));
                        }
                    }
                    else if (browserUrlTxtbox.Text.Contains(@"https://account.microsoft.com/?lang=en-US&refd=account.live.com&refp=landing"))
                    {
                        bool a = false;

                        //try
                        //{
                        //    // extract url       
                        //    HtmlElementCollection links = browser.Document.Links;
                        //    foreach (HtmlElement ele in links)
                        //    {

                        //        if ((ele.GetAttribute("href") != null)
                        //        && ele.GetAttribute("href").Contains(@"id=")
                        //        && ele.GetAttribute("href").Contains(@"login.live.com")
                        //        && !ele.GetAttribute("href").Contains(@"signup.live.com")
                        //        )
                        //        {
                        //            string text = ele.GetAttribute("href");
                        //            browser.Navigate(new Uri(text));
                        //            a = true;
                        //        }
                        //    }
                        //}
                        //catch { }

                        //prepare connection
                        if (chkbox_autorotate.Checked == true
                            && a == false
                            )
                        {
                           
                            this.accountVisited[this.accountNum] = true;
                            ++this.accountVisitedX;

                            string[] authstr = this.accounts[this.accountNum].Split('/');
                            this.username = authstr[0];
                            this.password = authstr[1];

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

                            this.initUserSQL();

                            // first step after user auth (very important) navigate bing.com or bing.com/rewards
                            browser.Navigate(new Uri("https://www.bing.com/rewards"));
                        }

                    }
                    else if ((browserUrlTxtbox.Text.Contains(@"https://account.live.com/identity/confirm")
                      || browserUrlTxtbox.Text.Contains(@"https://account.live.com/recover")
                      || browserUrlTxtbox.Text.Contains(@"https://account.live.com/Abuse")
                      || browserUrlTxtbox.Text.Contains(@"https://login.live.com/ppsecure/post.srf")
                      || (browserUrlTxtbox.Text.Contains(@"https://www.bing.com")
                      && this.statusTxtBox.Text != "Connected"
                      && this.statusTxtBox.Text != "Working"
                      && this.statusTxtBox.Text != "Dashboard"
                      && this.statusTxtBox.Text != "Desktopsearches"
                      && this.statusTxtBox.Text != "Mobilesearches")
                      && !this.toolStripStatusLabel1.Text.Contains(@"Connected")
                      )
                      && chkbox_autorotate.Checked == true
                      && this.button1.Text == "Stop"
                      )
                    {
                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;

                        this.restartAuth();
                    }
                    else if (this.button1.Text == "Stop"
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
                    else if (this.button1.Text == "Stop"
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
                    else if (this.button1.Text == "Stop"
                      && this.authLock == true
                      && this.chkbox_autorotate.Checked == true
                      && (this.statusTxtBox.Text == "Dashboard"
                      || this.toolStripStatusLabel1.Text.Contains(@"Finalize"))
                      && !this.toolStripStatusLabel1.Text.Contains(@"Searching")
                      )
                    {
                        statusTxtBox.Text = "Dashboard";

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

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                        this.dashboardta = true;

                        browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));

                    }
                    else if (this.button1.Text == "Stop"
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


                } else
                {
                    ++this.refcounter;                    
                }

                if (this.toolStripStatusLabel1.Text.Length < 70)
                {
                    this.toolStripStatusLabel1.Text += "+" + Convert.ToString(this.refcounter);

                } else if (this.authLock == true && this.checkaccount==false && this.button1.Text=="Stop") 
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
                    //

                    this.statusDebug("PC:");
                    this.toolStripStatusLabel1.Text += "+";

                } else
                {
                    this.statusDebug("PC:");
                    this.toolStripStatusLabel1.Text += "+";
                }
            }
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

            if (v == 0)
            {
                if (this.dxloops >= MAXLOOPS && this.mxloops >= MAXLOOPS)
                {
                    
                    this.button1.Text = "Start";
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";

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

                    this.statusDebug("Stop:");
                }
            }
            else
            {
                //this.accountVisited[this.accountNum] = true;
                //++this.accountVisitedX;
                
                string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                int z = randomNumber(Convert.ToInt32(auth[0]),
                    Convert.ToInt32(auth[1]));

                this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";
                
                string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                    Convert.ToInt32(wait[1]));
                this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                    Convert.ToInt32(wait[1]));

                this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                this.ClearCache();

                this.authLock = true;
                this.vrndnum = 0;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;

                this.statusDebug("Restart:");
                this.statusTxtBox.Text = "Authenticate";

                // first step before sign-in
                //browser.Navigate(new Uri("https://login.live.com/logout.srf"));

                DownloadAsync("https://login.live.com/logout.srf").ContinueWith(
                    (task) => this.statusDebug("PC1:"),
                        TaskScheduler.FromCurrentSynchronizationContext());
               
                //browser.Navigate(new Uri("http://www.google.com"));
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
        
        //****************************************************
        // start button
        //****************************************************

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onClickStart(object sender, EventArgs e)
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
                    this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]),
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

                            this.query = this.words[randomNumber(0, this.words.Count)];
                            if (randomNumber(0, 9) > (randomNumber(3, 7)))
                            {
                                this.query += " " + this.words[randomNumber(0, this.words.Count)];
                            }

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

                                    DownloadAsync("http://bing.com/search?q=" + this.query).ContinueWith(
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

                                    DownloadAsync("http://bing.com/search?q=" + this.query).ContinueWith(
                                        (task) => this.statusDebug("Search:"),
                                           TaskScheduler.FromCurrentSynchronizationContext());
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
                else if (chkbox_autorotate.Checked == true)
                {
                    this.button1.Text = "Stop";

                    this.Csearch = false;
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.vrndnum = 0;
                    
                    this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;

                    // reset visited
                    for (int i = 0,b = this.accountVisited.Count; i < b; i++)
                    {
                        this.accountVisited[i] = false;
                    }

                    statusTxtBox.Text = "Authenticate";
                    this.checkaccount = false;
                   
                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = randomNumber(Convert.ToInt32(auth[0]), Convert.ToInt32(auth[1]));

                    this.timer_auth = z > 1 ? z * 60 * 1000 : AUTHSHORT;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "some sec.";
                    
                    this.authLock = false;                                                                                      

                    this.statusDebug("Initial:");
                }
            }
        }

        private void settingsSaveBtn_Click(object sender, EventArgs e)
        {
            BingRewardsBot.Properties.Settings.Default.set_autorotate = chkbox_tor.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_tor = chkbox_autorotate.Checked == true ? true : false;
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
            BingRewardsBot.Properties.Settings.Default.Save();

            if (BingRewardsBot.Properties.Settings.Default.set_tor == true)
            {
                if (BingRewardsBot.Properties.Settings.Default.set_proxy != "")
                {
                    WinInetInterop.SetConnectionProxy(Properties.Settings.Default.set_proxy.ToString());

                } else
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
        }

        private void prev_button_Click(object sender, EventArgs e)
        {
            if (this.accountNum > 0)
            {
                --this.accountNum;
                string[] auth = this.accounts[this.accountNum].Split('/');
                this.username = auth[0];
                this.password = auth[1];

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;
            }
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            if (this.accountNum < (this.accounts.Count - 1))
            {
                ++this.accountNum;
                string[] auth = this.accounts[this.accountNum].Split('/');
                this.username = auth[0];
                this.password = auth[1];

                accountNameTxtBox.Text = this.username;
                accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;
            }
        }

        private void check_button_Click(object sender, EventArgs e)
        {
            BingRewardsBot.Properties.Settings.Default.Save();
            this.checkaccount = true;
            this.authLock = false;
            this.button1.Text = "Stop";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //var myForm = new Form2();
            //myForm.Show();

            BingRewardsBot.Properties.Settings.Default.set_tor = chkbox_tor.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_autorotate = chkbox_autorotate.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_mobile = chkbox_mobile.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_desktop = chkbox_desktop.Checked == true ? true : false;
            BingRewardsBot.Properties.Settings.Default.set_counter = txtbox_counter.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitsearches = txtbox_waitsearches.Text;
            BingRewardsBot.Properties.Settings.Default.set_waitauth = txtbox_waitauth.Text;
            BingRewardsBot.Properties.Settings.Default.set_autostart = txtbox_autostart.Text;
            BingRewardsBot.Properties.Settings.Default.set_uadesktop = txtboxcustomdesktop.Text;
            BingRewardsBot.Properties.Settings.Default.set_uamobile = txtboxcustommobile.Text;
            BingRewardsBot.Properties.Settings.Default.set_accounts = txtbox_customaccounts.Text;
            BingRewardsBot.Properties.Settings.Default.set_torsettings = this.txtbox_torsettings.Text;
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

            if (this.country != "US")
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
                "','"+
                Convert.ToString(a)+
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
            if (this.country == "US")
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
                this.ip = this.GetIP().Replace("\r\n", "");
            }
            catch { }

            try
            {
                this.country = this.QueryGeo(this.ip);
                this.toolStripStatusLabel1.Text = MYIP + this.ip + " Country:" + this.country;
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

                if (this.timer_tor==null)
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

                    while(toriddone == false && c < 10)
                    {
                        this.toolStripStatusLabel1.Text += c+"|";
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

        private void ClearCache()
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
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8");
            //Cookies()
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
            //History()
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 1");
            //Form(Data)
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 16");
            //Passwords
            System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 32");
            //Delete(All)
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 255");
            //Delete All – Also delete files and settings stored by add-ons
            //System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 4351")
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
                        ++v;
                    }
                }

                //foreach (bool ele in this.accountVisited)
                //{
                //    if (ele == false)
                //    {
                //        ++v;
                //    };
                //}

                if (b)
                {
                    this.toolStripStatusLabel1.Text += a + Convert.ToString(this.authLock) +
                        "|" + Convert.ToString(this.checkaccount) +
                        "|" + Convert.ToString(this.iniSearch) +
                        "|" + Convert.ToString(this.accountVisitedX) +
                        "|" + Convert.ToString(v) +
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
                      "|" + Convert.ToString(v) +
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
        private void ClickOKButton()
        {
            while (true)
            {
                Thread.Sleep(SLEEPDP);

                // double post error
                IntPtr hwnd = FindWindow("#32770", "Web Browser");      
                if (IsWindow(hwnd))
                {
                    //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Retry");                
                    hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                    uint message = 0xf5;
                    SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);
                    browser.Navigate(new Uri("https://www.google.com/"));
                    this.accountVisited[this.accountNum] = true;
                    ++this.accountVisitedX;

                    this.restartAuth();
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
            } else
            {
                ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), TORCONTROLPORT);
            }

            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                server.Connect(ip);
            }
            catch (Exception ex)
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
                    
                } else
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
            for (int i = 0,e = data.Length; i < e; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        private int randomNumber(int min, int max)
        {
            DateTime dateTime = DateTime.UtcNow.Date;
            Random random = new Random(dateTime.Millisecond+Guid.NewGuid().GetHashCode());
            return random.Next(min, max);
        }

        private void ReadFile(string name, List<string> list, int count=100000000)
        {
            try
            {
                using (StreamReader r = new StreamReader(name))
                {
                    string rLine;
                    int i = 0;
                    while ((rLine = r.ReadLine()) != null && count>0)
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
        private string GetIP()
        {
            // check IP using DynDNS's service
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            // IMPORTANT: set Proxy to null, to drastically INCREASE the speed of request
            //request.Proxy = null;

            // read complete response
            string ipAddress = stream.ReadToEnd();

            // replace everything and keep only IP
            return ipAddress.Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).Replace("</body></html>", string.Empty);
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
                    oIP2Location.IPDatabasePath = "geoip.bin";

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.TopMost = false;
            var si = new ProcessStartInfo("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=BBWLBNCPKP7AW");
            Process.Start(si);
            linkLabel1.LinkVisited = true;            
        }
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
