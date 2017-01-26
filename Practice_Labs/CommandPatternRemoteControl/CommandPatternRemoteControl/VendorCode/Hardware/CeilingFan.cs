using System;
using System.Diagnostics;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class CeilingFan : BaseThreeLevelDevice, IThreeLevelDevice, IOnOffDevice
    {

        private readonly string _location;
        private int _level = 0;

        public CeilingFan(string location)
        {
            _location = location;
        }

        public CeilingFan()
        {
            _location = "Undefined";
        }

        public bool IsOn { get; set; }
        public string On(int speed)
        {
            IsOn = true;
            _level = speed;
            return _location + " Ceiling Fan Is On " + GetLevel();
        }

        public string On()
        {
            IsOn = true;
            _level = LOW;
            return _location + " Ceiling Fan Is On " + GetLevel();
        }

        public string Off()
        {
            IsOn = false;
            _level = 0;
            return _location + " Ceiling Fan Is Off.";
        }

        public int GetLevel()
        {
            return _level;
        }

        public string High()
        {
           return On(HIGH);
        }

        public string Medium()
        {
           return On(MED);
        }
        public string Low()
        {
           return On(LOW);
        }

    }

}