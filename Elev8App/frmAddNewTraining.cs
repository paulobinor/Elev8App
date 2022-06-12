using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elev8App
{
    public partial class frmAddNewTraining : Form
    {
        public frmAddNewTraining()
        {
            InitializeComponent();
        }

        public trainingsession tsession = null;
        public List<course> courseList = null;
        public trainer trainer1 = null;
        private void frmAddNewTraining_Load(object sender, EventArgs e)
        {
            tsession = (trainingsession)this.Tag;
            trainingsessionBindingSource.DataSource = tsession;
            courseList = TrainingSessionService.trainingsessiondb.GetCourseList();
            courseBindingSource.DataSource =  courseList;
            trainerBindingSource.DataSource = TrainingSessionService.trainingsessiondb.GetTrainersList();

            if (tsession.coursecode != null)
            {
                courseComboBox.SelectedValue = tsession.coursecode;
            }

            if (tsession.trainerid != null)
            {
                comboBoxTrainer.SelectedValue = tsession.trainerid;
            }
        }

        private void trainerBindingSource_CurrentChanged(object sender, EventArgs e)
        {
             
        }

        private void courseBindingSource_CurrentChanged(object sender, EventArgs e)
        {
          //  course crs = ((course)courseBindingSource.Current);
           //tsession.coursecode = crs.coursecode;
            //tsession.coursename = crs.coursename;
          //  durationTextBox.Text = crs.duration.ToString();
            //trainingsessionBindingSource.DataSource = tsession;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tsession.expm = expmTextBox.Text;
            tsession.courselink = courselinkTextBox.Text;
            tsession.duration = durationTextBox.Text;

            tsession.coursecode = ((course)courseBindingSource.Current).coursecode;
            tsession.coursename = ((course)courseBindingSource.Current).coursename;
            
            tsession.trainer = ((trainer)(trainerBindingSource.Current)).fullname;
            tsession.trainerid = ((trainer)trainerBindingSource.Current).trainerid;

            tsession.startdate = startdateDateTimePicker.Value.Date;
            tsession.endate = endateDateTimePicker.Value.Date;

            tsession.startime = startdateDateTimePicker.Value;
            tsession.endtime = endateDateTimePicker.Value;

          //  tsession.teastart = teastartDateTimePicker.Value;
         //   tsession.teaend = teaendDateTimePicker.Value;

         //   tsession.lunchend = lunchendDateTimePicker.Value;
         //   tsession.lunchstart = lunchstartDateTimePicker.Value;

            this.DialogResult = DialogResult.OK;            
        }

        private void teastartDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
           
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void startimeDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
           endtimeDateTimePicker.Value = startimeDateTimePicker.Value.AddHours(8);
           // tsession.endtime = tsession.startime.Value.AddHours(7);
            
            teastartDateTimePicker.Value = startimeDateTimePicker.Value.AddHours(1).AddMinutes(30);
            teaendDateTimePicker.Value = teastartDateTimePicker.Value.AddMinutes(30);
            
            lunchstartDateTimePicker.Value = teaendDateTimePicker.Value.AddHours(2);
            lunchendDateTimePicker.Value = lunchstartDateTimePicker.Value.AddHours(1);
        }

        private void startdateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (durationTextBox.Text != string.Empty)
            {
                endateDateTimePicker.Value = startdateDateTimePicker.Value.Date.AddDays(Int32.Parse(durationTextBox.Text) - 1);
            }
        }

        private void courseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
