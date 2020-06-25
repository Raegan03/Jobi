using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;
using Jobi.Models;

namespace Jobi.ViewModels
{
    public class JobsViewModel : BaseViewModel
    {
        public ObservableCollection<JobItem> JobItems { get; set; }
        public Command LoadItemsCommand { get; set; }

        public JobsSearchItem CurrentSearchItem { get; set; }

        public JobsViewModel()
        {
            Title = "Jobs";
            JobItems = new ObservableCollection<JobItem>(App.JobsDataStore.GetItems());
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            CurrentSearchItem = new JobsSearchItem(App.UserDataStore.User);
            MessagingCenter.Subscribe<JobsSearchItem>(this, "Search", 
                async (x) => await UpdateSearchItem(x));
        }

        private async Task UpdateSearchItem(JobsSearchItem newSearchItem)
        {
            CurrentSearchItem = newSearchItem;
            await ExecuteLoadItemsCommand();
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