using System;
using System.ComponentModel;
using Xamarin.Forms;

using Jobi.Models;
using Jobi.ViewModels;

namespace Jobi.Views
{
    [DesignTimeVisible(false)]
    public partial class JobDetailPage : ContentPage
    {
        JobDetailViewModel viewModel;

        public JobDetailPage(JobDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public JobDetailPage()
        {
            InitializeComponent();

            var item = new JobItem();
            viewModel = new JobDetailViewModel(item);
            BindingContext = viewModel;
        }

        private void ApplyButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Sorry!", "Sorry, this feature wasn't implemented yet!", "OK");
        }
    }
}