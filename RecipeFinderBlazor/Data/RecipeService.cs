using System.Diagnostics;
using System.Text.Json;
using RecipeFinderBlazor.Models;

namespace RecipeFinderBlazor.Data
{
    public class RecipeService
    {
        public async Task<Recipe[]?> GetRecipeSearchByCuisine(string name, string cuisine)
        {
            try
            {
                var client = GetClient();
                var response = await client.GetAsync($"recipes/complexSearch?query={name}&cuisine={cuisine}&offset=0&number=20&limitLicense=false&ranking=2");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<ComplexSearch>(content);

                return result.results.ToArray();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private HttpClient GetClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/")
            };

            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", "a050c13f77msh25ab18508fd852ep1edf0ejsn88311a72d376");
            httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com");

            return httpClient;
        }

    }
}
