using System;
using Newtonsoft.Json;

namespace TheMealApp.Models.Response
{
	public class RecipeDetailResponse
	{
        [JsonProperty("meals")]
        public List<Recipe> RecipeDetail { get; set; }
    }
}

