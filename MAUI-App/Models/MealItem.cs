using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI_App.Models
{
	public class MealItem
	{
		public int MealItemId { get; set; }
		public string MealItemName { get; set; }
		public string UserName { get; set; }
		public bool? IsChecked { get; set; }
		public int? Weight { get; set; }
	}
}
