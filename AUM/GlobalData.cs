using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Net.NetworkInformation;
using System.Net;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net.Mail;

namespace AUM
{
    public static class GlobalData
    {

        //GLOBAL ATTRIBUTES FOR EVERY SITE ADDEDD
        public static string GD_SiteUrl;
        public static string GD_SiteDescp;
        public static int GD_PingsSent;
        public static int GD_PingInterval;
        public static int GD_PingThreshold;
        public static int GD_PingTimeout;
        public static string GD_Status;
        public static string GD_ErrorMessage;
        public static string GD_EmailAddress_To;
        public static string GD_EmailAddress_Cc;


        //ARE YAAR THESE THREADS NEEDS SO MANY RESOUCRES TO KEEP TRACK OF THEM . HERE ARE SOME MORE.
        public static int GD_SiteDeletedRow = -1;


        //Another grid to maintain and provide info on which thread is stopped
        public static int[] GD_SitesStopped = new int[50]; // the size is more than enough.

        //Another grid to maintain and provide info on which thread is deleted so that i dnt use them anymore.
        public static int[] GD_SitesDeleted = new int[50]; // the size is more than enough.
      
        
        //MAINTAINS THE COUNT OF THE GRID VIEW 
        //THROUGHT THE LIFE OF THE APPLICATION
        public static int GD_GridViewCount;
        public static int GD_CurrentGridViewLocation;


        //testing ..... haha it worked ... i ain't removing this
        public static int temp = 0;

        // To maintain if the current user has asked for configuration or Adding the site.
        public static int Site_Config = 0;

        //To keep a track of the users email id's mentioned.
        public static string GD_StoreEmailId_To = "Your_EmailId@domain.com";
        public static string GD_StoreEmailId_Cc = "Your_Cc_EmailId@domain.com";

        //The config details of the site put in here for temp purposse.
        //GLOBAL ATTRIBUTES FOR EVERY SITE ADDEDD 
        public static string GD_Config_SiteUrl;
        public static string GD_Config_SiteDescp;
        //public static int GD_PingsSent;
        public static int GD_Config_PingInterval;
        public static int GD_Config_PingThreshold;
        public static int GD_Config_PingTimeout;
        //public static string GD_Status;
        //public static string GD_ErrorMessage;
        public static string GD_Config_EmailAddress_To;
        public static string GD_Config_EmailAddress_Cc;
        
    }

    class Functionality
    {
        string g_SiteUrl;
        string g_SiteDescp;
        int g_PingsSent;
        int g_PingInterval;
        int g_PingThreshold;
        int g_PingTimeout;
        string g_Status;
        string g_ErrorMessage;
        string g_EmailAddress_To;
        string g_EmailAddress_Cc;
        int g_CurrentGridLocation;
        int g_PingsFailed; // Failed Pings Count.
        int g_SendMail; //Send Mail after every 3 consecutive attempts fail.

       
        //gridview declaration
        private DataGridView g_datagridview;

        //delegate declaration
        private delegate void DisplayStatusRequestDelegate(string del_SiteUrl,string del_SiteDescp,int del_PingsSent,int del_PingsInterval,int del_PingsThreshold,int del_PingTimeout,string del_Status,string del_ErrorMessage);

        //Images Required for the showing the status of all the current sites.
        //Image Status_Unknown = Image.FromFile("D:\\maddy\\icons\\unknown2.ico");
        //Image Status_Up = Image.FromFile("D:\\maddy\\icons\\up.ico");
        //Image Status_Down = Image.FromFile("D:\\maddy\\icons\\down.ico");

        //Testing 
        //Image Status_Unknown = Image.FromFile("C:\\icons\\unknown2.ico");
        //Image Status_Up = Image.FromFile("C:\\icons\\up.ico");
        //Image Status_Down = Image.FromFile("C:\\icons\\down.ico");
        //Image Status_Pause = Image.FromFile("C:\\icons\\pause.ico");


        //Testing -- Regardless of the location.
        Image Status_Unknown = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\unknown2.ico");
        Image Status_Up = Image.FromFile(Application.StartupPath.ToString() +  "\\icons\\up.ico");
        Image Status_Down = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\down.ico");
        Image Status_Pause = Image.FromFile(Application.StartupPath.ToString() + "\\icons\\pause.ico");

        //Image Status_Unknown = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\unknown2.ico");
        //Image Status_Up = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\up.ico");
        //Image Status_Down = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\down.ico");
        //Image Status_Pause = Image.FromFile("C:\\Documents and Settings\\rajesh_shetty02\\Desktop\\icons\\pause.ico");

        

        public Functionality()
        {
           
        }

