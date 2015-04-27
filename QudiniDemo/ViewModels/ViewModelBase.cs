using QudiniDemo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace QudiniDemo.ViewModels
{
	/// <summary>
	/// A basic implementation of INotifyPropertyChanged used as base class for ViewModels
	/// </summary>
	public class ViewModelBase : INotifyPropertyChanged
	{
		#region NotifyPropertyChanged Interface
		// Interface needed to notify the View of property changes
		public void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
            DispatcherHelper.InvokeOnUIThread((Action)(() =>
            {
                PropertyChangedEventHandler handler = PropertyChanged;

                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		#endregion
	}
}
