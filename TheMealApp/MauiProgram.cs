using Microsoft.Extensions.Logging;
using TheMealApp.Services;
using TheMealApp.ViewModels;
using TheMealApp.Views;

namespace TheMealApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<CaterogiesService>(s));


#if DEBUG
        builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MealCategoriesViewModel>();
        builder.Services.AddSingleton<MealListPage>();

        builder.Services.AddSingleton<RecipesViewModel>();
        builder.Services.AddSingleton<RecipesListPage>();

        builder.Services.AddSingleton<RecipeDetailViewModel>();
        builder.Services.AddSingleton<RecipeDetailPage>();

        return builder.Build();
	}
}

