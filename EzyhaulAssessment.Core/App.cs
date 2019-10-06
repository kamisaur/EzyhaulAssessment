using EzyhaulAssessment.Core.Services;
using EzyhaulAssessment.Core.ViewModels;
using MonkeyCache.SQLite;
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
            Barrel.ApplicationId = "Ezyhaul_kk";
            Mvx.IoCProvider.RegisterType<INetworkService, NetworkService>();

            RegisterAppStart<TabsRootViewModel>();
		}
	}
}
