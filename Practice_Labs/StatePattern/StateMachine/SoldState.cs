using System.Diagnostics;

namespace StateMachine
{
    public class SoldState : AbstractState
    {

        public SoldState(GumballMachineContext gbm) : base(gbm)
        {
        }


        public override void EjectQuarter()
        {
            Debug.WriteLine("Sorry, you already turned the crank.");
        }

        /// <summary>
        /// This wouldn't work since you already got your gumball
        /// </summary>
        public override void TurnCrank()
        {
            Debug.WriteLine("Turning twice doesn't get you a second gumball.");
        }

        /// <summary>
        /// The real work happens here, ask the machine toe release a gumball
        /// Then based on final inventory, set state to NoQuarter or SoldOut
        /// </summary>
        public override void Dispense()
        {
            if (_context.Inventory > 0)
            {
                _context.ReleaseBall();
                _context.SetState(_context.GetNoQuarterState);
            }
            else
            {
                Debug.WriteLine("Ooops. Out of gumballs!");
                _context.SetState(_context.GetSoldOutState);
            }
        }
    }
}