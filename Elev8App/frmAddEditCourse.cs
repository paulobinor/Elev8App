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
    public partial class frmAddEditCourse : Form
    {
        public frmAddEditCourse()
        {
            InitializeComponent();
        }

       // elev8dbEntities context = null;
        course mycourse = null;
        private void frmAddEditCourse_Load(object sender, EventArgs e)
        {
            mycourse = (course)this.Tag;
            courseBindingSource.DataSource = mycourse;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            mycourse.coursename = coursenameTextBox.Text;
            mycourse.coursecode = coursecodeTextBox.Text;

            this.DialogResult = DialogResult.OK;
        }
    }
}
