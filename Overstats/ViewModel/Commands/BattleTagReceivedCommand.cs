using System;
using System.Windows.Input;

namespace Overstats.ViewModel.Commands
{
    public class BattleTagReceivedCommand : ICommand
    {
        public MainMenuVM VM { get; set; }
        public event EventHandler CanExecuteChanged;

        public BattleTagReceivedCommand(MainMenuVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            VM.CheckValidBattleTag();
            if (App.response.IsSuccessStatusCode)
                VM.ProceedToMainMenu();
            else
                return;
        }
    }
}
