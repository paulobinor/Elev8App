﻿using System;
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
using CsvHelper;
using Microsoft.Office.Interop.Outlook;
using OutLook = Microsoft.Office.Interop.Outlook;
namespace Elev8App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Microsoft.Office.Interop.Outlook.Application app;
      //  public elev8dbEntities context = null;
        public trainingsession tsession = null;
        public ICollection<trainingsession> trainingSessionList = null;
        public IEnumerable<trainer> trainerList = null;
        public IEnumerable<course> courseList = null;
        public course mycourse = null;
        public trainer trainer = null;
        private async void Form1_Load(object sender, EventArgs e)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            frmDateTimePicker1.Value = firstDayOfMonth;
            toDateTimePicker2.Value = lastDayOfMonth;

            trainingSessionList = await Task.Run(() => TrainingSessionService.trainingsessiondb.GetTrainingList(frmDateTimePicker1.Value.Date, toDateTimePicker2.Value.Date).ToList());
             
            trainingsessionBindingSource.DataSource = trainingSessionList;
        }
        private void CreateMailItem()
        {
            app = new Microsoft.Office.Interop.Outlook.Application();

            OutLook.MailItem mailItem = (OutLook.MailItem)app.CreateItem(OutLook.OlItemType.olMailItem);
            mailItem.Subject = "This is the subject";
            mailItem.To = "someone@example.com";
            mailItem.HTMLBody = "This is the message.";
            mailItem.Importance = OutLook.OlImportance.olImportanceLow;
            mailItem.Display(false);
            mailItem.SendUsingAccount = MailService.mailservicedb.getaccount("");
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string trainsessionid = ((trainingsession)trainingsessionBindingSource.Current).trainingsessionid;
            tsession = TrainingSessionService.trainingsessiondb.GetTrainingSession(trainsessionid); 
            //trainingsessionBindingSource.Current;

            Form frmTrainingDetails = new frmTrainingDetails(tsession);
            frmTrainingDetails.Text = TrainingSessionService.trainingsessiondb.GetCourseShortCode(tsession).Replace("<sup>", "").Replace("</sup>", "");
            bool IsOpen = false;
            
            foreach (Form f in System.Windows.Forms.Application.OpenForms)
            {
                if (f.Text == frmTrainingDetails.Text)
                {
                    IsOpen = true;
                    frmTrainingDetails.Dispose();
                    f.Focus();
                    break;
                }
            }
            
            if (IsOpen == false)
            {
              //  frmTrainingDetails.Tag = tsession;
              //  frmTrainingDetails.MdiParent = this;
                frmTrainingDetails.Show();
            }
        }

        private async void groupControl1_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Add Training")
            {
                tsession = new trainingsession();
                tsession.trainingsessionid = System.Guid.NewGuid().ToString();

                frmAddNewTraining frmAddTraining = new frmAddNewTraining(tsession);
                frmAddTraining.StartPosition = FormStartPosition.CenterScreen;
                DialogResult result = frmAddTraining.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TrainingSessionService.trainingsessiondb.AddNewTrainingSession(tsession);
                    //context = new elev8dbEntities();
                    //context.trainingsessions.Add(tsession);
                    //context.SaveChanges();
                    //context = new elev8dbEntities();
                    trainingSessionList = await Task.Run(() => TrainingSessionService.trainingsessiondb.GetTrainingList(frmDateTimePicker1.Value.Date, toDateTimePicker2.Value.Date).ToList());

                    trainingsessionBindingSource.DataSource = trainingSessionList;
                }
            }
            if (e.Button.Properties.Caption == "Import")
            {
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    ReadTrainingCsvFile(openFileDialog1.FileName);
                }
            }
        }

        private async void ReadTrainingCsvFile(string filename)
        {
            TextReader textReader = File.OpenText(filename);
            var csv = new CsvReader(textReader, CultureInfo.InvariantCulture);

            List<csvtraining> trainings = csv.GetRecords<csvtraining>().ToList();
          //  var trainings1 = csv.GetRecords<csvtraining>();
            List<trainingsession> trainingsessionlist = new List<trainingsession>();
            List<trainingsession> trainingsessionlist1 = new List<trainingsession>();

            traningsessionlineitem tlineitem = null;
            trainingsession csvtsession = null;
          //  string iteration = "new";
            DateTime startdate = DateTime.Now.Date;
            DateTime endate = DateTime.Now.Date;

            string coursecode = string.Empty;

            foreach (var training in trainings)
            {
                csvtsession = new trainingsession();
                csvtsession.trainingsessionid = System.Guid.NewGuid().ToString();
                csvtsession.coursename = training.coursename;
                csvtsession.coursecode = training.coursecode;
                csvtsession.startdate = training.startdate;
                csvtsession.endate = Convert.ToDateTime(training.endate);
                csvtsession.trainer =  training.trainer;
                trainingsessionlist.Add(csvtsession);
            }

            //Filter the list to get single instance of training session
            foreach (trainingsession item in trainingsessionlist)
            {

                int count = trainingsessionlist1.FindAll(i => i.coursecode == item.coursecode && i.endate.Value == item.endate.Value && i.startdate.Value == item.startdate.Value).Count;
                if (count == 0)
                {
                    trainingsession ts0 = new trainingsession();
                    ts0.trainingsessionid = System.Guid.NewGuid().ToString();
                    ts0.coursename = item.coursename;
                    ts0.coursecode = item.coursecode;
                    ts0.startdate = item.startdate;
                    ts0.endate = item.endate;
                    ts0.trainer = item.trainer;
                    trainingsessionlist1.Add(ts0);
                }
            }

            foreach (var item in trainingsessionlist1)
            {
                trainingsession ts1 = new trainingsession();
                ts1.coursecode = item.coursecode;
                ts1.coursename = item.coursename;
                ts1.endate = item.endate;
                ts1.expm = item.expm;
                ts1.startdate = item.startdate;
                ts1.trainer = item.trainer;
                ts1.trainingsessionid = System.Guid.NewGuid().ToString();
                foreach (var ts2 in trainings)
                {
                    DateTime startdate1 = Convert.ToDateTime(ts2.startdate);
                    DateTime endate1 = Convert.ToDateTime(ts2.endate);
                    if (ts1.coursecode == ts2.coursecode && ts1.startdate.Value.Date == startdate1.Date && ts1.endate.Value.Date == endate1.Date)
                    {
                        tlineitem = new traningsessionlineitem();
                        tlineitem.linitemid = System.Guid.NewGuid().ToString();
                        tlineitem.trainingsessionid = ts1.trainingsessionid;
                        tlineitem.azpass = ts2.azurepass;
                        tlineitem.email = ts2.email;
                        tlineitem.examvoucher = ts2.examvoucher;
                        tlineitem.fullname = ts2.firstname + " " + ts2.lastname + " " + ts2.othernames;
                        tlineitem.lab = ts2.labkey;
                        tlineitem.organization = ts2.organization;
                        tlineitem.moc = ts2.moc;
                        tlineitem.phone = ts2.phone;
                        ts1.traningsessionlineitems.Add(tlineitem);
                    }
                }
               await Task.Run(()=>TrainingSessionService.trainingsessiondb.AddNewTrainingSession(ts1));
            }
            textReader.Close();
           // context.SaveChanges();
            trainingSessionList = await Task.Run(() => TrainingSessionService.trainingsessiondb.GetTrainingList());

            trainingsessionBindingSource.DataSource = trainingSessionList;

        }
        private void repositoryItemButtonEditSession_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            tsession = (trainingsession)trainingsessionBindingSource.Current;
            frmAddNewTraining editTsession = new frmAddNewTraining(tsession);
            editTsession.Text = "Edit " + tsession.coursecode;
            editTsession.StartPosition = FormStartPosition.CenterScreen;
          //  editTsession.Tag = tsession;
            DialogResult result = editTsession.ShowDialog();
            if (result == DialogResult.OK)
            {
                TrainingSessionService.trainingsessiondb.Updatetrainingsession(tsession);
                trainingSessionList =  TrainingSessionService.trainingsessiondb.GetTrainingList(frmDateTimePicker1.Value.Date, toDateTimePicker2.Value.Date);
                trainingsessionBindingSource.DataSource = trainingSessionList;
            }
        }

        private void repositoryItemButtonEditCourse_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            mycourse = (course)courseBindingSource.Current;
            frmAddEditCourse frmeditCourse = new frmAddEditCourse(mycourse);
           // frmeditCourse.Tag = mycourse;
            frmeditCourse.Text = "Edit Course";
            DialogResult result = frmeditCourse.ShowDialog();
            if (result == DialogResult.OK)
            {
                TrainingSessionService.trainingsessiondb.UpdateCourse(mycourse);// context.SaveChanges();
                courseBindingSource.ResetBindings(true);
                courseBindingSource.DataSource = TrainingSessionService.trainingsessiondb.GetCourseList();
                //context.courses.ToList();
            }
        }

        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            mycourse = new course();
            mycourse.courseid = System.Guid.NewGuid().ToString();
            frmAddEditCourse frmeditCourse = new frmAddEditCourse(mycourse);
          //  frmeditCourse.Tag = mycourse;
            frmeditCourse.Text = "Add New Course";
            DialogResult result = frmeditCourse.ShowDialog();
            if (result == DialogResult.OK)
            {
                TrainingSessionService.trainingsessiondb.AddNewCourse(mycourse);
               // context.SaveChanges();
                courseBindingSource.ResetBindings(true);
               // context = new elev8dbEntities();
                courseBindingSource.DataSource = TrainingSessionService.trainingsessiondb.GetCourseList();
            }
        }

        private void groupControl3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            trainer trn = new trainer();
            trn.trainerid = System.Guid.NewGuid().ToString();
            frmAddEditTrainer frmtrainer = new frmAddEditTrainer();
            frmtrainer.Tag = trn;
            frmtrainer.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = frmtrainer.ShowDialog();
            if (result == DialogResult.OK)
            {
                TrainingSessionService.trainingsessiondb.AddNewTrainer(trn);
                //context.SaveChanges();
               // context = new elev8dbEntities();
                trainerBindingSource.DataSource = TrainingSessionService.trainingsessiondb.GetTrainersList();
            }
        }

        private void gridControl3_Click(object sender, EventArgs e)
        {

        }

        private void repositoryItemButtonEdit2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            trainer = (trainer)trainerBindingSource.Current;
            frmAddEditTrainer frmEditrainer = new frmAddEditTrainer();
            frmEditrainer.Tag = trainer;
            frmEditrainer.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = frmEditrainer.ShowDialog();
            if (result == DialogResult.OK)
            {
                TrainingSessionService.trainingsessiondb.UpdateTrainer(trainer);
                //context.SaveChanges();
                //  context = new elev8dbEntities();
                trainerBindingSource.DataSource = TrainingSessionService.trainingsessiondb.GetTrainersList();
            }
        }

        private void groupControl4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Add New")
            {

            }
            else
            {

            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
           // e.Page.Focus();
        }

        private async void xtraTabPage4_Enter(object sender, EventArgs e)
        {
            if (trainerList == null)
            {
                trainerList = await TrainingSessionService.trainingsessiondb.GetTrainersList();
                trainerBindingSource.DataSource = trainerList.ToList();
            }
        }

        private  void xtraTabPage1_Enter(object sender, EventArgs e)
        {
           
        }

        private async void xtraTabPage2_Enter(object sender, EventArgs e)
        {
            if (courseList == null)
            {
                   courseList = await TrainingSessionService.trainingsessiondb.GetCourseList(); 
                 courseBindingSource.DataSource = courseList.OrderBy(c => c.coursename).ToList();
            }
        }

        private void gridControl2_Load(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void simpleButton1_Click(object sender, EventArgs e)
        {
            trainingSessionList = await Task.Run(() => TrainingSessionService.trainingsessiondb.GetTrainingList(frmDateTimePicker1.Value, toDateTimePicker2.Value).ToList());
            trainingsessionBindingSource.DataSource = trainingSessionList;
        }
    }
}
