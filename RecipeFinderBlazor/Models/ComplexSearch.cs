namespace RecipeFinderBlazor.Models
{
    public class ComplexSearch
    {
        public List<Recipe> results { get; set; }
        public int offset { get; set; }
        public int number { get; set; }
        public int totalResults { get; set; }
    }
}
