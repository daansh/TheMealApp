using TheMealApp.ViewModels;

namespace TheMealApp.Views;

public partial class MealListPage : ContentPage
{
	public MealListPage(MealCategoriesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}
