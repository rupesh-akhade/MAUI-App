using MAUI_App.ViewModels;
using Newtonsoft.Json;

namespace MAUI_App;

public partial class PageB : ContentPage
{
	PageBViewModel viewModel;
	public PageB(PageBViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		this.BindingContext = this.viewModel;
	}
	private async void btnNext_Clicked(object sender, EventArgs e)
	{
		var selectedItems = viewModel.selectedMealItems;
		string selectedItemsStr = JsonConvert.SerializeObject(selectedItems);
		Preferences.Set("SelectedMealItems", selectedItemsStr);

		await Shell.Current.GoToAsync($"/{nameof(PageC)}");
	}
}