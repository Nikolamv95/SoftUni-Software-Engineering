using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RealEstates.Models
{
    public class RealEstateProperty
    {
        public RealEstateProperty()
        {
            this.RealEstatePropertyTags = new HashSet<RealEstatePropertyTag>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Size { get; set; }
        public int? Floor { get; set; }
        public int? TotalNumberOfFloors { get; set; }

        //District
        [Required]
        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public int? BuildingYear { get; set; }

        //PropertyType
        [Required]
        public int PropertyTypeId { get; set; }
        public virtual PropertyType PropertyType { get; set; }

        //BuildingType
        [Required]
        public int BuildingTypeId { get; set; }
        public virtual BuildingType BuildingType { get; set; }

        [Required]
        public int Price { get; set; }

        //RealEstatePropertyTag
        public virtual ICollection<RealEstatePropertyTag> RealEstatePropertyTags { get; set; }
    }
}
