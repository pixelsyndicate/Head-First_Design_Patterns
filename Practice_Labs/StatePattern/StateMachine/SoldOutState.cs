using System.Diagnostics;

namespace StateMachine
{
    public class SoldOutState : IState
    {
        private GumballMachineContext _context;

        public SoldOutState(GumballMachineContext gbm)
        {
            _context = gbm;
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("You can't insert a quarter, the machine is sold out.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Sorry, you can't eject, you haven't inserted a quarter yet.");
        }

        /// <summary>
        /// This wouldn't work with it sold out
        /// </summary>
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