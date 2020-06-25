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

        private JobsSearchItem

        public JobsViewModel()
        {
            Title = "Jobs";
            JobItems = new ObservableCollection<JobItem>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                var jobsSearchItem = new JobsSearchItem(App.UserDataStore.User);
                JobItems.Clear();

                var items = await App.ApiHelper.GetJobsAsync(jobsSearchItem);
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