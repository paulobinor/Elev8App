using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Outlook;
using System.Threading.Tasks;
using OutLook = Microsoft.Office.Interop.Outlook;
using DevExpress.XtraReports.UI;

namespace Elev8App.MailService
{

    public static class mailservicedb
    {
        //Microsoft.Office.Interop.Outlook.Application app;
        public static void CreateMailItem()
        {
            Application app = new Application();

            OutLook.MailItem mailItem = (OutLook.MailItem)app.CreateItem(OutLook.OlItemType.olMailItem);
            mailItem.Subject = "This is the subject";
            mailItem.To = "someone@example.com";
            mailItem.HTMLBody = "This is the message.";
            mailItem.Importance = OutLook.OlImportance.olImportanceLow;
            mailItem.Display(false);
            mailItem.SendUsingAccount = MailService.mailservicedb.getaccount("");
        }
        public static void sendMail(string mail)
        { 

            //do something
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

        private static MAPIFolder GetFolder(string folderPath, Folders folders)
        {
            string dir = folderPath.Substring(0, folderPath.Substring(4).IndexOf("\\") + 4);
            try
            {
                foreach (MAPIFolder mf in folders)
                {
                    if (!(mf.FullFolderPath.StartsWith(dir))) continue;
                    if (mf.FullFolderPath == folderPath) return mf;
                    else
                    {
                        MAPIFolder temp = GetFolder(folderPath, mf.Folders);
                        if (temp != null)
                            return temp;
                    }
                }
                return null;
            }
            catch { return null; }
        }

        public static string CreateMailBody(string fullname, string moc, string labkey, string azpass, string examvoucher, string coursename, string htmlbody, string courselink, string exam, string phone) 
        {
             htmlbody = htmlbody
                    .Replace("[moc]", moc)
                    .Replace("[coursename]", "<b>" + coursename + "</b>")
                    .Replace("[lab]", labkey)
                    .Replace("[azurepass]", azpass)
                    .Replace("[examvoucher]", exam)
                    .Replace("[fullname]", fullname)
                    .Replace("[phone]", phone)
                    .Replace("[courselink]", coursename);

            return htmlbody;
        }

        public static string CreateMailBody(string fullname, string moc, string labkey, string azpass, string examvoucher, string coursename)
        {
            string mailbody = string.Empty;
             mailbody += "<p>Dear " + fullname.Trim() + ",</p>" +
                "<p>We would like to warmly welcome you to the <b> " + coursename + " </b> training!</p> " +
                "<p>I have included below, information and resources about the course for you to get started with.</p>";



            if (moc.Trim() != string.Empty)
            {
                mailbody += "<p><b><u>Your MOC code</u></b><br>" +
                    "Your MOCs can be claimed on <a href='www.skillpipe.com'>Skillpipe</a> to access your learning materials.<br>" +
                    "<b> MOC Code: </b>" + moc + "</p>";
            }
            if (labkey.Trim() != string.Empty)
            {
                mailbody += "<p><b><u>Your LAB-KEY</u></b><br>" +
                    "Your training key will be used to claim your labs on <a href='https://alh.learnondemand.net/'>LearnOnDemand</a><br>" +
                    "<b>LABKEY</b>:" + labkey + "</p>";
            }

            if (azpass.Trim() != string.Empty)
            {
                mailbody += "<p><b><u>Your Azure Pass</u></b><br>" +
                    "<b> Activation Code: " + azpass + "</b><br><br>" +
                    "Please note that the Azure pass can only be redeemed once. If you are not sure about how to redeem your Azure pass, We advise that you wait to redeem it during the training where you can get a live demonstration.</p>" +
                    "<p>However, you can find the steps below:</p>" +
                    "<p> It is recommended that you use your <span style='color:red;font-size:18px;'><i>personal email</i></span> to sign up for this process.</p>" +
                    "<ol>" +
                        "<li>On your edge browser, please activate <span style='color:red;'>In-private window.</span></li>" +
                        "<li>Navigate to <a href = 'www.microsoftazurepass.com'>Microsoft Azure Pass</a></li>" +
                        "<span style='color:red;'><li>Make sure you are signed out of the portal ( top right corner)</li></span>" +
                        "<li>Click on start</li>" +
                        "<li>User another account and sign in with your Hotmail or outlook email ( or create new if you don’t have already)—please save login details<span style='color:red;'> (preferably a personal email)</span></li>" +
                        "<li>Click on Confirm Microsoft Account button</li>" +
                        "<li>Enter the Code</li>" +
                        "<li>After successful validation, you will be taken to Portal.Azure.com when you can practice all the concept being taught</li>" +
                    "</ol>";
            }

            //mailItemi.HTMLBody = mailItemi.HTMLBody +
            //    "<p>Teams Link:&nbsp;<b><a href = '" + tsession.courselink + "'>Click here to join the " + GetCourseLink(tsession) + "</a></b> " +
            //    "<br><p>If you have any questions or need some guidance, please contact me.</p>" +
            //    "<address>Paul Obinor<br> " +
            //    "Experience Manager <br>" +
            //    "paul.obinor@elev8me.com <br>" +
            //    "<b>WhatsApp</b>: +234 8102468636<br>" +
            //    "www.elev8me.com</address>";

            return mailbody;
        }
    
        public static void CreateMail(traningsessionlineitem tlineitem, MailItem mailItemi, trainingsession tsession)
        {
          //  MailItem mailItemi = OutLook.MailItem
            mailItemi.HTMLBody = "<p>Dear " + tlineitem.fullname.Trim() + ",</p>" +
                "<p>We would like to warmly welcome you to the <b> " + tsession.coursename + " </b> training!</p> " +
                "<p>I have included below, information and resources about the course for you to get started with.</p>";

            if (tlineitem.moc.Trim() != string.Empty)
            {
                mailItemi.HTMLBody = mailItemi.HTMLBody + "<p><b><u>Your MOC code</u></b><br>" +
                    "Your MOCs can be claimed on <a href='www.skillpipe.com'>Skillpipe</a> to access your learning materials.<br>" +
                    "<b> MOC Code: </b>" + tlineitem.moc + "</p>";
            }
            if (tlineitem.lab.Trim() != string.Empty)
            {
                mailItemi.HTMLBody = mailItemi.HTMLBody + "<p><b><u>Your LAB-KEY</u></b><br>" +
                    "Your training key will be used to claim your labs on <a href='https://alh.learnondemand.net/'>LearnOnDemand</a><br>" +
                    "<b>LABKEY</b>:" + tlineitem.lab + "</p>";
            }

            if (tlineitem.azpass.Trim() != string.Empty)
            {
                mailItemi.HTMLBody = mailItemi.HTMLBody + "<p><b><u>Your Azure Pass</u></b><br>" +
                    "<b> Activation Code: " + tlineitem.azpass + "</b><br><br>" +
                    "Please note that the Azure pass can only be redeemed once. If you are not sure about how to redeem your Azure pass, We advise that you wait to redeem it during the training where you can get a live demonstration.</p>" +
                    "<p>However, you can find the steps below:</p>" +
                    "<p> It is recommended that you use your <span style='color:red;font-size:18px;'><i>personal email</i></span> to sign up for this process.</p>" +
                    "<ol>" +
                        "<li>On your edge browser, please activate <span style='color:red;'>In-private window.</span></li>" +
                        "<li>Navigate to <a href = 'www.microsoftazurepass.com'>Microsoft Azure Pass</a></li>" +
                        "<span style='color:red;'><li>Make sure you are signed out of the portal ( top right corner)</li></span>" +
                        "<li>Click on start</li>" +
                        "<li>User another account and sign in with your Hotmail or outlook email ( or create new if you don’t have already)—please save login details<span style='color:red;'> (preferably a personal email)</span></li>" +
                        "<li>Click on Confirm Microsoft Account button</li>" +
                        "<li>Enter the Code</li>" +
                        "<li>After successful validation, you will be taken to Portal.Azure.com when you can practice all the concept being taught</li>" +
                    "</ol>";
            }
            //mailItemi.HTMLBody = mailItemi.HTMLBody +
            //    "<p>Teams Link:&nbsp;<b><a href = '" + tsession.courselink + "'>Click here to join the " + GetCourseLink(tsession) + "</a></b> " +
            //    "<br><p>If you have any questions or need some guidance, please contact me.</p>" +
            //    "<address>Paul Obinor<br> " +
            //    "Experience Manager <br>" +
            //    "paul.obinor@elev8me.com <br>" +
            //    "<b>WhatsApp</b>: +234 8102468636<br>" +
            //    "www.elev8me.com</address>";
            mailItemi.Importance = OutLook.OlImportance.olImportanceNormal;

            //OutLook.Folder myinbox = (OutLook.Folder)app.ActiveExplorer().Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);
            //string userName = (string)app.ActiveExplorer().Session.CurrentUser.Name;

            //bool exist = false;
            //foreach (OutLook.Folder item in myinbox.Folders)
            //{
            //    if (item.Name == folderName)
            //    {
            //        exist = true;
            //        break;
            //    }
            //}
            //if (exist)
            //{
            //    customFolder = (OutLook.Folder)myinbox.Folders[folderName];
            //}
            //else
            //{
            //    customFolder = (OutLook.Folder)myinbox.Folders.Add(folderName, OutLook.OlDefaultFolders.olFolderInbox);
            //}
            //mailItemi.Move(customFolder);

            mailItemi.Display(false);
        }
        public static Folder GetorCreateCourseSessionFolder(string foldername, string courseyear, string coursecode)
        {
            bool trainingfolderexist = false;
            bool coursefolderexist = false;
            bool courseyearfolderexist = false;
            bool coursesessionfolderexist = false;
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            OutLook.Folder myinbox = (OutLook.Folder)app.ActiveExplorer().Session.GetDefaultFolder(OutLook.OlDefaultFolders.olFolderInbox);

            Folder trainingsFolder = null;
            Folder courseyearfolder = null;
            Folder coursefolder = null;
            Folder coursesessionfolder = null;


            //  string userName = (string)app.ActiveExplorer().Session.CurrentUser.Name;
            //string coursesessionfoldername = TrainingSessionService.trainingsessiondb.GetFolderName(tsession.startdate.Value, tsession.endate.Value, tsession.coursecode);

            // OutLook.Folder customerfol = null;
            foreach (OutLook.Folder tfolder in myinbox.Parent.Folders)
            {

                if (tfolder.Name == "Trainings")
                {
                    trainingfolderexist = true;
                    trainingsFolder = tfolder;
                }
            }
            if (trainingfolderexist)
            {
                foreach (OutLook.Folder yfolder in trainingsFolder.Folders)
                {
                    if (yfolder.Name == courseyear)
                    {
                        courseyearfolder = yfolder;
                        courseyearfolderexist = true;
                        break;
                    }
                }
                if (courseyearfolderexist)
                {
                    foreach (OutLook.Folder cfolder in courseyearfolder.Folders)
                    {
                        if (cfolder.Name == coursecode)
                        {
                            coursefolder = cfolder;
                            coursefolderexist = true;
                            break;
                        }
                    }
                    if (coursefolderexist)
                    {
                        foreach (OutLook.Folder cfolder in coursefolder.Folders)
                        {
                            if (cfolder.Name == foldername)
                            {
                                coursesessionfolder = cfolder;
                                coursesessionfolderexist = true;
                                break;
                            }
                        }
                        if (!coursesessionfolderexist)
                        {
                            coursesessionfolder = (OutLook.Folder)coursefolder.Folders.Add(foldername, OutLook.OlDefaultFolders.olFolderInbox);
                        }
                    }
                    else
                    {
                        coursefolder = (OutLook.Folder)courseyearfolder.Folders.Add(coursecode, OutLook.OlDefaultFolders.olFolderInbox);

                        coursesessionfolder = (OutLook.Folder)coursefolder.Folders.Add(foldername, OutLook.OlDefaultFolders.olFolderInbox);
                    }

                }
                if (!courseyearfolderexist)
                {
                    courseyearfolder = (OutLook.Folder)trainingsFolder.Folders.Add(courseyear, OutLook.OlDefaultFolders.olFolderInbox);

                    coursefolder = (OutLook.Folder)courseyearfolder.Folders.Add(coursecode, OutLook.OlDefaultFolders.olFolderInbox);

                    coursesessionfolder = (OutLook.Folder)coursefolder.Folders.Add(foldername, OutLook.OlDefaultFolders.olFolderInbox);
                }
            }
            if (!trainingfolderexist)
            {
                trainingsFolder = (OutLook.Folder)myinbox.Parent.Folders.Add("Trainings", OutLook.OlDefaultFolders.olFolderInbox);

                courseyearfolder = (OutLook.Folder)trainingsFolder.Folders.Add(courseyear, OutLook.OlDefaultFolders.olFolderInbox);

                coursefolder = (OutLook.Folder)courseyearfolder.Folders.Add(coursecode, OutLook.OlDefaultFolders.olFolderInbox);

                coursesessionfolder = (OutLook.Folder)coursefolder.Folders.Add(foldername, OutLook.OlDefaultFolders.olFolderInbox);
            }

            return coursesessionfolder;
        }
        public static int GetLastCertNo()
        {
            //#00010020NG
            elev8dbEntites  context = new elev8dbEntites();
            return context.certinumbers.Max(i => i.certendnumber).Value;
        }
        public static string AssignCertNo(int i)
        {
            //#00010020NG
          //  elev8dbEntites context = new elev8dbEntites();
            string certno = string.Empty;

            if (i > 9)
            {
                certno = "#000100" + i.ToString() + "NG"; // 020NG

            }
            if (i > 99)
            {
                certno = "#00010" + i.ToString() + "NG"; // 020NG

            }
            if (i > 999)
            {
                certno = "#0001" + i.ToString() + "NG";
            }
            if (i > 9999)
            {
                certno = "#000" + i.ToString() + "NG";
            }
            if (i > 999999)
            {
                certno = "#00" + i.ToString() + "NG";
            }
            if (i > 9999999)
            {
                certno = "#0" + i.ToString() + "NG";
            }
            return certno;
        }
        public static void Createmail(traningsessionlineitem item, Folder customFolder, string coursename, string sender, string subject, string htmlbody, string courselink, List<Elev8App.mailattach> mailattachmentList)
        {
           // List<mailattach> mailattachmentList = null;
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            OutLook.MailItem myMailItem = (MailItem)app.CreateItem(OutLook.OlItemType.olMailItem);
            myMailItem.Subject = subject; // "Courseware for the " + coursename + " Training!";
            myMailItem.To = item.email;
            myMailItem.SendUsingAccount = MailService.mailservicedb.getaccount(sender);
            myMailItem.HTMLBody = htmlbody
                .Replace("[moc]", item.moc)
                .Replace("[coursename]", "<b>" + coursename + "</b>")
                .Replace("[lab]", item.lab)
                .Replace("[azurepass]", item.azpass)
                .Replace("[examvoucher]", item.examvoucher)
                .Replace("[fullname]", item.fullname)
                .Replace("[courselink]", courselink)
                .Replace("[customfiled]", "");

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

        internal static void ExportCertificate(string coursename, string studentname, byte[] trainersignature, string savefilename, XtraReport report, string courseschedule, DateTime issuedate, string certno)
        {
            dsCertificate dscert = new dsCertificate();
            DevExpress.XtraReports.UI.XtraReport _report = report;
            dsCertificate.ReportRow cRow = dscert.Report.NewReportRow();
            cRow.lineitemID = System.Guid.NewGuid().ToString();
            cRow.issueDate = DateTime.Today.Date.ToString("MMM dd, yyyy"); //tsession.endate.Value.ToString("MMM dd, yyyy");
            cRow.CourseName = coursename;
            cRow.serialNumber = certno;
            cRow.CourseSchedule = courseschedule;
            cRow.AwardDate = "Awarded on this day " + issuedate.ToString("dd MMMM, yyyy");
            cRow.FullName = studentname;
            cRow.signature = trainersignature;
            dscert.Report.AddReportRow(cRow);
            _report.DataSource = dscert.Report;
            _report.ExportToPdf(savefilename, null);
        }
    }
}
