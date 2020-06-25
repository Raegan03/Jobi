using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Jobi.Models;
using Jobi.ViewModels;

namespace Jobi.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
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
    }
}