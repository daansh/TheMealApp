using System;
using Newtonsoft.Json;

namespace TheMealApp.Models.Response
{
	public class CategoryRecipeResponse
	{
        [JsonProperty("meals")]
        public List<Recipe> Recipes { get; set; }
    }
}

