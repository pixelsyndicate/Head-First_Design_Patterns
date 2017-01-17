using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class Stereo
    {
        public bool IsOn { get; set; } = false;
        public void On()
        {
            IsOn = true;
            Console.WriteLine("The Stereo Is On.");
        }

        public void Off()
        {
            IsOn = false; Console.WriteLine("The Stereo Is Off.");
        }

        public void SetCd()
        {
            Console.WriteLine("The Stereo Is Set To Play CD.");
        }

        public void SetVolume(int i)
        {
            Console.WriteLine("The Stereo Volume Is Now Set To " + i);
        }
    }
}