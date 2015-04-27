using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace QudiniDemo.Helpers
{
	public class VisualStateHelpers : DependencyObject
	{
		public static string GetVisualStateProperty(DependencyObject obj)
		{
			return (string)obj.GetValue(VisualStatePropertyProperty);
		}

		public static void SetVisualStateProperty(DependencyObject obj, string value)
		{
			obj.SetValue(VisualStatePropertyProperty, value);
		}

		public static readonly DependencyProperty VisualStatePropertyProperty =
			DependencyProperty.RegisterAttached("VisualStateProperty", typeof(string), typeof(VisualStateHelpers), new PropertyMetadata("", OnVisualStatePropertyChanged));
		
		private static void OnVisualStatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var propertyName = (string)e.NewValue;
			var ctrl = d as Control;

			if (ctrl != null)
			{
				VisualStateManager.GoToState(ctrl, (string)e.NewValue, true);
			}
		}
	}

}
