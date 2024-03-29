﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.OutputModels
{
    public class ProductDetailsServiceModel
    {
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
    }
}
