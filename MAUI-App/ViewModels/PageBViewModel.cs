using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MAUI_App.Models;
using MAUI_App.ViewModels;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace MAUI_App.ViewModels
{
	public class PageBViewModel : ObservableObject, INotifyPropertyChanged
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
		public ObservableCollection<MealItem> mealItems { get; set; } = new ObservableCollection<MealItem>();
		public ObservableCollection<MealItem> selectedMealItems { get; set; } = new ObservableCollection<MealItem>();

		

		public PageBViewModel()
		{
			GetAllItems();
		}
		private void GetAllItems()
		{
			Task.Run(async () =>
			{
				IsRunning = true;

				//IsRunning = false;
				var json = @"[{
                            'MealItemId': 115,
                            'MealItemName': '🍎 Apple',
                            'UserName': null,
                            'IsChecked': false,
                            'Weight': 0
                        },
                        {
                            'MealItemId': 100,
                            'MealItemName': 'Almond milk',
                            'UserName': null,
                            'IsChecked': false,
                            'Weight': 0
                        },
                        {
                            'MealItemId': 2495,
                            'MealItemName': 'Amys : Enchilada w/Spanish Rice & Beans',
                            'UserName': null,
                            'IsChecked': false,
                            'Weight': 0
                        },
                        {
                            'MealItemId': 1352,
                            'MealItemName': 'Beans - Lentil',
                            'UserName': null,
                            'IsChecked': false,
                            'Weight': 0
                        },
                        {
                            'MealItemId': 1396,
                            'MealItemName': 'Beans - Lentils',
                            'UserName': null,
                            'IsChecked': false,
                            'Weight': 0
                        }]";

				var mealItemList = JsonConvert.DeserializeObject<List<MealItem>>(json);
				App.Current.Dispatcher.Dispatch(() =>
				{
					IsRunning = false;
					if (mealItemList?.Count > 0)
					{
						foreach (var mealItem in mealItemList)
						{
							mealItems.Add(mealItem);
						}
					}
				});
			});
		}
		
	}
}
