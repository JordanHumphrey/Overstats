using Overstats.Model;
using Overstats.Model.Profile;
using Overstats.View;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Overstats
{
    public partial class App : Application
    {
        public static Player Player;
        public static string HttpRequestBattleTag = "";
        public static HttpResponseMessage response;
        public static ProfileData profileData;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BattleTagEntryScreen());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
