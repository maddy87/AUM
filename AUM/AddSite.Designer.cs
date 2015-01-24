namespace AUM
{
    partial class AddSite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSite));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSiteURL = new System.Windows.Forms.TextBox();
            this.txtSiteDescp = new System.Windows.Forms.TextBox();
            this.txtPingInterval = new System.Windows.Forms.TextBox();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.btnAddNewSite = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmailCc = new System.Windows.Forms.TextBox();
            this.txtRequestTimeOut = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRequestFailure = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Site Description";
            // 
            // txtSiteURL
            // 
            this.txtSiteURL.Location = new System.Drawing.Point(149, 15);
            this.txtSiteURL.Name = "txtSiteURL";
            this.txtSiteURL.Size = new System.Drawing.Size(228, 20);
            this.txtSiteURL.TabIndex = 1;
            this.txtSiteURL.Text = "www.google.com";
            this.txtSiteURL.Leave += new System.EventHandler(this.txtSiteURL_Leave);
            // 
            // txtSiteDescp
            // 
            this.txtSiteDescp.Location = new System.Drawing.Point(149, 47);
            this.txtSiteDescp.Name = "txtSiteDescp";
            this.txtSiteDescp.Size = new System.Drawing.Size(228, 20);
            this.txtSiteDescp.TabIndex = 2;
            this.txtSiteDescp.Text = "This is the Sparsh Intranet Link";
            this.txtSiteDescp.Leave += new System.EventHandler(this.txtSiteDescp_Leave);
            // 
            // txtPingInterval
            // 
            this.txtPingInterval.Location = new System.Drawing.Point(149, 79);
            this.txtPingInterval.Name = "txtPingInterval";
            this.txtPingInterval.Size = new System.Drawing.Size(50, 20);
            this.txtPingInterval.TabIndex = 3;
            this.txtPingInterval.Text = "10";
            this.txtPingInterval.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPingInterval_KeyDown);
            this.txtPingInterval.Leave += new System.EventHandler(this.txtPingInterval_Leave);
            this.txtPingInterval.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPingInterval_KeyUp);
            // 
            // txtEmailTo
            // 
            this.txtEmailTo.Location = new System.Drawing.Point(149, 175);
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(228, 20);
            this.txtEmailTo.TabIndex = 6;
            this.txtEmailTo.Text = "rajeshetty87@gmail.com";
            this.txtEmailTo.Leave += new System.EventHandler(this.txtEmailTo_Leave);
            // 
            // btnAddNewSite
            // 
            this.btnAddNewSite.Location = new System.Drawing.Point(112, 251);
            this.btnAddNewSite.Name = "btnAddNewSite";
            this.btnAddNewSite.Size = new System.Drawing.Size(75, 23);
            this.btnAddNewSite.TabIndex = 8;
            this.btnAddNewSite.Text = "Add Site";
            this.btnAddNewSite.UseVisualStyleBackColor = true;
            this.btnAddNewSite.Click += new System.EventHandler(this.btnAddNewSite_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(209, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(439, 49);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(417, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Please provide the below information for adding the site.  \r\nKindly provide the c" +
                "omplete link of the URL alog with the respective HTTP header to it.";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtEmailCc);
            this.panel2.Controls.Add(this.txtRequestTimeOut);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtRequestFailure);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.btnAddNewSite);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtEmailTo);
            this.panel2.Controls.Add(this.txtSiteURL);
            this.panel2.Controls.Add(this.txtPingInterval);
            this.panel2.Controls.Add(this.txtSiteDescp);
            this.panel2.Location = new System.Drawing.Point(12, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 290);
            this.panel2.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Email Address - Cc";
            // 
            // txtEmailCc
            // 
            this.txtEmailCc.Location = new System.Drawing.Point(152, 209);
            this.txtEmailCc.Name = "txtEmailCc";
            this.txtEmailCc.Size = new System.Drawing.Size(228, 20);
            this.txtEmailCc.TabIndex = 7;
            this.txtEmailCc.Text = "rajeshetty87@gmail.com";
            this.txtEmailCc.Leave += new System.EventHandler(this.txtEmailCc_Leave);
            // 
            // txtRequestTimeOut
            // 
            this.txtRequestTimeOut.Location = new System.Drawing.Point(149, 143);
            this.txtRequestTimeOut.Name = "txtRequestTimeOut";
            this.txtRequestTimeOut.Size = new System.Drawing.Size(50, 20);
            this.txtRequestTimeOut.TabIndex = 5;
            this.txtRequestTimeOut.Text = "30";
            this.txtRequestTimeOut.Leave += new System.EventHandler(this.txtRequestTimeOut_Leave);
            this.txtRequestTimeOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRequestTimeOut_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Request TimeOut";
            // 
            // txtRequestFailure
            // 
            this.txtRequestFailure.Location = new System.Drawing.Point(152, 111);
            this.txtRequestFailure.Name = "txtRequestFailure";
            this.txtRequestFailure.Size = new System.Drawing.Size(47, 20);
            this.txtRequestFailure.TabIndex = 4;
            this.txtRequestFailure.Text = "30";
            this.txtRequestFailure.Leave += new System.EventHandler(this.txtRequestFailure_Leave);
            this.txtRequestFailure.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtRequestFailure_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Request Failure Threshold";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ping Request Interval";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email Address - To";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 369);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSite";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddSite";
            this.Load += new System.EventHandler(this.AddSite_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddSite_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSiteURL;
        private System.Windows.Forms.TextBox txtSiteDescp;
        private System.Windows.Forms.TextBox txtPingInterval;
        private System.Windows.Forms.TextBox txtEmailTo;
        private System.Windows.Forms.Button btnAddNewSite;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtRequestFailure;
        private System.Windows.Forms.TextBox txtRequestTimeOut;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmailCc;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}