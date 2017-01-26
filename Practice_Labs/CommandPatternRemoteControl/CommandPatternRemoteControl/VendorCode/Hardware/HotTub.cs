using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class HotTub : IThreeLevelDevice, IOnOffDevice
    {
        internal const int HIGH = 3;
        internal const int MED = 2;
        internal const int LOW = 1;
        internal const int OFF = 0;
        private string _location;
        private int _temp = 0;

        public HotTub(string location)
        {
            _location = location;
        }

        public HotTub()
        {
            _location = "Undefined";
        }

        public bool IsOn { get; set; }
        public string On(int temperature)
        {
            IsOn = true;
            _temp = temperature;
            return "The HotTub Temp Is On " + _temp;
        }

        public string On()
        {
            return Medium();
        }

        public string Off()
        {
            IsOn = false;
            _temp = 0;
            return "The HotTub Is Off.";
        }

        public int GetLevel()
        {
            return _temp;
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