using System;
using System.Diagnostics;

namespace StateMachine
{
    public abstract class AbstractState : IState
    {
        protected GumballMachineContext _context;

        protected AbstractState(GumballMachineContext context)
        {
            _context = context;
        }

        public virtual void InsertQuarter()
        {
            Debug.WriteLine("You can't insert another quarter.");
        }

        public virtual void EjectQuarter()
        {
            Debug.WriteLine("Quarter Returned.");
            _context.SetState(_context.GetNoQuarterState);
        }

        public abstract void TurnCrank();

        public virtual void Dispense()
        {
            Debug.WriteLine("No gumball dispensed");
        }
    }
}