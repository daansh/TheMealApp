using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using TheMealApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using TheMealApp.Views;
using TheMealApp.Services;

namespace TheMealApp.ViewModels
{
    public partial class MealCategoriesViewModel : BaseViewModel
	{
        public ObservableCollection<Category> categories { get; private set; } = new();

        CaterogiesService _catService;

        public MealCategoriesViewModel(CaterogiesService service)
		{
            _catService = service;
            PerformGetCategoriesList();
        }

        [ObservableProperty]
        bool isRefreshing;

        private RelayCommand getCategoriesList;
        public ICommand GetCategoriesList => getCategoriesList ??= new RelayCommand(PerformGetCategoriesList);

        private async void PerformGetCategoriesList()
        {
            IsLoading = true;
            IsRefreshing = true;

            var categoriesList = await _catService.GetCategoriesList();
            if (categories.Count > 0) categories.Clear();
            foreach (var mealCategory in categoriesList) categories.Add(mealCategory);

            IsRefreshing = false;
            IsLoading = false;
        }

        private RelayCommand<string> getRecipesList;
        public ICommand GetRecipesCommand => getRecipesList ??= new RelayCommand<string>(PerformGetRecipesCommand);

        private async void PerformGetRecipesCommand(string category)
        {
            await Shell.Current.GoToAsync($"{nameof(RecipesListPage)}?category={category}", true);

        }
    }
}

