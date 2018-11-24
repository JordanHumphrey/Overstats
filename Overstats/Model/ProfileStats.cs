using System;
using System.Collections.Generic;
using System.Text;

namespace Overstats.Model
{
    namespace Profile
    {
        public class Awards
        {
            public int cards { get; set; }
            public int medals { get; set; }
            public int medalsBronze { get; set; }
            public int medalsSilver { get; set; }
            public int medalsGold { get; set; }
        }

        public class Games
        {
            public int played { get; set; }
            public int won { get; set; }
        }

        public class CompetitiveStats
        {
            public Awards awards { get; set; }
            public Games games { get; set; }
        }

        public class ProfileData
        {
            public CompetitiveStats competitiveStats { get; set; }
            public int endorsement { get; set; }
            public string endorsementIcon { get; set; }
            public int gamesWon { get; set; }
            public string icon { get; set; }
            public int level { get; set; }
            public string levelIcon { get; set; }
            public string name { get; set; }
            public int prestige { get; set; }
            public string prestigeIcon { get; set; }
            public int rating { get; set; }
            public string ratingIcon { get; set; }
        }
    }
    
}
