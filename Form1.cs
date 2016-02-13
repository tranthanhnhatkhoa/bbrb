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
//using System.Threading.Tasks;
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
        
        ///news?q=us+news&amp;FORM=ML11Z9&amp;CREA=ML11Z9&amp;rnoreward=1" id="srch1-2-15-NOT_T1T3_Control-Exist" class="tile rel blk tile-height" target="_blank" h="ID=rewards,5027.1
        ///explore/rewards-mobile?FORM=ML10NS&amp;CREA=ML10NS&amp;rnoreward=1" id="mobsrch1-2-10-NOT_T1T3_Control-Exist" class="tile rel blk tile-height" target="_blank" h="ID=rewards,5028.1
        //https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us&FORM=W5WA&uid=FC9008F2&sid=2E3761AF1D0966A7110269211C0E671C
        //https://www.bing.com/account/general
        //https://www.bing.com/
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https%3a%2f%2fwww.bing.com%2f%3fwlsso%3d1%26wlexpsignin%3d1&src=EXPLICIT&sig=1B21E07B7E04B43950F3680AF98691
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https%3a%2f%2fwww.bing.com%2frewards%2fsignin%3fFORM%3dMI0GMI%26PUBL%3dMUIDTrial%26CREA%3dMI0GMI%26wlsso%3d1%26wlexpsignin%3d1&src=EXPLICIT&sig=0348B174ED8666FA3E84B9FDEC01679C

        //https://account.live.com/identity/confirm?ru=https://login.live.com/login.srf%3flc%3d1033%26sf%3d1%26id%3d38936%26ru%3dhttps://account.live.com%253fmkt%253dEN-US%2526lc%253d1033%2526id%253d38936%26tw%3d20%26fs%3d0%26ts%3d0%26sec%3d%26mspp_share
        //https://login.live.com/login.srf?wa=wsignin1.0&amp;rpsnv=12&amp;ct=1451077233&amp;rver=6.5.6509.0&amp;wp=MBI_SSL&amp;wreply=https:%2F%2Faccount.microsoft.com%2Fauth%2Fcomplete-signin%3Fru%3Dhttps%253a%252f%252faccount.microsoft.com%252f%253frefd%253dlogin.live.com&amp;lc=1033&amp;id=292666"
        //private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https%3a%2f%2fwww.bing.com%2frewards%2fdashboard%3fwlexpsignin%3d1&src=EXPLICIT&sig=53EAA11DBE60C68B829049F399A1F2";
        ///fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&sig=05116B5A81F46BD83CAA63D280186ADD&return_url=https://www.bing.com\rewards\dashboard&Token=1
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&sig=27BCFAE69AA86D76381CF26E9B2F6CB6&return_url=https%3a%2f%2fwww.bing.com%3a443%2frewards%2fsignin%3fFORM%3dMI0GMI%26PUBL%3dMUIDTrial%26CREA%3dMI0GMI&Token=1
        //private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com&Token=1&sig=";
        //https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&sig=217B4DD1E3E46AEB169A4558E2086B86&return_url=https%3a%2f%2fwww.bing.com%3a443%2frewards%2fdashboard&Token=1
        private const string BRSIGNIN = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com/rewards/dashboard&Token=1&sig=";
        //private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https://www.bing.com/rewards/signin?FORM=MI0GMI&PUBL=MUIDTrial&CREA=MI0GMI&wlsso=1&wlexpsignin=1&src=EXPLICIT&sig=";
        //private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&src=rewardssi&perms=&return_url=https://www.bing.com&Token=1&sig=";
        private const string BRS2 = "https://www.bing.com/fd/auth/signin?action=interactive&provider=windows_live_id&return_url=https://www.bing.com/?wlsso=1%26wlexpsignin=1%26src=EXPLICIT&sig=";
        private const string BRM = "https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us&FORM=W5WA&uid=FC9008F2&sid=";

        private string[] rlink = new string[40];
        private const string MAXACCOUNTSPERIPLIMIT = "Not a valid IP. Maximum number of accounts per IP limit reached!";
        private const int DOCUMENTLOADED = 5;
        private int logtries = 0;
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
        private const int MAXIPSLEEP = 5 * 1000;
        private const int SLEEPDP = 15 * 1000;
        private const int SLEEPDASHBOARD = 30 * 1000;
        private const int SLEEPRD = 120 * 1000;
        private const int ARNDTRIES = 9;
        private int accountsRndtry = 0;
        private int accountVisitedX = 0;
        private bool loopauth = false;
        private List<bool> accountVisited;
        private const string TRIALOVER = "Too bad the trial period is over. If my program is helpful please consider to donate! Thank you very much!";
        private const string TITLE = "Better Bing Rewards Bot by Elephant7 : ";
        private const string MYIP = "My IP address: ";
        private bool trialstopped = false;
        private bool checkaccount = false;
        private string trialRegKey;
        private const int FREEX = 2000000;
        private const int DIVIDE = 50;
        private int trialCountUp = 0;
        private int trialCountDownReg = -1;
        private int authCounterX = 0;
        private bool searchesLock = false;
        private string query;
        private System.Timers.Timer timer_auth;
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
        Thread myThread;
        Thread rThread;

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
            myThread = new Thread(new ThreadStart(ClickOKButton));
            myThread.IsBackground = true;
            myThread.Start();

            rThread = new Thread(new ThreadStart(restartDocument));
            rThread.IsBackground = true;
            rThread.Start();            

            //http://stackoverflow.com/questions/204804/disable-image-loading-from-webbrowser-control-before-the-documentcompleted-event
            //RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main", true);
            //RegKey.SetValue("Display Inline Images", "no");

            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.ProgressChanged += new WebBrowserProgressChangedEventHandler(browser_ProgressChanged);

            browser.ScriptErrorsSuppressed = true;
            //this.ChangeUserAgent(this.txtboxcustomdesktop.Text);              
                     

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

            double x = (double)100 / FREEX;
            double z = x * (this.trialCountDownReg - (this.trialCountUp * DIVIDE));
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

            ReadFile(this.accountsFile, this.accounts);
            ReadFile(this.wordsFile, this.words);

            this.accountNrTxtBox.Text = "1/" + this.accounts.Count;

            this.accountVisited = new List<bool>(this.accounts.Count());
            for (int i = 0; i < this.accounts.Count; i++)
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
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand("CREATE TABLE searches (uid INTEGER PRIMARY KEY, date VARCHAR(20), ip VARCHAR(20),account VARCHAR(20),points INT)", 
                    m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();

            } else {

                // clean database
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                m_dbConnection.Open();
                DateTime dateTime = DateTime.UtcNow.Date;
                SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip,date desc",
                    m_dbConnection);
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
                        for (int i = 0; i < (c - 5);i++)
                        { 
                            command = new SQLiteCommand("delete from searches where uid=" + arr[i], m_dbConnection);
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
                m_dbConnection.Close();

                // delete 
                m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                m_dbConnection.Open();
                command = new SQLiteCommand("delete from searches where account <> '' and (points=0 or points>25) and points<>4242;", 
                    m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();

                // new us ip?
                if (this.country == "US")
                {                       
                    m_dbConnection.Open();
                    command = new SQLiteCommand("select count(*) from searches where points='" + 
                        this.ip + "," + this.country + "';", 
                        m_dbConnection);
                    reader = command.ExecuteReader();

                    int count = 0;
                    while (reader.Read())
                    {
                        count = Convert.ToInt32(reader["count(*)"]);
                    }

                    if (count == 0)
                    {
                        command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('','" +
                            this.ip +
                            "," +
                            this.country +
                            "','','')", m_dbConnection);
                        command.ExecuteNonQuery();
                    }
                    m_dbConnection.Close();
                }
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
                    this.accountsRndtry = 0;

                    this.checkaccount = false;

                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                    this.authCounterX = randomNumber(Convert.ToInt32(check[0]), Convert.ToInt32(check[1]));

                    this.authLock = false;
                    this.timer_auth.Enabled= true;                       // Enable the timer
                    this.timer_auth.Start();                              // Start the timer

                    statusTxtBox.Text = "Autostart";
                    this.button1.Text = "Auto";
                    counterTxtBox.Text = this.authCounterX.ToString() + " min.";

                    this.prevpts = 0;
                    this.pts = 0;
                    this.pts_txtbox.Text = Convert.ToString(this.pts);
                }
                else
                {
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.accountsRndtry = 0;
                    this.authLock = false;
                    this.loopauth = false;
                }
            }
            catch
            {
                statusTxtBox.Text = "Stop";
                counterTxtBox.Text = "0/0";
                this.dxloops = 0;
                this.mxloops = 0;
                this.logtries = 0;
                this.accountsRndtry = 0;
                this.authLock = false;
                this.loopauth = false;
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

        //**********************
        // Main webbrowser loop
        //**********************

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //if (this.timer_searches != null)
            //{
            //    this.timer_searches.Enabled = false;
            //}

            string url = e.Url.ToString();
            var loaded = (WebBrowser)sender;
            
            //*********************
            // Unsupported market
            //*********************

            if (loaded.Document != null
                && loaded.Url.ToString().Contains(@"https://www.bing.com/account/action?scope=web&setmkt=en-US&setplang=en-us&setlang=en-us"))
            {
                browser.Navigate(new Uri("https://www.bing.com/"));                

                //*********************
                // Unsupported market
                //*********************
            }
            else if (loaded.Document != null
                && loaded.Url.ToString().Contains(@"https://www.bing.com/rewards/unsupportedmarket")
                )
            {
                browser.Navigate(new Uri("https://www.bing.com/account/general"));
                

                //*********************
                // Unsupported market
                //*********************
            }
            else if (loaded.Document != null
                && loaded.Url.ToString().Contains(@"https://www.bing.com/account/general")
                && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                )
            {
                browser.Navigate(new Uri(BRM + this.siguid));
                

                //****************************************************
                // surpress browser dialog box & double post problem
                //****************************************************
            }
            else if (loaded.Document != null
                && (loaded.Url.ToString().Contains(@"https://account.live.com/identity/confirm")
                    || loaded.Url.ToString().Contains(@"https://account.live.com/recover")
                    || loaded.Url.ToString().Contains(@"https://account.live.com/Abuse")
                    || loaded.Url.ToString().Contains(@"https://login.live.com/ppsecure/post.srf")
                    )
                    && chkbox_autorotate.Checked == true
                    )
            {
             
                this.logtries++;

                if (this.logtries > 1)
                {
                    this.logtries = 0;
                    this.accountVisited[this.accountNum] = true;
                    ++this.accountVisitedX;                    
                    
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                    m_dbConnection.Open();
                    DateTime dateTime = DateTime.UtcNow.Date;
                    SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                        this.username +
                        "' and ip='" +
                        this.ip +
                        "' and date='" +
                        dateTime.ToString("yyyyMMdd") +
                        "';", m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    int count = 0;
                    while (reader.Read())
                    {
                        count = Convert.ToInt32(reader["count(*)"]);
                    }

                    if (count == 0)
                    {
                        command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                            dateTime.ToString("yyyyMMdd") +
                            "','" +
                            this.ip +
                            "','" +
                            this.username + "','4242')", m_dbConnection);
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        command = new SQLiteCommand("update searches set points='4242' WHERE ip='" +
                            this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") +
                            "' and account='" +
                            this.accountNameTxtBox.Text +
                            "';", m_dbConnection);
                        command.ExecuteNonQuery();                       
                    }
                    m_dbConnection.Close();

                    statusTxtBox.Text = "Authenticating";

                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled = false;
                        this.timer_auth.Stop();
                        this.timer_auth.Dispose();
                    }

                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.AutoReset = true;
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    
                    int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]), 
                        Convert.ToInt32(auth[1]));

                    this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";
                  
                    this.timer_auth.Enabled= true;
                    this.timer_auth.Start();

                    this.authLock = false;
                    this.loopauth = false;
                    this.accountsRndtry = 0;

                    browser.Navigate(new Uri("http://www.google.com"));
                    
                }

                //*********************
                // Extract sig
                //*********************
            }
            else if (loaded.Document != null
                && loaded.Url.ToString().Contains(@"https://www.bing.com/rewards/dashboard")
                && (String.IsNullOrEmpty(loaded.Document.GetElementById("id_n").InnerText)
                    || String.IsNullOrWhiteSpace(loaded.Document.GetElementById("id_n").InnerText)
                && String.IsNullOrEmpty(this.siguid) && String.IsNullOrWhiteSpace(this.siguid)
                && !loaded.Url.ToString().Contains(@"login.live.com"))
                && this.dashboardta == false
            )
            {
                try
                {
                    HtmlElementCollection links = loaded.Document.Links;
                    foreach (HtmlElement ele in links)
                    {
                        try
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
                                        browser.Navigate(new Uri(BRSIGNIN + this.siguid));
                                        break;
                                    }
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }

                //*********************
                // Sign-in Finalize
                //*********************
            }
            else if (loaded.Document != null
                && loaded.Url.ToString().Contains(@"https://www.bing.com/rewards/dashboard")
                && !String.IsNullOrEmpty(this.siguid) && !String.IsNullOrWhiteSpace(this.siguid)
                && !loaded.Url.ToString().Contains(@"login.live.com")
                && chkbox_autorotate.Checked == true
                && this.dashboardta == false
            )
            {
                browser.Navigate(new Uri("https://www.bing.com/"));
                

                //*********************
                // Sign-in Step 1
                //*********************
            }
            else if (loaded.Document != null
                && loaded.Document.GetElementById("i0116") != null)
            {
                try
                {
                    loaded.Document.GetElementById("i0116").SetAttribute("value", this.username);
                    loaded.Document.GetElementById("i0118").SetAttribute("value", this.password);
                    loaded.Document.GetElementById("idSIButton9").InvokeMember("click");
                }
                catch
                {
                }

                //*********************
                // Continue searches 
                //*********************
            }
            else if (loaded.Document != null
                && this.checkaccount == false
                && (this.Csearch == true || this.clicklist == true)
                && (loaded.Url.ToString().Contains(@"search?q=")
                     || loaded.Document.GetElementById("sb_form_q") != null)
                )
            {
                this.toolStripStatusLabel1.Text = "Searching...1";
                bool autorotate = this.chkbox_autorotate.Checked == true ? true : false;               

                // callback search bot
                if (this.pts >= 25 && autorotate == true)
                {
                    if (this.timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();
                    }

                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled = false;
                        this.timer_auth.Stop();
                        this.timer_auth.Dispose();
                    }

                    statusTxtBox.Text = "Authenticating";

                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.AutoReset = true;
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called
                    
                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]), 
                        Convert.ToInt32(auth[1]));

                    this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";

                    this.timer_auth.Enabled= true;
                    this.timer_auth.Start();
                    this.authLock = false;

                    this.searchesLock = true;
                    this.counterDx = 0;
                    this.counterMx = 0;
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.accountsRndtry = this.loopauth == true ? ARNDTRIES : 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.pts = 0;

                } else if (this.pts >= 25 && autorotate == false)
                {                   
                    if (this.timer_searches!=null)
                    {
                        this.timer_searches.Enabled = false;
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();
                    }

                    this.button1.Text = "Start";
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";

                    this.searchesLock = false;
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.authLock = false;
                    this.loopauth = false;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;

                    this.toolStripStatusLabel1.Text += "|Browser1";

                    this.toolStripStatusLabel1.Text += "|" + Convert.ToString(this.authLock) +
                       "|" + Convert.ToString(this.checkaccount) +
                       "|" + Convert.ToString(this.accountVisitedX) +
                       "|" + Convert.ToString(this.authCounterX) +
                       "|" + Convert.ToString(this.accountsRndtry) +
                       "|" + Convert.ToString(this.accounts.Count) +
                       "|" + Convert.ToString(this.accountNum) +
                       "|" + Convert.ToString(this.loopauth) +
                       "|" + this.country +
                       "|" + this.username +
                       "|" + this.pts +
                       "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                       "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");
                }
                else
                {
                    this.toolStripStatusLabel1.Text = "Searching...2";

                    if (this.timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();
                    }

                    this.timer_searches = new System.Timers.Timer();
                    this.timer_searches.AutoReset = true;
                    this.timer_searches.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                    string[] wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                    this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1])) * 1000;

                    this.timer_searches.Enabled = true;
                    this.timer_searches.Start();

                    this.searchesLock = false;
                    this.Csearch = false;
                }

                try
                {
                    if (loaded.Document.GetElementById("id_rc").InnerText != null)
                    {
                        //Thread.Sleep(1000);
                        int pts = Convert.ToInt32(loaded.Document.GetElementById("id_rc").InnerText);

                        //MessageBox.Show(string.Format("Curr P. {0} pts", pts), "Results", MessageBoxButtons.OK);
                        //MessageBox.Show(string.Format("Prev P. {0} pts", this.prevpts), "Results", MessageBoxButtons.OK);

                        if (pts == 0 || this.pts_txtbox.Text == "-")
                        {
                            Thread.Sleep(SLEEPPTS);
                            pts = Convert.ToInt32(loaded.Document.GetElementById("id_rc").InnerText);
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

                            if (delta >= 1 && delta < 2 && this.pts <= 25)
                            {
                                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                                m_dbConnection.Open();
                                DateTime dateTime = DateTime.UtcNow.Date;

                                SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                                    this.accountNameTxtBox.Text +
                                    "' and ip='" +
                                    this.ip +
                                    "' and date='" +
                                    dateTime.ToString("yyyyMMdd") +
                                    "';", m_dbConnection);
                                SQLiteDataReader reader = command.ExecuteReader();

                                int count = 0;
                                while (reader.Read())
                                {
                                    count = Convert.ToInt32(reader["count(*)"]);
                                }

                                if (count == 0)
                                {             
                                    command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                        dateTime.ToString("yyyyMMdd") +
                                        "','" +
                                        this.ip +
                                        "','" +
                                        this.accountNameTxtBox.Text +
                                        "','0')", m_dbConnection);
                                    command.ExecuteNonQuery();
                                } else
                                {                                  
                                    command = new SQLiteCommand("update searches set points='" +
                                        Convert.ToString(this.pts) +
                                        "' WHERE ip='" +
                                        this.ip +
                                        "' and date='" +
                                        dateTime.ToString("yyyyMMdd") +
                                        "' and account='" +
                                        this.accountNameTxtBox.Text +
                                        "';", m_dbConnection);
                                    command.ExecuteNonQuery();
                                }
                                m_dbConnection.Close();
                            }

                            //this.pts_txtbox.Text = Convert.ToString(this.prevpts+this.pts)+" ("+ Convert.ToString(this.pts)+")";
                            //this.pts_txtbox.Text = Convert.ToString(this.pts) + " (" + Convert.ToString(this.prevpts + this.pts) + ")";
                            this.pts_txtbox.Text = Convert.ToString(this.pts);
                        }
                    }
                }
                catch
                {
                }

                // alt search
                //loaded.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                //loaded.Document.GetElementById("sb_form_go").InvokeMember("click");

                //****************************************************
                // Sign in succesful
                // @"https://account.microsoft.com/?lang=en-US"
                //****************************************************
            }
            else if (loaded.Document != null
                && loaded.Url.ToString().Contains(@"https://account.microsoft.com/"))
            {
                ++this.logtries;
                if (this.logtries > DOCUMENTLOADED)
                {
                    this.logtries = 0;
                    bool a = false;

                    try
                    {
                        HtmlElementCollection links = loaded.Document.Links;
                        foreach (HtmlElement ele in links)
                        {
                            try
                            {
                                if ((ele.GetAttribute("href") != null)
                                && ele.GetAttribute("href").Contains(@"id=")
                                && ele.GetAttribute("href").Contains(@"login.live.com")
                                && !ele.GetAttribute("href").Contains(@"signup.live.com")
                                )
                                {
                                    string text = ele.GetAttribute("href");
                                    browser.Navigate(new Uri(text));
                                    a = true;
                                }
                            }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }

                    if (this.accountVisited[this.accountNum] == false
                        && chkbox_autorotate.Checked == true
                        && this.checkaccount == false
                        && a == false
                        )
                    {

                        if (this.timer_auth != null)
                        {
                            this.timer_auth.Enabled = false;
                            this.timer_auth.Stop();
                            this.timer_auth.Dispose();
                        }

                        this.prevpts = 0;
                        this.pts = 0;
                        this.pts_txtbox.Text = Convert.ToString(this.pts);

                        this.accountVisited[this.accountNum] = true;
                        ++this.accountVisitedX;
                        
                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        statusTxtBox.Text = "Connected";
                        counterTxtBox.Text = "0/0";
                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.logtries = 0;
                        this.searchesLock = false;
                        this.authLock = true;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;

                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();
                        DateTime dateTime = DateTime.UtcNow.Date;

                        SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                            this.accountNameTxtBox.Text +
                            "' and ip='" +
                            this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") +
                            "';", m_dbConnection);
                        SQLiteDataReader reader = command.ExecuteReader();

                        int count = 0;
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["count(*)"]);
                        }

                        if (count == 0)
                        {
                            command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                dateTime.ToString("yyyyMMdd") +
                                "','" +
                                this.ip +
                                "','" +
                                this.accountNameTxtBox.Text +
                                "','0')", m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            command = new SQLiteCommand("select * from searches where date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='" +
                                this.username +
                                "' order by ip,points", m_dbConnection);
                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["points"] != null)
                                {
                                    this.pts += Convert.ToInt32(reader["points"]);
                                }
                            }

                            this.pts_txtbox.Text = Convert.ToString(this.pts);
                        }
                        m_dbConnection.Close();

                        // first step after user auth (very important) navigate bing.com or bing.com/rewards
                        browser.Navigate(new Uri("https://www.bing.com/rewards"));
                        
                    }
                    else if (a == false
                        && (chkbox_autorotate.Checked == false || this.checkaccount == true)
                        )
                    {
                        this.prevpts = 0;
                        this.pts = 0;
                        this.pts_txtbox.Text = Convert.ToString(this.pts);

                        accountNameTxtBox.Text = this.username;
                        accountNrTxtBox.Text = (this.accountNum + 1) + "/" + this.accounts.Count;

                        statusTxtBox.Text = "Connected";
                        counterTxtBox.Text = "0/0";
                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.logtries = 0;
                        this.accountsRndtry = 0;
                        this.searchesLock = false;
                        this.authLock = false;
                        this.loopauth = false;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;

                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                            this.accountNameTxtBox.Text +
                            "' and ip='" +
                            this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") +
                            "';", m_dbConnection);
                        SQLiteDataReader reader = command.ExecuteReader();

                        int count = 0;
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["count(*)"]);
                        }

                        if (count == 0)
                        {
                            command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                dateTime.ToString("yyyyMMdd") +
                                "','" +
                                this.ip +
                                "','" +
                                this.accountNameTxtBox.Text +
                                "','0')", m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                        else
                        { 
                            command = new SQLiteCommand("select * from searches where date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='" +
                                this.username +
                                "' order by ip,points", m_dbConnection);
                            reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["points"] != null)
                                {
                                    this.pts += Convert.ToInt32(reader["points"]);
                                }
                            }
                            this.pts_txtbox.Text = Convert.ToString(this.pts);
                        }
                        m_dbConnection.Close();

                        // first step after sign in (very important) navigate bing.com or bing.com/rewards
                        browser.Navigate(new Uri("https://www.bing.com/rewards"));
                        
                    }
                    else
                    {
                        // retry
                        browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));                        
                    }
                }

                //*********************
                // Init searches
                //*********************
            }
            else if (loaded.Document != null
                && (!loaded.Url.ToString().Contains(@"https://www.bing.com/rewards") || this.dashboardta == true)
                && (loaded.Url.ToString().Contains(@"https://www.bing.com")
                    || loaded.Url.ToString().Contains(@"http://www.bing.com"))
                && !loaded.Url.ToString().Contains(@"search?q=")
                && this.checkaccount == false
                && this.searchesLock == false
                && (this.button1.Text == "Stop" || this.button1.Text == "Auto")
                )
            {
                if (this.dashboardta == false &&
                    (!loaded.Url.ToString().Contains(@"https://www.bing.com/rewards")
                    || !loaded.Url.ToString().Contains(@"http://www.bing.com")))
                {
                    this.toolStripStatusLabel1.Text = "Initial dashboard tasks!";
                    this.dashboardta = true;
                    browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));                    

                } else if (this.dashboardta == true && this.ldashboardta == false)
                {
                    this.toolStripStatusLabel1.Text = "Scrap dashboard tasks:";
                    this.numdashboardta = 0;
                    try
                    {
                        HtmlElementCollection links = loaded.Document.Links;
                        foreach (HtmlElement ele in links)
                        {
                            try
                            {
                                if ((ele.GetAttribute("href") != null)
                                && ele.GetAttribute("href").Contains(@"state=Active")
                                )
                                {
                                    this.toolStripStatusLabel1.Text = ele.GetAttribute("href");
                                    this.rlink[this.numdashboardta++] = ele.GetAttribute("href");
                                }
                                 }
                            catch
                            {
                            }
                        }
                    }
                    catch
                    {
                    }

                    Thread.Sleep(SLEEPPTS);
                    try
                    {  
                        if (browser.Document.GetElementById("srch1-2-15-NOT_T1T3_Control-Exist").InnerHtml.Contains(@"close-check"))
                        {
                            this.dxloops = MAXLOOPS;
                            this.counterDx = 0;
                            this.toolStripStatusLabel1.Text += "|Desktop";
                        } else
                        {
                            this.dxloops = 0;
                        }
                    } catch { }

                    Thread.Sleep(SLEEPPTS);
                    try
                    {
                        if (browser.Document.GetElementById("mobsrch1-2-10-NOT_T1T3_Control-Exist").InnerHtml.Contains(@"close-check"))
                        {
                            this.mxloops = MAXLOOPS;
                            this.counterMx = 0;
                            this.toolStripStatusLabel1.Text += "|Mobile";
                        } else
                        {
                            this.mxloops = 0;
                        }
                    } catch { }                    

                    if (this.mxloops == MAXLOOPS && this.dxloops == MAXLOOPS)
                    {
                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        SQLiteCommand command = new SQLiteCommand("select count(*) from searches where account='" +
                            this.accountNameTxtBox.Text +
                            "' and ip='" +
                            this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") +
                            "';", m_dbConnection);
                        SQLiteDataReader reader = command.ExecuteReader();

                        int count = 0;
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["count(*)"]);
                        }

                        if (count == 0)
                        {
                            command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                dateTime.ToString("yyyyMMdd") +
                                "','" +
                                this.ip +
                                "','" +
                                this.username +
                                "','25')", m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            command = new SQLiteCommand("update searches set points=25 WHERE ip='" +
                                this.ip +
                                "' and date='" +
                                dateTime.ToString("yyyyMMdd") +
                                "' and account='" +
                                this.username +
                                "';", m_dbConnection);
                            command.ExecuteNonQuery();                            
                        }
                        m_dbConnection.Close();
                    }

                    this.toolStripStatusLabel1.Text += "|No. Dashboard tasks ("+
                        Convert.ToString(this.numdashboardta)+")";

                    if (this.timer_dashboardta != null)
                    {
                        this.timer_dashboardta.Enabled = false;
                        this.timer_dashboardta.Stop();
                        this.timer_dashboardta.Dispose();
                    }

                    // earn dashboardta
                    this.timer_dashboardta = new System.Timers.Timer();
                    this.timer_dashboardta.Elapsed += new ElapsedEventHandler(earndashboardta); // Every time timer ticks, timer_Tick will be called
                    this.timer_dashboardta.Interval = SLEEPDASHBOARD;   // Timer will tick every 10 seconds
                    this.timer_dashboardta.Enabled = true;                         // Enable the timer
                    this.timer_dashboardta.Start();
                    this.ldashboardta = true;
                }
                else if (this.iniSearch == true)
                {
                    if (this.timer_dashboardta != null)
                    {
                        this.timer_dashboardta.Enabled = false;
                        this.timer_dashboardta.Stop();
                        this.timer_dashboardta.Dispose();
                    }

                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled = false;
                        this.timer_auth.Stop();
                        this.timer_auth.Dispose();
                    }

                    if (this.timer_searches!=null)
                    {
                        this.timer_searches.Enabled = false;                       
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();
                    }

                    // update account
                    string[] authstr = this.accounts[this.accountNum].Split('/');
                    this.username = authstr[0]; this.password = authstr[1];

                    // search parameter
                    string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                    this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));
                    this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));
                    
                    // start search bot
                    this.timer_searches = new System.Timers.Timer();
                    this.timer_searches.AutoReset = true;
                    this.timer_searches.Elapsed += new ElapsedEventHandler(searchCallback); 
                    
                    wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                    this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]), 
                        Convert.ToInt32(wait[1])) * 1000;  

                    this.timer_searches.Enabled = true;                         
                    this.timer_searches.Start();

                    this.Csearch = false;
                    this.searchesLock = false;
                    this.authLock = true;

                    this.toolStripStatusLabel1.Text += "|Initial searches";
                    this.toolStripStatusLabel1.Text += "|" + Convert.ToString(this.authLock) +
                      "|" + Convert.ToString(this.checkaccount) +
                      "|" + Convert.ToString(this.accountVisitedX) +
                      "|" + Convert.ToString(this.authCounterX) +
                      "|" + Convert.ToString(this.accountsRndtry) +
                      "|" + Convert.ToString(this.accounts.Count) +
                      "|" + Convert.ToString(this.accountNum) +
                      "|" + Convert.ToString(this.loopauth) +
                      "|" + this.country +
                      "|" + this.username +
                      "|" + this.pts +
                      "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                      "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");
                }

                //*******************************
                // sign out (check & autorotate)
                //*******************************
            }
            else if (loaded.Document != null
                && !loaded.Url.ToString().Contains(@"&")
                && (loaded.Url.ToString().Contains(@"http://login.live.com/logout.srf")
                || loaded.Url.ToString().Contains(@"http://www.msn.com")
                || loaded.Url.ToString().Contains(@"https://www.msn.com")
                || loaded.Url.ToString().Contains(@"https://login.live.com/logout.srf")
                ))
            {            
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                m_dbConnection.Open();       
                SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip desc", 
                    m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    if (this.ip == Convert.ToString(reader["ip"]) && 
                        this.accountNameTxtBox.Text != Convert.ToString(reader["account"])
                         && "4242" != Convert.ToString(reader["points"])
                        )
                    {
                        ++c;
                    }
                }
                m_dbConnection.Close();

                if (c >= MAXACCOUNTPERIP)
                {
                    this.toolStripStatusLabel1.Text = MAXACCOUNTSPERIPLIMIT + 
                        " (" + MYIP + this.ip + " Country:" + this.country + ")";

                    statusTxtBox.Text = "Authenticating";

                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled = false;
                        this.timer_auth.Stop();
                        this.timer_auth.Dispose();
                    }

                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.AutoReset = true;
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]), 
                        Convert.ToInt32(auth[1]));

                    this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";

                    this.timer_auth.Enabled= true;
                    this.timer_auth.Start();

                    this.authLock = false;
                    this.loopauth = false;
                    this.searchesLock = true;
                }
                else
                {
                    if (this.country == "US" || chkbox_tor.Checked == false)
                    {
                        if (this.timer_auth != null)
                        {
                            this.timer_auth.Enabled = false;
                            this.timer_auth.Stop();
                            this.timer_auth.Dispose();
                        }
                        this.authLock = true;
                        this.searchesLock = true;

                        // first step before sign-in
                        browser.Navigate(new Uri("https://login.live.com"));
                        
                    }
                    else
                    {
                        m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();
                        command = new SQLiteCommand("select count(*) from searches where ip='" + 
                            this.ip + "," + this.country + "';", m_dbConnection);
                        reader = command.ExecuteReader();

                        int count = 0;
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["count(*)"]);
                        }

                        if (count == 0)
                        {
                            command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('','" +
                                this.ip +
                                "," +
                                this.country +
                                "','','')", m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                        m_dbConnection.Close();

                        if (chkbox_autorotate.Checked == false)
                        {
                            if (this.timer_auth!=null)
                            {
                                this.timer_auth.Enabled = false;
                                this.timer_auth.Stop();
                                this.timer_auth.Dispose();
                            }                            

                        } else
                        {
                            statusTxtBox.Text = "Authenticating";

                            this.timer_auth = new System.Timers.Timer();
                            this.timer_auth.AutoReset = true;
                            this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                            string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                            int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]),
                                Convert.ToInt32(auth[1]));

                            this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                            counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";

                            this.timer_auth.Enabled = true;
                            this.timer_auth.Start();

                            this.authLock = false;
                            this.loopauth = false;
                            this.searchesLock = true;
                        }
                    }
                }
            }

            this.toolStripStatusLabel1.Text += "~";
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
        // Earn dashboardta
        //***********************
        private void earndashboardta(object sender, EventArgs e)
        {
            this.toolStripStatusLabel1.Text = "No. Dashboard tasks (" + Convert.ToString(this.numdashboardta) + ")";
            if (this.numdashboardta > 0)
            {
                this.dashboardtaalt = this.dashboardtaalt ^ 1;
                this.toolStripStatusLabel1.Text += " Dswitch:"+Convert.ToString(this.dashboardtaalt);

                if (this.dashboardtaalt == 0 || this.numdashboardta == 0)
                {
                    browser.Navigate(new Uri(this.rlink[--this.numdashboardta]));
                    
                }
                else
                {
                    browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));
                    
                }
            }
            else if (this.numdashboardta == 0)
            {
                --this.numdashboardta;
                browser.Navigate(new Uri("https://www.bing.com/rewards/dashboard"));                

            } else { 

                this.prevpts = 0;
                this.pts = 0;
                this.pts_txtbox.Text = Convert.ToString(this.pts);


                this.timer_dashboardta.Enabled = false;
                this.timer_dashboardta.Stop();
                this.timer_dashboardta.Dispose();

                this.iniSearch = true;
                browser.Navigate(new Uri("https://www.bing.com"));
                
            }
        }
    
        //**********************
        // Mainsearch Auth loop
        //***********************

        private void authCallback(object sender, EventArgs e)
        {
            //if (this.timer_auth != null)
            //{
            //    this.timer_auth.Enabled= false;
            //    this.timer_auth.Stop();
            //}

            string[] authstr = new string [4];
            
            --this.authCounterX;
            if (this.authCounterX > 1)
            {                
                counterTxtBox.Text = this.authCounterX.ToString() + " min.";

            } else if (this.authCounterX == 1)
            {
                counterTxtBox.Text = "30 sec.";
            }

            //********************
            // random visited
            //********************

            bool innervisited = false;

            if (this.accountVisitedX < this.accounts.Count
                && this.accountsRndtry < ARNDTRIES
                && this.checkaccount == false
                && (this.authLock == false || this.authCounterX < -10)
                && this.loopauth == false
                )
            {
                innervisited = true;

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip desc",
                    m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int c = 0;
                while (reader.Read())
                {
                    if (this.ip == Convert.ToString(reader["ip"]) &&
                        this.accountNameTxtBox.Text != Convert.ToString(reader["account"])
                         && "4242" != Convert.ToString(reader["points"])
                        )
                    {
                        ++c;
                    }
                }
                m_dbConnection.Close();

                int z = 0;
                
                //string[] list = new string[5];
                //try
                //{
                //    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                //    m_dbConnection.Open();

                //    SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip desc",
                //        m_dbConnection);
                //    SQLiteDataReader reader = command.ExecuteReader();

                //    while (reader.Read() && c < MAXACCOUNTPERIP )
                //    {
                //        if (this.ip == Convert.ToString(reader["ip"])
                //            && this.username != Convert.ToString(reader["account"])
                //            && "4242" != Convert.ToString(reader["points"])
                //            )
                //        {
                //            c++;

                //        } else if (this.ip == Convert.ToString(reader["ip"])
                //            && this.username != Convert.ToString(reader["account"])
                //            && "4242" == Convert.ToString(reader["points"])
                //            )
                //        {
                //            list[z++] = Convert.ToString(reader["account"]);
                //        }
                //    }
                //    m_dbConnection.Close();
                //}
                //catch { }

                //this.toolStripStatusLabel1.Text = "Filter:" + z + "|" + c;

                //int[] select = new int[this.accounts.Count - z];
                //int a = 0;
                //int x = 0;                    
                //bool m = false;
                //foreach (string user in this.accounts)
                //{
                //    foreach (string ele in list)
                //    {                        
                //        if (user == ele)
                //        {
                //            m = true;
                //            this.toolStripStatusLabel1.Text += "|" + ele;
                //        }
                //    }
                //    if (!m && a < select.Count())
                //    {
                //        select[a++] = x;                        
                //    } else
                //    {
                //        m = false;
                //    }
                //    ++x;
                //}

                int random = this.randomNumber(0, (this.accounts.Count - z));

                ++this.accountsRndtry;

                Array.Clear(authstr, 0, authstr.Length);
                authstr = this.accounts[random].Split('/');
                this.username = authstr[0]; this.password = authstr[1];

                this.toolStripStatusLabel1.Text = "1Loop:" + Convert.ToString(this.authLock) +
                      "|" + Convert.ToString(this.checkaccount) +
                      "|" + Convert.ToString(this.accountVisitedX) +
                      "|" + Convert.ToString(this.authCounterX) +
                      "|" + Convert.ToString(this.accountsRndtry) +
                      "|" + Convert.ToString(this.accounts.Count) +
                      "|" + Convert.ToString(this.accountNum) +
                      "|" + Convert.ToString(this.loopauth) +
                      "|" + this.country +
                      "|" + this.username +
                      "|" + this.pts +
                      "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                      "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");

                if (this.accountVisited[random] == false && random != this.accountNum)
                {
                    this.accountNum = random;
                    try
                    {
                        m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        command = new SQLiteCommand("select * from searches where date='" +
                            dateTime.ToString("yyyyMMdd") +
                            " and points<>4242" +
                            "' and account='" + this.username +
                            "' order by ip,points", m_dbConnection);
                        reader = command.ExecuteReader();
                        pts = 0;

                        while (reader.Read())
                        {
                            if (reader["points"] != null)
                            {
                                pts += Convert.ToInt32(reader["points"]);
                            }
                        }
                        m_dbConnection.Close();
                    }
                    catch { }                   
                    this.toolStripStatusLabel1.Text += "|pts:" + pts+"|c:" + c; ;

                    if (pts < 25 && c >= 0 && c < MAXACCOUNTPERIP)
                    {
                        if (this.timer_auth != null)
                        {
                            this.timer_auth.Enabled= false;
                            this.timer_auth.Stop();
                            this.timer_auth.Dispose();
                        } 

                        // use global variable 
                        this.authLock = true;
                        this.accountsRndtry = 0;

                        string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                        this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]), 
                            Convert.ToInt32(wait[1]));
                        this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]), 
                            Convert.ToInt32(wait[1]));

                        this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                        this.ClearCache();
                       
                        // first step before sign-in
                        browser.Navigate(new Uri("https://login.live.com/logout.srf"));

                    } else
                    {
                        ++this.accountVisitedX;

                        if (this.timer_auth != null)
                        {
                            this.timer_auth.Enabled = false;
                            this.timer_auth.Stop();
                            this.timer_auth.Dispose();
                        }

                        this.dxloops = 0;
                        this.mxloops = 0;
                        this.logtries = 0;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;

                        try {
                            m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                            m_dbConnection.Open();
                            DateTime dateTime = DateTime.UtcNow.Date;
                            command = new SQLiteCommand("select count(*) from searches where account='" +
                                this.username +
                                "' and ip='" + this.ip +
                                "' and date='" +
                                dateTime.ToString("yyyyMMdd") + "';", m_dbConnection);
                            reader = command.ExecuteReader();

                            int count = 0;
                            while (reader.Read())
                            {
                                count = Convert.ToInt32(reader["count(*)"]);
                            }

                            if (count == 0)
                            {
                                command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('" +
                                    dateTime.ToString("yyyyMMdd") +
                                    "','" +
                                    this.ip +
                                    "','" +
                                    this.username +
                                    "','4242')", m_dbConnection);
                                command.ExecuteNonQuery();
                            }
                            else
                            { 
                               command = new SQLiteCommand("update searches set points=4242 WHERE ip='" +
                                    this.ip +
                                    "' and date='" +
                                    dateTime.ToString("yyyyMMdd") +
                                    "' and account='" +
                                    this.username +
                                    "';", m_dbConnection);
                               command.ExecuteNonQuery();                               
                            }
                            m_dbConnection.Close();
                        } catch { }

                        if ((this.country != "US"
                           && chkbox_tor.Checked == true)
                           || c >= MAXACCOUNTPERIP)
                        {
                            this.toridswitcher();
                        }

                        this.timer_auth = new System.Timers.Timer();
                        this.timer_auth.AutoReset = true;
                        this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                        string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');

                        z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]),
                            Convert.ToInt32(auth[1]));

                        this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                        counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";

                        this.authLock = false;
                        this.timer_auth.Enabled= true;                       // Enable the timer
                        this.timer_auth.Start();                              // Start the timer
                    }
                       
                } else
                {
                    ++this.accountVisitedX;

                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled= false;
                        this.timer_auth.Stop();
                        this.timer_auth.Dispose();
                    }

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;

                    try
                    {
                        m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string sql = "select count(*) from searches where account='" +
                            this.username +
                            "' and ip='" + this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") + "';";
                        command = new SQLiteCommand(sql, m_dbConnection);
                        reader = command.ExecuteReader();

                        int count = 0;
                        while (reader.Read())
                        {
                            count = Convert.ToInt32(reader["count(*)"]);
                        }

                        if (count == 0)
                        {
                            sql = "insert into searches (date, ip, account, points) values ('" +
                                dateTime.ToString("yyyyMMdd") +
                                "','" +
                                this.ip +
                                "','" +
                                this.username +
                                "','4242')";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            sql = "update searches set points=4242 WHERE ip='" +
                                 this.ip +
                                 "' and date='" +
                                 dateTime.ToString("yyyyMMdd") +
                                 "' and account='" +
                                 this.username +
                                 "';";
                            command = new SQLiteCommand(sql, m_dbConnection);
                            command.ExecuteNonQuery();
                        }
                        m_dbConnection.Close();
                    }
                    catch { }

                    if ((this.country != "US"
                       && chkbox_tor.Checked == true)
                       || c >= MAXACCOUNTPERIP)
                    {
                        this.toridswitcher();
                    }

                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.AutoReset = true;
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]), 
                        Convert.ToInt32(auth[1]));
                    this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";

                    this.authLock = false;
                    this.timer_auth.Enabled= true;                       // Enable the timer
                    this.timer_auth.Start();                              // Start the timer

                    this.toolStripStatusLabel1.Text = "PC2:"+ Convert.ToString(this.authLock) +
                       "|" + Convert.ToString(this.checkaccount) +
                       "|" + Convert.ToString(this.accountVisitedX) +
                       "|" + Convert.ToString(this.authCounterX) +
                       "|" + Convert.ToString(this.accountsRndtry) +
                       "|" + Convert.ToString(this.accounts.Count) +
                       "|" + Convert.ToString(this.accountNum) +
                       "|" + Convert.ToString(this.loopauth) +
                       "|" + this.country +
                       "|" + this.username +
                       "|" + pts +
                       "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                       "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");
                }
            } 

            //********************
            // visit all accounts
            //********************           

