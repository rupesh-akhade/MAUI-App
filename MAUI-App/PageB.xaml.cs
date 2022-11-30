using MAUI_App.ViewModels;

namespace MAUI_App;

public partial class PageB : ContentPage
{
	PageBViewModel viewModel;
	public PageB(PageBViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
	private async void btnNext_Clicked(object sender, EventArgs e)
	{


		await Shell.Current.GoToAsync($"/{nameof(PageC)}");
	}
}