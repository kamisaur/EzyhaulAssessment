using MvvmCross.ViewModels;
using System;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.ViewModels
{

	public class JobsViewModel : MvxNavigationViewModel
	{
		public JobsViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService) : base(logProvider, navigationService)
		{

		}
	}
}
