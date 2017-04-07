using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GumballMachine
{
    // an enum to hold my states (for starters)
    public enum GBStates
    {
        SOLD_OUT = 0,
        NO_QUARTER = 1,
        HAS_QUARTER = 2,
        SOLD = 3
    }
    public class GumballMachine : IGumballMachine
    {
        private GBStates _state = GBStates.SOLD_OUT;
        private int _count = 0;

        public override string ToString()
        {
            //if (_state == GBStates.SOLD_OUT)
            //{
            //    Debug.WriteLine("The machine is sold out.");
            //}
            return _count.ToString();
        }

        public GumballMachine(int count)
        {
            _count = count;
            if (count > 0) { _state = GBStates.NO_QUARTER; }
        }

        // some actions which examine state before doing stuff.
        public void InsertQuarter()
        {
            switch (_state)
            {
                case GBStates.HAS_QUARTER:
                    Debug.WriteLine("You can't insert another quarter.");
                    break;
                case GBStates.NO_QUARTER:
                    _state = GBStates.HAS_QUARTER;
                    break;
                case GBStates.SOLD_OUT:
                    Debug.WriteLine("You can't insert a quarter, the machine is sold out.");
                    break;
                case GBStates.SOLD:
                    Debug.WriteLine("Please wait, we are dispensing a gumball.");
                    break;

            }
        }
        /// <summary>
        /// An action in here changes state = noquarter if state == hasquarter
        /// </summary>
        public void EjectQuarter()
        {
            switch (_state)
            {
                case GBStates.HAS_QUARTER:
                    Debug.WriteLine("Quarter Returned.");
                    _state = GBStates.NO_QUARTER;
                    break;
                case GBStates.NO_QUARTER:
                    Debug.WriteLine("You haven't inserted a quarter.");
                    break;
                case GBStates.SOLD:
                    Debug.WriteLine("Sorry, you already turned the crank.");
                    break;
                case GBStates.SOLD_OUT:
                    Debug.WriteLine("Sorry, you can't eject, you haven't inserted a quarter yet.");
                    break;


            }
        }

        /// <summary>
        /// An action in here changes state = sold if state == hasquarter
        /// </summary>
        public void TurnCrank()
        {
            switch (_state)
            {
                case GBStates.SOLD:
                    Debug.WriteLine("Turning twice doesn't get you a second gumball.");
                    break;
                case GBStates.NO_QUARTER:
                    Debug.WriteLine("You turned, but there's no quarter.");
                    break;
                case GBStates.SOLD_OUT:
                    Debug.WriteLine("You turned, but there are no gumballs.");
                    break;
                case GBStates.HAS_QUARTER:
                    Debug.WriteLine("You turned...");
                    _state = GBStates.SOLD;
                    Dispense();
                    break;
            }
        }

        private void Dispense()
        {
            switch (_state)
            {
                case GBStates.SOLD:
                    Debug.WriteLine("A gumball comes rolling out the slot.");
                    _count -= 1;
                    if (_count == 0)
                    {
                        Debug.WriteLine("Oops, out of gumballs.");
                        _state = GBStates.SOLD_OUT;
                    }
                    else { _state = GBStates.NO_QUARTER; }
                    break;
                case GBStates.NO_QUARTER:
                    Debug.WriteLine("You need to pay first.");
                    break;
                case GBStates.SOLD_OUT:
                    Debug.WriteLine("No gumball dispensed.");
                    break;
                case GBStates.HAS_QUARTER:
                    Debug.WriteLine("No gumball dispensed.");
                    break;
            }
        }
    }
}
