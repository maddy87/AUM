using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Threading;
using System.Web.Mail;


namespace AUM
{
    public partial class Console : Form
    {
        //trying to reduce the problem of redundant threads for the same url .... if user keeps on clicking the same url again and again.\
        static  int[] threadstatus = new int[50]; // i think its a sufficient no. .... /// yipee it worked

        //this arr will keep track of the deleted colouns and solve the dynamic invocation problem in the datagridview
        //for the deleted adn enabled rows
        static int[] deletedrows = new int[50]; // again taking a sufficient no. here.

        //Finally the images for showing the status of the ping sites.
        //Image Status_Unknown = Image.FromFile("D:\\maddy\\icons\\unknown2.ico");
        //Image Status_Up = Image.FromFile("D:\\maddy\\icons\\up.ico");
        //Image Status_Down = Image.FromFile("D:\\maddy\\icons\\down.ico");
        //Image Status_Pause = Image.FromFile("D:\\maddy\\icons\\pause.ico");

        //Testing 
        //Image Status_Unknown = Image.FromFile("C:\\icons\\unknown2.ico");
        //Image Status_Up = Image.FromFile("C:\\icons\\up.ico");
        //Image Status_Down = Image.FromFile("C:\\icons\\down.ico");
        //Image Status_Pause = Image.FromFile("C:\\icons\\pause.ico");
        string apppath = Application.StartupPath.ToString();
        //Testing -- Regardless of the location.
        Image Status_Unknown = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\unknown2.ico");
        Image Status_Up = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\up.ico");
        Image Status_Down = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\down.ico");
        Image Status_Pause = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\pause.ico");


        //Image Status_Unknown = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\unknown2.ico");
        //Image Status_Up = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\up.ico");
        //Image Status_Down = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\down.ico");
        //Image Status_Pause = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\pause.ico");

        public Console()
        {
            InitializeComponent();
        }

        private void Console_Load(object sender, EventArgs e)
        {
            try
            {
                ts_Config.Enabled = false;
                ts_Config.Visible = false; /// currently disabling the modify options in AUM.
                ts_StartAll.Visible = false;
                tsb_Delete.Enabled = false;
                DeleteSite_MenuItem.Enabled = false;
                toolStripButton1.Enabled = false;
                StartRequesting_MenuItem.Enabled = false;
                //hehe this was so so simple .... silly me  ... was digging the screenresolution and all shitt :)
                dgConsole.Width = this.Width - 20;

                this.WindowState = FormWindowState.Maximized;

                // NO BINDING OF DATAGRID ..... U SUCK WHEN U R DATABOUND.....CANT DO A FCKING OPERATION.
                //ImportData();
                //Loading the datagrid with the xml file.
                //XmlDataDocument xmldoc = new XmlDataDocument();
                //xmldoc.DataSet.ReadXml("D:\\aumsample1.xml");

                //DataSet ds = new DataSet();
                //ds = xmldoc.DataSet;
                //dgConsole.DataSource = ds.DefaultViewManager;
                //dgConsole.DataMember = "Site";

                //Filling the datagrid with the desired information.
                PopulateGridView();

                //Loading the unknown status for all the sites present as the pinging for them has yet no started
                for (int i = 0; i < dgConsole.Rows.Count; i++)
                {
                    dgConsole.Rows[i].Cells[0].Value = Status_Unknown;
                    threadstatus[i] = 0;
                }

                //Dispalying the About baby
                AboutBox1 frm = new AboutBox1();
                frm.ShowDialog();
                frm = null;

                #region : Starting all the sites

                //MessageBox.Show("Please wait till all the sites are started");
                System.Threading.Thread.Sleep(2000);
                for (int i = 0; i < dgConsole.Rows.Count; i++)
                {
                    int Current_Row = i;
                    //Disabling the start button for any future changes;
                    threadstatus[Current_Row] = 1;
                    GlobalData.temp = GlobalData.GD_SitesStopped[Current_Row];
                    GlobalData.GD_SitesStopped[Current_Row] = 0;
                    //Enabling the Stop Button
                    ts_Stop.Enabled = true;
                    PauseSite_MenuItem.Enabled = true;

                    GlobalData.GD_SiteUrl = dgConsole.Rows[Current_Row].Cells[1].Value.ToString();
                    GlobalData.GD_SiteDescp = dgConsole.Rows[Current_Row].Cells[2].Value.ToString();
                    GlobalData.GD_PingTimeout = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[6].Value);
                    GlobalData.GD_PingThreshold = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[5].Value);
                    GlobalData.GD_PingInterval = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[4].Value);
                    GlobalData.GD_EmailAddress_To = dgConsole.Rows[Current_Row].Cells[8].Value.ToString();
                    GlobalData.GD_EmailAddress_Cc = dgConsole.Rows[Current_Row].Cells[9].Value.ToString();
                    GlobalData.GD_CurrentGridViewLocation = Current_Row;//// u were the fuckin bug ... cnt believe u waste 20 mins

