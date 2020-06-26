using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Jobi.Services
{
    public static class LocationService
    {
        public static async Task<Location> GetGeolocation()
        {
            Location location;
            try
            {
                location = await Geolocation.GetLastKnownLocationAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return location;
        }
    }
}
