﻿namespace MAUI_App;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PageC), typeof(PageC));
	}
}
