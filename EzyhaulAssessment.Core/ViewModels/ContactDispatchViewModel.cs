using System;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.ViewModels
{
	public class ContactDispatchViewModel : MvxNavigationViewModel
	{
		public ContactDispatchViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
		{
			CloseViewModelCommand = new MvxAsyncCommand(async () => await NavigationService.Close(this));

		}
		public IMvxAsyncCommand CloseViewModelCommand { get; private set; }
	}
}
