﻿using System;
using System.Diagnostics;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class CeilingFan : BaseThreeLevelDevice, IThreeLevelDevice, IOnOffDevice
    {

        private string _location;
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
        public void On(int speed)
        {
            IsOn = true;
            _level = speed;
            Console.WriteLine("The Ceiling Fan Is On Speed " + _level);
        }

        public void On()
        {
            IsOn = true;
            _level = LOW;
            Console.WriteLine("The Ceiling Fan Is On Speed " + _level);
        }

        public void Off()
        {
            IsOn = false;
            _level = 0;
            Console.WriteLine("The Ceiling Fan Is Off.");
        }

        public int GetLevel()
        {
            return _level;
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