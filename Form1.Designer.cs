namespace BingRewardsBot
{
    partial class Form1
    {

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.browserUrlTxtbox = new System.Windows.Forms.TextBox();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btn_ip = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_cache = new System.Windows.Forms.Button();
            this.pts_txtbox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.next_button = new System.Windows.Forms.Button();
            this.prev_button = new System.Windows.Forms.Button();
            this.chkbox_autorotate = new System.Windows.Forms.CheckBox();
            this.check_button = new System.Windows.Forms.Button();
            this.counterTxtBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.statusTxtBox = new System.Windows.Forms.TextBox();
            this.accountNrTxtBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.accountNameTxtBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtbox_customaccounts = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtboxcustommobile = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtboxcustomdesktop = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtbox_proxy = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.chkbox_tor = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbox_autostart = new System.Windows.Forms.TextBox();
            this.settingsSaveBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkbox_desktop = new System.Windows.Forms.CheckBox();
            this.chkbox_mobile = new System.Windows.Forms.CheckBox();
            this.txtbox_waitauth = new System.Windows.Forms.TextBox();
            this.txtbox_counter = new System.Windows.Forms.TextBox();
            this.txtbox_waitsearches = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.passwd_txtbox = new System.Windows.Forms.TextBox();
            this.regcode_txtbox = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.btn_ip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // browserUrlTxtbox
            // 
            this.browserUrlTxtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browserUrlTxtbox.BackColor = System.Drawing.SystemColors.Window;
            this.browserUrlTxtbox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.browserUrlTxtbox.Location = new System.Drawing.Point(0, 31);
            this.browserUrlTxtbox.Name = "browserUrlTxtbox";
            this.browserUrlTxtbox.Size = new System.Drawing.Size(518, 20);
            this.browserUrlTxtbox.TabIndex = 0;
            this.browserUrlTxtbox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            // 
            // browser
            // 
            this.browser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.browser.Location = new System.Drawing.Point(0, 174);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(726, 284);
            this.browser.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.btn_ip);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(-2, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(736, 513);
            this.tabControl1.TabIndex = 2;
            // 
            // btn_ip
            // 
            this.btn_ip.BackColor = System.Drawing.Color.White;
            this.btn_ip.Controls.Add(this.button4);
            this.btn_ip.Controls.Add(this.btn_cache);
            this.btn_ip.Controls.Add(this.pts_txtbox);
            this.btn_ip.Controls.Add(this.button3);
            this.btn_ip.Controls.Add(this.statusStrip1);
            this.btn_ip.Controls.Add(this.next_button);
            this.btn_ip.Controls.Add(this.prev_button);
            this.btn_ip.Controls.Add(this.chkbox_autorotate);
            this.btn_ip.Controls.Add(this.check_button);
            this.btn_ip.Controls.Add(this.counterTxtBox);
            this.btn_ip.Controls.Add(this.label13);
            this.btn_ip.Controls.Add(this.statusTxtBox);
            this.btn_ip.Controls.Add(this.accountNrTxtBox);
            this.btn_ip.Controls.Add(this.label12);
            this.btn_ip.Controls.Add(this.accountNameTxtBox);
            this.btn_ip.Controls.Add(this.button1);
            this.btn_ip.Controls.Add(this.browserUrlTxtbox);
            this.btn_ip.Controls.Add(this.browser);
            this.btn_ip.Location = new System.Drawing.Point(4, 23);
            this.btn_ip.Name = "btn_ip";
            this.btn_ip.Padding = new System.Windows.Forms.Padding(3);
            this.btn_ip.Size = new System.Drawing.Size(728, 486);
            this.btn_ip.TabIndex = 0;
            this.btn_ip.Text = "Search";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(450, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 21);
            this.button4.TabIndex = 18;
            this.button4.Text = "IP";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_cache
            // 
            this.btn_cache.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btn_cache.Location = new System.Drawing.Point(425, 2);
            this.btn_cache.Name = "btn_cache";
            this.btn_cache.Size = new System.Drawing.Size(21, 21);
            this.btn_cache.TabIndex = 17;
            this.btn_cache.Text = "C";
            this.btn_cache.UseVisualStyleBackColor = true;
            this.btn_cache.Click += new System.EventHandler(this.btn_cache_Click);
            // 
            // pts_txtbox
            // 
            this.pts_txtbox.BackColor = System.Drawing.SystemColors.Window;
            this.pts_txtbox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.pts_txtbox.Location = new System.Drawing.Point(129, 2);
            this.pts_txtbox.Name = "pts_txtbox";
            this.pts_txtbox.Size = new System.Drawing.Size(49, 20);
            this.pts_txtbox.TabIndex = 16;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.button3.Location = new System.Drawing.Point(399, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 21);
            this.button3.TabIndex = 15;
            this.button3.Text = "I";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(722, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // next_button
            // 
            this.next_button.Font = new System.Drawing.Font("Tahoma", 9F);
            this.next_button.Location = new System.Drawing.Point(350, 2);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(21, 21);
            this.next_button.TabIndex = 14;
            this.next_button.Text = "+";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // prev_button
            // 
            this.prev_button.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.prev_button.Location = new System.Drawing.Point(108, 2);
            this.prev_button.Name = "prev_button";
            this.prev_button.Size = new System.Drawing.Size(19, 21);
            this.prev_button.TabIndex = 13;
            this.prev_button.Text = "-";
            this.prev_button.UseVisualStyleBackColor = true;
            this.prev_button.Click += new System.EventHandler(this.prev_button_Click);
            // 
            // chkbox_autorotate
            // 
            this.chkbox_autorotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbox_autorotate.AutoSize = true;
            this.chkbox_autorotate.Checked = true;
            this.chkbox_autorotate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_autorotate.Location = new System.Drawing.Point(551, 33);
            this.chkbox_autorotate.Name = "chkbox_autorotate";
            this.chkbox_autorotate.Size = new System.Drawing.Size(96, 18);
            this.chkbox_autorotate.TabIndex = 12;
            this.chkbox_autorotate.Text = "Autorotate";
            this.chkbox_autorotate.UseVisualStyleBackColor = true;
            // 
            // check_button
            // 
            this.check_button.Font = new System.Drawing.Font("Tahoma", 9F);
            this.check_button.Location = new System.Drawing.Point(375, 2);
            this.check_button.Name = "check_button";
            this.check_button.Size = new System.Drawing.Size(20, 21);
            this.check_button.TabIndex = 11;
            this.check_button.Text = "A";
            this.check_button.UseVisualStyleBackColor = true;
            this.check_button.Click += new System.EventHandler(this.check_button_Click);
            // 
            // counterTxtBox
            // 
            this.counterTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.counterTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.counterTxtBox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.counterTxtBox.Location = new System.Drawing.Point(541, 3);
            this.counterTxtBox.Name = "counterTxtBox";
            this.counterTxtBox.ReadOnly = true;
            this.counterTxtBox.Size = new System.Drawing.Size(65, 20);
            this.counterTxtBox.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label13.Location = new System.Drawing.Point(492, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 14);
            this.label13.TabIndex = 9;
            this.label13.Text = "Status:";
            // 
            // statusTxtBox
            // 
            this.statusTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statusTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.statusTxtBox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.statusTxtBox.Location = new System.Drawing.Point(612, 3);
            this.statusTxtBox.Name = "statusTxtBox";
            this.statusTxtBox.ReadOnly = true;
            this.statusTxtBox.Size = new System.Drawing.Size(116, 20);
            this.statusTxtBox.TabIndex = 8;
            // 
            // accountNrTxtBox
            // 
            this.accountNrTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.accountNrTxtBox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.accountNrTxtBox.Location = new System.Drawing.Point(65, 3);
            this.accountNrTxtBox.Name = "accountNrTxtBox";
            this.accountNrTxtBox.ReadOnly = true;
            this.accountNrTxtBox.Size = new System.Drawing.Size(40, 20);
            this.accountNrTxtBox.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label12.Location = new System.Drawing.Point(2, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 14);
            this.label12.TabIndex = 6;
            this.label12.Text = "Account:";
            // 
            // accountNameTxtBox
            // 
            this.accountNameTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.accountNameTxtBox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.accountNameTxtBox.Location = new System.Drawing.Point(184, 2);
            this.accountNameTxtBox.Name = "accountNameTxtBox";
            this.accountNameTxtBox.ReadOnly = true;
            this.accountNameTxtBox.Size = new System.Drawing.Size(161, 20);
            this.accountNameTxtBox.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(653, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onClickStart);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.txtbox_customaccounts);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.txtboxcustommobile);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.txtboxcustomdesktop);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.linkLabel1);
            this.tabPage2.Controls.Add(this.txtbox_proxy);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.chkbox_tor);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtbox_autostart);
            this.tabPage2.Controls.Add(this.settingsSaveBtn);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.chkbox_desktop);
            this.tabPage2.Controls.Add(this.chkbox_mobile);
            this.tabPage2.Controls.Add(this.txtbox_waitauth);
            this.tabPage2.Controls.Add(this.txtbox_counter);
            this.tabPage2.Controls.Add(this.txtbox_waitsearches);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(728, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // txtbox_customaccounts
            // 
            this.txtbox_customaccounts.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtbox_customaccounts.Location = new System.Drawing.Point(178, 402);
            this.txtbox_customaccounts.Name = "txtbox_customaccounts";
            this.txtbox_customaccounts.Size = new System.Drawing.Size(238, 22);
            this.txtbox_customaccounts.TabIndex = 36;
            this.txtbox_customaccounts.Text = "accounts.txt";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label19.Location = new System.Drawing.Point(7, 406);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(119, 14);
            this.label19.TabIndex = 35;
            this.label19.Text = "Custom account file:";
            // 
            // txtboxcustommobile
            // 
            this.txtboxcustommobile.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtboxcustommobile.Location = new System.Drawing.Point(178, 375);
            this.txtboxcustommobile.Name = "txtboxcustommobile";
            this.txtboxcustommobile.Size = new System.Drawing.Size(541, 22);
            this.txtboxcustommobile.TabIndex = 34;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label18.Location = new System.Drawing.Point(8, 379);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(154, 14);
            this.label18.TabIndex = 33;
            this.label18.Text = "Custom mobile user agent:";
            // 
            // txtboxcustomdesktop
            // 
            this.txtboxcustomdesktop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtboxcustomdesktop.Location = new System.Drawing.Point(178, 348);
            this.txtboxcustomdesktop.Name = "txtboxcustomdesktop";
            this.txtboxcustomdesktop.Size = new System.Drawing.Size(541, 22);
            this.txtboxcustomdesktop.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label17.Location = new System.Drawing.Point(9, 352);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(163, 14);
            this.label17.TabIndex = 31;
            this.label17.Text = "Custom desktop user agent:";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(359, 446);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(52, 14);
            this.linkLabel1.TabIndex = 30;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Donate";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtbox_proxy
            // 
            this.txtbox_proxy.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtbox_proxy.Location = new System.Drawing.Point(178, 322);
            this.txtbox_proxy.Name = "txtbox_proxy";
            this.txtbox_proxy.Size = new System.Drawing.Size(238, 22);
            this.txtbox_proxy.TabIndex = 29;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label15.Location = new System.Drawing.Point(9, 327);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "Proxy settings:";
            // 
            // chkbox_tor
            // 
            this.chkbox_tor.AutoSize = true;
            this.chkbox_tor.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkbox_tor.Location = new System.Drawing.Point(355, 301);
            this.chkbox_tor.Name = "chkbox_tor";
            this.chkbox_tor.Size = new System.Drawing.Size(46, 18);
            this.chkbox_tor.TabIndex = 27;
            this.chkbox_tor.Text = "Yes";
            this.chkbox_tor.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label16.Location = new System.Drawing.Point(8, 302);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(183, 14);
            this.label16.TabIndex = 26;
            this.label16.Text = "Tor (needs Tor and Iplocation)?";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label14.Location = new System.Drawing.Point(424, 283);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(8, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Auto start delay time:";
            // 
            // txtbox_autostart
            // 
            this.txtbox_autostart.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_autostart.Location = new System.Drawing.Point(355, 276);
            this.txtbox_autostart.Name = "txtbox_autostart";
            this.txtbox_autostart.Size = new System.Drawing.Size(61, 20);
            this.txtbox_autostart.TabIndex = 6;
            this.txtbox_autostart.Text = "0";
            // 
            // settingsSaveBtn
            // 
            this.settingsSaveBtn.Location = new System.Drawing.Point(417, 441);
            this.settingsSaveBtn.Name = "settingsSaveBtn";
            this.settingsSaveBtn.Size = new System.Drawing.Size(75, 26);
            this.settingsSaveBtn.TabIndex = 7;
            this.settingsSaveBtn.Text = "Save";
            this.settingsSaveBtn.UseVisualStyleBackColor = true;
            this.settingsSaveBtn.Click += new System.EventHandler(this.settingsSaveBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label11.Location = new System.Drawing.Point(423, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "minutes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label10.Location = new System.Drawing.Point(423, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 17;
            this.label10.Text = "searches";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.Location = new System.Drawing.Point(423, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(8, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(319, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "How long do you want to wait between each accounts?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(8, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "How long do you want to wait before doing searches?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(8, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "How many searches would you like to do on each account?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Do you want to search on Bing desktop site?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "Do you want to search on Bing mobile site?";
            // 
            // chkbox_desktop
            // 
            this.chkbox_desktop.AutoSize = true;
            this.chkbox_desktop.Checked = true;
            this.chkbox_desktop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_desktop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkbox_desktop.Location = new System.Drawing.Point(353, 34);
            this.chkbox_desktop.Name = "chkbox_desktop";
            this.chkbox_desktop.Size = new System.Drawing.Size(46, 18);
            this.chkbox_desktop.TabIndex = 2;
            this.chkbox_desktop.Text = "Yes";
            this.chkbox_desktop.UseVisualStyleBackColor = true;
            // 
            // chkbox_mobile
            // 
            this.chkbox_mobile.AutoSize = true;
            this.chkbox_mobile.Checked = true;
            this.chkbox_mobile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_mobile.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkbox_mobile.Location = new System.Drawing.Point(353, 11);
            this.chkbox_mobile.Name = "chkbox_mobile";
            this.chkbox_mobile.Size = new System.Drawing.Size(46, 18);
            this.chkbox_mobile.TabIndex = 1;
            this.chkbox_mobile.Text = "Yes";
            this.chkbox_mobile.UseVisualStyleBackColor = true;
            // 
            // txtbox_waitauth
            // 
            this.txtbox_waitauth.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_waitauth.Location = new System.Drawing.Point(355, 249);
            this.txtbox_waitauth.Name = "txtbox_waitauth";
            this.txtbox_waitauth.Size = new System.Drawing.Size(61, 20);
            this.txtbox_waitauth.TabIndex = 5;
            this.txtbox_waitauth.Text = "1-3";
            // 
            // txtbox_counter
            // 
            this.txtbox_counter.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_counter.Location = new System.Drawing.Point(355, 197);
            this.txtbox_counter.Name = "txtbox_counter";
            this.txtbox_counter.Size = new System.Drawing.Size(61, 20);
            this.txtbox_counter.TabIndex = 3;
            this.txtbox_counter.Text = "10-15";
            // 
            // txtbox_waitsearches
            // 
            this.txtbox_waitsearches.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_waitsearches.Location = new System.Drawing.Point(355, 223);
            this.txtbox_waitsearches.Name = "txtbox_waitsearches";
            this.txtbox_waitsearches.Size = new System.Drawing.Size(61, 20);
            this.txtbox_waitsearches.TabIndex = 4;
            this.txtbox_waitsearches.Text = "4-10";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.richTextBox1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.passwd_txtbox);
            this.tabPage3.Controls.Add(this.regcode_txtbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(728, 486);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Register";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(15, 250);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(632, 228);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Register";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.Location = new System.Drawing.Point(12, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 14);
            this.label8.TabIndex = 3;
            this.label8.Text = "Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 14);
            this.label7.TabIndex = 2;
            this.label7.Text = "Registration Code:";
            // 
            // passwd_txtbox
            // 
            this.passwd_txtbox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.passwd_txtbox.Location = new System.Drawing.Point(272, 176);
            this.passwd_txtbox.Name = "passwd_txtbox";
            this.passwd_txtbox.Size = new System.Drawing.Size(212, 20);
            this.passwd_txtbox.TabIndex = 1;
            // 
            // regcode_txtbox
            // 
            this.regcode_txtbox.Font = new System.Drawing.Font("Tahoma", 8F);
            this.regcode_txtbox.Location = new System.Drawing.Point(272, 18);
            this.regcode_txtbox.Name = "regcode_txtbox";
            this.regcode_txtbox.Size = new System.Drawing.Size(212, 20);
            this.regcode_txtbox.TabIndex = 0;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(733, 512);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.btn_ip.ResumeLayout(false);
            this.btn_ip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox browserUrlTxtbox;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage btn_ip;
        private System.Windows.Forms.TabPage tabPage2;
        //private System.Windows.Forms.WebBrowser cash1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txtbox_waitsearches;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox chkbox_desktop;
        private System.Windows.Forms.CheckBox chkbox_mobile;
        private System.Windows.Forms.TextBox txtbox_waitauth;
        private System.Windows.Forms.TextBox txtbox_counter;
        private System.Windows.Forms.TextBox regcode_txtbox;
        private System.Windows.Forms.TextBox passwd_txtbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox accountNrTxtBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox accountNameTxtBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox statusTxtBox;
        private System.Windows.Forms.TextBox counterTxtBox;
        //private System.Windows.Forms.WebBrowser cash2;
        //private System.Windows.Forms.WebBrowser cash3;
        private System.Windows.Forms.Button settingsSaveBtn;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button check_button;
        private System.Windows.Forms.CheckBox chkbox_autorotate;
        private System.Windows.Forms.Button next_button;
        private System.Windows.Forms.Button prev_button;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbox_autostart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox pts_txtbox;
        private System.Windows.Forms.CheckBox chkbox_tor;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_cache;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtbox_proxy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtboxcustomdesktop;
        private System.Windows.Forms.TextBox txtboxcustommobile;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtbox_customaccounts;
        private System.Windows.Forms.Label label19;
    }
}

