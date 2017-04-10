using System.Diagnostics;

namespace StateMachine
{
    public class HasQuarterState : IState
    {
        private readonly GumballMachineContext _context;

        public HasQuarterState(GumballMachineContext gbm)
        {
            _context = gbm;
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("You can't insert another quarter.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Quarter Returned.");
            _context.SetState(_context.NoQuarterState);
        }

        /// <summary>
        /// This sets state to SOLD
        /// </summary>
        public void TurnCrank()
        {
            Debug.WriteLine("You turned...");
            _context.SetState(_context.SoldState);
        }

        public void Dispense()
        {
            // dispense should never be called in this state.
            Debug.WriteLine("No gumball dispensed");
        }
    }
}