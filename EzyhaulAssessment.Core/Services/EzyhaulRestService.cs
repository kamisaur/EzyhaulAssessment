using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EzyhaulAssessment.Core.Models;
using Newtonsoft.Json;

namespace EzyhaulAssessment.Core.Services
{
	public class EzyhaulRestService : IEzyhaulRestService
	{
		string _baseUrl = "https://carrier-app-api.azurewebsites.net/api/data/offers?code=UwwoqV/ZrIXiUVZbvpRhCgxiujKqrAfSMxWkGGndjmJW8UOWD5xEvg==";
		HttpClient _client;


		public EzyhaulRestService()
		{
			_client = new HttpClient();
		}


		public async Task<List<OfferDetail>> GetJobInfo()
		{
			var uri = new Uri(_baseUrl);
			var response = await _client.GetAsync(uri);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var content = await response.Content.ReadAsStringAsync();
				var Items = JsonConvert.DeserializeObject<List<OfferDetail>>(content);
				return Items;
			}
			return null;
		}
	}
}
