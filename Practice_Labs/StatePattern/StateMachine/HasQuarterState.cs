using System;
using System.Diagnostics;

namespace StateMachine
{
    public class HasQuarterState : IState
    {
        private readonly GumballMachineContext _context;
        private readonly Random _rnd;
        private int _winner;

        // pu7tting the random chance to win code in the HasQuarterState, because that's where the crank is turned.

        public HasQuarterState(GumballMachineContext gbm)
        {
            _context = gbm;
            _rnd = new Random();
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("You can't insert another quarter.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Quarter Returned.");
            _context.SetState(_context.GetNoQuarterState);
        }

        /// <summary>
        /// This sets state to SOLD
        /// </summary>
        public void TurnCrank()
        {
            Debug.WriteLine("You turned...");
            _winner = _rnd.Next(1,10);
            Debug.WriteLine($"Rolled a {_winner}");
            if((_winner == 1) && (_context.Inventory > 1)) { _context.SetState(_context.GetWinnerState);}
            else { _context.SetState(_context.GetSoldState);}
        }

        public void Dispense()
        {
            // dispense should never be called in this state.
            Debug.WriteLine("No gumball dispensed");
        }

        public override string ToString()
        {
            return $"{_winner}";
        }
    }
}