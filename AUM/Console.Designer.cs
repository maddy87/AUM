namespace AUM
{
    partial class Console
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Console));
            this.dgConsole = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.DataGridViewImageColumn();
            this.SiteURL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SiteDescp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingsSent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingsInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PingsThreshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddressTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddressCc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSite_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartRequesting_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PauseSite_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSite_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendFeedBack = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tsb_AddSite = new System.Windows.Forms.ToolStripButton();
            this.tsb_Delete = new System.Windows.Forms.ToolStripButton();
            this.ts_Stop = new System.Windows.Forms.ToolStripButton();
            this.ts_Mail = new System.Windows.Forms.ToolStripButton();
            this.ts_Config = new System.Windows.Forms.ToolStripButton();
            this.ts_StartAll = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.AUM_notify = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsole)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgConsole
            // 
            this.dgConsole.AllowUserToAddRows = false;
            this.dgConsole.AllowUserToDeleteRows = false;
            this.dgConsole.AllowUserToResizeRows = false;
            this.dgConsole.BackgroundColor = System.Drawing.Color.White;
            this.dgConsole.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgConsole.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgConsole.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.status,
            this.SiteURL,
            this.SiteDescp,
            this.PingsSent,
            this.PingsInterval,
            this.PingsThreshold,
            this.RequestTimeOut,
            this.ErrorMessage,
            this.EmailAddressTo,
            this.EmailAddressCc});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgConsole.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgConsole.GridColor = System.Drawing.Color.White;
            this.dgConsole.Location = new System.Drawing.Point(0, 52);
            this.dgConsole.Name = "dgConsole";
            this.dgConsole.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgConsole.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgConsole.RowHeadersVisible = false;
            this.dgConsole.Size = new System.Drawing.Size(1016, 1044);
            this.dgConsole.TabIndex = 0;
            this.dgConsole.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsole_CellClick);
            this.dgConsole.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgConsole_CellContentClick);
            // 
            // status
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.NullValue = ((object)(resources.GetObject("dataGridViewCellStyle10.NullValue")));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.White;
            this.status.DefaultCellStyle = dataGridViewCellStyle10;
            this.status.HeaderText = "STATUS";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.ToolTipText = "Unknown";
            this.status.Width = 50;
            // 
            // SiteURL
            // 
            this.SiteURL.HeaderText = "SITE URL";
            this.SiteURL.Name = "SiteURL";
            this.SiteURL.ReadOnly = true;
            this.SiteURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SiteURL.ToolTipText = "URL/Link of the Site for which the request needs to be sent.";
            this.SiteURL.Width = 200;
            // 
            // SiteDescp
            // 
            this.SiteDescp.HeaderText = "SITE DESCRIPTION";
            this.SiteDescp.Name = "SiteDescp";
            this.SiteDescp.ReadOnly = true;
            this.SiteDescp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SiteDescp.ToolTipText = "Short Description of the Site ";
            this.SiteDescp.Width = 200;
            // 
            // PingsSent
            // 
            this.PingsSent.HeaderText = "REQUEST SENT";
            this.PingsSent.Name = "PingsSent";
            this.PingsSent.ReadOnly = true;
            this.PingsSent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PingsSent.ToolTipText = "Shows the No. of Request being Sent";
            this.PingsSent.Width = 60;
            // 
            // PingsInterval
            // 
            this.PingsInterval.HeaderText = "REQUEST INTERVAL";
            this.PingsInterval.Name = "PingsInterval";
            this.PingsInterval.ReadOnly = true;
            this.PingsInterval.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PingsInterval.ToolTipText = "Sets the Interval in Sec\'s for the Request to be Sent";
            this.PingsInterval.Width = 60;
            // 
            // PingsThreshold
            // 
            this.PingsThreshold.HeaderText = "FAIL PERIOD";
            this.PingsThreshold.Name = "PingsThreshold";
            this.PingsThreshold.ReadOnly = true;
            this.PingsThreshold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PingsThreshold.ToolTipText = "No. of Seconds for which the consecutive request\'s can fail";
            this.PingsThreshold.Width = 60;
            // 
            // RequestTimeOut
            // 
            this.RequestTimeOut.HeaderText = "TIMEOUT";
            this.RequestTimeOut.Name = "RequestTimeOut";
            this.RequestTimeOut.ReadOnly = true;
            this.RequestTimeOut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.RequestTimeOut.ToolTipText = "Request Timeout Value in Seconds";
            this.RequestTimeOut.Width = 60;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.HeaderText = "ERROR MESSAGE";
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ErrorMessage.ToolTipText = "Information about the latest request sent";
            this.ErrorMessage.Width = 250;
            // 
            // EmailAddressTo
            // 
            this.EmailAddressTo.HeaderText = "E-MAIL TO";
            this.EmailAddressTo.Name = "EmailAddressTo";
            this.EmailAddressTo.ReadOnly = true;
            this.EmailAddressTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmailAddressTo.ToolTipText = "Notify the below user (TO)";
            this.EmailAddressTo.Width = 160;
            // 
            // EmailAddressCc
            // 
            this.EmailAddressCc.HeaderText = "E-MAIL Cc";
            this.EmailAddressCc.Name = "EmailAddressCc";
            this.EmailAddressCc.ReadOnly = true;
            this.EmailAddressCc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EmailAddressCc.ToolTipText = "Notify the User Cc";
            this.EmailAddressCc.Width = 200;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1055, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSite_MenuItem,
            this.StartRequesting_MenuItem,
            this.PauseSite_MenuItem,
            this.DeleteSite_MenuItem,
            this.SendFeedBack,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.fileToolStripMenuItem.Text = "Sites";
            // 
            // AddSite_MenuItem
            // 
            this.AddSite_MenuItem.Name = "AddSite_MenuItem";
            this.AddSite_MenuItem.Size = new System.Drawing.Size(160, 22);
            this.AddSite_MenuItem.Text = "Add A Site ";
            this.AddSite_MenuItem.Click += new System.EventHandler(this.AddSite_MenuItem_Click);
            // 
            // StartRequesting_MenuItem
            // 
            this.StartRequesting_MenuItem.Name = "StartRequesting_MenuItem";
            this.StartRequesting_MenuItem.Size = new System.Drawing.Size(160, 22);
            this.StartRequesting_MenuItem.Text = "Start Requesting";
            this.StartRequesting_MenuItem.Click += new System.EventHandler(this.StartRequesting_MenuItem_Click);
            // 
            // PauseSite_MenuItem
            // 
            this.PauseSite_MenuItem.Name = "PauseSite_MenuItem";
            this.PauseSite_MenuItem.Size = new System.Drawing.Size(160, 22);
            this.PauseSite_MenuItem.Text = " Pause Site";
            this.PauseSite_MenuItem.Click += new System.EventHandler(this.PauseSite_MenuItem_Click);
            // 
            // DeleteSite_MenuItem
            // 
            this.DeleteSite_MenuItem.Name = "DeleteSite_MenuItem";
            this.DeleteSite_MenuItem.Size = new System.Drawing.Size(160, 22);
            this.DeleteSite_MenuItem.Text = "Delete Site";
            this.DeleteSite_MenuItem.Click += new System.EventHandler(this.DeleteSite_MenuItem_Click);
            // 
            // SendFeedBack
            // 
            this.SendFeedBack.Name = "SendFeedBack";
            this.SendFeedBack.Size = new System.Drawing.Size(160, 22);
            this.SendFeedBack.Text = "Send FeedBack";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.aboutToolStripMenuItem.Text = "Help";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.tsb_AddSite,
            this.tsb_Delete,
            this.ts_Stop,
            this.ts_Mail,
            this.ts_Config,
            this.ts_StartAll});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1055, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Start Requesting";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsb_AddSite
            // 
            this.tsb_AddSite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_AddSite.Image = ((System.Drawing.Image)(resources.GetObject("tsb_AddSite.Image")));
            this.tsb_AddSite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_AddSite.Name = "tsb_AddSite";
            this.tsb_AddSite.Size = new System.Drawing.Size(23, 22);
            this.tsb_AddSite.Text = "toolStripButton2";
            this.tsb_AddSite.ToolTipText = "Add New Site";
            this.tsb_AddSite.Click += new System.EventHandler(this.tsb_AddSite_Click);
            // 
            // tsb_Delete
            // 
            this.tsb_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Delete.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Delete.Image")));
            this.tsb_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Delete.Name = "tsb_Delete";
            this.tsb_Delete.Size = new System.Drawing.Size(23, 22);
            this.tsb_Delete.Text = "toolStripButton2";
            this.tsb_Delete.ToolTipText = "Delete Site";
            this.tsb_Delete.Click += new System.EventHandler(this.tsb_Delete_Click);
            // 
            // ts_Stop
            // 
            this.ts_Stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Stop.Image = ((System.Drawing.Image)(resources.GetObject("ts_Stop.Image")));
            this.ts_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Stop.Name = "ts_Stop";
            this.ts_Stop.Size = new System.Drawing.Size(23, 22);
            this.ts_Stop.Text = "toolStripButton2";
            this.ts_Stop.ToolTipText = "Pause Requesting";
            this.ts_Stop.Click += new System.EventHandler(this.ts_Stop_Click);
            // 
            // ts_Mail
            // 
            this.ts_Mail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Mail.Image = ((System.Drawing.Image)(resources.GetObject("ts_Mail.Image")));
            this.ts_Mail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Mail.Name = "ts_Mail";
            this.ts_Mail.Size = new System.Drawing.Size(23, 22);
            this.ts_Mail.Text = "toolStripButton2";
            this.ts_Mail.ToolTipText = "Send Feedback";
            this.ts_Mail.Click += new System.EventHandler(this.ts_Mail_Click);
            // 
            // ts_Config
            // 
            this.ts_Config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_Config.Image = ((System.Drawing.Image)(resources.GetObject("ts_Config.Image")));
            this.ts_Config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_Config.Name = "ts_Config";
            this.ts_Config.Size = new System.Drawing.Size(23, 22);
            this.ts_Config.Text = "ts_Config";
            this.ts_Config.ToolTipText = "Modify Current Site";
            this.ts_Config.Click += new System.EventHandler(this.ts_Config_Click);
            // 
            // ts_StartAll
            // 
            this.ts_StartAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ts_StartAll.Image = ((System.Drawing.Image)(resources.GetObject("ts_StartAll.Image")));
            this.ts_StartAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_StartAll.Name = "ts_StartAll";
            this.ts_StartAll.Size = new System.Drawing.Size(23, 22);
            this.ts_StartAll.Text = "toolStripButton2";
            this.ts_StartAll.ToolTipText = "Start Requesting  All Sites";
            this.ts_StartAll.Click += new System.EventHandler(this.ts_StartAll_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 593);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1055, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // AUM_notify
            // 
            this.AUM_notify.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.AUM_notify.Icon = ((System.Drawing.Icon)(resources.GetObject("AUM_notify.Icon")));
            this.AUM_notify.Text = "AUM";
            this.AUM_notify.Visible = true;
            this.AUM_notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AUM_notify_MouseDoubleClick);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 615);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dgConsole);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Console";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Console";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Console_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Console_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Console_FormClosing);
            this.Resize += new System.EventHandler(this.Console_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgConsole)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgConsole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton tsb_AddSite;
        private System.Windows.Forms.ToolStripButton tsb_Delete;
        private System.Windows.Forms.NotifyIcon AUM_notify;
        private System.Windows.Forms.ToolStripButton ts_Stop;
        private System.Windows.Forms.ToolStripButton ts_Mail;
        private System.Windows.Forms.ToolStripButton ts_Config;
        private System.Windows.Forms.ToolStripButton ts_StartAll;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.DataGridViewImageColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn SiteDescp;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingsSent;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingsInterval;
        private System.Windows.Forms.DataGridViewTextBoxColumn PingsThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddressTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddressCc;
        private System.Windows.Forms.ToolStripMenuItem AddSite_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartRequesting_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem PauseSite_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteSite_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SendFeedBack;
    }
}