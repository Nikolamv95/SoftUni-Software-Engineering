using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(x => x.Name)
                      .IsUnicode(true);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(x => x.Name)
                      .IsUnicode(true);

                entity.Property(x => x.Speciality)
                      .IsUnicode(true);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(x => x.FirstName)
                      .IsUnicode(true);

                entity.Property(x => x.LastName)
                      .IsUnicode(true);

                entity.Property(x => x.Address)
                      .IsUnicode(true);

                entity.Property(x => x.Email)
                      .IsUnicode(false);
            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(x => x.Name)
                      .IsUnicode(true);

                entity.Property(x => x.Comment)
                      .IsUnicode(true);
            });

            modelBuilder.Entity<Visitation>(entity =>
            {
                entity.Property(x => x.Comment)
                      .IsUnicode(true);               
            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity.HasKey(x => new { x.PatientId, x.MedicamentId });

                entity.HasOne(x => x.Patient)
                      .WithMany(x => x.PatientMedicaments)
                      .HasForeignKey(x => x.PatientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Medicament)
                      .WithMany(x => x.PatientMedicaments)
                      .HasForeignKey(x => x.MedicamentId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
