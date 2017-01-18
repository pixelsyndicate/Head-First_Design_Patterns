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
        public void On(int temperature)
        {
            IsOn = true;
            _temp = temperature;
            Console.WriteLine("The HotTub Temp Is On " + _temp);
        }

        public void On()
        {
            Medium();
        }

        public void Off()
        {
            IsOn = false;
            _temp = 0;
            Console.WriteLine("The HotTub Is Off.");
        }

        public int GetLevel()
        {
            return _temp;
        }

        public void High()
        {
            On(HIGH);
        }

        public void Medium()
        {
            On(MED);
        }
        public void Low()
        {
            On(LOW);
        }
    }
}