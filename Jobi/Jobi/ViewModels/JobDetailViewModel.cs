using System.Windows.Input;
using Jobi.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Jobi.ViewModels
{
    public class JobDetailViewModel : BaseViewModel
    {
        public JobItem Item { get; set; }
        public JobDetailViewModel(JobItem item = null)
        {
            Title = item?.Title;
            Item = item;
        }

        public ICommand HyperlinkCommand => new Command<string>(async (url) =>
        {
            await Launcher.OpenAsync(url);
        });
    }
}
