using Jobi.Models;
using Jobi.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JobsSearchPage : ContentPage
    {
        public JobsSearchPage(JobsSearchItem jobsSearchItem)
        {
            InitializeComponent();

            var viewModel = new JobsSearchViewModel(this, Navigation, jobsSearchItem);
            BindingContext = viewModel;
        }
    }
}