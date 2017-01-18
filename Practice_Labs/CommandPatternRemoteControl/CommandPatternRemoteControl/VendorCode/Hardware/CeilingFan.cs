using System;
using System.Diagnostics;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class CeilingFan
    {
        internal const int HIGH = 3;
        internal const int MED = 2;
        internal const int LOW = 1;
        internal const int OFF = 0;
        private string _location;
        private int _speed = 0;

        public CeilingFan(string location)
        {
            _location = location;
        }

        public CeilingFan()
        {
            _location = "Undefined";
        }

        public bool IsOn { get; set; }
        public void On(int speed)
        {
            IsOn = true;
            _speed = speed;
            Console.WriteLine("The Ceiling Fan Is On Speed " + _speed);
        }

        public void On()
        {
            IsOn = true;
            _speed = LOW;
            Console.WriteLine("The Ceiling Fan Is On Speed " + _speed);
        }

        public void Off()
        {
            IsOn = false;
            _speed = 0;
            Console.WriteLine("The Ceiling Fan Is Off.");
        }

        public int GetSpeed()
        {
            return _speed;
        }

        public void High()
        {
            On(HIGH);
            //Console.WriteLine("The Ceiling Fan Is Set To High.");
        }

        public void Medium()
        {
            On(MED);
            //  Console.WriteLine("The Ceiling Fan Is Set To Med.");
        }
        public void Low()
        {
            On(LOW);
            // Console.WriteLine("The Ceiling Fan Is Set To Low.");
        }

    }


    //public class CeilingFan
    //{
    //    public bool IsOn { get; set; } = false;
    //    public void On()
    //    {
    //        IsOn = true;
    //        Console.WriteLine("The Ceiling Fan Is On.");
    //    }

    //    public void Off()
    //    {
    //        IsOn = false; Debug.WriteLine("The Ceiling Fan Is Off.");
    //    }


    //    public void SetSpeed(int i)
    //    {
    //        Console.WriteLine("The Ceiling Fan Speed Is Now Set To " + i);
    //    }


    //}
}