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
using System.Threading.Tasks;
using Xamarin.Forms.StateSquid;
using Xamarin.Essentials;
using MvvmCross.Plugin.Messenger;
using EzyhaulAssessment.Core.Utilities;

namespace EzyhaulAssessment.Core.ViewModels
{

    public class JobsViewModel : MvxNavigationViewModel
    {
        INetworkService _networkService;
        IGlobalSettingsService _globalSettingsService;
        IMvxMessenger _messenger;

        private int ItemAmount = 6;

        private State _currentState;
        public State CurrentState
        {
            get => _currentState;
            set
            {
                _currentState = value;
                RaisePropertyChanged(() => CurrentState);
            }
        }


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


		private string _exMessage;
		public string ExMessage
		{
			get => _exMessage;
			set
			{
				_exMessage = value;
				RaisePropertyChanged(() => ExMessage);
			}
		}


		private List<OfferDetail> _offerDetails;
        public List<OfferDetail> OfferDetails
        {
            get => _offerDetails;
            set
            {
                _offerDetails = value;

                var countMessage = new ItemCountMessage(this, OfferDetails.Count);
                _messenger.Publish(countMessage);

                RaisePropertyChanged(() => OfferDetails);
            }
        }
      
        
        public JobsViewModel(
            IMvxLogProvider logProvider
            , IGlobalSettingsService globalSettingsService
            , IMvxNavigationService navigationService
            , IMvxMessenger messenger
            , INetworkService networkService) : base(logProvider, navigationService)
        {
            _networkService = networkService;
            _globalSettingsService = globalSettingsService;
            _messenger = messenger;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;


            CurrentState = State.Loading;

            OfferDetails = new List<OfferDetail>();
            Items = new InfiniteScrollCollection<OfferDetail>
            {
                OnLoadMore = async () => await PopulateList(),
                OnCanLoadMore = () => Items.Count < OfferDetails.Count
            };
        }


        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess == NetworkAccess.None || e.NetworkAccess == NetworkAccess.ConstrainedInternet)
            {

            }
            else if (e.NetworkAccess == NetworkAccess.Internet)
            {
                await GetOfferDetails();
            }
        }


        public async override void ViewAppeared()
        {
            base.ViewAppeared();

            var message = new TitleMessage(this, "Jobs");
            _messenger.Publish(message);


            await GetOfferDetails();

        }


        private async Task GetOfferDetails()
        {
            try
            {
                ItemAmount = _globalSettingsService.ItemAmount;

                if (_globalSettingsService.TestingState == State.None)
                {
                    CurrentState = State.Loading;

                    OfferDetails = await _networkService.GetOfferDetails();

                    Items.Clear();
                    await Items.LoadMoreAsync();

                    if (Items.Count > 0)
                        CurrentState = State.None;
                    else
                        CurrentState = State.Empty;

                }
                else
                {
                    CurrentState = _globalSettingsService.TestingState;
                }
            }
            catch (Exception ex)
            {
                CurrentState = State.Error;
            }
        }

        private async Task<InfiniteScrollCollection<OfferDetail>> PopulateList()
        {
            await Task.Delay(2000);

            InfiniteScrollCollection<OfferDetail> tempList = new InfiniteScrollCollection<OfferDetail>();
            var page = (Items.Count / ItemAmount);
            var startIndex = page * ItemAmount;

            var rangeList = OfferDetails.GetRange(startIndex, ItemAmount);
            tempList.AddRange(rangeList);
            return tempList;
        }


    }
}
