using EzyhaulAssessment.Core.Services;
using EzyhaulAssessment.Core.ViewModels;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			Mvx.IoCProvider.RegisterType<IServerApiService, ServerApiService>();

			RegisterAppStart<TabsRootViewModel>();
		}
	}
}
