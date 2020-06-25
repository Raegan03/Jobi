using Xamarin.Forms;
using Jobi.Services;
using Jobi.Views;
using Jobi.Helpers;

namespace Jobi
{
    public partial class App : Application
    {
        public static UserHelper UserHelper { get; private set; }

        public App()
        {
            InitializeComponent();

            UserHelper = new UserHelper();

            DependencyService.Register<MockDataStore>();
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
