using Newtonsoft.Json;
using Overstats.Model;
using Overstats.Model.Profile;
using Overstats.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Overstats.ViewModel
{
    public class MainMenuVM
    {
        private Player player;

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        public MainMenuVM()
        {
            Player = new Player();
            BattleTagReceivedCommand = new BattleTagReceivedCommand(this);
            FastTrackCommand = new FastTrackCommand(this);
        }

        #region Commands
        public BattleTagReceivedCommand BattleTagReceivedCommand { get; set; }
        public FastTrackCommand FastTrackCommand { get; set; }
        #endregion

        #region Event Handlers
        public event EventHandler OpenMainMenu;
        public event EventHandler OpenCareerProfile;
        #endregion

        #region Member Functions
        public void ProceedToMainMenu()
        {
            OpenMainMenu(this, new EventArgs());
        }

        public void ProceedCareerProfile()
        {
            OpenCareerProfile(this, new EventArgs());
        }

        public async void CheckValidBattleTag()
        {
            /*
             * Validate the entered battle tag to the OW-API server
             */
            if (Player.BattleTag != null &&
                Player.Region != null &&
                Player.Platform != null)
            {
                // Assemble Http Request string
                App.Player = Player;
                App.HttpRequestBattleTag += "https://ow-api.com/v1/stats/" +
                    Player.Platform.ToLower() +
                    "/" +
                    Player.Region.ToLower() +
                    "/" + 
                    Player.BattleTag + 
                    "/";
#if DEBUG
                Debug.Assert(App.HttpRequestBattleTag == String.Empty, 
                    "HttpRequest is Empty",
                    "App.HttpRequestBattleTag Failed Null Check in " +
                        System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif

                // Get the response message from OW-API,
                // If failure, return nothing.
                HttpClient httpClient = new HttpClient();
                try
                {
                    var response = Task.Run(async () => { App.response = await httpClient.GetAsync(App.HttpRequestBattleTag + "profile"); });
                    response.Wait();
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debug.WriteLine("Http.GetAsync threw exception:\n" + ex.ToString());
#endif
                    return;
                }
                
                // Check that the server found the player, if not, return immedietely 
                if(!App.response.IsSuccessStatusCode)
                {
#if DEBUG
                    Debug.WriteLine("HttpRequest Response Code Returned Not Success in " +
                        System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
                    return;
                }

                // Convert response string to viewable ProfileData object
                var responseString = await App.response.Content.ReadAsStringAsync();
                App.profileData = JsonConvert.DeserializeObject<ProfileData>(responseString);
#if DEBUG
                string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
                Debug.Assert(App.profileData == null, "ProfileData JsonConvert Failed in " +
                    methodName);
#endif

            }
        }
        #endregion
    }
}
