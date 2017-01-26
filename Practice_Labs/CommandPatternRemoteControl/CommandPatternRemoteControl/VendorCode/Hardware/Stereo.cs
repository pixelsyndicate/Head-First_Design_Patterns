using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class Stereo : INumericLevelDevice, IOnOffDevice
    {
        private readonly string _location;

        public Stereo(string location)
        {
            _location = location;
        }

        public Stereo()
        {
            _location = "Undefined";
        }

        public bool IsOn { get; set; } = false;
        public string On()
        {
            IsOn = true;
            return _location + " Stereo Is On. ";
        }

        public string Off()
        {
            IsOn = false;
            return _location + " Stereo Is Off. ";
        }

        public string SetCd()
        {
            return " Play CD Enabled. ";
        }

        public string SetLevel(int i)
        {
            return " Volume Set To " + i + ". ";
        }
    }
}