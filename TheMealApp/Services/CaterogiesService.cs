using System.Net;
using TheMealApp.Common;
using TheMealApp.Interfaces;
using TheMealApp.Models;
using TheMealApp.Models.Response;

namespace TheMealApp.Services
{
	public class CaterogiesService : ICategories
	{
        /* to fetch the list of categories */
        public async Task<List<Category>> GetCategoriesList()
        {
            var response = await HttpProcess.GetRequest<GetCategoriesListResponse>(TimoutConnector.Timout_030_Seconds, $"/categories.php");
            if (response.HttpStatus != HttpStatusCode.Unauthorized)
                return response.Data.Categories;
            return null;
        }

        /* to filter the recipes on the basis of category */
        public async Task<List<Recipe>> GetRecipesList(string category)
        {   
            var response = await HttpProcess.GetRequest<CategoryRecipeResponse>(TimoutConnector.Timout_030_Seconds, $"/filter.php?c="+category);
            if (response.HttpStatus != HttpStatusCode.Unauthorized)
                return response.Data.Recipes;
            return null;
        }

        /* to fetch the recipe details */
        public async Task<List<Recipe>> ShowRecipeDetails(string recipe)
        {
            var response = await HttpProcess.GetRequest<RecipeDetailResponse>(TimoutConnector.Timout_030_Seconds, $"/lookup.php?i="+ recipe);
            if (response.HttpStatus != HttpStatusCode.Unauthorized)
                return response.Data.RecipeDetail;
            return null;
        }
    }
}

