using System.Diagnostics;

namespace StateMachine
{
    public class NoQuarterState : IState
    {
        private readonly GumballMachineContext _context;

        public NoQuarterState(GumballMachineContext gbm)
        {
            _context = gbm;
        }

        public void InsertQuarter()
        {
            _context.SetState(_context.GetHasQuarterState);
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("You haven't inserted a quarter.");
        }

        /// <summary>
        /// This wouldn't work without a quarter
        /// </summary>
        public void TurnCrank()
        {
            Debug.WriteLine("You turned, but there's no quarter.");
        }

        public void Dispense()
        {
            Debug.WriteLine("You need to pay first.");
        }
    }
}