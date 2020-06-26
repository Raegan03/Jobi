using Jobi.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jobi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            var viewModel = new RegisterViewModel(this, Navigation);
            BindingContext = viewModel;
        }
    }
}