using System;
using System.Web;
using CommunityToolkit.Mvvm.ComponentModel;
using TheMealApp.Models;

namespace TheMealApp.ViewModels
{
    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public partial class RecipeDetailViewModel : BaseViewModel, IQueryAttributable
	{
        [ObservableProperty]
        Recipe recipeDetail;

        [ObservableProperty]
        string recipeId;

        [ObservableProperty]
        bool isRefreshing;

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            IsLoading = true;
            IsRefreshing = true;

            RecipeId = HttpUtility.UrlDecode(query["recipeId"].ToString());
            var recipeDetail = await App.caterogiesService.ShowRecipeDetails(RecipeId);
            RecipeDetail = recipeDetail[0];

            IsRefreshing = false;
            IsLoading = false;
        }
    }
}

