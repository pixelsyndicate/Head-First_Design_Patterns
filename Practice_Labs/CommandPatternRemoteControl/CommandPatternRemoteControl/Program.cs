using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommandPatternRemoteControl.VendorCode.Commands;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl
{
    class Program
    {

        private static RemoteControl _invoker;

        private static GarageDoor _doorReceiver;
        private static Light _lightReceiver;
        private static Stereo _stereoReceiver;

        private static GarageDoorOpenCommand _doorOpenCommand; private static GarageDoorCloseCommand _doorCloseCommand;

        private static IRemoteCommand _lightOnCommand; private static IRemoteCommand _lightOffCommand;
        private static IRemoteCommand _kitchenLightOnCommand; private static IRemoteCommand _kitchenLightOffCommand;
        private static IRemoteCommand _stereoOnCommand; private static IRemoteCommand _stereoOffCommand;
        private static CeilingFan _ceilingFanReceiver;
        private static CeilingFanOnCommand _ceilingFanOnCommand;
        private static CeilingFanOffCommand _ceilingFanOffCommand;
        private static Light _kitchenLightReceiver;


        static void Main(string[] args)
        {

            initialize();
            setUp();
            
            Console.WriteLine(_invoker.ToString());

            _invoker.OnButtonWasPressed(3);
            _invoker.OnButtonWasPressed(1);
            _invoker.OffButtonWasPressed(3);
            _invoker.OnButtonWasPressed(5);
            _invoker.OnButtonWasPressed(2);
            _invoker.OnButtonWasPressed(4);
            _invoker.OffButtonWasPressed(2);

            cleanUp();


            // my Invoker object in the Command Pattern
            _invoker = null;

            Console.ReadLine();
        }

        private static void setUp()
        {
            _invoker.SetCommand(1, _lightOnCommand, _lightOffCommand, "Living Room Light");
            _invoker.SetCommand(2, _stereoOnCommand, _stereoOffCommand, "Stereo With CD");
            _invoker.SetCommand(3, _doorOpenCommand, _doorCloseCommand, "Garage Door");
            _invoker.SetCommand(4, _kitchenLightOnCommand, _kitchenLightOffCommand, "Kitchen Light");
            _invoker.SetCommand(5, _ceilingFanOnCommand, _ceilingFanOffCommand, "Ceiling Fan");
            //_invoker.SetCommand(6, _lightOnCommand, _lightOffCommand, "Living Room");
            //_invoker.SetCommand(7, _lightOnCommand, _lightOffCommand, "Living Room");
        }

        private static void initialize()
        {
            // my Invoker object in the Command Pattern
            _invoker = new RemoteControl();

            // my Receiver object in the Command Pattern
            _doorReceiver = new GarageDoor();
            _lightReceiver = new Light(); // my Receiver object in the Command Pattern
            _stereoReceiver = new Stereo(); // my Receiver object in the Command Pattern
            _ceilingFanReceiver = new CeilingFan();
            _kitchenLightReceiver = new Light();


            // my Command object in the Command Pattern.
            _doorOpenCommand = new GarageDoorOpenCommand(_doorReceiver);
            _doorCloseCommand = new GarageDoorCloseCommand(_doorReceiver);
            _lightOnCommand = new LightOnCommand(_lightReceiver);
            _lightOffCommand = new LightOffCommand(_lightReceiver);
            _kitchenLightOnCommand = new LightOnCommand(_kitchenLightReceiver);
            _kitchenLightOffCommand = new LightOffCommand(_kitchenLightReceiver);
            _stereoOnCommand = new StereoOnWithCdCommand(_stereoReceiver);
            _stereoOffCommand = new StereoOffWithCdCommand(_stereoReceiver);
            _ceilingFanOnCommand = new CeilingFanOnCommand(_ceilingFanReceiver);
            _ceilingFanOffCommand = new CeilingFanOffCommand(_ceilingFanReceiver);
        }

        private static void cleanUp()
        {
            // my Receiver object in the Command Pattern
            _doorReceiver = null;
            _lightReceiver = null;
            _kitchenLightReceiver = null;
            _kitchenLightReceiver = null;

            // my Command object in the Command Pattern.
            _doorOpenCommand = null;
            _doorCloseCommand = null;
            _lightOnCommand = null;
            _stereoOnCommand = null;
            _stereoOffCommand = null;
            _kitchenLightOffCommand = null;
            _kitchenLightOnCommand = null;
        }
    }
}
