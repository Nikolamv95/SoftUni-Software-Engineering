using Microsoft.EntityFrameworkCore;
using StudentSystem.Data.Models;
using System;

namespace StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        //Constructors
        public StudentSystemContext()
        {
        }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
            : base(options)
        {
        }

        //Properties
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        //Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-0J5UCH7\SQLEXPRESS;Database=StudentSystem;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>(entity =>
            {
                //ResourceId
                entity.HasKey(x => x.RecourceId);

                entity.Property(x => x.RecourceId)
                      .IsRequired();

                //Name
                entity.Property(x => x.Name)
                      .HasMaxLength(50)
                      .IsUnicode(true)
                      .IsRequired();

                //Url
                entity.Property(x => x.Url)
                      .IsUnicode(false)
                      .IsRequired();

                //CourseId
               entity.HasOne(p => p.Course)
                     .WithMany(b => b.Recources)
                     .HasForeignKey(p => p.CourseId)
                     .IsRequired();
            });

            modelBuilder.Entity<Course>(entity => 
            {
                //CourceId
                entity.HasKey(x => x.CourseId);

                entity.Property(x => x.CourseId)
                      .IsRequired();

                //Name
                entity.Property(x => x.Name)
                      .HasMaxLength(80)
                      .IsUnicode(true)
                      .IsRequired();

                //Description
                entity.Property(x => x.Description)
                      .IsUnicode(true);

                //StartDate
                //EndDate
                //Price
            });

            modelBuilder.Entity<Student>(entity => 
            {
                //StudentId
                entity.HasKey(x => x.StudentId);

                entity.Property(x => x.StudentId)
                      .IsRequired();

                //Name
                entity.Property(x => x.Name)
                      .HasMaxLength(100)
                      .IsUnicode(true)
                      .IsRequired();

                //PhoneNumber
                entity.Property(x => x.PhoneNumber)
                      .HasMaxLength(10)
                      .IsUnicode(false)
                      .IsRequired(false);

                //RegisteredOn
                //BirthDay
                entity.Property(x => x.BirthDay)
                      .IsRequired(false);
            });

            modelBuilder.Entity<StudentCourse>(entity => 
            {
                //CompositeKey
                entity.HasKey(t => new { t.StudentId, t.CourseId });

                //StudentId
                entity.HasOne(sc => sc.Student)
                      .WithMany(s => s.StudentCourses)
                      .HasForeignKey(sc => sc.StudentId);

                //CourseId
                entity.HasOne(sc => sc.Course)
                      .WithMany(s => s.StudentCourses)
                      .HasForeignKey(sc => sc.CourseId);
            });

            modelBuilder.Entity<HomeworkSubmission>(entity =>
            {
                //HomeworkId
                entity.HasKey(x => x.HomeworkId);

                entity.Property(x => x.HomeworkId)
                      .IsRequired();

                //Content
                entity.Property(x => x.Content)
                      .IsUnicode(false)
                      .IsRequired();

                //ContentType
                entity.Property(x => x.ContentType)
                      .IsRequired();

                //SubmissionTime
                entity.Property(x => x.SubmissionTime)
                      .HasDefaultValue(DateTime.UtcNow);
                
                //StudentId
                entity.HasOne(p => p.Student)
                     .WithMany(b => b.HomeworkSubmissions)
                     .HasForeignKey(p => p.StudentId)
                     .IsRequired();

                //CourseId
                entity.HasOne(p => p.Course)
                     .WithMany(b => b.HomeworkSubmissions)
                     .HasForeignKey(p => p.CourseId)
                     .IsRequired();
            });
        }
    }
}
