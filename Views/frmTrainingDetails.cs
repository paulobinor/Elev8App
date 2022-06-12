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
        Microsoft.Office.Interop.Outlook.Application app;
         public trainingsession tsession;
        public traningsessionlineitem tlineitem = null;
        //   public elev8dbEntities context = null;
        OutLook.MailItem myMailItem = null;
        List<mailattach> mailattachmentList = null;
        //   string trainingsessionid = string.Empty;
        public frmTrainingDetails(trainingsession _tsession)
        {
            InitializeComponent();
            tsession = _tsession;
        }       

        private void frmTrainingDetails_Load(object sender, EventArgs e)
        {
            app = new Microsoft.Office.Interop.Outlook.Application();
            trainingsessionBindingSource.DataSource = tsession;
            traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();

            Cursor.Current = Cursors.Default;

            //OutLook.Accounts accounts = app.Session.Accounts;
            DevExpress.XtraBars.BarButtonItem bbItem;

            //Look for our account in the Outlook
            foreach (OutLook.Account account in app.Session.Accounts)
            {
                bbItem = new DevExpress.XtraBars.BarButtonItem();
                bbItem.Caption = account.SmtpAddress;
                bbItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
                //  bbItem.Id = 184;
                bbItem.ImageOptions.Image = global::Elev8App.Properties.Resources.mail_16x16;
                bbItem.ImageOptions.LargeImage = global::Elev8App.Properties.Resources.mail_32x32;
                bbItem.Name = account.SmtpAddress;
                this.popupMenu1.ItemLinks.Add(bbItem);
            }
            label1.Text = app.Session.Accounts[1].SmtpAddress;
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
                   
                    myMailItem.HTMLBody = MailService.mailservicedb.CreateMailBody(tlineitem.fullname, tlineitem.moc, tlineitem.lab, tlineitem.azpass, tlineitem.examvoucher, tsession.coursename, richEditControl1.HtmlText, TrainingSessionService.trainingsessiondb.GetCourseLink(tsession), tlineitem.examvoucher, tlineitem.phone);
                    myMailItem.Importance = OutLook.OlImportance.olImportanceNormal;
                    myMailItem.Display(false);

                    //string foldername = tsession.coursecode + " (" + tsession.startdate.Value.Day.ToString("d") + " - " + tsession.startdate.Value.ToString("d MMM") + " " + tsession.startdate.Value.ToString("yyyy") + ")";
                }
            }
        }

            

        private async void repositoryItemButtonCertificate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                traningsessionlineitem tlineitem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;
                saveFileDialog1.FileName = tlineitem.fullname;
                result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //dsCertificate dscert = new dsCertificate();
                    //PopulateDataSet(dscert);
                    //XtraReport1 report = new XtraReport1();
                    //report.DataSource = dscert.Report;
                    //await report.ExportToPdfAsync(saveFileDialog1.FileName, null);
                    await Task.Run(() => SaveCertificate(tlineitem.fullname, tsession.coursename, DateTime.Now.Date, tsession.trainer1.signature, saveFileDialog1.FileName,openFileDialog1.FileName));
                }
            }
        }

        public async void SaveCertificate(string fullname, string coursename, DateTime date, byte[] signature, string filename, string reportfilepath)
        {
            DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile(reportfilepath);
            dsCertificate dscert = new dsCertificate();
            dsCertificate.ReportRow cRow = dscert.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = date.ToString("MMM dd, yyyy");
            cRow.CourseSchedule = TrainingSessionService.trainingsessiondb.GetCourseSchedule(tsession);
            cRow.AwardDate = "Awarded on this day " + tsession.endate.Value.ToString("dd MMMM, yyyy");
            cRow.CourseName = coursename;
            cRow.FullName = fullname;

            if (signature != null)
            {
                cRow.signature = signature;
            }
            dscert.Report.AddReportRow(cRow);
            report.DataSource = dscert.Report;
            await report.ExportToPdfAsync(filename, null);
        }
        public void PopulateDataSet(dsCertificate dsi)
        {
            dsi.Clear();
            traningsessionlineitem currentItem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;

            dsCertificate.ReportRow cRow = dsi.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = tsession.endate.Value.ToString("MMM dd, yyyy");
            cRow.CourseSchedule = TrainingSessionService.trainingsessiondb.GetCourseSchedule(tsession);
            cRow.AwardDate = "Awarded on this day " + tsession.endate.Value.ToString("dd MMMM, yyyy");
            cRow.serialNumber =currentItem.certno;
            cRow.CourseName = tsession.coursename;
            cRow.FullName = currentItem.fullname;
            if (tsession.trainer1.signature != null)
            {
                cRow.signature = tsession.trainer1.signature;
            }
            dsi.Report.AddReportRow(cRow);
        }

        public DataSet BuildDataSet(DateTime issuedate, string coursename, string fullname, string schedule)
        {
            dsCertificate dsi = new dsCertificate();
            dsCertificate.ReportRow cRow = dsi.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = issuedate.ToString("MMM dd, yyyy");
            cRow.CourseSchedule = schedule;
            cRow.AwardDate = "Awarded on this day " + issuedate.ToString("dd MMMM, yyyy");
            cRow.CourseName = coursename;
            cRow.FullName = fullname;
            if (tsession.trainer1.signature != null)
            {
                cRow.signature = tsession.trainer1.signature;
            }
            dsi.Report.AddReportRow(cRow);
            return dsi;
        }


        private void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Add")
            {
                traningsessionlineitem tlineitem = new traningsessionlineitem();
                tlineitem.linitemid = System.Guid.NewGuid().ToString();
                tlineitem.trainingsessionid = tsession.trainingsessionid;
                frmAddEditLearner fraddLearner = new frmAddEditLearner(tlineitem);
                fraddLearner.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = fraddLearner.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int CertNo = MailService.mailservicedb.GetLastCertNo() + 1;
                    tlineitem.certno = MailService.mailservicedb.AssignCertNo(CertNo);

                    certinumber cn = new certinumber();
                    cn.certnumberid = System.Guid.NewGuid().ToString();
                    cn.certstartnumber = CertNo;
                    cn.certendnumber = cn.certstartnumber;
                    cn.trainingsessionid = tsession.trainingsessionid;

                    TrainingSessionService.trainingsessiondb.AddNewLearner(tlineitem, cn);
                    tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(tsession.trainingsessionid);
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
            TextReader textReader = null;
            List<traningsessionlineitem> LearnersList = new List<traningsessionlineitem>();
            try
            {
                textReader = File.OpenText(filename);
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
                    tlineitem.certno = MailService.mailservicedb.AssignCertNo(Convert.ToInt16(learner.certno));
                    LearnersList.Add(tlineitem);
                    // nextCertNoCount++;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (textReader != null)
                {
                    textReader.Close();
                }
            }
            
          //  int lastCertNo = MailService.mailservicedb.GetLastCertNo();
          //  int nextCertNoCount = lastCertNo + 1;
            



          //  certinumber cn = new certinumber();
          //  cn.certnumberid = System.Guid.NewGuid().ToString();
         //   cn.certstartnumber = lastCertNo + 1;
          //  cn.certendnumber = lastCertNo + LearnersList.Count();
          //  cn.trainingsessionid = tsession.trainingsessionid;

            await Task.Run(() => TrainingSessionService.trainingsessiondb.AddNewLearners(LearnersList));

            tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(tsession.trainingsessionid);
            traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();
        }

       
        private void repositoryItemButtonEditLearner_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tlineitem = (traningsessionlineitem)traningsessionlineitemBindingSource.Current;
            frmAddEditLearner frmae = new frmAddEditLearner(tlineitem);
            
            DialogResult result = frmae.ShowDialog();

            if (result == DialogResult.No)
            {
                Cursor.Current = Cursors.WaitCursor;
                TrainingSessionService.trainingsessiondb.RemoveLearner(tlineitem);
            }
            else
            {
                TrainingSessionService.trainingsessiondb.UpdateLearner(tlineitem);
            }

            tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(tsession.trainingsessionid);

            if (tsession != null)
            {
                trainingsessionBindingSource.DataSource = tsession;
                traningsessionlineitemBindingSource.DataSource = tsession.traningsessionlineitems.ToList();
            }
            Cursor.Current = Cursors.Default;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //tsession.coursewaremail = richEditControl1.Text;
            //context.SaveChanges();
        }

        private async void btnGenerateMail_Click(object sender, EventArgs e)
        {
           string foldername = TrainingSessionService.trainingsessiondb.GetFolderName(tsession.startdate.Value, tsession.endate.Value, tsession.coursecode);

            Folder coursesessionfolder = MailService.mailservicedb.GetorCreateCourseSessionFolder(foldername, tsession.endate.Value.Year.ToString(), tsession.coursecode);

            string courselink = TrainingSessionService.trainingsessiondb.GetCourseLink(tsession);

            foreach (traningsessionlineitem item in tsession.traningsessionlineitems)
            {
                await Task.Run(() => MailService.mailservicedb.Createmail(item, coursesessionfolder, tsession.coursename, label1.Text, txtsubject.Text, richEditControl1.HtmlText, tsession.courselink, mailattachmentList));
            }
            MessageBox.Show("Successfully created");
        }

        private void xtraTabControl1_CustomHeaderButtonClick(object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
        {
            DialogResult result;
            openFileDialog1.Title = "Please select the Report template";
            result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                app = new Microsoft.Office.Interop.Outlook.Application();
               
                folderBrowserDialog1.Description = "Select folder to save certificates";
                result = folderBrowserDialog1.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string foldername = TrainingSessionService.trainingsessiondb.GetFolderName(tsession.startdate.Value, tsession.endate.Value, tsession.coursecode);

                    Folder coursesessionfolder = MailService.mailservicedb.GetorCreateCourseSessionFolder(foldername, tsession.endate.Value.Year.ToString(), tsession.coursecode);
                    foreach (traningsessionlineitem item in tsession.traningsessionlineitems)
                    {
                        myMailItem = (OutLook.MailItem)app.CreateItem(OutLook.OlItemType.olMailItem);
                        myMailItem.Subject = $"Certificate of Attendance for the { tsession.coursename } Training";
                        myMailItem.To = item.email;
                        myMailItem.HTMLBody = $"<p>Dear {item.fullname},</p> <p>Congratulations on your completion of the training on <b><i>{tsession.coursename}</i></b>. " +
                            $"Attached here is your certificate. This is to certify that you have attended, in its entirety, the <b><i>{tsession.coursename}</i></b>. <br/>" +
                            $"We treasure your participation immensely and are deeply honored you gave the opportunity to deliver. To this end we hope your experience with elev8 was impactful and rewarding." +
                           $"<p>Going forward we hope the new knowledge and skill(s) you have acquired will enable you excel in your current and future professional endeavor. We look forward to seeing you next time, when we will put extra effort into making our next training even more useful and exciting.</p>" +
                           $"<p>Warm regards</p>";


                        //create certificate
                        //await Task.Run(() => ExportCertificate(tsession.coursename, item.fullname, tsession.trainer1.signature, folderBrowserDialog1.SelectedPath + "\\" + item.fullname + ".pdf", report, TrainingSessionService.trainingsessiondb.GetCourseSchedule(tsession), tsession.endate.Value, item.certno));
                        DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile(openFileDialog1.FileName);

                        MailService.mailservicedb.ExportCertificate(tsession.coursename, item.fullname, tsession.trainer1.signature, folderBrowserDialog1.SelectedPath + "\\" + item.fullname + ".pdf", report, TrainingSessionService.trainingsessiondb.GetCourseSchedule(tsession), tsession.endate.Value, item.certno);
                        myMailItem.Attachments.Add(folderBrowserDialog1.SelectedPath + "\\" + item.fullname + ".pdf", OutLook.OlAttachmentType.olByValue, myMailItem.Attachments.Count + 1, item.fullname);
                        myMailItem.SendUsingAccount = MailService.mailservicedb.getaccount(label1.Text);
                        myMailItem.Move(coursesessionfolder);
                        myMailItem.SaveSentMessageFolder = coursesessionfolder;
                    }
                }
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonPreviewCertificate_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult result;
            result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                dsCertificate dscert = new dsCertificate();
                PopulateDataSet(dscert);
                DevExpress.XtraReports.UI.XtraReport report = DevExpress.XtraReports.UI.XtraReport.FromFile(openFileDialog1.FileName);
                report.DataSource = dscert.Report;
                Form frmReport = new Form2();
                frmReport.Tag = report;
                frmReport.StartPosition = FormStartPosition.CenterScreen;
                frmReport.Show();
            }

            //save report
            //result = saveFileDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    dsCertificate dscert = new dsCertificate();
            //    PopulateDataSet(dscert);
            //    XtraReport1 report = new XtraReport1();
            //    report.DataSource = dscert.Report;
            //    // report.LoadLayout(openFileDialog1.FileName);
            //    Form frmReport = new Form2();
            //    report.CreateDocument();
            //    report.SaveLayout(saveFileDialog1.FileName);
            //    frmReport.Tag = report;
            //    frmReport.StartPosition = FormStartPosition.CenterScreen;
            //    //   frmReport.ShowInTaskbar = false;
            //    frmReport.Show();
            //}
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

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
          // label1.Text  = (sender as DevExpress.XtraEditors.DropDownButton).Tag.ToString();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            label1.Text = e.Item.Caption;
        }
    }
}
