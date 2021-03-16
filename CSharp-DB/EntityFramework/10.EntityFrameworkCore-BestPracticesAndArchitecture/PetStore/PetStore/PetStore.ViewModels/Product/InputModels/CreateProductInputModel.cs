using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PetStore.Common;

namespace PetStore.ViewModels.Product.InputModels
{
    public class CreateProductInputModel
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
