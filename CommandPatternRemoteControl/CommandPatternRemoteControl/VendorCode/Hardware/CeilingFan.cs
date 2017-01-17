using System;
using System.Diagnostics;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class CeilingFan
    {
        public bool IsOn { get; set; } = false;
        public void On()
        {
            IsOn = true;
            Console.WriteLine("The Ceiling Fan Is On.");
        }

        public void Off()
        {
            IsOn = false; Debug.WriteLine("The Ceiling Fan Is Off.");
        }


        public void SetSpeed(int i)
        {
            Console.WriteLine("The Ceiling Fan Speed Is Now Set To " + i);
        }
    }
}