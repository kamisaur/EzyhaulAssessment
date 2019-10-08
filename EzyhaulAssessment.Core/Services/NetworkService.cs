using EzyhaulAssessment.Core.Models;
using MonkeyCache.SQLite;
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
        IGlobalSettingsService _globalSettingsService;
		EzyhaulRestService _ezserv;


		public NetworkService(IGlobalSettingsService globalSettingsService)
        {
            _globalSettingsService = globalSettingsService;


			_ezserv = new EzyhaulRestService();
		}

        public IServerApiService GetApiService()
        {
            serverApiService = RestService.For<IServerApiService>(_baseUrl);
            return serverApiService;
        }

        public async Task<List<OfferDetail>> GetOfferDetails()
        {


            if (_globalSettingsService.UseCache)
            {
                // get OfferDetails from cache if no internet
                if (Connectivity.NetworkAccess == NetworkAccess.None || Connectivity.NetworkAccess == NetworkAccess.ConstrainedInternet)
                    return Barrel.Current.Get<List<OfferDetail>>(key: _baseUrl);


                // get OfferDetails from cache if cache is not expire
                if (!Barrel.Current.IsExpired(key: _baseUrl))
                    return Barrel.Current.Get<List<OfferDetail>>(key: _baseUrl);
            }

            // get OfferDetails form api 
            try
            {
				var response = await _ezserv.GetJobInfo();
				Barrel.Current.Add(key: _baseUrl, data: response, expireIn: TimeSpan.FromMinutes(_globalSettingsService.CacheExpiry));
                return response;



				//serverApiService = RestService.For<IServerApiService>(_baseUrl);
    //            var response = await serverApiService.GetJobInfo();
				//Barrel.Current.Add(key: _baseUrl, data: response, expireIn: TimeSpan.FromMinutes(_globalSettingsService.CacheExpiry));
    //            return response;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }




    }

}
