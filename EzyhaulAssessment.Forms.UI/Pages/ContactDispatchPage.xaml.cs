using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzyhaulAssessment.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EzyhaulAssessment.Forms.UI.Pages
{
	[MvxTabbedPagePresentation(WrapInNavigationPage = false)]
	public partial class ContactDispatchPage : MvxContentPage<ContactDispatchViewModel>
	{
		public ContactDispatchPage()
		{
			InitializeComponent();
		}
	}
}