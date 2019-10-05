using MvvmCross.ViewModels;
using System;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using System.Collections.Generic;
using System.Text;
using EzyhaulAssessment.Core.Services;
using EzyhaulAssessment.Core.Models;
using Xamarin.Forms.Extended;

namespace EzyhaulAssessment.Core.ViewModels
{

	public class JobsViewModel : MvxNavigationViewModel
	{
        IServerApiService _serverApiService;
        private const int PageSize = 6;
        private  int currentPage = 1;

        private InfiniteScrollCollection<OfferDetail> _items;
        public InfiniteScrollCollection<OfferDetail> Items
        {
            get => _items;
            set
            {
                _items = value;
				RaisePropertyChanged(() => Items);
            }
        }


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


               

                Items = new InfiniteScrollCollection<OfferDetail>
                {
                    OnLoadMore = async () =>
                    {
                        InfiniteScrollCollection<OfferDetail> tempList = new InfiniteScrollCollection<OfferDetail>();
                        // load the next page
                        var page = (Items.Count / PageSize);

                        for (int i = page; i < page * PageSize; i++)
                        {
                            tempList.Add(OfferDetails[i]);
                        }
                        return tempList;
                    },
                    OnCanLoadMore = () => Items.Count < OfferDetails.Count
                };

                for (int i = 0; i < 6; i++)
                    Items.Add(OfferDetails[i]);
            }
            catch (Exception ex)
            {

            }      
        }




    }
}
