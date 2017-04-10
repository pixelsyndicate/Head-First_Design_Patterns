namespace GumballMachine
{
    /// <summary>
    /// Upgraded version of Gumball Machine now uses IState instances.
    /// It will also be passed as a reference parameter for the State implimentations
    /// </summary>
    public interface IGumballMachine
    {

        // todo: other methods like toString() and refill()
        string ToString();

        IState GetHasQuarterState();
        IState GetNoQuarterState();
        IState GetSoldOutState();
        IState GetSoldState();
        IState GetWinnerState();

        void SetState(IState newState);

        void InsertQuarter();
        void EjectQuarter();
        void TurnCrank();
        void ReleaseBall();

    }

    public class GumballMachine : IGumballMachine
    {
        private int _count = 0;
        private static IState _soldOutState;
        private static IState _soldState;
        private static IState _noQuarterState;
        private static IState _hasQuarterState;
        private static IState _winnerState;

        private IState _state;

        public int Inventory { get { return _count; } set { _count = value; } }

        public GumballMachine(int count)
        {
            _count = count;
            _soldOutState = new SoldOutState(this);
            _soldState = new SoldState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _winnerState = new WinnerState(this);
            _state = count > 0 ? _noQuarterState : _soldOutState;
        }

        public GumballMachine(int count, IState soldOutState, IState soldState, IState noQuarterState, IState hasQuarterState, IState winnerState)
        {
            _count = count;
            _soldOutState = soldOutState;
            _soldState = soldState;
            _noQuarterState = noQuarterState;
            _hasQuarterState = hasQuarterState;
            _winnerState = winnerState;
            if (count > 0) { }
        }
        public override string ToString()
        {
            return _count.ToString();
        }

        public IState GetHasQuarterState()
        {
            return new HasQuarterState(this);
        }

        public IState GetNoQuarterState()
        {
            return new NoQuarterState(this);
        }

        public IState GetSoldOutState()
        {
            return new SoldOutState(this);
        }

        public IState GetSoldState()
        {
            return new SoldState(this);
        }

        public IState GetWinnerState()
        {
            return new WinnerState(this);
        }

        public void SetState(IState newState)
        {
            _state = newState;
        }

        public void InsertQuarter()
        {
            _state.InsertQuarter();
        }

        public void EjectQuarter()
        {
            _state.EjectQuarter();
        }

        public void TurnCrank()
        {
            _state.TurnCrank();
            _state.Dispense();
        }

        public void ReleaseBall()
        {
            throw new System.NotImplementedException();
        }
    }


    public enum GBStates
    {
        SOLD_OUT = 0,
        NO_QUARTER = 1,
        HAS_QUARTER = 2,
        SOLD = 3,
        WINNER = 4
    }
}