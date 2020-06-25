using Jobi.Helpers;
using Jobi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobsSearchPage : ContentPage
    {
        public JobsSearchItem JobSearchItem { get; set; }

        public JobsSearchPage()
        {
            InitializeComponent();

            JobSearchItem = new JobsSearchItem(App.UserDataStore.User);
            BindingContext = this;
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(JobSearchItem.SearchTerms))
            {
                await DisplayAlert("No search terms provided!", "You need to provide search terms to continue.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(JobSearchItem.Location))
            {
                await DisplayAlert("No location provided!", "You need to provide location to continue.", "OK");
                return;
            }

            await Navigation.PopModalAsync();
        }
    }
}