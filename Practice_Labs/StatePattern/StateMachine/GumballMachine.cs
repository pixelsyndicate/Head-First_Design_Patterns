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

        public GumballMachineContext(int count)
        {
            Inventory = count;
            SoldOutState = new SoldOutState(this);
            SoldState = new SoldState(this);
            NoQuarterState = new NoQuarterState(this);
            HasQuarterState = new HasQuarterState(this);
            //_winnerState = new WinnerState(this);
            _state = count > 0 ? NoQuarterState : SoldOutState;
        }

        public int Inventory { get; set; }

        protected internal IState SoldOutState
        {
            get { return _soldOutState; }
            set { _soldOutState = value; }
        }

        protected internal IState SoldState
        {
            get { return _soldState; }
            set { _soldState = value; }
        }

        protected internal IState NoQuarterState
        {
            get { return _noQuarterState; }
            set { _noQuarterState = value; }
        }

        protected internal IState HasQuarterState
        {
            get { return _hasQuarterState; }
            set { _hasQuarterState = value; }
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