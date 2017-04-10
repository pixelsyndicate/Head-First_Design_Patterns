using System;
using System.Diagnostics;

namespace StateMachine
{
    public class HasQuarterState : AbstractState
    {
        // private readonly GumballMachineContext _context;
        private readonly Random _rnd;
        private int _winner;

        // pu7tting the random chance to win code in the HasQuarterState, because that's where the crank is turned.

        public HasQuarterState(GumballMachineContext gbm) : base(gbm)
        {
            _rnd = new Random();
        }



        /// <summary>
        /// This sets state to SOLD
        /// </summary>
        public override void TurnCrank()
        {
            _winner = _rnd.Next(1, 10);
            Debug.WriteLine("You turned..." + this);
            if ((_winner == 1) && (_context.Inventory > 1)) { _context.SetState(_context.GetWinnerState); }
            else { _context.SetState(_context.GetSoldState); }
        }


        public override string ToString()
        {
            return $"{_winner}";
        }
    }
}