using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EzyhaulAssessment.Core.ViewModels
{
	public class TabsRootViewModel : MvxNavigationViewModel
	{
		public TabsRootViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
		{
			ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
		}

		public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }


		private async Task ShowInitialViewModels()
		{
			var tasks = new List<Task>();
			tasks.Add(NavigationService.Navigate<JobsViewModel>());
            tasks.Add(NavigationService.Navigate<ContactDispatchViewModel>());
			tasks.Add(NavigationService.Navigate<SettingsViewModel>());
			await Task.WhenAll(tasks);


        }



		private int _itemIndex;
		public int ItemIndex
		{
			get { return _itemIndex; }
			set
			{
				if (_itemIndex == value) return;
				_itemIndex = value;
				Log.Trace("Tab item changed to {0}", _itemIndex.ToString());
				RaisePropertyChanged(() => ItemIndex);
			}
		}
	}
}
