using EzyhaulAssessment.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EzyhaulAssessment.Core.Services
{
	public class ServerApiService : IServerApiService
	{
		IServerApiService serverApiService;

		public ServerApiService()
		{
			serverApiService = RestService.For<IServerApiService>("https://carrier-app-api.azurewebsites.net");
		}

		public async Task<List<OfferDetail>> GetJobInfo()
		{
			return await serverApiService.GetJobInfo();
		}
	}
}
