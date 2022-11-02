namespace RecipeFinderBlazor.Models
{
    public class Step
    {
        public int number { get; set; }

        public string step { get; set; }

        public List<Ingredient> ingredients { get; set; }

        public List<Equipment> equipment { get; set; }

        public Length length { get; set; }
    }
}
