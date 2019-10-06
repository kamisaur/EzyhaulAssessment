using EzyhaulAssessment.Core.Utilities;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace EzyhaulAssessment.Core.ViewModels
{
	public class TabsRootViewModel : MvxNavigationViewModel
	{
        IMvxMessenger _messenger;
        private readonly MvxSubscriptionToken _token;
        private readonly MvxSubscriptionToken _tokenCountMessage;


        private string _itemsCount;
        public string ItemsCount
        {
            get => _itemsCount;
            set
            {
                _itemsCount = value;
                RaisePropertyChanged(() => ItemsCount);
            }
        }

        private string _titleName;
        public string TitleName
        {
            get => _titleName;
            set
            {
                _titleName = value;
                RaisePropertyChanged(() => TitleName);
            }
        }


        private bool _showToolbarIcons;
        public bool ShowToolbarIcons
        {
            get => _showToolbarIcons;
            set
            {
                _showToolbarIcons = value;
                RaisePropertyChanged(() => ShowToolbarIcons);
            }
        }


        public TabsRootViewModel(
            IMvxLogProvider logProvider
            , IMvxMessenger messenger
            , IMvxNavigationService navigationService)
            : base(logProvider, navigationService)
		{
			ShowInitialViewModelsCommand = new MvxAsyncCommand(ShowInitialViewModels);
            _messenger = messenger;
            _token = _messenger.Subscribe<TitleMessage>(OnTitleMessage);
            _tokenCountMessage = _messenger.Subscribe<ItemCountMessage>(OnCountMessage);

        }

        private void OnCountMessage(ItemCountMessage obj)
        {
            ItemsCount = $"Total {obj.Count}";
        }

        private void OnTitleMessage(TitleMessage obj)
        {
            TitleName = obj.Title;

            if(TitleName == "Jobs")
                ShowToolbarIcons = true;
            else
                ShowToolbarIcons = false;

        }

        public IMvxAsyncCommand ShowInitialViewModelsCommand { get; private set; }


		private async Task ShowInitialViewModels()
		{
			var tasks = new List<Task>();
			tasks.Add(NavigationService.Navigate<JobsViewModel>());
            tasks.Add(NavigationService.Navigate<ContactDispatchViewModel>());
			tasks.Add(NavigationService.Navigate<SettingsViewModel>());
			await Task.WhenAll(tasks);


        }



		private int _itemIndex;
		public int ItemIndex
		{
			get { return _itemIndex; }
			set
			{
				if (_itemIndex == value) return;
				_itemIndex = value;
				Log.Trace("Tab item changed to {0}", _itemIndex.ToString());
				RaisePropertyChanged(() => ItemIndex);
			}
		}
	}
}
