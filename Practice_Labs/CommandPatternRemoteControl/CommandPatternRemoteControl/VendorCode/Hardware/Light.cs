using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class Light : IOnOffDevice
    {
        private string _location;
        public Light(string location)
        {
            _location = location;
        }

        public Light()
        {
            _location = "Undefined";
        }

        public string Name { get; set; }

        public bool IsOn { get; set; }

        public string On()
        {
            IsOn = true;
            return _location + " Light Is On.";

        }

        public string Off()
        {
            IsOn = false;
            return _location + " Light Is Off.";
        }
    }
}