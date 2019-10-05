using MvvmCross.ViewModels;
using System;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using System.Collections.Generic;
using System.Text;
using EzyhaulAssessment.Core.Services;
using EzyhaulAssessment.Core.Models;

namespace EzyhaulAssessment.Core.ViewModels
{

	public class JobsViewModel : MvxNavigationViewModel
	{
        IServerApiService _serverApiService;

        private List<OfferDetail> _offerDetails;
        public List<OfferDetail> OfferDetails
        {
            get => _offerDetails;
            set
            {
                _offerDetails = value;
				RaisePropertyChanged(() => OfferDetails);
            }
        }

        public JobsViewModel(
            IMvxLogProvider logProvider
            , IMvxNavigationService navigationService
            , IServerApiService serverApiService) : base(logProvider, navigationService)
		{
            _serverApiService = serverApiService;
        }


        public async override void ViewAppeared()
        {
            base.ViewAppeared();

            try
            {
                OfferDetails = await _serverApiService.GetJobInfo();

            }
            catch (Exception ex)
            {

            }      
        }




    }
}
