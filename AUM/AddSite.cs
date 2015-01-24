using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AUM
{
    public partial class AddSite : Form
    {
        //declaring a gridview for displaying the requested data.
        private DataGridView dg_AddSite;

        //Declaring the delegate for out Saviour the "INVOKE" statement
        private delegate void Load_Data_Delegate();
        
        public AddSite()
        {
            InitializeComponent();
        }

        //Constructor for initializing the grid view.
        public AddSite(DataGridView dg_Local)
        {
            InitializeComponent();
            dg_AddSite = dg_Local;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNewSite_Click(object sender, EventArgs e)
        {
            try
            {//Setting these vaules to the GlobalData Attributes.

                //Functionality obj = new Functionality();
                //Console frm = new Console();
               //dg_AddSite.Rows.Add();
                //obj.AddSite_SetGlobalData(txtSiteURL.Text, txtSiteDescp.Text, Convert.ToInt32(txtPingInterval.Text), Convert.ToInt32(txtRequestFailure.Text), Convert.ToInt32(txtRequestTimeOut.Text), txtEmailTo.Text, txtEmailCc.Text);
                if (txtEmailTo.Text == "Your_EmailId@domain.com" || txtEmailCc.Text == "Your_Cc_EmailId@domain.com")
                {
                    MessageBox.Show("Please enter a valid email Id");
                }
                else
                {
                    dg_AddSite.Invoke(new Load_Data_Delegate(Load_Data));
                    //frm.BindGridview();
                    //frm.AddSite();

                    ///JUST TRYING MAN ... LETS C IF U CAN WORK 

                    //Functionality obj = new Functionality();
                    //Thread th1 = new Thread(new ThreadStart(obj.StartRequest));
                    //dgConsole.DataSource = null;
                    //dgConsole.Rows.Add();
                    //dgConsole.Rows[Current_Row].Cells[7].Value = "Sending Request...";
                    //th1.Start();
                    GlobalData.GD_StoreEmailId_To = txtEmailTo.Text;
                    GlobalData.GD_StoreEmailId_Cc = txtEmailCc.Text;

                    this.Dispose();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Invoking New Site : " + ex.Message.ToString());
            }

        }

        private void AddSite_Load(object sender, EventArgs e)
        {
            GlobalData.Site_Config = 0;
            txtEmailTo.Text = GlobalData.GD_StoreEmailId_To.ToString();
            txtEmailCc.Text = GlobalData.GD_StoreEmailId_Cc.ToString();

            try
            {
                this.ControlBox = false;

                if (GlobalData.Site_Config == 1)
                {
                    this.Text = "Modify/Config Site";
                    btnAddNewSite.Text = "Modify";

                    txtSiteURL.Text = GlobalData.GD_Config_SiteUrl.ToString();
                    txtSiteDescp.Text = GlobalData.GD_Config_SiteDescp.ToString();
                    txtPingInterval.Text = GlobalData.GD_Config_PingInterval.ToString();
                    txtRequestFailure.Text = GlobalData.GD_Config_PingThreshold.ToString();
                    txtRequestTimeOut.Text = GlobalData.GD_Config_PingTimeout.ToString();
                    txtEmailTo.Text = GlobalData.GD_Config_EmailAddress_To.ToString();
                    txtEmailCc.Text = GlobalData.GD_Config_EmailAddress_Cc.ToString();
                    
                    txtPingInterval.Enabled = false;
                    txtRequestTimeOut.Enabled = false;
                    txtRequestFailure.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Add New Site - Load : " + ex.Message.ToString());
            }

        }

        public void Load_Data()
        {
           
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[1].Value = txtSiteURL.Text;
             dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[2].Value = txtSiteDescp.Text;
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[3].Value = "0";
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[4].Value = txtPingInterval.Text;
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[5].Value = txtRequestFailure.Text;
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[6].Value = txtRequestTimeOut.Text;
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[7].Value = "Ready.";
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[8].Value = txtEmailTo.Text;
            dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[9].Value = txtEmailCc.Text;
                
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(GlobalData.Site_Config == 0)
            {
               dg_AddSite.Rows.RemoveAt(GlobalData.GD_CurrentGridViewLocation);
            }

            this.Dispose();
            this.Close();
        }

        private void AddSite_FormClosing(object sender, FormClosingEventArgs e)
        {

            //            dg_AddSite.Rows.RemoveAt(GlobalData.GD_CurrentGridViewLocation);
            //if (dg_AddSite.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[0].Value == "") 
            //{
            //    dg_AddSite.Rows.RemoveAt(GlobalData.GD_CurrentGridViewLocation);
            //}

        }

        private void txtSiteURL_Leave(object sender, EventArgs e)
        {
            if (txtSiteURL.Text =="")
            {
                MessageBox.Show("The Site URL Feild cannot be empty");
                txtSiteURL.Focus();
            }
        }

        private void txtSiteDescp_Leave(object sender, EventArgs e)
        {
            if (txtSiteDescp.Text == "")
            {
                MessageBox.Show("The Site Description Feild cannot be empty");
                txtSiteDescp.Focus();
            }
        }

        private void txtPingInterval_Leave(object sender, EventArgs e)
        {
            if (txtPingInterval.Text == "")
            {
                MessageBox.Show("The Request Interval Feild cannot be empty");
                txtSiteURL.Focus();
            }

            else
            {
                try
                {
                    int x = Int32.Parse(txtPingInterval.Text);

                    int interval = Convert.ToInt32(txtPingInterval.Text);

                    if (interval < 10 || interval > 1000)
                    {
                        MessageBox.Show("Please provide a valid input for the Interval (Input should be between 10 to 1000 ");
                    }

                    else
                    {
                        interval = interval * 3;
                        txtRequestFailure.Text = interval.ToString();
                        txtRequestTimeOut.Text = interval.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Only Numbers Please");
                    txtPingInterval.Focus();
                }
            }
        }

        private void txtEmailTo_Leave(object sender, EventArgs e)
        {
            if (txtEmailTo.Text == "" || txtEmailTo.Text == "Your_EmailId@domain.com" )
            {
                MessageBox.Show("Please Enter a Valid Email Id.");
                txtEmailTo.Focus();
            }

        }

        private void txtEmailCc_Leave(object sender, EventArgs e)
        {
            if (txtEmailCc.Text == "" || txtEmailCc.Text == "Your_Cc_EmailId@Domain.com")
            {
                MessageBox.Show("Please Enter A Valid Email Id");
                txtEmailCc.Focus();
            }

        }

        private void txtPingInterval_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtPingInterval_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    int x = Int32.Parse(txtPingInterval.Text);
            //    errorProvider1.SetError(txtPingInterval, "");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Only Numberrs Please");
            //    txtPingInterval.Text = "";
            //}
        }

        private void txtRequestFailure_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    int x = Int32.Parse(txtRequestFailure.Text);
            //    errorProvider1.SetError(txtRequestFailure, "");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Only Numberrs Please");
            //    txtRequestFailure.Text = "";
            //}
        }

        private void txtRequestTimeOut_KeyUp(object sender, KeyEventArgs e)
        {
            //try
            //{
            //    int x = Int32.Parse(txtRequestTimeOut.Text);
            //    errorProvider1.SetError(txtRequestTimeOut, "");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Only Numberrs Please");
            //    txtRequestTimeOut.Text = "";
            //}

        }

        private void txtRequestFailure_Leave(object sender, EventArgs e)
        {
            int x1  = Convert.ToInt32(txtPingInterval.Text) * 3;
            txtRequestFailure.Text = x1.ToString();
            try
            {
                int x = Int32.Parse(txtRequestFailure.Text);
                errorProvider1.SetError(txtRequestFailure, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Only Numberrs Please");
                txtRequestFailure.Text = "";
                txtRequestFailure.Focus();
            }
        }

        private void txtRequestTimeOut_Leave(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(txtPingInterval.Text) * 3;
            txtRequestTimeOut.Text = x1.ToString();
            try
            {
                int x = Int32.Parse(txtRequestTimeOut.Text);
                errorProvider1.SetError(txtRequestTimeOut, "");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Only Numberrs Please");
                txtRequestTimeOut.Text = "";
                txtRequestFailure.Focus();
            }

        }

    }
}
