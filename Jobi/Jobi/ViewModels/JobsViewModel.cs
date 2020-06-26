using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Jobi.Models;
using Jobi.Helpers;

namespace Jobi.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {
        public ObservableCollection<JobItem> JobItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public JobsSearchItem CurrentSearchItem { get; set; }

        public JobsViewModel()
        {
            Title = string.Format("Hello, {0}", App.UserDataStore.IsUserRegistered ? App.UserDataStore.User.Nickname : string.Empty);
            JobItems = new ObservableCollection<JobItem>(App.JobsDataStore.GetItems());
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            CurrentSearchItem = new JobsSearchItem(App.UserDataStore.User);
            MessagingCenter.Subscribe<JobsSearchItem>(this, MessagingHelper.SearchMessage,
                async (x) => await UpdateSearchItem(x));

            MessagingCenter.Subscribe<User>(this, MessagingHelper.RegisteredMessage,
                async (x) => await UserRegistered(x));
        }

        private async Task UpdateSearchItem(JobsSearchItem newSearchItem)
        {
            CurrentSearchItem = newSearchItem;
            await ExecuteLoadItemsCommand();
        }

        private async Task UserRegistered(User newUser)
        {
            Title = string.Format("Hello, {0}", newUser.Nickname);
            await UpdateSearchItem(new JobsSearchItem(newUser));
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                JobItems.Clear();
                var items = await App.JobsDataStore.FetchItems(CurrentSearchItem);
                foreach (var item in items)
                {
                    JobItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}