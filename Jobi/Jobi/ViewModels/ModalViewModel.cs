using Xamarin.Forms;

namespace Jobi.ViewModels
{
    public abstract class ModalViewModel : BaseViewModel
    {
        protected INavigation navigation;
        protected Page modalPage;

        public ModalViewModel(Page modalPage, INavigation navigation)
        {
            this.navigation = navigation;
            this.modalPage = modalPage;
        }
    }
}
