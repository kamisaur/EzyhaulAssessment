using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.StateSquid;

namespace EzyhaulAssessment.Core.Services
{
    public class GlobalSettingsService : IGlobalSettingsService
    {
        public int ItemAmount { get; set; } = 3;
        public int CacheExpiry { get; set; } = 1;
        public bool UseCache { get; set; } = true;
        public State TestingState { get; set; } = State.None;
    }
}
