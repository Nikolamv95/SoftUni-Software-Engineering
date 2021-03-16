using PetStore.Models.Enumerations;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PetStore.Common;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            //This is a method which transform the ID to string
            //like from 1 to asdhi0 (random string combination)
            this.Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.PetNameMinLength)]
        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Range(GlobalConstants.MinAgeRange, GlobalConstants.MaxAgeRange)]
        public byte Age { get; set; }

        //Breed FK
        [Required]
        [ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        [Range(GlobalConstants.PetMinPrice, double.MaxValue)]
        public decimal Price { get; set; }
        public bool IsSold { get; set; }

        //Client FK
        [ForeignKey(nameof(Client))]
        public string ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
