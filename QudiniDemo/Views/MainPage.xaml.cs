using QudiniDemo.ViewModels;
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

namespace QudiniDemo.Views
{
	public sealed partial class MainPage : Page
	{
		private MainViewModel viewModel;

		public MainPage()
		{
			this.InitializeComponent();

			// Linking the View with the ViewModel
			viewModel = new MainViewModel();
			this.DataContext = viewModel;
		}

		protected override async void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			// Initializing the ViewModel
			await viewModel.InitAsync();
		}
	}
}
