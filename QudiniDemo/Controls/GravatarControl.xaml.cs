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
	public sealed partial class GravatarControl : UserControl
	{
		public GravatarControl()
		{
			this.InitializeComponent();

			LayoutRoot.DataContext = this;
			VisualStateManager.GoToState(this, "DefaultState", true);
		}
		
		public ImageSource ActualImage
		{
			get { return (ImageSource)GetValue(ActualImageProperty); }
			set { SetValue(ActualImageProperty, value); }
		}		
		public static readonly DependencyProperty ActualImageProperty =
			DependencyProperty.Register("ActualImage", typeof(ImageSource), typeof(GravatarControl), new PropertyMetadata(null));
				

		public ImageSource DefaultImage
		{
			get { return (ImageSource)GetValue(DefaultImageProperty); }
			set { SetValue(DefaultImageProperty, value); }
		}		
		public static readonly DependencyProperty DefaultImageProperty =
			DependencyProperty.Register("DefaultImage", typeof(ImageSource), typeof(GravatarControl), new PropertyMetadata(null));


		private void ImageOpenedHandler(object sender, RoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, "ActualState", true);
		}

		private void ImageFailedHandler(object sender, ExceptionRoutedEventArgs e)
		{
			VisualStateManager.GoToState(this, "DefaultState", true);
		}
	}
}