/*
            if (innervisited == false
                && this.checkaccount == false 
                && this.accountVisitedX < this.accounts.Count
                && (this.accountsRndtry >= ARNDTRIES || this.loopauth == true)
                )
            {
                if (this.country != "US"
                            && chkbox_tor.Checked == true)
                {
                    this.toridswitcher();
                }

                this.loopauth = true;

                int c = 0;
                try
                {
                    SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                    m_dbConnection.Open();
                    SQLiteCommand command = new SQLiteCommand("select * from searches group by account, ip order by ip desc",
                        m_dbConnection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if (this.ip == Convert.ToString(reader["ip"])
                            && this.username != Convert.ToString(reader["account"]))
                        {
                            ++c;
                        }
                    }
                    m_dbConnection.Close();
                }
                catch { }

                this.toolStripStatusLabel1.Text = "2Loop:" + Convert.ToString(this.authLock) +
                   "|" + Convert.ToString(this.checkaccount) +
                   "|" + Convert.ToString(this.accountVisitedX) +
                   "|" + Convert.ToString(this.authCounterX) +
                   "|" + Convert.ToString(this.accountsRndtry) +
                   "|" + Convert.ToString(this.accounts.Count) +
                   "|" + Convert.ToString(this.accountNum) +
                   "|" + Convert.ToString(this.loopauth) +
                   "|" + this.country +
                   "|" + this.username +
                   "|" + pts;

                int i;
                for (i=0; i < this.accountVisited.Count; i++)
                {
                    ++this.accountVisitedX;
                    Array.Clear(authstr, 0, authstr.Length);

                    authstr = this.accounts[i].Split('/');
                    this.username = authstr[0]; this.password = authstr[1];
                    this.toolStripStatusLabel1.Text += "|"+this.username;

                    if (this.accountVisited[i] == false)
                    {                                                    
                        this.accountNum = i;
                        int pts = 0;

                        try {
                            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                            m_dbConnection.Open();
                            DateTime dateTime = DateTime.UtcNow.Date;
                            SQLiteCommand command = new SQLiteCommand("select * from searches where date='" +
                                dateTime.ToString("yyyyMMdd") +
                                " and points<>4242" +
                                "' and account='" +
                                this.username +
                                "' order by ip,points", m_dbConnection);
                            SQLiteDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                if (reader["points"] != null)
                                {
                                    pts += Convert.ToInt32(reader["points"]);
                                }
                            }
                            m_dbConnection.Close();
                        } catch { }                       

                        this.toolStripStatusLabel1.Text += "|pts:" + pts;

                        if (pts < 25 && c >= 0 && c < MAXACCOUNTPERIP)
                        {                           
                            if (this.timer_auth != null)
                            {
                                this.timer_auth.Enabled= false;
                                this.timer_auth.Stop();
                            }

                            this.accountVisited[i] = true;

                            // use global variable 
                            this.authLock = true;
                            this.loopauth = true;

                            string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                            this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]), 
                                Convert.ToInt32(wait[1]));
                            this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]), 
                                Convert.ToInt32(wait[1]));

                            this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                            this.ClearCache();
                            
                            // first step before sign-in
                            browser.Navigate(new Uri("https://login.live.com/logout.srf"));                                
                            break;

                        } else
                        {
                            this.accountVisited[i] = true;

                            if ((this.country != "US"
                             && chkbox_tor.Checked == true)
                            || c >= MAXACCOUNTPERIP)
                            {
                                this.toridswitcher();
                            }
                            break;
                        }                            
                    }
                }

                if (this.accountVisitedX >= this.accounts.Count)
                {
                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled= false;
                        this.timer_auth.Stop();
                    }

                    this.button1.Text = "Start";
                    statusTxtBox.Text = "Completed";
                    counterTxtBox.Text = "0/0";

                    //this.dxloops = 0;
                    //this.mxloops = 0;
                    //this.logtries = 0;
                    //this.accountsRndtry = 0;
                    this.authLock = false;
                    this.loopauth = false;
                    //this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;

                    this.toolStripStatusLabel1.Text += "|PC1";

                }  else
                {
                    this.toolStripStatusLabel1.Text = "PC1:" + Convert.ToString(this.authLock) +
                        "|" + Convert.ToString(this.checkaccount) +
                        "|" + Convert.ToString(this.accountVisitedX) +
                        "|" + Convert.ToString(this.authCounterX) +
                        "|" + Convert.ToString(this.accountsRndtry) +
                        "|" + Convert.ToString(this.accounts.Count) +
                        "|" + Convert.ToString(this.accountNum) +
                        "|" + Convert.ToString(this.loopauth) +
                        "|" + this.country+
                        "|" + this.username+
                        "|" + pts;

                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                }                  

            } 

   */
            if (this.checkaccount == true)
            {
                if (this.authLock && this.timer_auth != null)
                {
                    this.timer_auth.Enabled=false;
                    this.timer_auth.Stop();
                    this.timer_auth.Dispose();
                    this.loopauth = false;
                    this.authLock = false;
                }                        

                string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                    Convert.ToInt32(wait[1]));
                this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]),
                    Convert.ToInt32(wait[1]));

                authstr = this.accounts[this.accountNum].Split('/');
                this.username = authstr[0]; this.password = authstr[1];
                        
                // use global variable 
                this.authLock = true;

                this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                this.ClearCache();                  

                // first step before sign-in
                browser.Navigate(new Uri("https://login.live.com/logout.srf"));                    

            }

            this.toolStripStatusLabel1.Text += "-";
        }

        //*******************
        // Mainsearch loop
        //*******************

        private void searchCallback(object sender, EventArgs e)
        {

            //if (timer_searches != null)
            //{
            //    this.timer_searches.Enabled = false;
            //    this.timer_searches.Stop();
            //    this.Csearch = false;
            //}

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
                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.timer_searches.Stop();
                    this.timer_searches.Dispose();
                    this.Csearch = false;
                }

                if (this.timer_auth != null)
                {
                    this.timer_auth.Enabled = false;
                    this.timer_auth.Stop();
                    this.timer_auth.Dispose();
                }

                this.toolStripStatusLabel1.Text = "A. visited:" +Convert.ToString(this.accountVisitedX);
                this.toolStripStatusLabel1.Text += "|" + Convert.ToString(this.authLock) +
                   "|" + Convert.ToString(this.checkaccount) +
                   "|" + Convert.ToString(this.accountVisitedX) +
                   "|" + Convert.ToString(this.authCounterX) +
                   "|" + Convert.ToString(this.accountsRndtry) +
                   "|" + Convert.ToString(this.accounts.Count) +
                   "|" + Convert.ToString(this.accountNum) +
                   "|" + Convert.ToString(this.loopauth) +
                   "|" + this.country +
                   "|" + this.username +
                   "|" + this.pts +
                   "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                   "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");

                // accounts visited
                if (this.accountVisitedX < this.accounts.Count())
                {
                    this.qpage = 0;
                    statusTxtBox.Text = "Authenticating";
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.accountsRndtry = this.loopauth == true ? ARNDTRIES : 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;
                    this.searchesLock = true;

                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.AutoReset = true;
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called
                     
                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');
                    int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]),
                        Convert.ToInt32(auth[1]));

                    this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";
                    
                    this.timer_auth.Enabled= true;                       // Enable the timer
                    this.timer_auth.Start();                              // Start the timer

                    this.authLock = false;
                }
                else
                {
                    if (timer_searches != null)
                    {
                        this.timer_searches.Enabled = false;
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();
                    }

                    if (this.timer_auth != null)
                    {
                        this.timer_auth.Enabled = false;
                        this.timer_auth.Stop();
                        this.timer_auth.Dispose();
                    }

                    if (Convert.ToInt16(pts_txtbox.Text) >= 25 
                        || String.IsNullOrEmpty(pts_txtbox.Text) 
                        || pts_txtbox.Text == "0" 
                        || pts_txtbox.Text == "-")
                    {
                        SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                        m_dbConnection.Open();

                        DateTime dateTime = DateTime.UtcNow.Date;
                        SQLiteCommand command = new SQLiteCommand("update searches set points='4242' WHERE ip='" +
                            this.ip +
                            "' and date='" +
                            dateTime.ToString("yyyyMMdd") +
                            "' and account='" +
                            this.accountNameTxtBox.Text +
                            "';", m_dbConnection);
                        command.ExecuteNonQuery();
                        m_dbConnection.Close();
                    }
                    
                    this.button1.Text = "Start";
                    statusTxtBox.Text = "Stop";
                    counterTxtBox.Text = "0/0";
                    this.dxloops = 0;
                    this.mxloops = 0;
                    this.logtries = 0;
                    this.accountsRndtry = 0;
                    this.authLock = false;
                    this.loopauth = false;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
                    this.Csearch = false;

                    this.toolStripStatusLabel1.Text += "|Mainsearches1";

                    this.toolStripStatusLabel1.Text += "|" + Convert.ToString(this.authLock) +
                    "|" + Convert.ToString(this.checkaccount) +
                    "|" + Convert.ToString(this.accountVisitedX) +
                    "|" + Convert.ToString(this.authCounterX) +
                    "|" + Convert.ToString(this.accountsRndtry) +
                    "|" + Convert.ToString(this.accounts.Count) +
                    "|" + Convert.ToString(this.accountNum) +
                    "|" + Convert.ToString(this.loopauth) +
                    "|" + this.country +
                    "|" + this.username +
                    "|" + this.pts +
                    "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                    "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");
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
                this.checkaccount = false;
                this.searchesLock = true;

                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.timer_searches.Stop();
                    this.timer_searches.Dispose();
                    this.Csearch = false;
                }
                
                if (this.timer_auth != null)
                {
                    this.timer_auth.Enabled= false;
                    this.timer_auth.Stop();
                    this.timer_auth.Dispose();
                }

                this.button1.Text = "Start";
                statusTxtBox.Text = "Stop";
                counterTxtBox.Text = "0/0";
                this.dxloops = 0;
                this.mxloops = 0;
                this.logtries = 0;
                this.accountsRndtry = 0;
                this.authLock = false;
                this.loopauth = false;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;
                this.toolStripStatusLabel1.Text += "|Mainsearches2";

                this.toolStripStatusLabel1.Text += "|" + Convert.ToString(this.authLock) +
                "|" + Convert.ToString(this.checkaccount) +
                "|" + Convert.ToString(this.accountVisitedX) +
                "|" + Convert.ToString(this.authCounterX) +
                "|" + Convert.ToString(this.accountsRndtry) +
                "|" + Convert.ToString(this.accounts.Count) +
                "|" + Convert.ToString(this.accountNum) +
                "|" + Convert.ToString(this.loopauth) +
                "|" + this.country +
                "|" + this.username +
                "|" + this.pts +
                "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");

            }
            else if (this.searchesLock == false && this.trialstopped == false)
            {

                if (timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.timer_searches.Stop();
                    this.Csearch = false;
                }

                if (this.timer_auth != null)
                {
                    this.timer_auth.Enabled = false;
                    this.timer_auth.Stop();
                    this.timer_auth.Dispose();
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
                
                this.searchesLock = true;
                this.checkaccount = false;

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
                                    } else if (browser.Document.GetElementById("sb_form_go") != null)
                                    {
                                        browser.Document.GetElementById("sb_form_go").InvokeMember("click");
                                    } else
                                    {
                                        browser.Navigate("http://bing.com/search?q=" + this.query);
                                        
                                    }
                                }
                            }
                            else if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);
                                
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);
                                
                            }
                        }
                        catch
                        {
                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);
                                
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);
                                
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
                                        
                                    }
                                }
                            }
                            else if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: " 
                                    + this.clickref);                                
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);
                                
                            }
                        }
                        catch
                        {
                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: " + 
                                    this.clickref);                                
                            }
                            else
                            {
                                this.clicklist = false;
                                browser.Navigate("http://bing.com/search?q=" + this.query);
                                
                            }
                        }
                    }
                }
                else
                {
                    //**************************
                    // special search
                    //**************************

                    if (statusTxtBox.Text == "Mobilesearches")
                    {
                        this.ChangeUserAgent(this.txtboxcustommobile.Text);
                    }
                    else
                    {
                        this.ChangeUserAgent(this.txtboxcustomdesktop.Text);
                    }

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
                                                
                        if (c == 0)
                        {
                            this.qpage = 0;

                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                this.Csearch = true;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);
                                
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

                                try
                                {
                                    //browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                    //browser.Document.GetElementById("sbBtn").InvokeMember("click");

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
                                        }
                                    }
                                }
                                catch
                                {
                                    browser.Navigate("http://bing.com/search?q=" + this.query);                                    
                                }
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

                                try
                                {
                                    //browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                    //browser.Document.GetElementById("sb_form_go").InvokeMember("click");

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
                                        }
                                    }
                                }
                                catch
                                {
                                    browser.Navigate("http://bing.com/search?q=" + this.query);                                    
                                }
                            }                            
                        }
                        else if (c == 1)
                        {
                            //this.clicklist = true;
                            this.clicklink = this.browserUrlTxtbox.Text;
                            this.clickref = links[0];
                            if (!String.IsNullOrEmpty(this.clicklink))
                            {
                                this.Csearch = true;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: "
                                    + this.clickref);
                                
                            }
                        }
                        else if (c > 1)
                        {
                            c = randomNumber(0, c - 1);
                            this.clicklink = this.browserUrlTxtbox.Text;

                            this.clickref = links[c];
                            if (!String.IsNullOrEmpty(this.clicklink))
                            {
                                this.Csearch = true;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: " 
                                    + this.clickref);                                
                            }
                        }
                    }
                    else
                    {   //****************
                        // pagination
                        //****************

                        int c = 0;
                        int j = 0;
                        string[] links = new string[4];

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
                        } catch { }
                        

                        if (c == 0)
                        {
                            this.qpage = 0;

                            if (this.clicklist == true && !String.IsNullOrEmpty(this.clicklink))
                            {
                                this.clicklist = false;
                                this.Csearch = true;
                                browser.Navigate(new Uri(this.clicklink), "_self", null, "Referrer: " 
                                    + this.clickref);
                                
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

                                try
                                {
                                    //browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                    //browser.Document.GetElementById("sbBtn").InvokeMember("click");

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
                                            
                                        }
                                    }
                                }
                                catch
                                {
                                    browser.Navigate("http://bing.com/search?q=" + this.query);                                    
                                }
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

                                try
                                {
                                    //browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                    //browser.Document.GetElementById("sb_form_go").InvokeMember("click");

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
                                            
                                        }
                                    }
                                }
                                catch
                                {
                                    browser.Navigate("http://bing.com/search?q=" + this.query);
                                    
                                }
                            }
                        }
                        else if (c > 0)
                        {
                            this.Csearch = true;
                            if (this.qpage == 0 && !String.IsNullOrEmpty(links[0]))
                            {
                                this.qpage = 1;
                                browser.Navigate(new Uri(links[0]));
                            }
                            else if (this.qpage == 1 && !String.IsNullOrEmpty(links[1]))
                            {
                                this.qpage = 2;
                                browser.Navigate(new Uri(links[1]));
                            }
                            else if (this.qpage == 2 && !String.IsNullOrEmpty(links[2]))
                            {
                                this.qpage = 3;
                                browser.Navigate(new Uri(links[2]));
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

                                    try
                                    {
                                        //browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                        //browser.Document.GetElementById("sbBtn").InvokeMember("click");

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
                                                
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        browser.Navigate("http://bing.com/search?q=" + this.query);
                                        
                                    }
                                }
                                else
                                { 
                                    // desktop
                                    --this.counterDx;
                                    counterTxtBox.Text = (this.countDownDesktop - this.counterDx) 
                                        + "/" + this.countDownDesktop;
                                    this.Csearch = true;

                                    try
                                    {
                                        //browser.Document.GetElementById("sb_form_q").SetAttribute("value", this.query);
                                        //browser.Document.GetElementById("sb_form_go").InvokeMember("click");

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
                                                
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        browser.Navigate("http://bing.com/search?q=" + this.query);
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (this.searchesLock == false)
            {
                browser.Navigate(new Uri(browserUrlTxtbox.Text));
            }
            this.toolStripStatusLabel1.Text += "+";
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
                this.searchesLock = false;
                this.authLock = false;

                this.logtries = 0;
                this.accountsRndtry = 0;
                this.loopauth = false;
                this.accountVisitedX = 0;
                this.iniSearch = false;
                this.dashboardta = false;
                this.ldashboardta = false;
                this.Csearch = false;

                this.counterDx = this.countDownDesktop = this.counterMx = this.countDownMobile = 0;

                if (this.timer_searches != null)
                {
                    this.timer_searches.Enabled = false;
                    this.timer_searches.Stop();
                    this.timer_searches.Dispose();
                }
                
                if (this.timer_auth != null)
                {
                    this.timer_auth.Enabled= false;                       // Enable the timer
                    this.timer_auth.Stop();                              // Stop the timer
                    this.timer_auth.Dispose();
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

                    // use global variable 
                    this.authLock = true;
                    this.searchesLock = false;

                    this.logtries = 0;
                    this.accountsRndtry = 0;
                    this.loopauth = false;
                    this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;
     
                    string[] wait = Properties.Settings.Default.set_counter.ToString().Split('-');
                    this.counterDx = this.countDownDesktop = randomNumber(Convert.ToInt32(wait[0]),
                        Convert.ToInt32(wait[1]));
                    this.counterMx = this.countDownMobile = randomNumber(Convert.ToInt32(wait[0]), 
                        Convert.ToInt32(wait[1]));

                    if (this.timer_searches!=null)
                    {
                        this.timer_searches.Enabled = false;                         // Enable the timer
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();
                    }

                    this.timer_searches = new System.Timers.Timer();
                    this.timer_searches.Elapsed += new ElapsedEventHandler(searchCallback); // Every time timer ticks, timer_Tick will be called

                    string[] ns = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                    this.timer_searches.Interval = randomNumber(Convert.ToInt32(ns[0]), 
                        Convert.ToInt32(ns[1])) * 1000;   // Timer will tick every 10 seconds

                    this.timer_searches.Enabled = true;                         // Enable the timer
                    this.timer_searches.Start();     

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
                                    browser.Navigate("http://bing.com/search?q=" + this.query);
                                    
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
                                    browser.Navigate("http://bing.com/search?q=" + this.query);
                                    
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

                    this.logtries = 0;
                    this.accountsRndtry = 0;
                    
                    this.accountVisitedX = 0;
                    this.iniSearch = false;
                    this.dashboardta = false;
                    this.ldashboardta = false;

                    // reset visited
                    for (int i = 0; i < this.accountVisited.Count; i++)
                    {
                        this.accountVisited[i] = false;
                    }

                    statusTxtBox.Text = "Authenticating";
                    this.checkaccount = false;
                   
                    this.timer_auth = new System.Timers.Timer();
                    this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called
                    
                    string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');                                        
                    int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]), Convert.ToInt32(auth[1]));
                    this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                    counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";

                    this.loopauth = false;
                    this.authLock = false;
                    this.timer_auth.Enabled= true;                       // Enable the timer
                    this.timer_auth.Start();                              // Start the timer
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
            this.ClearCache();
            this.checkaccount = true;
            //MessageBox.Show(this.checkaccount == true ? "true" : "false");
            this.authLock = false;
            this.authCallback(null, null);
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
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=points.sqlite;Version=3;");
                m_dbConnection.Open();
                SQLiteCommand command = new SQLiteCommand("select count(*) from searches where ip='" + 
                    this.ip + "," + this.country + "';", m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count = Convert.ToInt32(reader["count(*)"]);
                }

                if (count == 0)
                {
                    command = new SQLiteCommand("insert into searches (date, ip, account, points) values ('','" +
                        this.ip + ","
                        + this.country +
                        "','','')", m_dbConnection);
                    command.ExecuteNonQuery();
                }
                m_dbConnection.Close();
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
                this.accountNameTxtBox.Text + "' group by account,ip";
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
                        "' and account='" + ele + "'";
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

                if (this.timer_tor!=null)
                {
                    this.timer_tor.Enabled = false;
                    this.timer_tor.Stop();
                }

                this.timer_tor = new System.Timers.Timer();
                this.timer_tor.Elapsed += new ElapsedEventHandler(RefreshTor); // Every time timer ticks, timer_Tick will be called

                this.timer_tor.Interval = SLEEPTOR;
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
                    }

                    this.timer_tor.Enabled = false;
                    this.timer_tor.Stop();

                    subgetip();
                }
                catch (Exception e)
                {
                    this.timer_tor.Enabled = false;
                    this.timer_tor.Stop();
                    MessageBox.Show(e.Message);
                } 
            }
        }

        private void ClearCache()
        {
            //browser.Document.ExecCommand("ClearAuthenticationCache", false, null);

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            //browser.Navigate(new Uri("https://www.bing.com/"));

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

        private void restartDocument()
        {
            while (true)
            {
                Thread.Sleep(SLEEPRD);

                // refresh
                if (this.button1.Text == "Stop" 
                    && this.statusTxtBox.Text != "Authenticating"
                    && this.statusTxtBox.Text != "Connected"
                    && this.statusTxtBox.Text != "Stop"
                    && this.authLock == true
                    )
                {
                    this.toolStripStatusLabel1.Text = "Restart searches:";

                    this.toolStripStatusLabel1.Text += Convert.ToString(this.authLock) +
                           "|" + Convert.ToString(this.checkaccount) +
                           "|" + Convert.ToString(this.accountVisitedX) +
                           "|" + Convert.ToString(this.authCounterX) +
                           "|" + Convert.ToString(this.accountsRndtry) +
                           "|" + Convert.ToString(this.accounts.Count) +
                           "|" + Convert.ToString(this.accountNum) +
                           "|" + Convert.ToString(this.loopauth) +
                           "|" + this.country +
                           "|" + this.username +
                           "|" + pts +
                           "|" + this.timer_searches.Enabled;

                    if (!this.timer_searches.Enabled)
                    {
                        this.timer_searches.Enabled = false;
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();

                        this.timer_searches = new System.Timers.Timer();
                        this.timer_searches.AutoReset = true;
                        this.timer_searches.Elapsed += new ElapsedEventHandler(searchCallback); // Every time timer ticks, timer_Tick will be called
                        string temp = Properties.Settings.Default.set_waitsearches.ToString();
                        string[] wait = temp.Split('-');
                        this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]), 
                            Convert.ToInt32(wait[1])) * 1000;
                        this.timer_searches.Enabled = true;
                        this.timer_searches.Start();
                    }
                    
                    this.Csearch = true;

                    browser.Navigate(new Uri(browserUrlTxtbox.Text));

                } else if (this.button1.Text == "Stop" 
                    && this.statusTxtBox.Text == "Authenticating"
                    && this.chkbox_autorotate.Checked == true
                    && this.timer_auth.Enabled == true
                    )
                {
                    if (this.accountVisitedX >= this.accounts.Count)
                    {
                        if (this.timer_auth != null)
                        {
                            this.timer_auth.Enabled = false;
                            this.timer_auth.Stop();
                            this.timer_auth.Dispose();
                        }

                        this.button1.Text = "Start";
                        statusTxtBox.Text = "Completed";
                        counterTxtBox.Text = "0/0";

                        //this.dxloops = 0;
                        //this.mxloops = 0;
                        //this.logtries = 0;
                        //this.accountsRndtry = 0;
                        this.authLock = false;
                        this.loopauth = false;
                        //this.accountVisitedX = 0;
                        this.iniSearch = false;
                        this.dashboardta = false;
                        this.ldashboardta = false;
                        this.Csearch = false;

                        this.toolStripStatusLabel1.Text += "Completed at Restart";
                    }
                    else
                    {
                        this.toolStripStatusLabel1.Text = "Restart Authenticating:";

                        this.toolStripStatusLabel1.Text += Convert.ToString(this.authLock) +
                            "|" + Convert.ToString(this.checkaccount) +
                            "|" + Convert.ToString(this.accountVisitedX) +
                            "|" + Convert.ToString(this.authCounterX) +
                            "|" + Convert.ToString(this.accountsRndtry) +
                            "|" + Convert.ToString(this.accounts.Count) +
                            "|" + Convert.ToString(this.accountNum) +
                            "|" + Convert.ToString(this.loopauth) +
                            "|" + this.country +
                            "|" + this.username +
                            "|" + pts +
                            "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                            "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");

                        if (!this.timer_auth.Enabled)
                        {
                            this.timer_auth.Enabled = false;
                            this.timer_auth.Stop();
                            this.timer_auth.Dispose();

                            this.timer_auth = new System.Timers.Timer();
                            this.timer_auth.Elapsed += new ElapsedEventHandler(authCallback); // Every time timer ticks, timer_Tick will be called

                            string[] auth = Properties.Settings.Default.set_waitauth.ToString().Split('-');

                            int z = this.authCounterX = randomNumber(Convert.ToInt32(auth[0]),
                                Convert.ToInt32(auth[1]));
                            this.timer_auth.Interval = z > 1 ? z * 60 * 1000 : 1 * 30 * 1000;
                            counterTxtBox.Text = z > 1 ? z.ToString() + " min." : "30 sec.";
                            
                            this.timer_auth.Enabled = true;                       // Enable the timer
                            this.timer_auth.Start();                              // Start the timer

                            this.authLock = false;
                        }
                        authCallback(null, null);
                    }

                } else if (this.button1.Text == "Stop"
                     && this.statusTxtBox.Text == "Connected"
                    && this.chkbox_autorotate.Checked == true
                    && this.timer_auth.Enabled==true
                )
                {
                    this.timer_auth.Enabled = false;
                    this.timer_auth.Stop();
                    this.timer_auth.Dispose();

                    this.toolStripStatusLabel1.Text = "Restart searches:";

                    this.toolStripStatusLabel1.Text += Convert.ToString(this.authLock) +
                           "|" + Convert.ToString(this.checkaccount) +
                           "|" + Convert.ToString(this.accountVisitedX) +
                           "|" + Convert.ToString(this.authCounterX) +
                           "|" + Convert.ToString(this.accountsRndtry) +
                           "|" + Convert.ToString(this.accounts.Count) +
                           "|" + Convert.ToString(this.accountNum) +
                           "|" + Convert.ToString(this.loopauth) +
                           "|" + this.country +
                           "|" + this.username +
                           "|" + pts +
                           "|" + (this.timer_auth != null ? Convert.ToString(this.timer_auth.Enabled) : "no auth") +
                           "|" + (this.timer_searches != null ? Convert.ToString(this.timer_searches.Enabled) : "no searches");

                    if (!this.timer_searches.Enabled)
                    {
                        this.timer_searches.Enabled = false;
                        this.timer_searches.Stop();
                        this.timer_searches.Dispose();

                        this.timer_searches = new System.Timers.Timer();
                        this.timer_searches.AutoReset = true;
                        this.timer_searches.Elapsed += new ElapsedEventHandler(searchCallback); // Every time timer ticks, timer_Tick will be called

                        string[] wait = Properties.Settings.Default.set_waitsearches.ToString().Split('-');
                        this.timer_searches.Interval = randomNumber(Convert.ToInt32(wait[0]),
                            Convert.ToInt32(wait[1])) * 1000;
                        this.timer_searches.Enabled = true;
                        this.timer_searches.Start();
                    }

                    this.Csearch = true;

                    browser.Navigate(new Uri(browserUrlTxtbox.Text));
                }            
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
                // double post error
                IntPtr hwnd = FindWindow("#32770", "Web Browser");
                //hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Retry");
                hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                uint message = 0xf5;
                SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);

                // gps location
                hwnd = FindWindow("#32770", "Message from webpage");
                hwnd = FindWindowEx(hwnd, IntPtr.Zero, "Button", "Cancel");
                message = 0xf5;
                SendMessage(hwnd, message, IntPtr.Zero, IntPtr.Zero);              

                Thread.Sleep(SLEEPDP);
 
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
            for (int i = 0; i < data.Length; i++)
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

        private void ReadFile(string name, List<string> list)
        {
            try
            {
                using (StreamReader r = new StreamReader(name))
                {
                    string rLine;
                    int i = 0;
                    while ((rLine = r.ReadLine()) != null)
                    {
                        list.Add(rLine);
                        ++i;
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
