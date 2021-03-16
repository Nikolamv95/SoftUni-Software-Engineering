﻿using System;
using System.Collections.Generic;
using System.Text;
using PetStore.Models.Enumerations;

namespace PetStore.ServiceModels.OutputModels
{
    public class ListAllProductsServiceModel
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
    }
}
