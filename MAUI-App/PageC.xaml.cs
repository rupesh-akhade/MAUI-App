using MAUI_App.ViewModels;

namespace MAUI_App;

public partial class PageC : ContentPage
{

	PageCViewModel viewModel;
	public PageC(PageCViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		this.BindingContext = this.viewModel;
	}
}