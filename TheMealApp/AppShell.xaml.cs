using TheMealApp.Views;

namespace TheMealApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(MealListPage), typeof(MealListPage));
        Routing.RegisterRoute(nameof(RecipesListPage), typeof(RecipesListPage));
        Routing.RegisterRoute(nameof(RecipeDetailPage), typeof(RecipeDetailPage));
    }
}

