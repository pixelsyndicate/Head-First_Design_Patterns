using System.Diagnostics;

namespace StateMachine
{
    public class SoldState : IState
    {
        private readonly GumballMachine _gbMachine;

        public SoldState(GumballMachine gbm)
        {
            _gbMachine = gbm;
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("Please wait, we are dispensing a gumball.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Sorry, you already turned the crank.");
        }

        public void TurnCrank()
        {
            Debug.WriteLine("Turning twice doesn't get you a second gumball.");
        }

        /// <summary>
        /// The real work happens here, ask the machine toe release a gumball
        /// Then based on final inventory, set state to NoQuarter or SoldOut
        /// </summary>
        public void Dispense()
        {
            if (_gbMachine.Inventory > 0)
            {
                _gbMachine.ReleaseBall();
                _gbMachine.SetState(_gbMachine.getNoQuarterState);
            }
            else
            {
                Debug.WriteLine("Ooops. Out of gumballs!");
                _gbMachine.SetState(_gbMachine.getSoldOutState);
            }
        }
    }
}