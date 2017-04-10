using System.Diagnostics;

namespace StateMachine
{
    public class WinnerState : SoldState
    {
       
        // insert, eject and turn are the same as in SoldState
        //public void InsertQuarter()
        //public void EjectQuarter()
        //public void TurnCrank()

        public WinnerState(GumballMachineContext gbm) : base(gbm)
        {
        }


        public override void Dispense()
        {
            base.Dispense();
           // _context.ReleaseBall();
            if (_context.Inventory == 0)
            {
                _context.SetState(_context.GetSoldOutState);
            }
            else
            {
                // if have second gumball, then release it.
                _context.ReleaseBall();
                // if we did release a 2nd one, let the user know they are a winner.
                Debug.WriteLine("YOU'RE A WINNER! You got two gumballs for your quarter");
                if (_context.Inventory > 0)
                {
                    _context.SetState(_context.GetNoQuarterState);
                }
                else
                {
                    Debug.WriteLine("Oops, out of gumballs");
                    _context.SetState(_context.GetSoldOutState);
                }
            }
        }
    }
}