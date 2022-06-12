using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Elev8App
{
    public partial class elev8dbEntities : DbContext
    {
        public elev8dbEntities()
            : base("name=elev8dbEntities")
        {
        }

        public virtual DbSet<course> courses { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<trainer> trainers { get; set; }
        public virtual DbSet<trainingsession> trainingsessions { get; set; }
        public virtual DbSet<traningsessionlineitem> traningsessionlineitems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<course>()
                .Property(e => e.courseid)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.coursename)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.coursecode)
                .IsUnicode(false);

            modelBuilder.Entity<course>()
                .Property(e => e.coursedescription)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.studentid)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.organization)
                .IsUnicode(false);

            modelBuilder.Entity<student>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.trainerid)
                .IsUnicode(false);

            modelBuilder.Entity<trainer>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.trainingsessionid)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.Col)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.coursename)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.coursecode)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.trainer)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.duration)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.expm)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.courselink)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.trainerid)
                .IsUnicode(false);

            modelBuilder.Entity<trainingsession>()
                .Property(e => e.coursewaremail)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.linitemid)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.trainingsessionid)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.studentid)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.moc)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.lab)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.azpass)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.examvoucher)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.organization)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<traningsessionlineitem>()
                .Property(e => e.phone)
                .IsUnicode(false);
        }
    }
}
