using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

using MAUI_App.Models;
using MAUI_App.ViewModels;

namespace MAUI_App.ViewModels
{

	public partial class PageCViewModel : ObservableObject, INotifyPropertyChanged
	{
		bool isRunning;
		public bool IsRunning
		{
			get => isRunning;
			set
			{
				isRunning = value;
				OnPropertyChanged(nameof(IsRunning));
			}
		}
		public ObservableCollection<MealItem> selectedMealItems { get; set; } = new ObservableCollection<MealItem>();


		public PageCViewModel()
		{
			GetSelectedMealItems();
		}
		private void GetSelectedMealItems()
		{
			Task.Run(async () =>
			{

				IsRunning = true;
				string SelectedItemsStr = Preferences.Get("SelectedMealItems", "");
				if (!string.IsNullOrWhiteSpace(SelectedItemsStr))
				{
					var mealItemList = JsonConvert.DeserializeObject<ObservableCollection<MealItem>>(SelectedItemsStr);
					App.Current.Dispatcher.Dispatch(() =>
					{
						IsRunning = false;
						if (mealItemList?.Count > 0)
						{
							foreach (var mealItem in mealItemList)
							{
								selectedMealItems.Add(mealItem);
							}
						}
					});
				}
			});
		}

		[ICommand]
		async Task GoBack()
		{
			await Shell.Current.GoToAsync("..");
			//await Shell.Current.GoToAsync($"{nameof(PageB)}");
		}

	}
}
