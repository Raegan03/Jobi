using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Jobi.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About Jobi";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://jobs.github.com/positions)"));
        }

        public ICommand OpenWebCommand { get; }
    }
}