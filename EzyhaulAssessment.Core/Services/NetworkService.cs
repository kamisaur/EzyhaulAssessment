using EzyhaulAssessment.Core.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

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

        public async Task<List<OfferDetail>> GetOfferDetails()
        {
            serverApiService = RestService.For<IServerApiService>(_baseUrl);


            // get OfferDetails from cache if no internet
            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {

            }

            //// get OfferDetails from cache if no internet
            //if (Connectivity.NetworkAccess == NetworkAccess.None)
            //        return Barrel.Current.Get<List<OfferDetail>>(key: _baseUrl);

            //// get OfferDetails from cache if cache is not expire
            //if (!Barrel.Current.IsExpired(key: _baseUrl))
            //    return Barrel.Current.Get<List<OfferDetail>>(key: _baseUrl);

            // get OfferDetails form api 
            try
            {
                var response = await serverApiService.GetJobInfo();
                //Barrel.Current.Add(key: _baseUrl, data: response, expireIn: TimeSpan.FromMinutes(5));
                return response;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }




    }

}
