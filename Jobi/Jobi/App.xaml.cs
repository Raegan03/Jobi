using Xamarin.Forms;
using Jobi.Services;
using Jobi.Views;
using Jobi.Helpers;

namespace Jobi
{
    public partial class App : Application
    {
        public static ApiHelper ApiHelper;
        public static UserDataStore UserDataStore;

        public App()
        {
            ApiHelper = new ApiHelper();
            UserDataStore = new UserDataStore();

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
