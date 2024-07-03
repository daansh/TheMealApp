using TheMealApp.Interfaces;
using TheMealApp.Services;

namespace TheMealApp;

public partial class App : Application
{
    public static CaterogiesService caterogiesService { get; private set; }

    public App(CaterogiesService CaterogiesService)
	{
		InitializeComponent();
        MainPage = new AppShell();
        caterogiesService = CaterogiesService;
	}
}

