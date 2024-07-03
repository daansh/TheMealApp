using TheMealApp.Services;
using TheMealApp.ViewModels;

namespace MealUnitTestApp;

public class UnitTest1
{
    [Fact]
    public async void TestCategoriesAPIPulledUpWhenViewModelInitialised()
    {
        var service = new CaterogiesService();
        var viewModel = new MealCategoriesViewModel(service);

        var order = await service.GetRecipesList("Chicken");

        Assert.NotNull(order);
    }
}
