using System.Diagnostics;

namespace StateMachine
{
    public class WinnerState : IState
    {
        private GumballMachineContext _context;

        public WinnerState(GumballMachineContext gbm)
        {
            _context = gbm;
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