using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Elev8App
{
    public partial class elev8dbEntites : DbContext
    {
        public elev8dbEntites()
            : base("name=elev8dbEntites")
        {
        }

        public virtual DbSet<certinumber> certinumbers { get; set; }
        public virtual DbSet<certinumberlineitem> certinumberlineitems { get; set; }
        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<customfield> customfields { get; set; }
        public virtual DbSet<trainer> trainers { get; set; }
        public virtual DbSet<trainingsession> trainingsessions { get; set; }
        public virtual DbSet<traningsessionlineitem> traningsessionlineitems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<certinumber>()
                .Property(e => e.certnumberid)
                .IsUnicode(false);

            modelBuilder.Entity<certinumber>()
                .Property(e => e.trainingsessionid)
                .IsUnicode(false);

            modelBuilder.Entity<certinumberlineitem>()
                .Property(e => e.certnumerlineitemid)
                .IsUnicode(false);

            modelBuilder.Entity<certinumberlineitem>()
                .Property(e => e.certnumberid)
                .IsUnicode(false);

            modelBuilder.Entity<certinumberlineitem>()
                .Property(e => e.studentid)
                .IsUnicode(false);

            modelBuilder.Entity<certinumberlineitem>()
                .Property(e => e.certnumber)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.certinumber)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.coursewaremail)
                .IsUnicode(false);
        }
    }
}
