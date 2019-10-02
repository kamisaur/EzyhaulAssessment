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
	[MvxTabbedPagePresentation(WrapInNavigationPage = false, Title = "Tab1")]
	public partial class Tab1Page : MvxContentPage<Tab1ViewModel>
	{
		public Tab1Page()
		{
			InitializeComponent();
		}
	}
}