        public Functionality(DataGridView dg_Local)
        {
            g_datagridview = dg_Local;
        }

        
        public void StartRequest()
        {
            try
            {
                //Assgning the value of the global variable to the local ones.
                g_SiteUrl = GlobalData.GD_SiteUrl;
                g_SiteDescp = GlobalData.GD_SiteDescp;
                g_PingsSent = 0;
                g_PingInterval = GlobalData.GD_PingInterval * 1000; // converting it itno ms
                g_PingThreshold = GlobalData.GD_PingThreshold * 1000; // converting it itno ms
                g_PingTimeout = GlobalData.GD_PingTimeout * 1000; // converting it itno ms
                //g_Status = GlobalData.GD_Status;
                g_ErrorMessage = "-";// GlobalData.GD_ErrorMessage;
                g_CurrentGridLocation = GlobalData.GD_CurrentGridViewLocation;
                g_EmailAddress_To = GlobalData.GD_EmailAddress_To;
                g_EmailAddress_Cc = GlobalData.GD_EmailAddress_Cc;

                //Variables required for updating the value of the sites according to the no of pings sent.

                System.Timers.Timer t_ConsoleTimer = new System.Timers.Timer();


                //SendRequest(g_SiteUrl, g_SiteDescp, g_PingsSent, g_PingInterval, g_PingThreshold, g_PingTimeout, g_Status, g_ErrorMessage);

                //for resumed sites which have been stopped earlier
                //if (GlobalData.GD_SitesStopped[g_CurrentGridLocation] == 1)
                if (GlobalData.temp == 1)
                {
                    t_ConsoleTimer.Enabled = false;

                }
                else
                {
                    t_ConsoleTimer.Interval = g_PingInterval;
                    t_ConsoleTimer.Elapsed += new ElapsedEventHandler(t_ConsoleTimer_Elapsed);
                    t_ConsoleTimer.Enabled = true;
                }

                //GlobalData.GD_CurrentGridViewLocation++;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in Starting Request : " + ex.Message.ToString());
            }

        }

        void  t_ConsoleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //if (GlobalData.GD_SitesStopped[g_CurrentGridLocation] == 1)
            //{
                
            //    System.Threading.Thread.CurrentThread.Abort();
                             
            //}
            //else
            //{
                //MessageBox.Show("I am still alive");
                SendRequest(g_SiteUrl, g_SiteDescp, g_PingsSent, g_PingInterval, g_PingThreshold, g_PingTimeout, g_Status, g_ErrorMessage);
          //  }
            
        }

        public void SendRequest(string func_SiteUrl, string func_SiteDescp, int func_PingsSent, int func_PingsInterval, int func_PingsThreshold, int func_PingTimeout, string func_Status, string func_ErrorMessage)
        {
            try
            {
                //Sending the actual request to the servers.
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(func_SiteUrl);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.google.com");

                //Sending the logged in users credentials.
                request.Credentials = CredentialCache.DefaultCredentials;

                request.Timeout = func_PingTimeout + 5000;


                ////Code for overcoming the 407 Proxy Autnetication Error.
                request.Proxy = WebProxy.GetDefaultProxy();
                request.Proxy.Credentials = CredentialCache.DefaultCredentials;

                //request.AllowAutoRedirect = true;
                //request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //lbltest.Text = response.StatusCode.ToString();
                func_Status = response.StatusDescription.ToString();
                //MessageBox.Show(response.StatusCode.ToString());

                //Error message if not correct data displayed.
                func_ErrorMessage = func_Status == "OK" ? "OK" : func_Status;

                /////Addding Other Credentials
                //CredentialCache NewCredentials = new CredentialCache();
                //NewCredentials.Add(new Uri(func_SiteUrl),"Basic",new NetworkCredential("AMERICAS\\kwbh960","renuga2009"));
                //request.Credentials = NewCredentials;

                response.Close(); // Closing the response and hence resolving a bug here.
                request = null;

                GC.Collect(); ///////// Yipppee ..... resources free ........ the biggest bug so far removed.
            }
            catch (WebException weberr)
            {
                func_ErrorMessage = weberr.Message.ToString();
            }
            catch (UriFormatException e)
            {
                //MessageBox.Show(e.Message.ToString());
                func_ErrorMessage = e.Message.ToString();
                //  MessageBox.Show(System.Threading.Thread.CurrentThread.ThreadState.ToString());

                //Aborting the thread as it will keep on throwing the error.
                System.Threading.Thread.CurrentThread.Abort();

            }
            catch (HttpListenerException httperr)
            {
                func_ErrorMessage = httperr.Message.ToString();
            }
            
            finally
            {
                // MessageBox.Show(g_SiteUrl);  
                //g_datagridview.Invoke(new DisplayStatusRequestDelegate(DisplayRequestStatus), new object[] { func_SiteUrl, func_SiteDescp, g_PingsSent++, func_PingsInterval, func_PingsThreshold, func_PingTimeout, func_Status, func_ErrorMessage });
                if (g_CurrentGridLocation == GlobalData.GD_SiteDeletedRow)
                {
                    System.Threading.Thread.CurrentThread.Abort();
                   
                   
                }
                if (GlobalData.GD_SitesStopped[g_CurrentGridLocation] == 1)
                {
                   
                   System.Threading.Thread.CurrentThread.Suspend();
                }

                else
                { g_datagridview.Invoke(new DisplayStatusRequestDelegate(DisplayRequestStatus), new object[] { func_SiteUrl, func_SiteDescp, g_PingsSent++, func_PingsInterval, func_PingsThreshold, func_PingTimeout, func_Status, func_ErrorMessage }); }
            }
        
        }
          
