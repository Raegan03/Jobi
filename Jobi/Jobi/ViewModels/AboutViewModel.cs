using Jobi.Views;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Essentials;
using Xamarin.Forms;

namespace Jobi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public ICommand OpenWebCommand { get; }
        public ICommand FlushUserCommand { get; }

        private INavigation navigation;

        public AboutViewModel(INavigation navigation)
        {
            this.navigation = navigation;

            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://jobs.github.com/positions)"));

            FlushUserCommand = new Command(async () => await FlushUser());
        }

        private async Task FlushUser()
        {
            App.UserDataStore.FlushUser();
            await navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
        }
    }
}