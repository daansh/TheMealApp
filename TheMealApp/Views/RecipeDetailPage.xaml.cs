using TheMealApp.ViewModels;

namespace TheMealApp.Views;

public partial class RecipeDetailPage : ContentPage
{
	public RecipeDetailPage(RecipeDetailViewModel recipeDetail)
	{
		InitializeComponent();
		BindingContext = recipeDetail;
	}
}
