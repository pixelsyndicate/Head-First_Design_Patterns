using System.Diagnostics;

namespace GumballMachine
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
            _gbMachine.SetState(_gbMachine.GetHasQuarterState());
        }

        public void TurnCrank()
        {
            Debug.WriteLine("You turned...");
            _gbMachine.SetState(_gbMachine.GetSoldState());
            Dispense();
        }

        public void Dispense()
        {
           
        }
    }
}