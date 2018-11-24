using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Overstats.Model
{
    public class Player : INotifyPropertyChanged
    {
        private string battleTag;
        public string BattleTag
        {
            get { return battleTag; }
            set { battleTag = value; OnPropertyChanged("BattleTag"); }
        }

        private string region;
        public string Region
        {
            get { return region; }
            set { region = value; }
        }

        private string platform;
        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
