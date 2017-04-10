using System.Diagnostics;

namespace StateMachine
{
    public class NoQuarterState : AbstractState
    {

        public NoQuarterState(GumballMachineContext gbm) : base(gbm)
        {
        }

        public override void InsertQuarter()
        {
            _context.SetState(_context.GetHasQuarterState);
        }

        public override void EjectQuarter()
        {
            Debug.WriteLine("You haven't inserted a quarter.");
        }

        /// <summary>
        /// This wouldn't work without a quarter
        /// </summary>
        public override void TurnCrank()
        {
            Debug.WriteLine("You turned, but there's no quarter.");
        }

        public override void Dispense()
        {
            Debug.WriteLine("You need to pay first.");
        }
    }
}