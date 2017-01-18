using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class TV : IOnOffDevice
    {
        public bool IsOn { get; set; }

        private int _channel { get; set; } = 1;

        public void On()
        {
            IsOn = true;
            Console.WriteLine("The TV Is On.");
        }

        public void Off()
        {
            IsOn = false;
            Console.WriteLine("The TV Is Off.");
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