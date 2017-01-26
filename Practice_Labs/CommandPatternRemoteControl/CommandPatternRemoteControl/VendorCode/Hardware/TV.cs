using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class TV : IOnOffDevice
    {
        private string _location;

        public TV(string location)
        {
            _location = location;
        }
        public TV()
        {
            _location = "Undefined";
        }

        public bool IsOn { get; set; }

        private int _channel { get; set; } = 1;

        public string On()
        {
            IsOn = true;
            return _location + "The TV Is On.";
        }

        public string Off()
        {
            IsOn = false;
            return _location + "The TV Is Off.";
        }

        public int GetChannel()
        {
            return _channel;
        }

        public void SetChannel(int newCh)
        {
            _channel = newCh;
            Console.WriteLine("The TV channel is set to " + GetChannel());
        }
    }
}