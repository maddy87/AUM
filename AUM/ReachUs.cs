using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace AUM
{
    public partial class ReachUs : Form
    {
        public ReachUs()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBody.Text == "")
                {
                    MessageBox.Show("The Message Feild Cannot Be Empty ");
                }
                else
                {
                    //Sending mail to the users mentioned in the 

                    MailMessage notify_mail = new MailMessage();
                    notify_mail.To.Add("rajesh.shetty@Ikran.com");
                    //notify_mail.CC.Add(g_EmailAddress_Cc);
                    notify_mail.From = new MailAddress(GlobalData.GD_StoreEmailId_To.ToString());
                    notify_mail.Subject = txtSubject.Text;// "The Site " + g_SiteUrl + " is currently not responding ";
                    notify_mail.Body = txtBody.Text; // "The Site " + g_SiteUrl + " is currently not responding. The follwing is the response from the last request " + g_ErrorMessage + " , Kindly take the neccasary actions ";
                    SmtpClient client = new SmtpClient("172.19.98.22", 25); ///addr of the SMTP Server.
                    client.UseDefaultCredentials = true;
                    //MessageBox.Show("Sending Mail");
                    //client.Send(notify_mail);
                    this.Close();
                }
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message.ToString());
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSubject_Enter(object sender, EventArgs e)
        {
            txtSubject.Text = "AUM_" + comboBox1.Text + " : ";
        }
    }
}
