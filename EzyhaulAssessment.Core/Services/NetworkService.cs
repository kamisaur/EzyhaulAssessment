using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.Services
{
    public class NetworkService : INetworkService
    {
        string _baseUrl = "https://carrier-app-api.azurewebsites.net";
        IServerApiService serverApiService;

        public IServerApiService GetApiService()
        {
            serverApiService = RestService.For<IServerApiService>(_baseUrl);
            return serverApiService;
        }



    }

}
