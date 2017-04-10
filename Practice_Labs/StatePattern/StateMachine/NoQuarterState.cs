using System.Diagnostics;

namespace StateMachine
{
    public class NoQuarterState : IState
    {
        private readonly GumballMachine _gbMachine;

        public NoQuarterState(GumballMachine gbm)
        {
            _gbMachine = gbm;
        }

        public void InsertQuarter()
        {
            _gbMachine.SetState(_gbMachine.getHasQuarterState);
        }

        public void EjectQuarter()
        {
            Debug.WriteLine("You haven't inserted a quarter.");
        }

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