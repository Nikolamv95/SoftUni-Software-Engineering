using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebProjectExample.ValidationAttributes;

namespace WebProjectExample.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [YearRange(1990)]
        public DateTime ActiveFrom { get; set; }
    }
}
