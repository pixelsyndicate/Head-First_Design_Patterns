using System;

namespace CommandPatternRemoteControl.VendorCode.Hardware
{
    public class GarageDoor
    {
        public bool IsOpen { get; set; } = false;
        public void Up()
        {
            IsOpen = true;
            Console.WriteLine("Garage Door Is Open.");
        }

        public void Down()
        {
            IsOpen = false;
            Console.WriteLine("Garage Door Is Closed.");
        }
    }
}