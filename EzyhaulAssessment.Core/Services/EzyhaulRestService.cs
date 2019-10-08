using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EzyhaulAssessment.Core.Models;
using MvvmCross.Logging;
using Newtonsoft.Json;

namespace EzyhaulAssessment.Core.Services
{
	public class EzyhaulRestService : IEzyhaulRestService
	{
		string _baseUrl = "https://carrier-app-api.azurewebsites.net/api/data/offers?code=UwwoqV/ZrIXiUVZbvpRhCgxiujKqrAfSMxWkGGndjmJW8UOWD5xEvg==";
		HttpClient _client;

		private readonly IMvxLog _log;

		public EzyhaulRestService(IMvxLogProvider logProvider)
		{
			_log = logProvider.GetLogFor<EzyhaulRestService>();
			_client = new HttpClient();
		}


		public async Task<List<OfferDetail>> GetJobInfo()
		{
			try
			{

				var uri = new Uri(_baseUrl);
				var response = await _client.GetAsync(uri);
				if (response.StatusCode == System.Net.HttpStatusCode.OK)
				{
					_log.Warn(response.StatusCode.ToString());
					var content = await response.Content.ReadAsStringAsync();

					_log.Warn(content);

					var Items = JsonConvert.DeserializeObject<List<OfferDetail>>(content);
					return Items;
				}
				return new List<OfferDetail>();
			}
			catch (Exception ex)
			{
				_log.Warn(ex.StackTrace);
				return new List<OfferDetail>();
			}
		}
	}
}
