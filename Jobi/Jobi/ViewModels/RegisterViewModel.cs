using Jobi.Helpers;
using Jobi.Models;
using Jobi.Services;
using Jobi.Views;
using System;
using System.Linq;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Jobi.ViewModels
{
    public class RegisterViewModel : ModalViewModel
    {
        public User User { get; set; }

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

        public ICommand RegisterCommand { get; }
        public ICommand GeolocationCommand { get; }

        public RegisterViewModel(Page modalPage, INavigation navigation) 
            : base(modalPage, navigation)
        {
            User = new User();

            RegisterCommand = new Command(RegisterButtonCommand);
            GeolocationCommand = new Command(GeolocationButtonCommand);
        }

        private async void RegisterButtonCommand()
        {
            if (string.IsNullOrWhiteSpace(User.Nickname))
            {
                await modalPage.DisplayAlert("No nickname provided!", "You need to provide nickname to continue.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(User.SearchTerms))
            {
                await modalPage.DisplayAlert("No search terms provided!", "You need to provide search terms to continue.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(User.Location) && User.Latitude == 0 && User.Longitude == 0)
            {
                await modalPage.DisplayAlert("No location provided!", "You need to provide location to continue.", "OK");
                return;
            }

            App.UserDataStore.RegisterUser(User);
            await navigation.PopModalAsync();

            var mainPage = Application.Current.MainPage as TabbedPage;
            mainPage.CurrentPage = mainPage.Children[0];

            MessagingCenter.Send(User, MessagingHelper.RegisteredMessage);
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

            User.Latitude = location.Latitude;
            User.Longitude = location.Longitude;
            User.UseGeolocation = true;

            LatitudeValue = User.Latitude;
            LongitudeValue = User.Longitude;

            ShowGeolocation = true;
            ShowGeolocationButton = false;
        }
    }
}
