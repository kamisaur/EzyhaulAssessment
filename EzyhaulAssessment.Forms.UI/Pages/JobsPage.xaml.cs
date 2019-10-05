using System;
using System.Collections.Generic;
using System.Linq;
using EzyhaulAssessment.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EzyhaulAssessment.Forms.UI.Pages
{
	[MvxTabbedPagePresentation(WrapInNavigationPage = true)]
	public partial class JobsPage : MvxContentPage<JobsViewModel>
	{
		public JobsPage()
		{
			InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
		}

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lv = sender as ListView;
            lv.SelectedItem = null;
        }


    }
}