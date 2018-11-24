using Overstats.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Overstats.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BattleTagEntryScreen : ContentPage
	{
		public BattleTagEntryScreen ()
		{            
			InitializeComponent ();
            MainMenuVM vm = new MainMenuVM();
            BindingContext = vm;
            vm.OpenMainMenu += OpenMainMenu;
        }

        #region Event Handlers
        private void OpenMainMenu(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainMenuScreen());
        }
        #endregion
    }
}