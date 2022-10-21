using System.Text.Json;
using RecipeFinderBlazor.Models;

namespace RecipeFinderBlazor.Data;

public class RapidApiService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }

    public async Task<List<RecipeSearch>?> GetRecipeSearch(string name)
    {
        try
        {
            var client = GetClient();
            var response = await client.GetAsync($"recipes/findByIngredients?ingredients={name}&number=20&ignorePantry=true&ranking=1");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<RecipeSearch>>(content);

            return result;
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

    /*
     * 
     * var client = new HttpClient();
var request = new HttpRequestMessage
{
	Method = HttpMethod.Get,
	RequestUri = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/findByIngredients?ingredients=steak&number=5&ignorePantry=true&ranking=1"),
	Headers =
	{
		{ "X-RapidAPI-Key", "a050c13f77msh25ab18508fd852ep1edf0ejsn88311a72d376" },
		{ "X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
	},
};
using (var response = await client.SendAsync(request))
{
	response.EnsureSuccessStatusCode();
	var body = await response.Content.ReadAsStringAsync();
	Console.WriteLine(body);
}
     * 
     * */
}

