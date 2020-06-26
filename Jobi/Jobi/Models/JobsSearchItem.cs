namespace Jobi.Models
{
    public class JobsSearchItem
    {
        public string SearchTerms { get; set; }

        public string Location { get; set; }

        public bool UseGeolocation { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public bool FullTime { get; set; }

        public JobsSearchItem() { }

        public JobsSearchItem(User user)
        {
            SearchTerms = user.SearchTerms;
            Location = user.Location;

            UseGeolocation = user.UseGeolocation;
            Latitude = user.Latitude;
            Longitude = user.Longitude;

            FullTime = user.FullTime;
        }
    }
}
