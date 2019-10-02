using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Presenters.Hints;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.ViewModels
{
	public class Tab3ViewModel : MvxNavigationViewModel
	{
		public Tab3ViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
		{
			//ShowRootViewModelCommand = new MvxAsyncCommand(async () => await NavigationService.Navigate<RootViewModel>());

			CloseViewModelCommand = new MvxAsyncCommand(async () => await NavigationService.Close(this));

			ShowPageOneCommand = new MvxCommand(() => NavigationService.ChangePresentation(new MvxPagePresentationHint(typeof(Tab1ViewModel))));
		}

		public IMvxAsyncCommand ShowRootViewModelCommand { get; private set; }

		public IMvxAsyncCommand CloseViewModelCommand { get; private set; }

		public IMvxCommand ShowPageOneCommand { get; private set; }
	}
}