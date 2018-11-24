using Overstats.ViewModel;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Overstats.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainMenuScreen : ContentPage
	{
		public MainMenuScreen ()
		{
			InitializeComponent ();
            MainMenuVM vm = new MainMenuVM();
            BindingContext = vm;
            vm.OpenCareerProfile += OpenCareerProfile;
		}

        private void OpenCareerProfile(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CareerProfileScreen());
        }
	}
}