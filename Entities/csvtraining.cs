using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elev8App
{
    class csvtraining
    {
        public string coursename { get; set; }

        public string coursecode { get; set; }

        public string trainer { get; set; }

        public string duration { get; set; }
        public string expm { get; set; }

        private DateTime _startdate;
        public DateTime startdate
        {
            get => _startdate; set
            {
                startdate = Convert.ToDateTime(value);
            }
        }
        public string endate { get; set; }

        public string fullname { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string othernames { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string organization { get; set; }
        public string moc { get; set; }
        public string labkey { get; set; }
        public string azurepass { get; set; }
        public string examvoucher { get; set; }
        public string certno { get; set; }
    }
}
