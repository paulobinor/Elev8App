using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Outlook;
using OutLook = Microsoft.Office.Interop.Outlook;

namespace Elev8App
{
    public partial class frmTrainingDetails : Form
    {
        public frmTrainingDetails()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Outlook.Application app;
        public trainingsession tsession = null;
        public traningsessionlineitem tlineitem = null;
     //   public elev8dbEntities context = null;
        private Folder customFolder;
        OutLook.MailItem myMailItem = null;
        List<mailattach> mailattachmentList = null;
        string trainingsessionid = string.Empty;
        private void frmTrainingDetails_Load(object sender, EventArgs e)
        {
            app = new Microsoft.Office.Interop.Outlook.Application();

          // this.Tag.ToString();
            tsession = (trainingsession)this.Tag; // TrainingSessionService.trainingsessiondb.GetTrainingSession(trainingsessionid);

            if (tsession != null)
            {
                trainingsessionBindingSource.DataSource = tsession;
                traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();
                trainingsessionid = tsession.trainingsessionid;
            }
            trainingsessionid = tsession.trainingsessionid;
            Cursor.Current = Cursors.Default;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void hyperlinkLabelControl1_Click(object sender, EventArgs e)
        {
            
        }
        
       
        private void repositoryItemButtonSendMail_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            traningsessionlineitem tlineitem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;
            if (tlineitem != null)
            {
                openFileDialog1.Filter = "Rich Text Format (*.rtf)|*.rtf";
                openFileDialog1.Title = "Select a File";
                openFileDialog1.FileName = string.Empty;
                openFileDialog1.Multiselect = false;
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                  richEditControl1.LoadDocument(openFileDialog1.FileName);
                   myMailItem = app.CreateItem(OlItemType.olMailItem); //.Session.OpenSharedItem(openFileDialog1.FileName);
                  
                    myMailItem.Subject = $"Courseware for the { tsession.coursename } Training!";
                    myMailItem.To = tlineitem.email;
                   
                    myMailItem.HTMLBody = MailService.mailservicedb.CreateMailBody(tlineitem.fullname, tlineitem.moc, tlineitem.lab, tlineitem.azpass, tlineitem.examvoucher, tsession.coursename, richEditControl1.HtmlText, TrainingSessionService.trainingsessiondb.GetCourseLink(tsession));
                    myMailItem.Importance = OutLook.OlImportance.olImportanceNormal;
                    myMailItem.Display(false);

                    //string foldername = tsession.coursecode + " (" + tsession.startdate.Value.Day.ToString("d") + " - " + tsession.startdate.Value.ToString("d MMM") + " " + tsession.startdate.Value.ToString("yyyy") + ")";
                }
            }
        }

            