        private void DisplayRequestStatus(string disp_SiteUrl, string disp_SiteDescp, int disp_PingsSent, int disp_PingsInterval, int disp_PingsThreshold, int disp_PingTimeout, string disp_Status, string disp_ErrorMessage)
        {
            if (GlobalData.GD_SitesDeleted[g_CurrentGridLocation] == 0)
            {
                try
                {

                    //g_datagridview.Rows[g_CurrentGridLocation].Cells[1].Value = disp_SiteUrl;
                    //g_datagridview.Rows[g_CurrentGridLocation].Cells[2].Value = disp_SiteDescp;
                    g_datagridview.Rows[g_CurrentGridLocation].Cells[3].Value = disp_PingsSent;
                    //g_datagridview.Rows[g_CurrentGridLocation].Cells[4].Value = disp_PingsInterval;
                    //g_datagridview.Rows[g_CurrentGridLocation].Cells[5].Value = disp_PingsThreshold;
                    //g_datagridview.Rows[g_CurrentGridLocation].Cells[6].Value = disp_PingTimeout;
                    g_datagridview.Rows[g_CurrentGridLocation].Cells[7].Value = disp_ErrorMessage;
                    g_datagridview.Rows[g_CurrentGridLocation].Cells[8].Value = g_EmailAddress_To;
                    g_datagridview.Rows[g_CurrentGridLocation].Cells[9].Value = g_EmailAddress_Cc;

                    //Displaying the status images accordingly.
                    if (disp_ErrorMessage == "OK")
                    {
                        g_datagridview.Rows[g_CurrentGridLocation].Cells[0].Value = Status_Up;
                    }
                    else
                    {
                        g_PingsFailed = g_PingsFailed + disp_PingsInterval;
                        if (g_PingsFailed >= disp_PingsThreshold)
                        {
                            g_datagridview.Rows[g_CurrentGridLocation].Cells[0].Value = Status_Down;
                            g_SendMail++;
                            g_PingsFailed = 0;//Setting the failed ping again to 0 
                        }
                        if (g_SendMail >= 3)
                        {
                            // g_SendMail = 0;

                            try
                            {

                                g_SendMail = 0;

                                //Sending mail to the users mentioned in the 
                                string email_to = g_datagridview.Rows[g_CurrentGridLocation].Cells[8].Value.ToString();
                                string email_from = g_datagridview.Rows[g_CurrentGridLocation].Cells[9].Value.ToString();

                                MailMessage notify_mail = new MailMessage();
                                notify_mail.To.Add(email_to);
                                notify_mail.CC.Add(email_from);
                                notify_mail.From = new MailAddress("AUM_MAILER@Ikran.com");
                                notify_mail.Subject = "The Site " + g_SiteUrl + " is currently not responding ";
                                notify_mail.Body = "The Site " + g_SiteUrl + " is currently not responding. The follwing is the response from the last request ' " + disp_ErrorMessage + " '. Kindly take the neccasary actions. ";

                                SmtpClient client = new SmtpClient("172.19.98.22", 25); ///addr of the SMTP Server.
                                client.UseDefaultCredentials = true;
                               

                                //lient.Send(notify_mail);

                                notify_mail = null;
                            }
                            catch (System.Exception e1)
                            {
                                MessageBox.Show(e1.Message.ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Displaying Site Info : " + ex.Message.ToString());
                }

            }
            else
            {
                //This particular site has been deleted so no need to perform any display operation.
            }
        }

        public void AddSite_SetGlobalData(string Set_SiteUrl, string Set_SiteDescp,int Set_PingsInterval, int Set_PingsThreshold, int Set_PingTimeout,string Set_Email_To,string Set_Email_Cc)
        {
            GlobalData.GD_SiteUrl = Set_SiteUrl;
            GlobalData.GD_SiteDescp = Set_SiteDescp;
            GlobalData.GD_PingsSent = 0;
            GlobalData.GD_PingInterval = Set_PingsInterval;
            GlobalData.GD_PingThreshold = Set_PingsThreshold;
            GlobalData.GD_PingTimeout = Set_PingTimeout;
            GlobalData.GD_Status = "T";
            GlobalData.GD_ErrorMessage = "Ready";
            GlobalData.GD_EmailAddress_To = Set_Email_To;
            GlobalData.GD_EmailAddress_Cc = Set_Email_Cc;
            
        }
    }


}
/*Deleteing row and also aborting the thread for that particular row - solved
 *Icons +Icons + Icons - Solved
 *Images in the GridView - SOLVED!!!
 *Aboout Box thing - SOLVED !!!!!!!!!! so simple
 *Chaniging image status on the request thing - SOLVED !!!
 *\\\\\\\\Sending email and delaying the email status  ...SOLVED
 *notifying the user accordingly.
 *Config Window for the existing Sites  - Solved
 *Request DEtails in Seconds  - SOLVED.
 *\\\\\\\\Help File
 *Configuring MEnu Items Accordingly
 *Validations.
 *Try Catch in every thing.
 *Feedback
 */

