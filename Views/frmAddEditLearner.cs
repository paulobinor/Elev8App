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
        public frmAddEditLearner(traningsessionlineitem tlineitem)
        {
            InitializeComponent();
            _tlineitem = tlineitem;
        }

        public traningsessionlineitem _tlineitem = null;
        private void azpassLabel_Click(object sender, EventArgs e)
        {

        }

        private void frmAddEditLearner_Load(object sender, EventArgs e)
        {
            if (this.Text == "Add Learner")
            {
                btndelete.Visible = false;
            }
            traningsessionlineitemBindingSource.DataSource = _tlineitem;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            _tlineitem.azpass = azpassTextBox.Text;
            _tlineitem.email = emailTextBox.Text;
            _tlineitem.examvoucher = examvoucherTextBox.Text;
            _tlineitem.fullname = fullnameTextBox.Text;
            _tlineitem.lab = labTextBox.Text;
            _tlineitem.moc = mocTextBox.Text;
            _tlineitem.organization = organizationTextBox.Text;
            _tlineitem.phone = phoneTextBox.Text;
            _tlineitem.certno = textBoxSerialNo.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
