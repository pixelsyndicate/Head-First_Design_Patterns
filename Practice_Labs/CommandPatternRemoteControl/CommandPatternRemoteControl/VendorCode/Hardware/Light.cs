using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class Light : IOnOffDevice
    {
        public Light(string name)
        {
            Name = name;
        }

        public Light()
        {
            Name = "Undefined";
        }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public void On()
        {
            IsOn = true;
            Console.WriteLine("The Light Is On.");
        }

        public void Off()
        {
            IsOn = false;
            Console.WriteLine("The Light Is Off.");
        }
    }
}