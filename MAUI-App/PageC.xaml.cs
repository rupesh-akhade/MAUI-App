using MAUI_App.ViewModels;

namespace MAUI_App;

public partial class PageC : ContentPage
{

	PageCViewModel viewModel;
	public PageC(PageCViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}