using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.StateSquid;

namespace EzyhaulAssessment.Core.Services
{
    public interface IGlobalSettingsService
    {

        int ItemAmount { get; set; }
        int CacheExpiry { get; set; }
        bool UseCache { get; set; }
        State TestingState { get; set; }
    }
}
