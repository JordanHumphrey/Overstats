using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Overstats.ViewModel.Commands
{
    public class FastTrackCommand : ICommand
    {
        MainMenuVM VM { get; set; }

        public FastTrackCommand(MainMenuVM vm)
        {
            VM = vm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.ProceedCareerProfile();
        }
    }
}
