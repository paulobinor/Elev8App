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
    public partial class frmAddEditLearner : Form
    {
        public frmAddEditLearner()
        {
            InitializeComponent();
        }

        public traningsessionlineitem tlineitem = null;
        private void azpassLabel_Click(object sender, EventArgs e)
        {

        }

        private void frmAddEditLearner_Load(object sender, EventArgs e)
        {
            if (this.Text == "Add Learner")
            {
                btndelete.Visible = false;
            }
            tlineitem = (traningsessionlineitem)this.Tag;
            traningsessionlineitemBindingSource.DataSource = tlineitem;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            tlineitem.azpass = azpassTextBox.Text;
            tlineitem.email = emailTextBox.Text;
            tlineitem.examvoucher = examvoucherTextBox.Text;
            tlineitem.fullname = fullnameTextBox.Text;
            tlineitem.lab = labTextBox.Text;
            tlineitem.moc = mocTextBox.Text;
            tlineitem.organization = organizationTextBox.Text;
            tlineitem.phone = phoneTextBox.Text;
            if (this.Text == "Add Learner" )
            {
                TrainingSessionService.trainingsessiondb.AddNewLearner(tlineitem);
                //TrainingSessionService.trainingsessiondb.AddNewLearner(azpassTextBox.Text, emailTextBox.Text, examvoucherTextBox.Text, fullnameTextBox.Text, labTextBox.Text, mocTextBox.Text, organizationTextBox.Text, phoneTextBox.Text);
            }
            else
            {
                TrainingSessionService.trainingsessiondb.UpdateLearner(tlineitem);
            }
            this.DialogResult = DialogResult.OK;

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            TrainingSessionService.trainingsessiondb.RemoveLearner(tlineitem);
            this.DialogResult = DialogResult.No;
        }
    }
}
