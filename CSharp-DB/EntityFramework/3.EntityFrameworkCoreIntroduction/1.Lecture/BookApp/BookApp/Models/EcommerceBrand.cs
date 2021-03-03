using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookApp.Models
{
    public class EcommerceBrand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BrandName { get; set; }
        public string Description { get; set; }

        [ForeignKey("Market")]
        public int MarketId { get; set; }
        public Market Market { get; set; }
    }
}