        private async void repositoryItemButtonCertificate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            traningsessionlineitem tlineitem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;
            saveFileDialog1.FileName = tlineitem.fullname;
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                //dsCertificate dscert = new dsCertificate();
                //PopulateDataSet(dscert);
                //XtraReport1 report = new XtraReport1();
                //report.DataSource = dscert.Report;
                //await report.ExportToPdfAsync(saveFileDialog1.FileName, null);
                await Task.Run(()=>  SaveCertificate(tlineitem.fullname, tsession.coursename, DateTime.Now.Date, tsession.trainer1.signature, saveFileDialog1.FileName));
            }
        }

        public async void SaveCertificate(string fullname, string coursename, DateTime date, byte[] signature, string filename)
        {
          //  DevExpress.XtraReports.UI.XtraReport report = new DevExpress.XtraReports.UI.XtraReport();
            dsCertificate dscert = new dsCertificate();
            dsCertificate.ReportRow cRow = dscert.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = date.ToString("MMM dd, yyyy");
            cRow.CourseName = coursename;
            cRow.FullName = fullname;
            if (signature != null)
            {
                cRow.signature = signature;
            }
            dscert.Report.AddReportRow(cRow);
          
            XtraReport1 report = new XtraReport1();
           // report.SaveLayout("C:\\Data\\xtrareport.repx");
            report.DataSource = dscert.Report;
            await report.ExportToPdfAsync(filename, null);
        }
        public void PopulateDataSet(dsCertificate dsi)
        {
            dsi.Clear();
            traningsessionlineitem currentItem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;

            dsCertificate.ReportRow cRow = dsi.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = DateTime.Today.Date.ToString("MMM dd, yyyy"); //tsession.endate.Value.ToString("MMM dd, yyyy");
            cRow.CourseName = tsession.coursename;
            cRow.FullName = currentItem.fullname;
            if (tsession.trainer1.signature != null)
            {
                cRow.signature = tsession.trainer1.signature;
            }
            dsi.Report.AddReportRow(cRow);
        }

        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            
            if (e.Button.Properties.Caption == "Add")
            {
                traningsessionlineitem tlineitem = new traningsessionlineitem();
                tlineitem.linitemid = System.Guid.NewGuid().ToString();
                tlineitem.trainingsessionid = tsession.trainingsessionid;
                frmAddEditLearner fraddLearner = new frmAddEditLearner();
                fraddLearner.StartPosition = FormStartPosition.CenterParent;
                fraddLearner.Tag = tlineitem;
                DialogResult result = fraddLearner.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(trainingsessionid);

                    if (tsession != null)
                    {
                        trainingsessionBindingSource.DataSource = tsession;
                        traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();

                    }
                    Cursor.Current = Cursors.Default;
                }
                
            }
            if (e.Button.Properties.Caption == "Import")
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ReadCsvFile(openFileDialog1.FileName);
                }                
            }
        }
        private async void ReadCsvFile(string filename)
        {
            TextReader textReader = File.OpenText(filename);
            var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);

            var learners = csv.GetRecords<learner>();
            traningsessionlineitem tlineitem = null;
            foreach (var learner in learners)
            {
                tlineitem = new traningsessionlineitem();
                tlineitem.linitemid = System.Guid.NewGuid().ToString();
                tlineitem.trainingsessionid = tsession.trainingsessionid;
                tlineitem.azpass = learner.azurepass;
                tlineitem.email = learner.email;
                tlineitem.examvoucher = learner.examvoucher;
                tlineitem.fullname = learner.fullname;
                tlineitem.lab = learner.labkey;
                tlineitem.organization = learner.organization;
                tlineitem.moc = learner.moc;
                tlineitem.phone = learner.phone;
               await Task.Run(()=> TrainingSessionService.trainingsessiondb.AddNewLearner(tlineitem));
            }
            textReader.Close();
            tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(trainingsessionid);
            traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();
        }

       
        private void repositoryItemButtonEditLearner_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tlineitem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;
            frmAddEditLearner frmae = new frmAddEditLearner();
            frmae.Tag = tlineitem;
            DialogResult result = frmae.ShowDialog();

            if (result == DialogResult.No)
            {
                tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(trainingsessionid);

                if (tsession != null)
                {
                    trainingsessionBindingSource.DataSource = tsession;
                    traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();

                }
                Cursor.Current = Cursors.Default;
                tsession.traningsessionlineitems.Remove(tlineitem);
            }
            traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //tsession.coursewaremail = richEditControl1.Text;
            //context.SaveChanges();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private async void btnGenerateMail_Click(object sender, EventArgs e)
        {            
            bool exist = false;
            OutLook.Folder myinbox = (OutLook.Folder)app.ActiveExplorer().Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
            string userName = (string)app.ActiveExplorer().Session.CurrentUser.Name;
            string foldername = TrainingSessionService.trainingsessiondb.GetFolderName(tsession.startdate.Value, tsession.endate.Value, tsession.coursecode);

            foreach (OutLook.Folder item1 in myinbox.Folders)
            {       
                if (item1.Name == foldername)
                {
                    exist = true;
                    break;
                }
            }
            if (exist)
            {
                customFolder = (OutLook.Folder)myinbox.Folders[foldername];
            }
            else
            {
                customFolder = (OutLook.Folder)myinbox.Folders.Add(foldername, OutLook.OlDefaultFolders.olFolderInbox);
            }

            foreach (traningsessionlineitem item in tsession.traningsessionlineitems)
            {
             await Task.Run(()=>  Createmail(item, customFolder));               
            }
        }

        private void Createmail(traningsessionlineitem item, Folder customFolder)
        {
            myMailItem = (MailItem)app.CreateItem(OutLook.OlItemType.olMailItem);
            myMailItem.Subject = "Courseware for the " + tsession.coursename + " Training!";
            myMailItem.To = item.email;

            myMailItem.HTMLBody = richEditControl1.HtmlText
                .Replace("[moc]", item.moc)
                .Replace("[coursename]", "<b>" + tsession.coursename + "</b>")
                .Replace("[lab]", item.lab)
                .Replace("[azurepass]", item.azpass)
                .Replace("[fullname]", item.fullname)
                .Replace("[courselink]", TrainingSessionService.trainingsessiondb.GetCourseLink(tsession));

            myMailItem.Importance = OutLook.OlImportance.olImportanceNormal;

            if (mailattachmentList != null && mailattachmentList.Count > 0)
            {
                int index = 1;
                foreach (mailattach item1 in mailattachmentList)
                {
                    myMailItem.Attachments.Add(item1.fullfilename, OutLook.OlAttachmentType.olByValue, index, item1.filename);
                    index++;
                }
            }
            //  myMailItem.SaveSentMessageFolder = customFolder;
            myMailItem.Move(customFolder);
        }

        private async void xtraTabControl1_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            app = new Microsoft.Office.Interop.Outlook.Application();
            OutLook.MailItem myMailItem = null;
            folderBrowserDialog1.Description = "Select folder to save certificates";
            XtraReport1 report = new XtraReport1();
            DialogResult result = folderBrowserDialog1.ShowDialog();


            if (result == DialogResult.OK)
            {
                bool exist = false;
                OutLook.Folder myinbox = (OutLook.Folder)app.ActiveExplorer().Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
               

               // string userName = (string)app.ActiveExplorer().Session.CurrentUser.Name;
                string foldername = TrainingSessionService.trainingsessiondb.GetFolderName(tsession.startdate.Value, tsession.endate.Value, tsession.coursecode);

                foreach (OutLook.Folder item1 in myinbox.Folders)
                {
                    if (item1.Name == foldername)
                    {
                        exist = true;
                        break;
                    }
                }
                if (exist)
                {
                    customFolder = (OutLook.Folder)myinbox.Folders[foldername];
                }
                else
                {
                    customFolder = (OutLook.Folder)myinbox.Folders.Add(foldername, OutLook.OlDefaultFolders.olFolderInbox);
                }
                foreach (traningsessionlineitem item in tsession.traningsessionlineitems)
                {
                    //string mystring = "This is an example: {myMailItem.Subject}";
                    myMailItem = (OutLook.MailItem)app.CreateItem(OutLook.OlItemType.olMailItem);
                    myMailItem.Subject = $"Certificate of Attendance for the { tsession.coursename } Training";
                    myMailItem.To = item.email;
                    myMailItem.Importance = OutLook.OlImportance.olImportanceNormal;
                    myMailItem.HTMLBody = $"<p>Dear {item.fullname},</p> <p>Congratulations on your successful participation and completion of the {tsession.coursename} training with Elev8. We treasure your participation immensely  and are greatly honored you gave use the opportunity to deliver.</p> Attached here is your certificate of participation from Elev8 :) We hope your experience with elev8 was impactful and rewarding.</p>" +
                        $"<p>Going forward we hope the new knowledge and skill(s) you have acquired will enable you excel in your current and future professional endeavor. We look forward to seeing you next time, when we will put extra effort into making our next training even more useful and exciting.</p>" +
                        $"<p>Warm regards</p>";

                    //create certificate
                    await Task.Run(() => ExportCertificate(tsession.coursename, item.fullname, tsession.trainer1.signature, folderBrowserDialog1.SelectedPath + "\\" + item.fullname + ".pdf"));
                    myMailItem.Attachments.Add(folderBrowserDialog1.SelectedPath + "\\" + item.fullname + ".pdf", OutLook.OlAttachmentType.olByValue, 1, item.fullname);
                    myMailItem.Move(customFolder);
                  
                }
            }
        }

        private void ExportCertificate(string coursename, string studentname, byte[] trainersignature, string filename) 
        {
          
            dsCertificate dscert = new dsCertificate();
            XtraReport1 report = new XtraReport1();
            dsCertificate.ReportRow cRow = dscert.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = DateTime.Today.Date.ToString("MMM dd, yyyy"); //tsession.endate.Value.ToString("MMM dd, yyyy");
            cRow.CourseName = coursename;
            cRow.FullName = studentname;
            if (tsession.trainer1.signature != null)
            {
                cRow.signature = trainersignature;
            }
            dscert.Report.AddReportRow(cRow);
            report.DataSource = dscert.Report;
            report.ExportToPdf(filename, null);
           
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonPreviewCertificate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            dsCertificate dscert = new dsCertificate();
            PopulateDataSet(dscert);
            XtraReport1 report = new XtraReport1();
            report.DataSource = dscert.Report;
            Form frmReport = new Form2();
            frmReport.Tag = report;
            frmReport.StartPosition = FormStartPosition.CenterScreen;
         //   frmReport.ShowInTaskbar = false;
            frmReport.Show();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSelectAccount sa = new frmSelectAccount();
            sa.StartPosition = FormStartPosition.CenterParent;
            sa.ShowInTaskbar = false;
            if (mailattachmentList == null)
            {
                mailattachmentList = new List<mailattach>();
            }
            sa.Tag = mailattachmentList;
            DialogResult result = sa.ShowDialog();
            if (result == DialogResult.OK)
            {
                e.Item.Caption = mailattachmentList.Count.ToString();
            }
        }
    }
}
