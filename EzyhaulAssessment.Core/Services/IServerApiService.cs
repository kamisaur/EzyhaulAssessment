using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EzyhaulAssessment.Core.Services
{
	public interface IServerApiService
	{
		[Get("/api/data/offers?code=UwwoqV/ZrIXiUVZbvpRhCgxiujKqrAfSMxWkGGndjmJW8UOWD5xEvg==")]
		Task<string> GetJobInfo();
	}
}
