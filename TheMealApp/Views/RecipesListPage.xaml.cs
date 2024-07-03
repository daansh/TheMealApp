using TheMealApp.ViewModels;

namespace TheMealApp.Views;

public partial class RecipesListPage : ContentPage
{
	public RecipesListPage(RecipesViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}
