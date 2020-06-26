using Xamarin.Forms;
using Jobi.Services;
using Jobi.Views;
using Jobi.Helpers;

namespace Jobi
{
    public partial class App : Application
    {
        public static ApiService ApiHelper;
        public static UserDataStore UserDataStore;
        public static JobsDataStore JobsDataStore;

        public App()
        {
            ApiHelper = new ApiService();
            UserDataStore = new UserDataStore();
            JobsDataStore = new JobsDataStore();

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
