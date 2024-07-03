using System.Collections.ObjectModel;
using System.Web;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TheMealApp.Models;
using TheMealApp.Views;

namespace TheMealApp.ViewModels
{
    [QueryProperty(nameof(MealCategory), nameof(MealCategory))]
    public partial class RecipesViewModel : BaseViewModel, IQueryAttributable
	{
        public ObservableCollection<Recipe> Recipes { get; private set; } = new();

        [ObservableProperty]
        string mealCategory;

        [ObservableProperty]
        bool isRefreshing;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            MealCategory = HttpUtility.UrlDecode(query["category"].ToString());
            PerformGetRecipesCommand();
        }

        private RelayCommand getRecipesCommand;
        public ICommand GetRecipesCommand => getRecipesCommand ??= new RelayCommand(PerformGetRecipesCommand);

        private async void PerformGetRecipesCommand()
        {
            IsLoading = true;
            IsRefreshing = true;

            var recipesList = await App.caterogiesService.GetRecipesList(MealCategory);
            if (Recipes.Count > 0) Recipes.Clear();
            foreach (var recipe in recipesList) Recipes.Add(recipe);

            IsLoading = false;
            IsRefreshing = false;

        }

        private RelayCommand<string> getRecipesDetail;
        public ICommand GetRecipeDetailCommand => getRecipesDetail ??= new RelayCommand<string>(PerformGetRecipeDetailCommand);

        private async void PerformGetRecipeDetailCommand(string recipeId)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipeDetailPage)}?recipeId={recipeId}", true);

        }
    }
}

