using System.Diagnostics;

namespace StateMachine
{
    public class WinnerState : IState
    {
        private GumballMachine _gbMachine;

        public WinnerState(GumballMachine gbm)
        {
            _gbMachine = gbm;
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("Please wait, we are dispensing your winnings.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Sorry, you already turned the crank... AND WON!");
        }

        public void TurnCrank()
        {
            Debug.WriteLine("Turning twice doesn't get you a second chance to win.");
        }

        public void Dispense()
        {
        }
    }
}