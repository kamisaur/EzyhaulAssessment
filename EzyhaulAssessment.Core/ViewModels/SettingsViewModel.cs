using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EzyhaulAssessment.Core.Services;
using EzyhaulAssessment.Core.Utilities;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using Xamarin.Forms.StateSquid;

namespace EzyhaulAssessment.Core.ViewModels
{
	public class SettingsViewModel : MvxNavigationViewModel
	{
        IMvxMessenger _messenger;

        private int _itemAmount;
        public int ItemAmount
        {
            get => _itemAmount;
            set
            {
                _itemAmount = value;
                RaisePropertyChanged(() => ItemAmount);
            }
        }


        private int _cacheExpiry;
        public int CacheExpiry
        {
            get => _cacheExpiry;
            set
            {
                _cacheExpiry = value;
                RaisePropertyChanged(() => CacheExpiry);
            }
        }


        private bool _useCache;
        public bool UseCache
        {
            get => _useCache;
            set
            {
                _useCache = value;
                RaisePropertyChanged(() => UseCache);
            }
        }


        private State _testState;
        public State TestState
        {
            get => _testState;
            set
            {
                _testState = value;
                RaisePropertyChanged(() => TestState);
            }
        }


        private List<string> _states;
        public List<string> States
        {
            get => _states;
            set
            {
                _states = value;
                RaisePropertyChanged(() => States);
            }
        }


        private string _selectedState;
        public string SelectedState
        {
            get => _selectedState;
            set
            {
                _selectedState = value;
                RaisePropertyChanged(() => SelectedState);
            }
        }

        IGlobalSettingsService _globalSettingsService;

        public SettingsViewModel(
            IMvxLogProvider logProvider
            , IGlobalSettingsService globalSettingsService
            , IMvxMessenger messenger
            , IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
		{
            _globalSettingsService = globalSettingsService;
            _messenger = messenger;

        }


        public override void ViewAppeared()
        {

            var message = new TitleMessage(this, "Settings");
            _messenger.Publish(message);


            ItemAmount = _globalSettingsService.ItemAmount;
            CacheExpiry = _globalSettingsService.CacheExpiry;
            UseCache = _globalSettingsService.UseCache;

            States = new List<string> { "None", "Loading", "Error", "Empty" };

            switch (_globalSettingsService.TestingState)
            {
                case State.None:
                    SelectedState = States[0];
                    break;
                case State.Loading:
                    SelectedState = States[1];
                    break;
                case State.Error:
                    SelectedState = States[2];
                    break;
                case State.Empty:
                    SelectedState = States[3];
                    break;
                default:
                    SelectedState = States[0];
                    break;
            }
        }


        public override void ViewDisappeared()
        {
            base.ViewDisappeared();

            if(ItemAmount == 0)
                ItemAmount = 1;
            
            if(CacheExpiry == 0)
                CacheExpiry = 1;


            _globalSettingsService.ItemAmount = ItemAmount;
            _globalSettingsService.CacheExpiry = CacheExpiry;
            _globalSettingsService.UseCache = UseCache;


            switch (SelectedState)
            {
                case "None":
                    _globalSettingsService.TestingState = State.None;
                    break;
                case "Loading":
                    _globalSettingsService.TestingState = State.Loading;
                    SelectedState = States[1];
                    break;
                case "Error":
                    _globalSettingsService.TestingState = State.Error;
                    break;
                case "Empty":
                    _globalSettingsService.TestingState = State.Empty;
                    break;
                default:
                    _globalSettingsService.TestingState = State.None;
                    break;
            }
        }


    }
}
