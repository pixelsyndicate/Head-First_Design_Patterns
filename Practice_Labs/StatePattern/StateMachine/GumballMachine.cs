#region USING DIRECTIVES (collapse to hide)

using System;
using System.Diagnostics;

#endregion

namespace StateMachine
{
    public class GumballMachine : IGumballMachine
    {
        private static IState _soldOutState;

        private IState _state;

        public GumballMachine(int count)
        {
            Inventory = count;
            _soldOutState = new SoldOutState(this);
            getSoldState = new SoldState(this);
            getNoQuarterState = new NoQuarterState(this);
            getHasQuarterState = new HasQuarterState(this);
            //_winnerState = new WinnerState(this);
            _state = count > 0 ? getNoQuarterState : _soldOutState;
        }

        public int Inventory { get; set; }

        protected internal IState getSoldOutState
        {
            get { return _soldOutState; }
            set { _soldOutState = value; }
        }

        protected internal IState getSoldState { get; set; }

        protected internal IState getNoQuarterState { get; set; }

        protected internal IState getHasQuarterState { get; set; }

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
            // todo: fix. only dispense if turncrank shows SoldState and isn't empty?
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