using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using OutLook = Microsoft.Office.Interop.Outlook;


namespace Elev8App
{
    public partial class frmSelectAccount : Form
    {
        public frmSelectAccount()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Outlook.Application app;
        OutLook.MailItem mailItem = null;
        mailattach ma = null;
        List<mailattach> mailattachmentList = null;
        private void frmSelectAccount_Load(object sender, EventArgs e)
        {
            app = new Microsoft.Office.Interop.Outlook.Application();
            mailattachmentList = (List<mailattach>)this.Tag;
         //   mailattachmentList = new List<mailattach>();
         //   comboBox1.DataSource = getaccountList();
             mailattachBindingSource.DataSource = mailattachmentList.ToList();
            
        }
        public static OutLook.Account getaccount(string sFromAddress)
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            OutLook.Accounts accounts = app.Session.Accounts;
            OutLook.Account acc = null;

            //Look for our account in the Outlook
            foreach (OutLook.Account account in accounts)
            {
                if (account.SmtpAddress.Equals(sFromAddress, StringComparison.CurrentCultureIgnoreCase))
                {
                    //Use it
                    acc = account;
                    break;
                }
            }
            return acc;
        }
        public static List<string> getaccountList()
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            OutLook.Accounts accounts = app.Session.Accounts;
          //  OutLook.Account acc = null;
            List<string> Accountlist = new List<string>();
            //Look for our account in the Outlook
            foreach (OutLook.Account account in accounts)
            {
                Accountlist.Add(account.SmtpAddress);
            }
            return Accountlist;
        }

        public static List<OutLook.Account> getaccountList2()
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            OutLook.Accounts accounts = app.Session.Accounts;
            //  OutLook.Account acc = null;
            List<OutLook.Account> Accountlist = new List<Account>();
            //Look for our account in the Outlook
            foreach (OutLook.Account account in accounts)
            {
                Accountlist.Add(account);
            }
            return Accountlist;
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
         //   mailItem.SendUsingAccount = MailService.mailservicedb.getaccount(comboBox1.Text);
           // mailItem.HTMLBody = richEditControl1.HtmlText;
         //   this.Tag = mailItem;
            this.DialogResult = DialogResult.OK;
        }

        private void AddAttachment()
        {
            OpenFileDialog attachment = new OpenFileDialog();
            
            attachment.Title = "Select a file to send";
            attachment.ShowDialog();

            if (attachment.FileName.Length > 0)
            {
                mailItem.Attachments.Add(
                    attachment.FileName,
                    OutLook.OlAttachmentType.olByValue,
                    1,
                    attachment.FileName);
            }
         
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog attachment = new OpenFileDialog();
            attachment.Title = "Select a file to attach";
            DialogResult result = attachment.ShowDialog();
            if (result == DialogResult.OK)
            {
                ma = new mailattach { filename = attachment.SafeFileName, fullfilename = attachment.FileName };
                mailattachmentList.Add(ma);
                mailattachBindingSource.DataSource = mailattachmentList.ToList();
            }           
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
           
        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            ma = (mailattach)mailattachBindingSource.Current;
            if (ma != null)
            {
                mailattach rm = mailattachmentList.FirstOrDefault(r => r.filename == ma.filename);
                if (rm != null)
                {
                    mailattachmentList.Remove(rm);
                    mailattachBindingSource.DataSource = mailattachmentList.ToList();
                }
            }
        }
    }
}
