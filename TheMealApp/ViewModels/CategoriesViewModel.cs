using System;
using CommunityToolkit.Mvvm.ComponentModel;
using TheMealApp.Models;

namespace TheMealApp.ViewModels
{
	public partial class CategoriesViewModel : ObservableObject
    {

        [ObservableProperty]
        List<Category> categories;

        public CategoriesViewModel()
		{
            categories = App.caterogiesService.GetCategoriesList().Result;


        }
	}
}

