using EzyhaulAssessment.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EzyhaulAssessment.Forms.UI.Pages
{
	[MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = false)]
	public partial class TabsRootPage : MvxTabbedPage<TabsRootViewModel>
	{
		public TabsRootPage()
		{
			InitializeComponent();

		}

		private bool _firstTime = true;

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (_firstTime)
			{
				ViewModel.ShowInitialViewModelsCommand.ExecuteAsync(null);
				_firstTime = false;
			}
		}

		protected override void OnViewModelSet()
		{
			base.OnViewModelSet();
		}
	}
}