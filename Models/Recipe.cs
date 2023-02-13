using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NextGenInventories_4.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int IngredientId { get; set; }
        [ForeignKey("IngredientId")]
        [ValidateNever]
        public virtual Ingredient Ingredient { get; set; }
    }
}
