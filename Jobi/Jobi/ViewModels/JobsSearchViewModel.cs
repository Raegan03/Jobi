using Jobi.Helpers;
using Jobi.Models;
using Jobi.Services;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Jobi.ViewModels
{
    public class JobsSearchViewModel : ModalViewModel
    {
        public JobsSearchItem JobSearchItem { get; set; }

        private bool _showGeolocation;
        public bool ShowGeolocation
        {
            get => _showGeolocation;
            set => SetProperty(ref _showGeolocation, value);
        }

        private bool _showGeolocationButton = true;
        public bool ShowGeolocationButton
        {
            get => _showGeolocationButton;
            set => SetProperty(ref _showGeolocationButton, value);
        }

        private double _latitudeValue;
        public double LatitudeValue
        {
            get => _latitudeValue;
            set => SetProperty(ref _latitudeValue, value);
        }

        private double _longitudeValue;
        public double LongitudeValue
        {
            get => _longitudeValue;
            set => SetProperty(ref _longitudeValue, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand GeolocationCommand { get; }
        public ICommand BackCommand { get; }

        public JobsSearchViewModel(Page modalPage, INavigation navigation, JobsSearchItem jobsSearchItem)
            : base(modalPage, navigation)
        {
            JobSearchItem = jobsSearchItem;

            SearchCommand = new Command(SearchButtonCommand);
            GeolocationCommand = new Command(GeolocationButtonCommand);
            BackCommand = new Command(BackButtonCommand);
        }

        private async void SearchButtonCommand()
        {
            if (string.IsNullOrWhiteSpace(JobSearchItem.SearchTerms))
            {
                await modalPage.DisplayAlert("No search terms provided!", "You need to provide search terms to continue.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(JobSearchItem.Location) && JobSearchItem.Latitude == 0 && JobSearchItem.Longitude == 0)
            {
                await modalPage.DisplayAlert("No location provided!", "You need to provide location to continue.", "OK");
                return;
            }

            await navigation.PopModalAsync();
            MessagingCenter.Send(JobSearchItem, MessagingHelper.SearchMessage);
        }

        private async void GeolocationButtonCommand()
        {
            Location location;
            try
            {
                location = await LocationService.GetGeolocation();
            }
            catch (Exception ex)
            {
                await modalPage.DisplayAlert("Geolocation error!", ex.Message, "OK");
                return;
            }

            if (location == null)
            {
                await modalPage.DisplayAlert("Geolocation error!", "Location is null.", "OK");
                return;
            }

            JobSearchItem.Latitude = location.Latitude;
            JobSearchItem.Longitude = location.Longitude;
            JobSearchItem.UseGeolocation = true;

            LatitudeValue = JobSearchItem.Latitude;
            LongitudeValue = JobSearchItem.Longitude;

            ShowGeolocation = true;
            ShowGeolocationButton = false;
        }

        private async void BackButtonCommand()
        {
            JobSearchItem = null;
            await navigation.PopModalAsync();
        }
    }
}
