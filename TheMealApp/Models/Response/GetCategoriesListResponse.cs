using System;
using Newtonsoft.Json;

namespace TheMealApp.Models.Response
{
	public class GetCategoriesListResponse
	{
        [JsonProperty("categories")]
        public List<Category> Categories { get; set; }
    }
}

