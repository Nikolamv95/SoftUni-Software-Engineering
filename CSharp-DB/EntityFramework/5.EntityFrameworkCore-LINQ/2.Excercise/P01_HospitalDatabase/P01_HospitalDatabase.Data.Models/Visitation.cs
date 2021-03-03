using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        [Key]
        [Required]
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(250)]
        public int Comment { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
