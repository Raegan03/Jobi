using Jobi.ViewModels;
using System.ComponentModel;

using Xamarin.Forms;

namespace Jobi.Views
{
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            var viewModel = new AboutViewModel(Navigation);
            BindingContext = viewModel;
        }
    }
}