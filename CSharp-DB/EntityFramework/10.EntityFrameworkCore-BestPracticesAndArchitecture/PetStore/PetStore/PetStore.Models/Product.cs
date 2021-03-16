using PetStore.Models.Enumerations;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PetStore.Common;

namespace PetStore.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ClientProducts = new HashSet<ClientProduct>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        public string Name { get; set; }

        [Required]
        public ProductType ProductType { get; set; }

        [Range(GlobalConstants.ProductMinPrice, double.MaxValue)]
        public decimal Price { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
