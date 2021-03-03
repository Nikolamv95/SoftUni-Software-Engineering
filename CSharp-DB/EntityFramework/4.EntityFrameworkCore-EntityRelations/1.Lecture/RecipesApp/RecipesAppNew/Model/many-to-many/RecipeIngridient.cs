using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesAppNew.Model.many_to_many
{
    public class RecipeIngridient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public int IngridientID { get; set; }
        public Ingridient Ingridient { get; set; }

        public decimal QuantityIngridient { get; set; }

        //In the onModelCreating method we have to combine RecipeId and IngridientID as a composite key
        //we do that with the following code.
        //modelBuilder.Entity<RecipeIngredient>()
        //.HasKey(x=> new {x.RecipeId, x.IngridientID} );
        //Overall we can skip this code because we have public int Id { get; set; } as a property
    }
}
