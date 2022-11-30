using CommunityToolkit.Maui;
using DevExpress.Maui;
using MAUI_App.ViewModels;
using MAUI_App.Models;

namespace MAUI_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseDevExpress()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});


		//Pages
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddTransient<PageA>();
		builder.Services.AddTransient<PageB>();
		builder.Services.AddTransient<PageC>();


		//View Models
		builder.Services.AddTransient<PageBViewModel>();
		builder.Services.AddTransient<PageCViewModel>();


		return builder.Build();
	}
}
