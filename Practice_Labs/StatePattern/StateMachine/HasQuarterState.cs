using System.Diagnostics;

namespace StateMachine
{
    public class HasQuarterState : IState
    {
        private readonly GumballMachine _gbMachine;

        public HasQuarterState(GumballMachine gbm)
        {
            _gbMachine = gbm;
        }
        public void InsertQuarter()
        {
            Debug.WriteLine("You can't insert another quarter.");
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("Quarter Returned.");
            _gbMachine.SetState(_gbMachine.getNoQuarterState);
        }

        public void TurnCrank()
        {
            Debug.WriteLine("You turned...");
            _gbMachine.SetState(_gbMachine.getSoldState);
        }

        public void Dispense()
        {
            // dispense should never be called in this state.
            Debug.WriteLine("No gumball dispensed");
        }
    }
}