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
            this.updatetab = new System.Windows.Forms.TabControl();
            this.btn_ip = new System.Windows.Forms.TabPage();
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
            this.label26 = new System.Windows.Forms.Label();
            this.txtbox_autostartrecurrence = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.elementHost4 = new System.Windows.Forms.Integration.ElementHost();
            this.chkbox_as = new System.Windows.Forms.CheckBox();
            this.label24 = new System.Windows.Forms.Label();
            this.elementHost3 = new System.Windows.Forms.Integration.ElementHost();
            this.elementHost2 = new System.Windows.Forms.Integration.ElementHost();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.chkbox_ns = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.randomo = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.txtbox_torsettings = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtbox_customaccounts = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtboxcustommobile = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtboxcustomdesktop = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.log = new System.Windows.Forms.ListView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.passwd_txtbox = new System.Windows.Forms.TextBox();
            this.regcode_txtbox = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.updatetab.SuspendLayout();
            this.btn_ip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.browser.Location = new System.Drawing.Point(0, 58);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(726, 400);
            this.browser.TabIndex = 1;
            // 
            // updatetab
            // 
            this.updatetab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatetab.Controls.Add(this.btn_ip);
            this.updatetab.Controls.Add(this.tabPage2);
            this.updatetab.Controls.Add(this.tabPage1);
            this.updatetab.Controls.Add(this.tabPage4);
            this.updatetab.Controls.Add(this.tabPage3);
            this.updatetab.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatetab.Location = new System.Drawing.Point(-2, -1);
            this.updatetab.Name = "updatetab";
            this.updatetab.SelectedIndex = 0;
            this.updatetab.Size = new System.Drawing.Size(736, 513);
            this.updatetab.TabIndex = 2;
            // 
            // btn_ip
            // 
            this.btn_ip.BackColor = System.Drawing.Color.Transparent;
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
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.label26);
            this.tabPage2.Controls.Add(this.txtbox_autostartrecurrence);
            this.tabPage2.Controls.Add(this.label25);
            this.tabPage2.Controls.Add(this.elementHost4);
            this.tabPage2.Controls.Add(this.chkbox_as);
            this.tabPage2.Controls.Add(this.label24);
            this.tabPage2.Controls.Add(this.elementHost3);
            this.tabPage2.Controls.Add(this.elementHost2);
            this.tabPage2.Controls.Add(this.elementHost1);
            this.tabPage2.Controls.Add(this.chkbox_ns);
            this.tabPage2.Controls.Add(this.label23);
            this.tabPage2.Controls.Add(this.randomo);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.txtbox_torsettings);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Controls.Add(this.txtbox_customaccounts);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.txtboxcustommobile);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.txtboxcustomdesktop);
            this.tabPage2.Controls.Add(this.label17);
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
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label26.Location = new System.Drawing.Point(405, 272);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(32, 14);
            this.label26.TabIndex = 55;
            this.label26.Text = "hour";
            this.label26.Visible = false;
            // 
            // txtbox_autostartrecurrence
            // 
            this.txtbox_autostartrecurrence.Location = new System.Drawing.Point(353, 267);
            this.txtbox_autostartrecurrence.Name = "txtbox_autostartrecurrence";
            this.txtbox_autostartrecurrence.ReadOnly = true;
            this.txtbox_autostartrecurrence.Size = new System.Drawing.Size(45, 22);
            this.txtbox_autostartrecurrence.TabIndex = 54;
            this.txtbox_autostartrecurrence.Visible = false;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Enabled = false;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label25.Location = new System.Drawing.Point(8, 270);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(181, 14);
            this.label25.TabIndex = 53;
            this.label25.Text = "Autostart recurrence daily time:";
            this.label25.Visible = false;
            // 
            // elementHost4
            // 
            this.elementHost4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.elementHost4.Location = new System.Drawing.Point(480, 242);
            this.elementHost4.Name = "elementHost4";
            this.elementHost4.Size = new System.Drawing.Size(239, 18);
            this.elementHost4.TabIndex = 10;
            this.elementHost4.Text = "elementHost4";
            this.elementHost4.Child = null;
            // 
            // chkbox_as
            // 
            this.chkbox_as.AutoSize = true;
            this.chkbox_as.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkbox_as.Location = new System.Drawing.Point(355, 218);
            this.chkbox_as.Name = "chkbox_as";
            this.chkbox_as.Size = new System.Drawing.Size(46, 18);
            this.chkbox_as.TabIndex = 9;
            this.chkbox_as.Text = "Yes";
            this.chkbox_as.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Enabled = false;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label24.Location = new System.Drawing.Point(8, 220);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 14);
            this.label24.TabIndex = 50;
            this.label24.Text = "Autostart:";
            // 
            // elementHost3
            // 
            this.elementHost3.Location = new System.Drawing.Point(480, 148);
            this.elementHost3.Name = "elementHost3";
            this.elementHost3.Size = new System.Drawing.Size(239, 18);
            this.elementHost3.TabIndex = 6;
            this.elementHost3.Text = "elementHost3";
            this.elementHost3.Child = null;
            // 
            // elementHost2
            // 
            this.elementHost2.Location = new System.Drawing.Point(480, 123);
            this.elementHost2.Name = "elementHost2";
            this.elementHost2.Size = new System.Drawing.Size(239, 18);
            this.elementHost2.TabIndex = 5;
            this.elementHost2.Text = "elementHost2";
            this.elementHost2.Child = null;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(480, 97);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(239, 18);
            this.elementHost1.TabIndex = 4;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // chkbox_ns
            // 
            this.chkbox_ns.AutoSize = true;
            this.chkbox_ns.Checked = true;
            this.chkbox_ns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkbox_ns.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkbox_ns.Location = new System.Drawing.Point(355, 174);
            this.chkbox_ns.Name = "chkbox_ns";
            this.chkbox_ns.Size = new System.Drawing.Size(46, 18);
            this.chkbox_ns.TabIndex = 7;
            this.chkbox_ns.Text = "Yes";
            this.chkbox_ns.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Enabled = false;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label23.Location = new System.Drawing.Point(8, 174);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(88, 14);
            this.label23.TabIndex = 45;
            this.label23.Text = "Natural search:";
            // 
            // randomo
            // 
            this.randomo.AutoSize = true;
            this.randomo.Checked = true;
            this.randomo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomo.Font = new System.Drawing.Font("Tahoma", 9F);
            this.randomo.Location = new System.Drawing.Point(355, 196);
            this.randomo.Name = "randomo";
            this.randomo.Size = new System.Drawing.Size(46, 18);
            this.randomo.TabIndex = 8;
            this.randomo.Text = "Yes";
            this.randomo.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Enabled = false;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label22.Location = new System.Drawing.Point(9, 197);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(150, 14);
            this.label22.TabIndex = 43;
            this.label22.Text = "Autorotate random order:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Enabled = false;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label21.Location = new System.Drawing.Point(8, 58);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 14);
            this.label21.TabIndex = 42;
            this.label21.Text = "Language:";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Items.AddRange(new object[] {
            "US english",
            "India"});
            this.listBox1.Location = new System.Drawing.Point(355, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(131, 32);
            this.listBox1.TabIndex = 3;
            // 
            // txtbox_torsettings
            // 
            this.txtbox_torsettings.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtbox_torsettings.Location = new System.Drawing.Point(199, 322);
            this.txtbox_torsettings.Name = "txtbox_torsettings";
            this.txtbox_torsettings.Size = new System.Drawing.Size(217, 22);
            this.txtbox_torsettings.TabIndex = 12;
            this.txtbox_torsettings.Text = "127.0.0.1:9050";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Enabled = false;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label20.Location = new System.Drawing.Point(8, 325);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(189, 14);
            this.label20.TabIndex = 37;
            this.label20.Text = "Tor settings (server:controlport):";
            // 
            // txtbox_customaccounts
            // 
            this.txtbox_customaccounts.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtbox_customaccounts.Location = new System.Drawing.Point(199, 430);
            this.txtbox_customaccounts.Name = "txtbox_customaccounts";
            this.txtbox_customaccounts.Size = new System.Drawing.Size(217, 22);
            this.txtbox_customaccounts.TabIndex = 16;
            this.txtbox_customaccounts.Text = "accounts.txt";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label19.Location = new System.Drawing.Point(9, 432);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(119, 14);
            this.label19.TabIndex = 35;
            this.label19.Text = "Custom account file:";
            // 
            // txtboxcustommobile
            // 
            this.txtboxcustommobile.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtboxcustommobile.Location = new System.Drawing.Point(199, 403);
            this.txtboxcustommobile.Name = "txtboxcustommobile";
            this.txtboxcustommobile.Size = new System.Drawing.Size(520, 22);
            this.txtboxcustommobile.TabIndex = 15;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Enabled = false;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label18.Location = new System.Drawing.Point(9, 408);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(154, 14);
            this.label18.TabIndex = 33;
            this.label18.Text = "Custom mobile user agent:";
            // 
            // txtboxcustomdesktop
            // 
            this.txtboxcustomdesktop.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtboxcustomdesktop.Location = new System.Drawing.Point(199, 376);
            this.txtboxcustomdesktop.Name = "txtboxcustomdesktop";
            this.txtboxcustomdesktop.Size = new System.Drawing.Size(520, 22);
            this.txtboxcustomdesktop.TabIndex = 14;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Enabled = false;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label17.Location = new System.Drawing.Point(9, 379);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(163, 14);
            this.label17.TabIndex = 31;
            this.label17.Text = "Custom desktop user agent:";
            // 
            // txtbox_proxy
            // 
            this.txtbox_proxy.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtbox_proxy.Location = new System.Drawing.Point(199, 349);
            this.txtbox_proxy.Name = "txtbox_proxy";
            this.txtbox_proxy.Size = new System.Drawing.Size(217, 22);
            this.txtbox_proxy.TabIndex = 13;
            this.txtbox_proxy.Text = "127.0.0.1:8118";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Enabled = false;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label15.Location = new System.Drawing.Point(9, 351);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 14);
            this.label15.TabIndex = 28;
            this.label15.Text = "Proxy settings:";
            // 
            // chkbox_tor
            // 
            this.chkbox_tor.AutoSize = true;
            this.chkbox_tor.Font = new System.Drawing.Font("Tahoma", 9F);
            this.chkbox_tor.Location = new System.Drawing.Point(355, 297);
            this.chkbox_tor.Name = "chkbox_tor";
            this.chkbox_tor.Size = new System.Drawing.Size(46, 18);
            this.chkbox_tor.TabIndex = 11;
            this.chkbox_tor.Text = "Yes";
            this.chkbox_tor.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Enabled = false;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label16.Location = new System.Drawing.Point(8, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(110, 14);
            this.label16.TabIndex = 26;
            this.label16.Text = "Tor (requires Tor):";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label14.Location = new System.Drawing.Point(420, 245);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 14);
            this.label14.TabIndex = 23;
            this.label14.Text = "minutes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(8, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Autostart delay time:";
            // 
            // txtbox_autostart
            // 
            this.txtbox_autostart.Enabled = false;
            this.txtbox_autostart.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_autostart.Location = new System.Drawing.Point(354, 240);
            this.txtbox_autostart.Name = "txtbox_autostart";
            this.txtbox_autostart.ReadOnly = true;
            this.txtbox_autostart.Size = new System.Drawing.Size(61, 20);
            this.txtbox_autostart.TabIndex = 6;
            this.txtbox_autostart.Text = "1-3";
            // 
            // settingsSaveBtn
            // 
            this.settingsSaveBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsSaveBtn.Location = new System.Drawing.Point(3, 457);
            this.settingsSaveBtn.Name = "settingsSaveBtn";
            this.settingsSaveBtn.Size = new System.Drawing.Size(722, 26);
            this.settingsSaveBtn.TabIndex = 7;
            this.settingsSaveBtn.Text = "Save";
            this.settingsSaveBtn.UseVisualStyleBackColor = true;
            this.settingsSaveBtn.Click += new System.EventHandler(this.settingsSaveBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label11.Location = new System.Drawing.Point(420, 150);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 14);
            this.label11.TabIndex = 18;
            this.label11.Text = "minutes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label10.Location = new System.Drawing.Point(420, 99);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 14);
            this.label10.TabIndex = 17;
            this.label10.Text = "searches";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label9.Location = new System.Drawing.Point(420, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 14);
            this.label9.TabIndex = 16;
            this.label9.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label6.Location = new System.Drawing.Point(8, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(319, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "How long do you want to wait between each accounts?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label5.Location = new System.Drawing.Point(8, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 14);
            this.label5.TabIndex = 14;
            this.label5.Text = "How long do you want to wait before doing searches?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(8, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 14);
            this.label4.TabIndex = 13;
            this.label4.Text = "How many searches would you like to do on each account?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label2.Location = new System.Drawing.Point(8, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(255, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "Do you want to search on Bing desktop site?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(8, 11);
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
            this.chkbox_desktop.Location = new System.Drawing.Point(356, 34);
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
            this.chkbox_mobile.Location = new System.Drawing.Point(356, 11);
            this.chkbox_mobile.Name = "chkbox_mobile";
            this.chkbox_mobile.Size = new System.Drawing.Size(46, 18);
            this.chkbox_mobile.TabIndex = 1;
            this.chkbox_mobile.Text = "Yes";
            this.chkbox_mobile.UseVisualStyleBackColor = true;
            // 
            // txtbox_waitauth
            // 
            this.txtbox_waitauth.Enabled = false;
            this.txtbox_waitauth.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_waitauth.Location = new System.Drawing.Point(355, 147);
            this.txtbox_waitauth.Name = "txtbox_waitauth";
            this.txtbox_waitauth.ReadOnly = true;
            this.txtbox_waitauth.Size = new System.Drawing.Size(61, 20);
            this.txtbox_waitauth.TabIndex = 5;
            this.txtbox_waitauth.Text = "1-3";
            // 
            // txtbox_counter
            // 
            this.txtbox_counter.Enabled = false;
            this.txtbox_counter.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_counter.Location = new System.Drawing.Point(355, 95);
            this.txtbox_counter.Name = "txtbox_counter";
            this.txtbox_counter.ReadOnly = true;
            this.txtbox_counter.Size = new System.Drawing.Size(61, 20);
            this.txtbox_counter.TabIndex = 40;
            this.txtbox_counter.Text = "10-15";
            // 
            // txtbox_waitsearches
            // 
            this.txtbox_waitsearches.Enabled = false;
            this.txtbox_waitsearches.Font = new System.Drawing.Font("Tahoma", 8F);
            this.txtbox_waitsearches.Location = new System.Drawing.Point(355, 120);
            this.txtbox_waitsearches.Name = "txtbox_waitsearches";
            this.txtbox_waitsearches.ReadOnly = true;
            this.txtbox_waitsearches.Size = new System.Drawing.Size(61, 20);
            this.txtbox_waitsearches.TabIndex = 4;
            this.txtbox_waitsearches.Text = "4-10";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.log);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(728, 486);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Log";
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.log.Location = new System.Drawing.Point(10, 6);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(709, 472);
            this.log.TabIndex = 0;
            this.log.UseCompatibleStateImageBehavior = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.richTextBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(728, 486);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Update";
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button4.Location = new System.Drawing.Point(3, 460);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(722, 23);
            this.button4.TabIndex = 25;
            this.button4.Text = "-=:|:- Check update! -:|:=-";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(10, 10);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(710, 442);
            this.richTextBox1.TabIndex = 24;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.passwd_txtbox);
            this.tabPage3.Controls.Add(this.regcode_txtbox);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(728, 486);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Register";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 72);
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
            this.label8.Location = new System.Drawing.Point(12, 45);
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
            this.passwd_txtbox.Location = new System.Drawing.Point(272, 45);
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
            this.Controls.Add(this.updatetab);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.updatetab.ResumeLayout(false);
            this.btn_ip.ResumeLayout(false);
            this.btn_ip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox browserUrlTxtbox;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.TabControl updatetab;
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
        private System.Windows.Forms.TextBox txtbox_proxy;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtboxcustomdesktop;
        private System.Windows.Forms.TextBox txtboxcustommobile;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtbox_customaccounts;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtbox_torsettings;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView log;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox randomo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.CheckBox chkbox_ns;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private System.Windows.Forms.Integration.ElementHost elementHost3;
        private System.Windows.Forms.Integration.ElementHost elementHost2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox chkbox_as;
        private System.Windows.Forms.Integration.ElementHost elementHost4;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtbox_autostartrecurrence;
        private System.Windows.Forms.Label label26;
    }
}

