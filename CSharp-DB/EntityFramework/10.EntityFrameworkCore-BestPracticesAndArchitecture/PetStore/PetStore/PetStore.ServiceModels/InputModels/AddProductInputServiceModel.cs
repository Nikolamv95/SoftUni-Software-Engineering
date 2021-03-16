using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PetStore.Common;
using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.InputModels
{
    public class AddProductInputServiceModel
    {
        [Required]
        [MinLength(GlobalConstants.ProductNameMinLength)]
        [MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        public int ProductType { get; set; }

        [Range(GlobalConstants.ProductMinPrice, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
