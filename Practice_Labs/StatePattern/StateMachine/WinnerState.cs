using System.Diagnostics;

namespace GumballMachine
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
            Debug.WriteLine("A gumball comes rolling out the slot.");
            _gbMachine.Inventory -= 2;
            if (_gbMachine.Inventory == 0)
            {
                Debug.WriteLine("Oops, out of gumballs.");
                _gbMachine.SetState(_gbMachine.GetSoldOutState());
            }
            else { _gbMachine.SetState(_gbMachine.GetNoQuarterState()); }
        }
    }
}