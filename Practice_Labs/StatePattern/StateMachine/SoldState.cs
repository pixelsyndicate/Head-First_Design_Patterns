using System.Diagnostics;

namespace GumballMachine
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

        public void Dispense()
        {
            Debug.WriteLine("A gumball comes rolling out the slot.");
            _gbMachine.Inventory -= 1;
            if (_gbMachine.Inventory == 0)
            {
                Debug.WriteLine("Oops, out of gumballs.");
                _gbMachine.SetState(_gbMachine.GetSoldOutState());
            }
            else
            {
                _gbMachine.SetState(_gbMachine.GetNoQuarterState());
            }
        }
    }
}