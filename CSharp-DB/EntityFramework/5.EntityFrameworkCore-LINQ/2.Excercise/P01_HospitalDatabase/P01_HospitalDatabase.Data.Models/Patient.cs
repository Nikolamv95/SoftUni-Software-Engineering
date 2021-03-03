using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();
            this.PatientMedicaments = new HashSet<PatientMedicament>();
        }

        [Key]
        [Required]
        public int PatientId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required]
        [MaxLength(80)]
        [EmailAddress]
        public string Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }
        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual ICollection<PatientMedicament> PatientMedicaments { get; set; }
    }
}
