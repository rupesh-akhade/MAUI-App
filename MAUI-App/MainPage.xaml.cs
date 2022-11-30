namespace MAUI_App;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();

		AddFlyoutMenusDetails();
	}
	public async Task AddFlyoutMenusDetails()
	{


		var pageAInfo = AppShell.Current.Items.Where(f => f.Route == nameof(PageA)).FirstOrDefault();
		if (pageAInfo != null) AppShell.Current.Items.Remove(pageAInfo);

		var flyoutItem = new FlyoutItem()
		{
			Title = "Page A",
			Route = nameof(PageA),
			FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
			Items = {
						new ShellContent
						{
							//Icon = Icons.Dashboard,
							Title = "PageA",
							FlyoutItemIsVisible = false,
							ContentTemplate = new DataTemplate(typeof(PageA)),
							Route="PageA"
						},
						new ShellContent
						{
							//Icon = Icons.Meal,
							Title = "PageB",
							FlyoutItemIsVisible = false,
							ContentTemplate = new DataTemplate(typeof(PageB)),
							Route="PageB"
						},
						//new ShellContent
						//{
						//	Icon = "",
						//	Title = "Meal Weight",
						//	//FlyoutItemIsVisible = false,
						//	IsVisible = false,
						//	ContentTemplate = new DataTemplate(typeof(MealItemWeight)),
						//	Route="Meal/MealItemWeight",
						//	Flyou
						//}
				}
		};

		if (!AppShell.Current.Items.Contains(flyoutItem))
		{
			AppShell.Current.Items.Add(flyoutItem);
			if (DeviceInfo.Platform == DevicePlatform.WinUI)
			{
				AppShell.Current.Dispatcher.Dispatch(async () =>
				{
					await Shell.Current.GoToAsync($"//{nameof(PageA)}");
				});
			}
			else
			{
				await Shell.Current.GoToAsync($"//{nameof(PageA)}");
			}
		}
	}
		private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

