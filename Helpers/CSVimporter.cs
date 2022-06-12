using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elev8App.Helpers
{
    public class CSVimporter : Iimportable
    {
        public async void ImportData(string filename)
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
                csvtsession.trainer = training.trainer;
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
                await Task.Run(() => TrainingSessionService.trainingsessiondb.AddNewTrainingSession(ts1));
            }
            textReader.Close();
        }
    }
}
