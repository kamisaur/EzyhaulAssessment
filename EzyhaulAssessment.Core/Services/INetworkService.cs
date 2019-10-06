using System;
using System.Collections.Generic;
using System.Text;

namespace EzyhaulAssessment.Core.Services
{
    public interface INetworkService
    {
        IServerApiService GetApiService();
        //Task<List<OfferDetail>> GetOfferDetails();
    }
}
