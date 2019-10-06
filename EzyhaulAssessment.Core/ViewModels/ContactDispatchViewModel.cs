using System;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Plugin.Messenger;
using EzyhaulAssessment.Core.Utilities;

namespace EzyhaulAssessment.Core.ViewModels
{
	public class ContactDispatchViewModel : MvxNavigationViewModel
	{
        IMvxMessenger _messenger;

        public ContactDispatchViewModel(
            IMvxLogProvider logProvider
            , IMvxMessenger messenger
            , IMvxNavigationService navigationService) 
            : base(logProvider, navigationService)
		{
			CloseViewModelCommand = new MvxAsyncCommand(async () => await NavigationService.Close(this));
            _messenger = messenger;
        }


        public override void ViewAppeared()
        {
            var message = new TitleMessage(this, "Contact Dispatch");
            _messenger.Publish(message);
        }

        public IMvxAsyncCommand CloseViewModelCommand { get; private set; }
	}
}
