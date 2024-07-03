using System;
using TheMealApp.Models;

namespace TheMealApp.Interfaces
{
	public interface ICategories
	{

		Task<List<Category>> GetCategoriesList();
		Task<List<Recipe>> GetRecipesList(string category);
		Task<List<Recipe>> ShowRecipeDetails(string recipe);

	}
}

