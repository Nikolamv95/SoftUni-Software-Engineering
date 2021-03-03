using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OrmTestsStudents.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        public decimal Value { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
