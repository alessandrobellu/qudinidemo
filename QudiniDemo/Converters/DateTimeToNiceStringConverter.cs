using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace QudiniDemo.Converters
{
	public class DateTimeToNiceStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			var str = value as string;
			DateTime date = DateTime.MinValue;
			DateTime.TryParse(str, out date);

			var totalMinutes = Math.Round((date - DateTime.Now).TotalMinutes, 0);

			if (totalMinutes < 0)
			{
				return String.Format("Expected {0} minutes ago", Math.Abs(totalMinutes));
			}
			else if (totalMinutes == 0)
			{
				return String.Format("Expected now");
			}
			else if (totalMinutes <= 60)
			{
				return String.Format("Expected in {0} minutes", totalMinutes);
			}
			else if (totalMinutes > 60)
			{
				return String.Format("Expected in {0} hours {1} minutes", (date - DateTime.Now).Hours, (date - DateTime.Now).Minutes);
			}

			return string.Format(str);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
