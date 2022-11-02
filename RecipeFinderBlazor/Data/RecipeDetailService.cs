using Newtonsoft.Json;

namespace RecipeFinderBlazor.Models
{
    public class RecipeDetailService

    {

        public async Task<RecipeDetail> getRecipeDetail(long id)

        {

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage

            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/" + id.ToString() + "/information"),
                Headers = {
                    { "X-RapidAPI-Key", "0f17f51ee0msh4b2797fd278017fp14ce0cjsn6c3d3a8925e0" },
                    { "X-RapidAPI-Host", "spoonacular-recipe-food-nutrition-v1.p.rapidapi.com" },
                }

            };





            using (HttpResponseMessage response = await client.SendAsync(request))

            {

                response.EnsureSuccessStatusCode();

                var body = response.Content.ReadAsStringAsync().Result;

                RecipeDetail recipeData = JsonConvert.DeserializeObject<RecipeDetail>(body);

                return recipeData;



            }

        }

    }

}
   