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
        public static elev8dbEntities context = null;
        public static void Updatetrainingsession(trainingsession t)
        {
            context = new elev8dbEntities();
            trainingsession updateSession = context.trainingsessions.FirstOrDefault(tsession => tsession.trainingsessionid == t.trainingsessionid);
            if (updateSession != null)
            {
                //updateSession.trainingsessionid = System.Guid.NewGuid().ToString();
                updateSession.trainer = t.trainer;
                updateSession.trainerid = t.trainerid;
               
                updateSession.coursename = t.coursename;
                updateSession.courselink = t.courselink;
                updateSession.coursecode = t.coursecode;
                updateSession.duration = t.duration;
               
                updateSession.startdate = t.startdate;
                updateSession.endate = t.endate;

                updateSession.teastart = t.teastart;
                updateSession.teaend = t.teaend;

                updateSession.lunchstart = t.lunchstart;
                updateSession.lunchend = t.lunchend;
                context.SaveChanges();
            }
        }

        internal static List<trainingsession> GetTrainingList()
        {
            context = new elev8dbEntities();
            return  context.trainingsessions.Include("traningsessionlineitems").OrderByDescending(t => t.coursename).ToList();
        }

        internal static void AddNewLearner(string azpass, string email, string examvoucher, string fullname, string lab, string moc, string organization, string phone)
        {
            using (context = new elev8dbEntities())
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
                    context.traningsessionlineitems.Add(newlineitem);
                    context.SaveChanges();
                }
            }
        }

        public static void UpdateLearner(traningsessionlineitem tlineitem)
        {
            using (context = new elev8dbEntities())
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
                    context.SaveChanges();
                }
            }
        }

        public static void AddNewLearner(traningsessionlineitem tlineitem)
        {
            using (context = new elev8dbEntities())
            {
                traningsessionlineitem newlineitem = new traningsessionlineitem();
                if (newlineitem != null)
                {
                    newlineitem.linitemid = tlineitem.linitemid;
                    newlineitem.trainingsessionid = tlineitem.trainingsessionid;
                    newlineitem.azpass = tlineitem.azpass;
                    newlineitem.email = tlineitem.email;
                    newlineitem.examvoucher = tlineitem.examvoucher;
                    newlineitem.fullname = tlineitem.fullname;
                    newlineitem.lab = tlineitem.lab;
                    newlineitem.moc = tlineitem.moc;
                    newlineitem.organization = tlineitem.organization;
                    newlineitem.phone = tlineitem.phone;
                    context.traningsessionlineitems.Add(newlineitem);
                    context.SaveChanges();
                }
            }
        }

        public static void RemoveLearner(traningsessionlineitem tlineitem) 
        {
            using (context = new elev8dbEntities())
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

        internal static void AddNewTrainingSession(trainingsession ts1)
        {
            context = new elev8dbEntities();
            // context.trainingsessions.Attach(ts1);
            context.trainingsessions.Add(ts1);
            context.SaveChanges();
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
                coursedate = t.startdate.Value.Day.ToString() + GetDaySuffix(t.startdate.Value.Day) + " " + t.startdate.Value.ToString("MMM") + " - " + t.endate.Value.Day.ToString() + "<sup>" + GetDaySuffix(t.endate.Value.Day) + " " + t.endate.Value.ToString("MMM") + " " + t.startdate.Value.ToString("yyyy");
            }
            return coursedate;
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
        internal static trainingsession GetTrainingSession(string trainingsessionid)
        {
            context = new elev8dbEntities();
            return context.trainingsessions.Include("traningsessionlineitems").Include("trainer1").FirstOrDefault(ts => ts.trainingsessionid == trainingsessionid);
        }

        internal static IEnumerable<trainer> GetTrainersList()
        {
            context = new elev8dbEntities();
            return context.trainers.ToList();
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

        internal static void AddNewCourse(course mycourse)
        {
            context = new elev8dbEntities();
            context.courses.Add(mycourse);
            context.SaveChanges();
        }

        public static List<course> GetCourseList()
        {
            context = new elev8dbEntities();
            return context.courses.ToList();
        }
    }
}
