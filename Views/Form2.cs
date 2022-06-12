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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

      //  Elev8DB.elev8dbEntities context = null;
        private void Form2_Load(object sender, EventArgs e)
        {

            DevExpress.XtraReports.UI.XtraReport xr = (DevExpress.XtraReports.UI.XtraReport)this.Tag;
            documentViewer1.DocumentSource = xr;
            xr.CreateDocument(true);
            
            //trainingsessionBindingSource.DataSource = context.trainingsessions.ToList();
        }
    }
}
