﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ProductShop.DTO.Users
{
    public class UserProductSoldDTO
    {
        [JsonProperty("name")]
        public string ProductName { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("buyerFirstName")]
        public string BuyerFirstName { get; set; }

        [JsonProperty("buyerLastName")]
        public string BuyerLastName { get; set; }
    }
}
