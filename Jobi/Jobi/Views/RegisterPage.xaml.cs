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
    public partial class RegisterPage : ContentPage
    {
        public User User { get; set; }

        public RegisterPage()
        {
            InitializeComponent();

            User = new User();
            BindingContext = this;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(User.Nickname))
            {
                await DisplayAlert("No nickname provided!", "You need to provide nickname to continue.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(User.SearchTerm))
            {
                await DisplayAlert("No search terms provided!", "You need to provide search terms to continue.", "OK");
                return;
            }
            else if (string.IsNullOrWhiteSpace(User.Location))
            {
                await DisplayAlert("No location provided!", "You need to provide location to continue.", "OK");
                return;
            }

            App.UserHelper.RegisterUser(User);
            await Navigation.PopModalAsync();
        }
    }
}