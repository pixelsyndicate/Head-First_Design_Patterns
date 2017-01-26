using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class GarageDoor : IUpDownDevice
    {
        public bool IsOpen { get; set; } = false;
        public string Up()
        {
            IsOpen = true;
            return "Garage Door Is Open.";
        }

        public string Down()
        {
            IsOpen = false;
            return "Garage Door Is Closed.";
        }
    }
}