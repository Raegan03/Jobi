﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Jobi.Models;
using Jobi.ViewModels;
using System.Diagnostics;

namespace Jobi.Views
{
    [DesignTimeVisible(false)]
    public partial class JobsPage : ContentPage
    {
        JobsViewModel viewModel;

        public JobsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new JobsViewModel();

            if (!App.UserDataStore.IsUserRegistered) 
            {
                Task.Run(async () => await Navigation.PushModalAsync(new NavigationPage(new JobsSearchPage()))).Wait();
            }
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (JobItem)layout.BindingContext;
            await Navigation.PushAsync(new JobDetailPage(new JobDetailViewModel(item)));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (App.UserDataStore.IsUserRegistered && viewModel.JobItems.Count == 0)
                viewModel.IsBusy = true;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var jobsPage = new JobsSearchPage();
            await Navigation.PushAsync(new NavigationPage(jobsPage));
        }
    }
}