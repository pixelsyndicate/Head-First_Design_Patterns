#region USING DIRECTIVES (collapse to hide)

using System;
using System.Diagnostics;

#endregion

namespace StateMachine
{
    public class GumballMachineContext : IContext
    {
        private IState _state;
        private IState _soldOutState;
        private IState _soldState;
        private IState _noQuarterState;
        private IState _hasQuarterState;
        private IState _winnerState;
        private int _count;

        public GumballMachineContext(int count)
        {
            _count = count;
            _soldOutState = new SoldOutState(this);
            _soldState = new SoldState(this);
            _noQuarterState = new NoQuarterState(this);
            _hasQuarterState = new HasQuarterState(this);
            _winnerState = new WinnerState(this);
            _state = _count > 0 ? _noQuarterState : _soldOutState;
        }

        public int Inventory
        {
            get { return _count; }
            set { _count = value; }
        }

        protected internal IState GetSoldOutState
        {
            get { return _soldOutState; }
            set { _soldOutState = value; }
        }

        protected internal IState GetSoldState
        {
            get { return _soldState; }
            set { _soldState = value; }
        }

        protected internal IState GetNoQuarterState
        {
            get { return _noQuarterState; }
            set { _noQuarterState = value; }
        }

        protected internal IState GetHasQuarterState
        {
            get { return _hasQuarterState; }
            set { _hasQuarterState = value; }
        }

        protected internal IState GetWinnerState
        {
            get { return _winnerState; }
            set { _winnerState = value; }
        }

        public override string ToString()
        {
            return Inventory.ToString();
        }


        public void SetState(IState newState)
        {
            _state = newState;
        }


        // Action methods are very easy now. just delegate to the current state.

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
            // todo: fix. only dispense if turncrank shows SoldState and isn't empty? or move this to the implementation
            if (Inventory > 0)
                _state.Dispense();
        }

        /// <summary>
        ///     The machine supports a ReleaseBall() helper method that releases the ball and ecrements the count instance
        ///     variable.
        /// </summary>
        protected internal void ReleaseBall()
        {
            Debug.WriteLine("A gumball comes rolling out the slot.");
            if (Inventory != 0)
            {
                Inventory -= 1;
            }
        }
    }
}