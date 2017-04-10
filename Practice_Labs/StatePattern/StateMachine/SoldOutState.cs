using System.Diagnostics;

namespace StateMachine
{
    public class SoldOutState : IState
    {
        private GumballMachine _gbMachine;

        public SoldOutState(GumballMachine gbm)
        {
            _gbMachine = gbm;
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("You can't insert a quarter, the machine is sold out.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Sorry, you can't eject, you haven't inserted a quarter yet.");
        }

        public void TurnCrank()
        {
            Debug.WriteLine("You turned, but there are no gumballs.");
        }

        public void Dispense()
        {
            Debug.WriteLine("No gumball dispensed.");
        }

        public override string ToString()
        {
            return "Sold Out";
        }
    }
}