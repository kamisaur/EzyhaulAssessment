using EzyhaulAssessment.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EzyhaulAssessment.Core.Services
{
    public interface INetworkService
    {
        IServerApiService GetApiService();
        Task<List<OfferDetail>> GetOfferDetails();
    }
}
