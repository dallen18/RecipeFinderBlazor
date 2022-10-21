using System;
namespace RecipeFinderBlazor.Models
{
    public class RecipeSearch
    {
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public int usedIngredientCount { get; set; }
        public int missedIngredientCount { get; set; }
        public List<IngredientSearch> usedIngredients { get; set; }
        public int likes { get; set; }
    }
}

