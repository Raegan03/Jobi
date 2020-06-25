using Jobi.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobsSearchPage : ContentPage
    {
        public JobsSearchItem JobSearchItem { get; set; }

        public JobsSearchPage(JobsSearchItem jobsSearchItem)
        {
            InitializeComponent();

            JobSearchItem = jobsSearchItem;
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
            MessagingCenter.Send(JobSearchItem, "Search");
        }
    }
}