                    string threadname = "thread" + Current_Row.ToString();
                    Functionality obj = new Functionality(dgConsole);
                    Thread th1 = new Thread(new ThreadStart(obj.StartRequest));
                    //dgConsole.DataSource = null;
                    //dgConsole.Rows.Add();
                    //MessageBox.Show(dgConsole.Rows[Current_Row].Cells[1].Value.ToString());
                    dgConsole.Rows[Current_Row].Cells[7].Value = "Sending Request...";
                    th1.Name = threadname;
                    th1.Start();
                    //disabling so that it wont cause problem
                    //toolStripButton1.Enabled = false;
                    obj = null;
                    AUM_notify.ShowBalloonTip(3000, "Monitoring Started", "The Monitoring for the Site " + dgConsole.Rows[Current_Row].Cells[1].Value.ToString() + " has been started", ToolTipIcon.Info);

                }

                //Disabling the Start All button.
                ts_StartAll.Enabled = false;

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Load : " + ex.Message.ToString());
            }

            //MessageBox.Show(Application.StartupPath.ToString());

        }

        private void dgConsole_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void Console_FormClosing(object sender, FormClosingEventArgs e)
        {
            ExportData(); //check carefully whether the files are placed properly.

            try
            {

                AUM_notify.Visible = false;

                System.Threading.Thread.Sleep(2000);
                System.Threading.Thread.CurrentThread.Abort();

                this.Dispose();
                this.Close();
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(" Thank You For Using AUM "); //: Error Message - " + e1.Message.ToString());
                //System.Threading.Thread.CurrentThread.Abort();
                System.Environment.Exit(System.Environment.ExitCode);
                this.Dispose();
                this.Close();
            }
            
        }

        //Starting the Requests
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {

                GlobalData.Site_Config = 0; ///neccessary for additiion stuff
                int Current_Row = 0;

                if (dgConsole.CurrentRow.Index == null)
                {
                    GlobalData.GD_CurrentGridViewLocation = 0;
                    Current_Row = 0;
                }
                else
                {
                    GlobalData.GD_CurrentGridViewLocation = dgConsole.CurrentRow.Index;
                    Current_Row = dgConsole.CurrentRow.Index;
                }
                //Disabling the start button for any future changes;
                threadstatus[Current_Row] = 1;
                GlobalData.temp = GlobalData.GD_SitesStopped[Current_Row];
                GlobalData.GD_SitesStopped[Current_Row] = 0;
                //Enabling the Stop Button
                ts_Stop.Enabled = true;
                PauseSite_MenuItem.Enabled = true;

                //assigning the values of the selected site to the global variables.
                GlobalData.GD_SiteUrl = dgConsole.Rows[Current_Row].Cells[1].Value.ToString();
                GlobalData.GD_SiteDescp = dgConsole.Rows[Current_Row].Cells[2].Value.ToString();
                GlobalData.GD_PingTimeout = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[6].Value);
                GlobalData.GD_PingThreshold = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[5].Value);
                GlobalData.GD_PingInterval = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[4].Value);
                GlobalData.GD_EmailAddress_To = dgConsole.Rows[Current_Row].Cells[8].Value.ToString();
                GlobalData.GD_EmailAddress_Cc = dgConsole.Rows[Current_Row].Cells[9].Value.ToString();

                //MessageBox.Show(dgConsole.CurrentRow.Index.ToString());

                //Creating a new threqad for that particular site.
                string threadname = "thread" + Current_Row.ToString();
                Functionality obj = new Functionality(dgConsole);
                Thread th1 = new Thread(new ThreadStart(obj.StartRequest));
                //dgConsole.DataSource = null;
                //dgConsole.Rows.Add();
                dgConsole.Rows[Current_Row].Cells[7].Value = "Sending Request...";
                th1.Name = threadname;
                th1.Start();

                //disabling so that it wont cause problem
                toolStripButton1.Enabled = false;
                StartRequesting_MenuItem.Enabled = false;
                obj = null;
                AUM_notify.ShowBalloonTip(3000, "Monitoring Started", "The Monitoring for the Site " + dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString() + " has been started", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Start Requesting : " + ex.Message.ToString());
            }
        }

        #region : Obsolete Code once which i thought was the only solution for my databinding problem.
        public void BindGridview()
        {
            //I cannot add a new coloumn directly as it is databoud to our very much usefull XML file
            // also removing the databinding will enforce defining the columns before entering any 
            //information which is again a pain in the ass.
            //So please welcome some redundant code ..... i hate this.

            
            dgConsole.Rows.Add();
            int x = dgConsole.Rows.Count;
            dgConsole.Rows[x - 1].Cells[1].Value = GlobalData.GD_SiteUrl;
            dgConsole.Rows[x - 1].Cells[2].Value = GlobalData.GD_SiteDescp;
            dgConsole.Rows[x - 1].Cells[3].Value = 0;
            dgConsole.Rows[x - 1].Cells[4].Value = GlobalData.GD_PingInterval;
            dgConsole.Rows[x - 1].Cells[5].Value = GlobalData.GD_PingThreshold;
            dgConsole.Rows[x - 1].Cells[6].Value = GlobalData.GD_PingTimeout;
            dgConsole.Rows[x - 1].Cells[7].Value = GlobalData.GD_ErrorMessage;
            dgConsole.Rows[x - 1].Cells[8].Value = GlobalData.GD_EmailAddress_To;
            dgConsole.Rows[x - 1].Cells[9].Value = GlobalData.GD_EmailAddress_Cc;
     

            //Following is the part of the import data along with some modification in the end
            DataTable dt = new DataTable("Site"); //Name similar to the node int the xml file
            DataColumn dc;
            DataRow drw;
            DataSet ds = new DataSet("Sites"); //Name similar to the node int the xml file

           ///////////////////// ds.Tables.Add(dt);
            //Creating the apporpriate rows for the XML File

            //Creating coloumn 1 : Site URL
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "SiteUrl";
            dc.Caption = "Site URL";
            //dc.Unique = true;


            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 2 : Site Description
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "SiteDescp";
            dc.Caption = "Site Description";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 3 : Request's Sent
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "RequestSent";
            dc.Caption = "Request Sent";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 4 : Request Interval
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "RequestInterval";
            dc.Caption = "Request Interval";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 5 : Request Threshold
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "RequestThreshold";
            dc.Caption = "Request Failure Threshold";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 6 : Request Timeout
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.Int32");
            dc.ColumnName = "RequestTimeout";
            dc.Caption = "Request TimeOut";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 7 : Error Message
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "ErrorMessage";
            dc.Caption = "Error Message";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating coloumn 8 : Notification Email Address To
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "EmailAddressTo";
            dc.Caption = "Email Address To";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);


            //Creating coloumn 9 : Notification Email Address Cc
            dc = new DataColumn();
            dc.DataType = System.Type.GetType("System.String");
            dc.ColumnName = "EmailAddressCc";
            dc.Caption = "Email Address Cc";
            //dc.Unique = true;

            //Adding the created coloumn to the datacoloumn collection
            dt.Columns.Add(dc);

            //Creating Row from the Datagridview
            int i = 0;
            
            //MessageBox.Show(dgConsole.Rows.Count.ToString());

            //drw = dt.NewRow();

            //drw["SiteUrl"] = GlobalData.GD_SiteUrl;
            ////drw["siteurl"] = "www.google.com";
            //drw["SiteDescp"] = GlobalData.GD_SiteDescp;
            ////drw["sitedescp"] = "This is sample site " + i + "";
            //drw["RequestSent"] = 0;// Convert.ToInt32(dgConsole.Rows[i].Cells[2].Value.ToString());
            ////drw["siteinterval"] = 10;
            //drw["RequestInterval"] = GlobalData.GD_PingInterval;
            ////drw["siteinterval"] = 10;
            //drw["RequestThreshold"] = GlobalData.GD_PingThreshold;
            ////drw["siteinterval"] = 10;
            //drw["RequestTimeout"] = GlobalData.GD_PingTimeout;
            ////drw["siteinterval"] = 10;
            //drw["ErrorMessage"] = GlobalData.GD_ErrorMessage;
            ////drw["sitedescp"] = "This is sample site " + i + "";
            //drw["EmailAddressTo"] = GlobalData.GD_EmailAddress_To;
            ////drw["sitedescp"] = "This is sample site " + i + "";
            //drw["EmailAddressCc"] = GlobalData.GD_EmailAddress_Cc;
            ////drw["sitedescp"] = "This is sample site " + i + "";


            //dt.Rows.Add(drw);

            for (i = 0; i <= dgConsole.Rows.Count - 2; i++)
            {
                //MessageBox.Show(dgConsole.Rows[i].Cells[1].Value.ToString());

                drw = dt.NewRow();

                drw["SiteUrl"] = dgConsole.Rows[i].Cells[1].Value.ToString();
                //drw["siteurl"] = "www.google.com";
                drw["SiteDescp"] = dgConsole.Rows[i].Cells[2].Value.ToString();
                //drw["sitedescp"] = "This is sample site " + i + "";
                drw["RequestSent"] = Convert.ToInt32(dgConsole.Rows[i].Cells[3].Value.ToString());
                //drw["siteinterval"] = 10;
                drw["RequestInterval"] = Convert.ToInt32(dgConsole.Rows[i].Cells[4].Value.ToString());
                //drw["siteinterval"] = 10;
                drw["RequestThreshold"] = Convert.ToInt32(dgConsole.Rows[i].Cells[5].Value.ToString());
                //drw["siteinterval"] = 10;
                drw["RequestTimeout"] = Convert.ToInt32(dgConsole.Rows[i].Cells[6].Value.ToString());
                //drw["siteinterval"] = 10;
                drw["ErrorMessage"] = dgConsole.Rows[i].Cells[7].Value.ToString();
                //drw["sitedescp"] = "This is sample site " + i + "";
                drw["EmailAddressTo"] = dgConsole.Rows[i].Cells[8].Value.ToString();
                //drw["sitedescp"] = "This is sample site " + i + "";
                drw["EmailAddressCc"] = dgConsole.Rows[i].Cells[9].Value.ToString();
                //drw["sitedescp"] = "This is sample site " + i + "";


                dt.Rows.Add(drw);

            }

            //Adding the newly added coloumn to the grid view
            //#region : Adding new row


            drw = dt.NewRow();

            drw["SiteUrl"] = GlobalData.GD_SiteUrl;
            //drw["siteurl"] = "www.google.com";
            drw["SiteDescp"] = GlobalData.GD_SiteDescp;
            //drw["sitedescp"] = "This is sample site " + i + "";
            drw["RequestSent"] = 0;// Convert.ToInt32(dgConsole.Rows[i].Cells[2].Value.ToString());
            //drw["siteinterval"] = 10;
            drw["RequestInterval"] = GlobalData.GD_PingInterval;
            //drw["siteinterval"] = 10;
            drw["RequestThreshold"] = GlobalData.GD_PingThreshold;
            //drw["siteinterval"] = 10;
            drw["RequestTimeout"] = GlobalData.GD_PingTimeout;
            //drw["siteinterval"] = 10;
            drw["ErrorMessage"] = GlobalData.GD_ErrorMessage;
            //drw["sitedescp"] = "This is sample site " + i + "";
            drw["EmailAddressTo"] = GlobalData.GD_EmailAddress_To;
            //drw["sitedescp"] = "This is sample site " + i + "";
            drw["EmailAddressCc"] = GlobalData.GD_EmailAddress_Cc;
            //drw["sitedescp"] = "This is sample site " + i + "";


            dt.Rows.Add(drw);

            MessageBox.Show(dt.Rows.Count.ToString());
            dgConsole.DataSource = dt;

            //ds.WriteXml("D:\\aumsample2.xml");
            //this.Refresh();
            //MessageBox.Show("M here");
            //Again Impoeting the same information into the gridview 
            // and re-binding the data grid to show the newly added column
            // this.InitializeComponent();
            //ImportData();

        }
        #endregion


        #region : Exporting the Data into a Grid View
        public void ExportData()
        {
            try
            {
                DataTable dt = new DataTable("Site"); //Name similar to the node int the xml file
                DataColumn dc;
                DataRow drw;
                DataSet ds = new DataSet("Sites"); //Name similar to the node int the xml file

                ds.Tables.Add(dt);
                //Creating the apporpriate rows for the XML File

                //Creating coloumn 1 : Site URL
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "SiteUrl";
                dc.Caption = "Site URL";
                //dc.Unique = true;


                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 2 : Site Description
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "SiteDescp";
                dc.Caption = "Site Description";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 3 : Request's Sent
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "RequestSent";
                dc.Caption = "Request Sent";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 4 : Request Interval
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "RequestInterval";
                dc.Caption = "Request Interval";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 5 : Request Threshold
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "RequestThreshold";
                dc.Caption = "Request Failure Threshold";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 6 : Request Timeout
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.Int32");
                dc.ColumnName = "RequestTimeout";
                dc.Caption = "Request TimeOut";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 7 : Error Message
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "ErrorMessage";
                dc.Caption = "Error Message";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating coloumn 8 : Notification Email Address To
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "EmailAddressTo";
                dc.Caption = "Email Address To";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);


                //Creating coloumn 9 : Notification Email Address Cc
                dc = new DataColumn();
                dc.DataType = System.Type.GetType("System.String");
                dc.ColumnName = "EmailAddressCc";
                dc.Caption = "Email Address Cc";
                //dc.Unique = true;

                //Adding the created coloumn to the datacoloumn collection
                dt.Columns.Add(dc);

                //Creating Row from the Datagridview
                int i;
                for (i = 0; i <= dgConsole.Rows.Count - 1; i++)
                {
                    //MessageBox.Show(dgConsole.Rows[i].Cells[1].Value.ToString());
                    //i dont want the deleted shitt to appear in the next login session so wont 
                    // add then in the desired column
                    if (deletedrows[i] == 0)
                    {
                        drw = dt.NewRow();

                        drw["SiteUrl"] = dgConsole.Rows[i].Cells[1].Value.ToString();
                        //drw["siteurl"] = "www.google.com";
                        drw["SiteDescp"] = dgConsole.Rows[i].Cells[2].Value.ToString();
                        //drw["sitedescp"] = "This is sample site " + i + "";
                        drw["RequestSent"] = Convert.ToInt32(dgConsole.Rows[i].Cells[3].Value.ToString());
                        //drw["siteinterval"] = 10;
                        drw["RequestInterval"] = Convert.ToInt32(dgConsole.Rows[i].Cells[4].Value.ToString());
                        //drw["siteinterval"] = 10;
                        drw["RequestThreshold"] = Convert.ToInt32(dgConsole.Rows[i].Cells[5].Value.ToString());
                        //drw["siteinterval"] = 10;
                        drw["RequestTimeout"] = Convert.ToInt32(dgConsole.Rows[i].Cells[6].Value.ToString());
                        //drw["siteinterval"] = 10;
                        drw["ErrorMessage"] = "Ready"; // dgConsole.Rows[i].Cells[7].Value.ToString();
                        //drw["sitedescp"] = "This is sample site " + i + "";
                        drw["EmailAddressTo"] = dgConsole.Rows[i].Cells[8].Value.ToString();
                        //drw["sitedescp"] = "This is sample site " + i + "";
                        drw["EmailAddressCc"] = dgConsole.Rows[i].Cells[9].Value.ToString();
                        //drw["sitedescp"] = "This is sample site " + i + "";

                        dt.Rows.Add(drw);
                    }
                    else { /*no need to add this row as it is deleted*/};
                }

                //ds.WriteXml("D:\\aumsample1.xml");
                //ds.WriteXml("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\aumsample1.xml");// testing 
                //ds.WriteXml("D:\\aumsample1.xml");
                //ds.WriteXml("C:\\aumsample1.xml");
                ds.WriteXml(Application.StartupPath.ToString() + "\\aumsample1.xml"); // not harcoding the location of the file.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Exporting Data : " + ex.Message.ToString());
            }
        }
        #endregion


        #region : Importing the Data into GridView
        public void ImportData()
        {
            //Loading the datagrid with the xml file.
            XmlDataDocument xmldoc = new XmlDataDocument();
            xmldoc.DataSet.ReadXml("D:\\aumsample1.xml");

            DataSet ds = new DataSet();
            ds = xmldoc.DataSet;
            dgConsole.DataSource = ds.DefaultViewManager;
            dgConsole.DataMember = "Site";

            //dgConsole.Columns[2].Width = 1600;
            //dgConsole.Rows[1].DividerHeight = 40;

            //ParentMDI parent = new ParentMDI();

        }
        #endregion

        private void tsb_AddSite_Click(object sender, EventArgs e)
        {
            try
            {
                dgConsole.Rows.Add();
                GlobalData.GD_CurrentGridViewLocation = dgConsole.RowCount - 1;
                dgConsole.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[0].Value = Status_Unknown;

                AddSite frm = new AddSite(dgConsole);
                frm.Text = "Add Site";
                frm.Show();
                frm = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Adding New Site : " + ex.Message.ToString());
            }
        }

        private void tsb_Delete_Click(object sender, EventArgs e)
        {
            try
            {

                GlobalData.GD_SiteDeletedRow = dgConsole.CurrentRow.Index;
                System.Threading.Thread.Sleep(2000);

                deletedrows[dgConsole.CurrentRow.Index] = 1;
                GlobalData.GD_SitesDeleted[dgConsole.CurrentRow.Index] = 1; // marking the particular site as deleted in the array
                /// yipeeee ..... balloon tip .... feels so good. :)
                AUM_notify.ShowBalloonTip(3000, "Site Deleted", "The Site " + dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString() + " has been deleted", ToolTipIcon.Info);

                dgConsole.Rows[dgConsole.CurrentRow.Index].Visible = false;

                //dgConsole.Rows.RemoveAt(GlobalData.GD_CurrentGridViewLocation);

                tsb_Delete.Enabled = false;
                DeleteSite_MenuItem.Enabled = false;
                //toolStripButton1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Deleting : " + ex.Message.ToString());
            }
        }

        public void PopulateGridView()
        {
            try
            {
                XmlDataDocument xmldoc = new XmlDataDocument();
                //xmldoc.DataSet.ReadXml("D:\\aumsample1.xml");
                //xmldoc.DataSet.ReadXml("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\aumsample1.xml"); // testing for demo purpose.
                xmldoc.DataSet.ReadXml(Application.StartupPath.ToString() + "\\aumsample1.xml");
                //xmldoc.DataSet.ReadXml("C:\\AUM\\aumsample1.xml");
                DataSet ds = new DataSet();
                ds = xmldoc.DataSet;
                DataTable dt_xml = new DataTable();
                dt_xml = ds.Tables[0];

                int i = 0; int j = 0;
                int rowcount = dt_xml.Rows.Count;

                for (; i < rowcount; i++)
                {
                    dgConsole.Rows.Add();
                    dgConsole.Rows[i].Cells[1].Value = dt_xml.Rows[i]["SiteUrl"].ToString();
                    dgConsole.Rows[i].Cells[2].Value = dt_xml.Rows[i]["SiteDescp"].ToString();
                    dgConsole.Rows[i].Cells[3].Value = dt_xml.Rows[i]["RequestSent"].ToString();
                    dgConsole.Rows[i].Cells[4].Value = dt_xml.Rows[i]["RequestInterval"].ToString();
                    dgConsole.Rows[i].Cells[5].Value = dt_xml.Rows[i]["RequestThreshold"].ToString();
                    dgConsole.Rows[i].Cells[6].Value = dt_xml.Rows[i]["RequestTimeout"].ToString();
                    dgConsole.Rows[i].Cells[7].Value = dt_xml.Rows[i]["ErrorMessage"].ToString();
                    dgConsole.Rows[i].Cells[8].Value = dt_xml.Rows[i]["EmailAddressTo"].ToString();
                    dgConsole.Rows[i].Cells[9].Value = dt_xml.Rows[i]["EmailAddressCc"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Importing Data : " + ex.Message.ToString());
            }
          }

        public void AddSite()
        {

            try
            {

                // this.InitializeComponent();
                dgConsole.Rows.Add();
                int x = dgConsole.Rows.Count;
                dgConsole.Rows[x - 1].Cells[0].Value = GlobalData.GD_SiteUrl;
                dgConsole.Rows[x - 1].Cells[1].Value = GlobalData.GD_SiteDescp;
                dgConsole.Rows[x - 1].Cells[2].Value = 0;
                dgConsole.Rows[x - 1].Cells[3].Value = GlobalData.GD_PingInterval;
                dgConsole.Rows[x - 1].Cells[4].Value = GlobalData.GD_PingThreshold;
                dgConsole.Rows[x - 1].Cells[5].Value = GlobalData.GD_PingTimeout;
                dgConsole.Rows[x - 1].Cells[6].Value = GlobalData.GD_ErrorMessage;
                dgConsole.Rows[x - 1].Cells[7].Value = GlobalData.GD_EmailAddress_To;
                dgConsole.Rows[x - 1].Cells[8].Value = GlobalData.GD_EmailAddress_Cc;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in AddSite : " + ex.Message.ToString());

            }
        }

         private void Console_Resize(object sender, EventArgs e)
          {
            if (FormWindowState.Minimized == WindowState)
                Hide();
          }


               
        
        private void AUM_notify_MouseDoubleClick(object sender, MouseEventArgs e)
         {
             Show();
             WindowState = FormWindowState.Maximized;
         }

         private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
         {

         }

         private void dgConsole_CellClick(object sender, DataGridViewCellEventArgs e)
         {
             try
             {
                 //GlobalData.GD_SiteDeletedRow = dgConsole.CurrentRow.Index;
                // ts_Config.Enabled = true; ----> to be implemented in  the next major version.
                 tsb_Delete.Enabled = true;
                 DeleteSite_MenuItem.Enabled = true;

                 //dont want the user toolStrip1 keep clicking the start button so enabling it only when it is not active
                 if (threadstatus[dgConsole.CurrentRow.Index] == 0)
                 {
                     toolStripButton1.Enabled = true;
                     StartRequesting_MenuItem.Enabled = true;
                 }
                 else
                 { 
                     toolStripButton1.Enabled = false;
                     StartRequesting_MenuItem.Enabled = false;
                 }

                 //again don't want the Stop option to be displayed to an already stopped thread
                 //but enable a start option for the same thread if it is stopped
                 if (GlobalData.GD_SitesStopped[dgConsole.CurrentRow.Index] == 1)
                 {
                     ts_Stop.Enabled = false;
                     PauseSite_MenuItem.Enabled = false;
                     //ts_Config.Enabled = true;
                 }
                 else
                 {
                     ts_Stop.Enabled = true;
                     PauseSite_MenuItem.Enabled = true;
                     //ts_Config.Enabled = false;
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Cell Content : " + ex.Message.ToString());

             }
         }

         private void ts_Stop_Click(object sender, EventArgs e)
         {
             try
             {
                 GlobalData.GD_SitesStopped[dgConsole.CurrentRow.Index] = 1;
                 threadstatus[dgConsole.CurrentRow.Index] = 0;
                 toolStripButton1.Enabled = true;
                 StartRequesting_MenuItem.Enabled = true;
                 ts_Stop.Enabled = false;
                 PauseSite_MenuItem.Enabled = false;

                 //GlobalData.temp = dgConsole.CurrentRow.Index;
                 //GlobalData.temp = 1;
                 AUM_notify.ShowBalloonTip(3000, "Site Monitoring Paused", "The Site " + dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString() + " has been Paused", ToolTipIcon.Info);
                 dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[7].Value = "Paused";
                 dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[0].Value = Status_Pause;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Stop Requesting : " + ex.Message.ToString());
             }
         }

         private void Console_FormClosed(object sender, FormClosedEventArgs e)
         {
             AUM_notify.Visible = false;
         }

         private void ts_Mail_Click(object sender, EventArgs e)
         {
             #region : Something i tried for sending email ... eeeks looks so desparate
             //             /// the problem here is the SMTP doesn't allow the sending of relay messages from the system
//             /// should work in AZ systems .... but i dnt have an option 
//             // mentioning the AZ systems smtp servers which allow relay 
////             string mail = "mailto:rajeshetty87@gmail.com?subject=Test mail";

//             Microsoft.Office.Interop.Outlook.Application Outlook_mail = new Microsoft.Office.Interop.Outlook.Application();

//             Microsoft.Office.Interop.Outlook.MailItem mailitem = (Microsoft.Office.Interop.Outlook.MailItem)Outlook_mail.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);
//             mailitem.To = "rajeshetty87@gmail.com";
//             mailitem.Subject = "Test Mail";
//             mailitem.Body = "Test Mail";
//            // mailitem.Display(true);
             
//             //mailitem.Send();

//             ((Microsoft.Office.Interop.Outlook._MailItem)mailitem).Send();

//             mailitem = null;
//             Outlook_mail = null;


//             //MailMessage mail = new MailMessage();
//             //mail.To = "rajeshetty87@gmail.com";
//             //mail.From = "rajeshetty87@gmail.com";
//             //mail.Subject = "Test";
//             //mail.Body = " this is a test mail ";
//             //SmtpMail.Send(mail);

#endregion

             ReachUs frm = new ReachUs();
             frm.ShowDialog();

         }

         private void ts_Config_Click(object sender, EventArgs e)
         {
             try
             {
                 //giving all the global vairables the values so that they can be passed on to other forms. 
                 GlobalData.Site_Config = 1;
                 GlobalData.GD_CurrentGridViewLocation = dgConsole.CurrentRow.Index;

                 GlobalData.GD_Config_SiteUrl = dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString();
                 GlobalData.GD_Config_SiteDescp = dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[2].Value.ToString();
                 GlobalData.GD_Config_PingInterval = Convert.ToInt32(dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[4].Value);
                 GlobalData.GD_Config_PingThreshold = Convert.ToInt32(dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[5].Value);
                 GlobalData.GD_Config_PingTimeout = Convert.ToInt32(dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[6].Value);
                 GlobalData.GD_Config_EmailAddress_To = dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[8].Value.ToString();
                 GlobalData.GD_Config_EmailAddress_Cc = dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[9].Value.ToString();

                 AddSite frm = new AddSite(dgConsole);
                 frm.Show();
                 frm = null;
                 //GlobalData.Site_Config = 0;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Modify Site : " + ex.Message.ToString());
             }
         }

         private void ts_StartAll_Click(object sender, EventArgs e)
         {
             try
             {
              MessageBox.Show("Please wait till all the sites are started");
              System.Threading.Thread.Sleep(2000);
              for (int i = 0; i < dgConsole.Rows.Count; i++)
              {
                 int Current_Row = i;

                 //Disabling the start button for any future changes;
                 threadstatus[Current_Row] = 1;
                 GlobalData.temp = GlobalData.GD_SitesStopped[Current_Row];
                 GlobalData.GD_SitesStopped[Current_Row] = 0;
                 //Enabling the Stop Button
                 ts_Stop.Enabled = true;
                 PauseSite_MenuItem.Enabled = true;

                 GlobalData.GD_SiteUrl = dgConsole.Rows[Current_Row].Cells[1].Value.ToString();
                 GlobalData.GD_SiteDescp = dgConsole.Rows[Current_Row].Cells[2].Value.ToString();
                 GlobalData.GD_PingTimeout = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[6].Value);
                 GlobalData.GD_PingThreshold = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[5].Value);
                 GlobalData.GD_PingInterval = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[4].Value);
                 GlobalData.GD_EmailAddress_To = dgConsole.Rows[Current_Row].Cells[8].Value.ToString();
                 GlobalData.GD_EmailAddress_Cc = dgConsole.Rows[Current_Row].Cells[9].Value.ToString();
                 GlobalData.GD_CurrentGridViewLocation = Current_Row;//// u were the fuckin bug ... cnt believe u wasted my precious 20 mins

                 string threadname = "thread" + Current_Row.ToString();
                 Functionality obj = new Functionality(dgConsole);
                 Thread th1 = new Thread(new ThreadStart(obj.StartRequest));
                 //dgConsole.DataSource = null;
                 //dgConsole.Rows.Add();
                 //MessageBox.Show(dgConsole.Rows[Current_Row].Cells[1].Value.ToString());
                 dgConsole.Rows[Current_Row].Cells[7].Value = "Sending Request...";
                 th1.Name = threadname;
                 th1.Start();
                 //disabling so that it wont cause problem
                 // toolStripButton1.Enabled = false;
                 obj = null;
                 AUM_notify.ShowBalloonTip(3000, "Monitoring Started", "The Monitoring for the Site " + dgConsole.Rows[Current_Row].Cells[1].Value.ToString() + " has been started", ToolTipIcon.Info);
              }
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Modify Site : " + ex.Message.ToString());
             }

             //Disabling the Start All button.
             ts_StartAll.Enabled = false;
            
         }

         private void exitToolStripMenuItem_Click(object sender, EventArgs e)
         {
             ExportData();
             try
             {

                 AUM_notify.Visible = false;

                 System.Threading.Thread.Sleep(2000);
                 System.Threading.Thread.CurrentThread.Abort();

                 this.Dispose();
                 this.Close();
             }
             catch (System.Exception e1)
             {
                 MessageBox.Show(" Thank You For Using AUM ");//Closing AUM : Error Message - " + e1.Message.ToString());
                 //System.Threading.Thread.CurrentThread.Abort();
                 System.Environment.Exit(System.Environment.ExitCode);
                 this.Dispose();
                 this.Close();

             }

         }

         private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
         {

         }

         private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
         {
             AboutBox1 frm = new AboutBox1();
             frm.ShowDialog();
         }

         private void AddSite_MenuItem_Click(object sender, EventArgs e)
         {
             //Code for Adding  A Site Comes Here
             try
             {
                 dgConsole.Rows.Add();
                 GlobalData.GD_CurrentGridViewLocation = dgConsole.RowCount - 1;
                 dgConsole.Rows[GlobalData.GD_CurrentGridViewLocation].Cells[0].Value = Status_Unknown;

                 AddSite frm = new AddSite(dgConsole);
                 frm.Text = "Add Site";
                 frm.Show();
                 frm = null;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Adding New Site : " + ex.Message.ToString());
             }
         }

         private void StartRequesting_MenuItem_Click(object sender, EventArgs e)
         {
             //Code for Start Requesting A Site


             try
             {

                 GlobalData.Site_Config = 0; ///neccessary for additiion stuff
                 int Current_Row = 0;

                 if (dgConsole.CurrentRow.Index == null)
                 {
                     GlobalData.GD_CurrentGridViewLocation = 0;
                     Current_Row = 0;
                 }
                 else
                 {
                     GlobalData.GD_CurrentGridViewLocation = dgConsole.CurrentRow.Index;
                     Current_Row = dgConsole.CurrentRow.Index;
                 }
                 //Disabling the start button for any future changes;
                 threadstatus[Current_Row] = 1;
                 GlobalData.temp = GlobalData.GD_SitesStopped[Current_Row];
                 GlobalData.GD_SitesStopped[Current_Row] = 0;
                 //Enabling the Stop Button
                 ts_Stop.Enabled = true;
                 PauseSite_MenuItem.Enabled = true;

                 //assigning the values of the selected site to the global variables.
                 GlobalData.GD_SiteUrl = dgConsole.Rows[Current_Row].Cells[1].Value.ToString();
                 GlobalData.GD_SiteDescp = dgConsole.Rows[Current_Row].Cells[2].Value.ToString();
                 GlobalData.GD_PingTimeout = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[6].Value);
                 GlobalData.GD_PingThreshold = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[5].Value);
                 GlobalData.GD_PingInterval = Convert.ToInt32(dgConsole.Rows[Current_Row].Cells[4].Value);
                 GlobalData.GD_EmailAddress_To = dgConsole.Rows[Current_Row].Cells[8].Value.ToString();
                 GlobalData.GD_EmailAddress_Cc = dgConsole.Rows[Current_Row].Cells[9].Value.ToString();

                 //MessageBox.Show(dgConsole.CurrentRow.Index.ToString());

                 //Creating a new threqad for that particular site.
                 string threadname = "thread" + Current_Row.ToString();
                 Functionality obj = new Functionality(dgConsole);
                 Thread th1 = new Thread(new ThreadStart(obj.StartRequest));
                 //dgConsole.DataSource = null;
                 //dgConsole.Rows.Add();
                 dgConsole.Rows[Current_Row].Cells[7].Value = "Sending Request...";
                 th1.Name = threadname;
                 th1.Start();

                 //disabling so that it wont cause problem
                 toolStripButton1.Enabled = false;
                 StartRequesting_MenuItem.Enabled = false;
                 obj = null;
                 AUM_notify.ShowBalloonTip(3000, "Monitoring Started", "The Monitoring for the Site " + dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString() + " has been started", ToolTipIcon.Info);
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Start Requesting : " + ex.Message.ToString());
             }

         }

         private void PauseSite_MenuItem_Click(object sender, EventArgs e)
         {
               //Code For Pausing A Site


             try
             {
                 GlobalData.GD_SitesStopped[dgConsole.CurrentRow.Index] = 1;
                 threadstatus[dgConsole.CurrentRow.Index] = 0;
                 toolStripButton1.Enabled = true;
                 StartRequesting_MenuItem.Enabled = true;
                 ts_Stop.Enabled = false;
                 PauseSite_MenuItem.Enabled = false;
                 //GlobalData.temp = dgConsole.CurrentRow.Index;
                 //GlobalData.temp = 1;
                 AUM_notify.ShowBalloonTip(3000, "Site Monitoring Paused", "The Site " + dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString() + " has been Paused", ToolTipIcon.Info);
                 dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[7].Value = "Paused";
                 dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[0].Value = Status_Pause;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Stop Requesting : " + ex.Message.ToString());
             }


         }

         private void DeleteSite_MenuItem_Click(object sender, EventArgs e)
         {
             //Deleting Sites

             try
             {

                 GlobalData.GD_SiteDeletedRow = dgConsole.CurrentRow.Index;
                 System.Threading.Thread.Sleep(2000);

                 deletedrows[dgConsole.CurrentRow.Index] = 1;
                 GlobalData.GD_SitesDeleted[dgConsole.CurrentRow.Index] = 1; // marking the particular site as deleted in the array
                 /// yipeeee ..... balloon tip .... feels so good. :)
                 AUM_notify.ShowBalloonTip(3000, "Site Deleted", "The Site " + dgConsole.Rows[dgConsole.CurrentRow.Index].Cells[1].Value.ToString() + " has been deleted", ToolTipIcon.Info);

                 dgConsole.Rows[dgConsole.CurrentRow.Index].Visible = false;

                 //dgConsole.Rows.RemoveAt(GlobalData.GD_CurrentGridViewLocation);

                 tsb_Delete.Enabled = false;
                 DeleteSite_MenuItem.Enabled = false;
                 //toolStripButton1.Enabled = true;
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error in Deleting : " + ex.Message.ToString());
             }

         }



    }
    }

