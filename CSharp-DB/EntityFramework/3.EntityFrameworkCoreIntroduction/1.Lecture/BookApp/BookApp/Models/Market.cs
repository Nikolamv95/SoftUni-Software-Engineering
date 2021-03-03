using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookApp.Models
{
    public class Market
    {
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string MarketDescription { get; set; }

        public virtual ICollection<EcommerceBrand> EcommerceBrands { get; set; }
    }
}
