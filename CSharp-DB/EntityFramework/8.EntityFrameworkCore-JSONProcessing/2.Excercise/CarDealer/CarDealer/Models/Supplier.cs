﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsImporter { get; set; }

        public virtual ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
