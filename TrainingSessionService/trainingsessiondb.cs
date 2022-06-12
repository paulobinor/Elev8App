using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elev8App.TrainingSessionService
{
    public static class trainingsessiondb
    {
        public static elev8dbEntites context = null;
        public static async void Updatetrainingsession(trainingsession t)
        {
           trainingsession updateSession = context.trainingsessions.FirstOrDefault(tsession => tsession.trainingsessionid == t.trainingsessionid);
            if (updateSession != null)
            {
                context.Entry(t).State = System.Data.Entity.EntityState.Modified;

                //updateSession.trainingsessionid = System.Guid.NewGuid().ToString();
                //updateSession.trainer = t.trainer;
                //updateSession.trainerid = t.trainerid;

                //updateSession.coursename = t.coursename;
                //updateSession.courselink = t.courselink;
                //updateSession.coursecode = t.coursecode;
                //updateSession.duration = t.duration;

                //updateSession.startdate = t.startdate;
                //updateSession.endate = t.endate;

                //updateSession.teastart = t.teastart;
                //updateSession.teaend = t.teaend;

                //updateSession.lunchstart = t.lunchstart;
                //updateSession.lunchend = t.lunchend;
                await context.SaveChangesAsync();
            }
        }

        public async static Task<List<trainingsession>> GetTrainingList()
        {
            context = new elev8dbEntites();

            return await Task.Run(() => context.trainingsessions.Include("traningsessionlineitems").ToList());
           // return context.trainingsessions.ToList();
        }

        public static ICollection<trainingsession> GetTrainingList(DateTime startdate, DateTime endate)
        {
            context = new elev8dbEntites();
            return context.trainingsessions.Where(m => m.startdate.Value >= startdate.Date && m.endate.Value <= endate.Date).ToList();

            
            // return context.trainingsessions.ToList();


        }

        internal static void AddNewLearner(string azpass, string email, string examvoucher, string fullname, string lab, string moc, string organization, string phone)
        {
            using (context = new elev8dbEntites())
            {
                traningsessionlineitem newlineitem = new traningsessionlineitem();
                if (newlineitem != null)
                {
                    newlineitem.linitemid = System.Guid.NewGuid().ToString();
                    newlineitem.azpass = azpass;
                    newlineitem.email = email;
                    newlineitem.examvoucher = examvoucher;
                    newlineitem.fullname = fullname;
                    newlineitem.lab = lab;
                    newlineitem.moc = moc;
                    newlineitem.organization = organization;
                    newlineitem.phone = phone;
                 //   newlineitem.certno = tlineitem.certno;
                    context.traningsessionlineitems.Add(newlineitem);
                    context.SaveChanges();
                }
            }
        }

        public async static void UpdateLearner(traningsessionlineitem tlineitem)
        {
            using (context = new elev8dbEntites())
            {
                traningsessionlineitem updatelineitem = context.traningsessionlineitems.FirstOrDefault(tl => tl.linitemid == tlineitem.linitemid);
                if (updatelineitem != null)
                {
                    updatelineitem.azpass = tlineitem.azpass;
                    updatelineitem.email = tlineitem.email;
                    updatelineitem.examvoucher = tlineitem.examvoucher;
                    updatelineitem.fullname = tlineitem.fullname;
                    updatelineitem.lab = tlineitem.lab;
                    updatelineitem.moc = tlineitem.moc;
                    updatelineitem.organization = tlineitem.organization;
                    updatelineitem.phone = tlineitem.phone;
                    updatelineitem.certno = tlineitem.certno;
                    await context.SaveChangesAsync();
                }
            }
        }

        public static void AddNewLearner(traningsessionlineitem tlineitem, certinumber cn)
        {
            using (context = new elev8dbEntites())
            {
                context.traningsessionlineitems.Attach(tlineitem);
                context.certinumbers.Attach(cn);
                context.Entry(tlineitem).State = System.Data.Entity.EntityState.Added;
                context.Entry(cn).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                //traningsessionlineitem newlineitem = new traningsessionlineitem();
                //if (newlineitem != null)
                //{
                //    newlineitem.linitemid = tlineitem.linitemid;
                //    newlineitem.trainingsessionid = tlineitem.trainingsessionid;
                //    newlineitem.azpass = tlineitem.azpass;
                //    newlineitem.email = tlineitem.email;
                //    newlineitem.examvoucher = tlineitem.examvoucher;
                //    newlineitem.fullname = tlineitem.fullname;
                //    newlineitem.lab = tlineitem.lab;
                //    newlineitem.moc = tlineitem.moc;
                //    newlineitem.organization = tlineitem.organization;
                //    newlineitem.phone = tlineitem.phone;
                //    context.traningsessionlineitems.Add(newlineitem);
                //    context.SaveChanges();
                //}
            }
        }
        public static void AddNewLearners(List<traningsessionlineitem> tlineitems, certinumber cn)
        {
            using (context = new elev8dbEntites())
            {
                foreach (var tlineitem in tlineitems)
                {
                    context.traningsessionlineitems.Attach(tlineitem);
                    context.certinumbers.Attach(cn);
                    context.Entry(tlineitem).State = System.Data.Entity.EntityState.Added;
                    context.Entry(cn).State = System.Data.Entity.EntityState.Added;

                    //traningsessionlineitem newlineitem = new traningsessionlineitem();
                    //if (newlineitem != null)
                    //{
                    //    newlineitem.linitemid = tlineitem.linitemid;
                    //    newlineitem.trainingsessionid = tlineitem.trainingsessionid;
                    //    newlineitem.azpass = tlineitem.azpass;
                    //    newlineitem.email = tlineitem.email;
                    //    newlineitem.examvoucher = tlineitem.examvoucher;
                    //    newlineitem.fullname = tlineitem.fullname;
                    //    newlineitem.lab = tlineitem.lab;
                    //    newlineitem.moc = tlineitem.moc;
                    //    newlineitem.organization = tlineitem.organization;
                    //    newlineitem.phone = tlineitem.phone;
                    //    context.traningsessionlineitems.Add(newlineitem);
                    //    context.SaveChanges();
                    //}
                }
                
                context.SaveChanges();
            }
        }
        public static void AddNewLearners(List<traningsessionlineitem> tlineitems)
        {
            using (context = new elev8dbEntites())
            {
                foreach (var tlineitem in tlineitems)
                {
                    context.traningsessionlineitems.Attach(tlineitem);
                    context.Entry(tlineitem).State = System.Data.Entity.EntityState.Added;
                }
                context.SaveChanges();
            }
        }
        public static void RemoveLearner(traningsessionlineitem tlineitem) 
        {
            using (context = new elev8dbEntites())
            {
                traningsessionlineitem removelearner = context.traningsessionlineitems.FirstOrDefault(tl => tl.linitemid == tlineitem.linitemid);
                if (removelearner != null)
                {
                    context.traningsessionlineitems.Remove(removelearner);
                    context.SaveChanges();
                }
            }
        }
        public static string GetFolderName(DateTime startdate, DateTime endate, string coursecode)
        {
            string foldername = string.Empty;
            if (startdate.Month == endate.Month)
            {
                foldername = coursecode + " (" + startdate.Day.ToString() + " - " + endate.Day.ToString() + " " + startdate.ToString(" MMM yyyy") + ")";
            }
            else
            {
                foldername = coursecode + " (" + startdate.ToString("d MMM") + " - " + endate.ToString("d MMM") + " " + startdate.ToString("yyyy") + ")";
            }
            if (startdate.Day == endate.Day)
            {
                foldername = coursecode + " (" + startdate.ToString("d MMM yyyy") + ")";
            }

            return foldername;
        }

        public static MAPIFolder getOutlookFolder(string foldername, Application app)
        {
            MAPIFolder rootFolder = app.Session.DefaultStore.GetRootFolder();
            //  var processedFolder = rootFolder.Folders.Cast<OutLook.MAPIFolder>().Where(r => r.Name == foldername).FirstOrDefault();
            MAPIFolder myfolder = null;

            foreach (MAPIFolder folder in rootFolder.Folders)
            {
                if (folder.Name == foldername)
                {
                    myfolder = folder;
                    break;
                }
            }
            return myfolder;
        }
        public static string GetCourseLink(string coursecode, string courselink, DateTime startdate, DateTime endate)
        {
            string teamscourselink = string.Empty;
            if (startdate.Month == endate.Month)
            {
                if (startdate.Day == endate.Day)
                {
                    teamscourselink = coursecode + " Training " + "(" + startdate.Day.ToString() + "<sup>" + GetDaySuffix(startdate.Day) + "</sup>" + " " + startdate.ToString("MMM") + " " + startdate.ToString("yyyy") + ")";
                }
                else
                {
                    teamscourselink = coursecode + " Training " + "(" + startdate.Day.ToString() + "<sup>" + GetDaySuffix(startdate.Day) + "</sup>" + " - " + endate.Day.ToString() + "<sup>" + GetDaySuffix(endate.Day) + "</sup>" + " " + endate.ToString("MMM") + " " + startdate.ToString("yyyy") + ")";
                }
            }
            else
            {
                teamscourselink = coursecode + " Training " + "(" + startdate.Day.ToString() + "<sup>" + GetDaySuffix(startdate.Day) + "</sup>" + " " + startdate.ToString("MMM") + " - " + endate.Day.ToString() + "<sup>" + GetDaySuffix(endate.Day) + "</sup>" + " " + endate.ToString("MMM") + " " + startdate.ToString("yyyy") + ")";
            }
            return "Teams Link: &nbsp;<b><a href = '" + courselink + "'>Click here to join the " + teamscourselink + "</a></b>";
        }
        public static string GetCourseLink(trainingsession t)
        {
            string courselink = string.Empty;
            if (t.startdate.Value.Month == t.endate.Value.Month)
            {
                if (t.startdate.Value.Day == t.endate.Value.Day)
                {
                    courselink = t.coursecode + " Training " + "(" + t.startdate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.startdate.Value.Day) + "</sup>" + " " + t.startdate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
                }
                else
                {
                    courselink = t.coursecode + " Training " + "(" + t.startdate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.startdate.Value.Day) + "</sup>" + " - " + t.endate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.endate.Value.Day) + "</sup>" + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
                }
            }
            else
            {
                courselink = t.coursecode + " Training " + "(" + t.startdate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.startdate.Value.Day) + "</sup>" + " " + t.startdate.Value.ToString("MMM") + " - " + t.endate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.endate.Value.Day) + "</sup>" + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
            }
            return "Teams Link: &nbsp;<b><a href = '" + t.courselink + "'> Click here to join the " + courselink + "</a></b>";
        }

        public static void AddNewTrainingSession(trainingsession ts1)
        {
            context = new elev8dbEntites();
            // context.trainingsessions.Attach(ts1);
            context.trainingsessions.Add(ts1);
            context.SaveChangesAsync();
        }

        public static string GetCourseDate(trainingsession t)
        {
            string coursedate = string.Empty;
            if (t.startdate.Value.Month == t.endate.Value.Month)
            {
                if (t.startdate.Value.Day == t.endate.Value.Day)
                {
                    coursedate = t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " " + t.startdate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
                }
                else
                {
                    coursedate = t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " - " + t.endate.Value.Day.ToString() + GetDaySuffix(t.endate.Value.Day) + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
                }
            }
            else
            {
                coursedate = t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " " + t.startdate.Value.ToString("MMM") + " - " + t.endate.Value.Day.ToString() + " " + GetDaySuffix(t.endate.Value.Day) + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy");
            }
            return coursedate;
        }

        public static string GetCourseSchedule(trainingsession t)
        {
            string courseschedule = string.Empty;
            if (t.startdate.Value.Month == t.endate.Value.Month)
            {
                if (t.startdate.Value.Day == t.endate.Value.Day)
                {
                    courseschedule = "For " + t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " " + t.startdate.Value.ToString("MMMM") + " " + t.startdate.Value.ToString("yyyy");
                }
                else
                {
                    courseschedule = "From " + t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " - " + t.endate.Value.Day.ToString() + GetDaySuffix(t.endate.Value.Day) + " " + t.endate.Value.ToString("MMMM") + " " + t.startdate.Value.ToString("yyyy");
                }
            }
            else
            {
                courseschedule = "From " + t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " " + t.startdate.Value.ToString("MMMM") + " - " + t.endate.Value.Day.ToString() + " " + GetDaySuffix(t.endate.Value.Day) + " " + t.endate.Value.ToString("MMMM") + " " + t.startdate.Value.ToString("yyyy");
            }
            return courseschedule;
        }

        public static void UpdateCourse(course mycourse)
        {
            context = new elev8dbEntites();
            context.Entry(mycourse).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
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

        public static void AddNewTrainer(trainer trn)
        {
            context = new elev8dbEntites();
            context.Entry(trn).State = System.Data.Entity.EntityState.Added;
            context.SaveChanges();
        }

        public static trainingsession GetTrainingSession(string trainingsessionid)
        {
            context = new elev8dbEntites();
            return context.trainingsessions.Include("traningsessionlineitems").Include("trainer1").FirstOrDefault(ts => ts.trainingsessionid == trainingsessionid);
        }

        public static async Task<IEnumerable<trainer>> GetTrainersList()
        {
            context = new elev8dbEntites();
            return await Task.Run(() => context.trainers.ToList());
        }

        public static string GetCourseShortCode(trainingsession t)
        {
            string courselink = string.Empty;
            if (t.startdate.Value.Month == t.endate.Value.Month)
            {
                if (t.startdate.Value.Day == t.endate.Value.Day)
                {
                    courselink = t.coursecode + " Training " + "(" + t.startdate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.startdate.Value.Day) + "</sup>" + " " + t.startdate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
                }
                else
                {
                    courselink = t.coursecode + " Training " + "(" + t.startdate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.startdate.Value.Day) + "</sup>" + " - " + t.endate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.endate.Value.Day) + "</sup>" + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
                }
            }
            else
            {
                courselink = t.coursecode + " Training " + "(" + t.startdate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.startdate.Value.Day) + "</sup>" + " " + t.startdate.Value.ToString("MMM") + " - " + t.endate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.endate.Value.Day) + "</sup>" + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy") + ")";
            }
            return courselink;
        }

        public static void UpdateTrainer(trainer trainer)
        {
            context = new elev8dbEntites();
            context.Entry(trainer).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public static string  GetDaySuffix(int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }

        public static void AddNewCourse(course mycourse)
        {
            context = new elev8dbEntites();
            context.courses.Add(mycourse);
            context.SaveChanges();
        }

        public static async Task<IEnumerable<course>> GetCourseList()
        {
            context = new elev8dbEntites();
            return await Task.Run(() => context.courses);
        }

        public static string GetNextCertNo()
        {
            //#00010020NG
            context = new elev8dbEntites();
            int lastnumber = context.certinumbers.Max(i=>i.certendnumber).Value;
            string certno = string.Empty;

            if (lastnumber > 9)
            {
                certno = "#000100" + lastnumber + "NG"; // 020NG

            }
            if (lastnumber > 99)
            {
                certno = "#00010" + lastnumber + "NG"; // 020NG

            }
            if (lastnumber > 999)
            {
                certno = "#0001" + "NG";
            }
            if (lastnumber > 9999)
            {
                certno = "#000" + (lastnumber + 10000).ToString() + "NG";
            }
            if (lastnumber > 999999)
            {
                certno = "#00" + lastnumber.ToString() + "NG";
            }
            if (lastnumber > 9999999)
            {
                certno = "#0" + lastnumber.ToString() + "NG";
            }
            return certno;
        }
    }
}
