using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace QudiniDemo.Controls
{
	public sealed partial class CountdownControl : UserControl
	{
		public CountdownControl()
		{
			this.InitializeComponent();
			this.LayoutRoot.DataContext = this;

			VisualStateManager.GoToState(this, "Loading", false);
		}
		
		public bool IsLoading
		{
			get { return (bool)GetValue(IsLoadingProperty); }
			set { SetValue(IsLoadingProperty, value); }
		}

		public static readonly DependencyProperty IsLoadingProperty =
			DependencyProperty.Register("IsLoading", typeof(bool), typeof(CountdownControl), new PropertyMetadata(true, OnIsLoadingPropertyChanged));

		private static void OnIsLoadingPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctrl = d as CountdownControl;
			if (ctrl != null)
			{
				VisualStateManager.GoToState(ctrl, ((bool)e.NewValue) ? "Loading" : "Countdown", true);
			}
		}
	}
}
