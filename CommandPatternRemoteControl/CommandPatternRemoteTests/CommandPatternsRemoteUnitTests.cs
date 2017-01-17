using System;
using CommandPatternRemoteControl;
using CommandPatternRemoteControl.VendorCode;
using CommandPatternRemoteControl.VendorCode.Commands;
using CommandPatternRemoteControl.VendorCode.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandPatternRemoteTests
{
    [TestClass]
    public class CommandPatternsRemoteUnitTests
    {
        private RemoteControl _invoker;

        private GarageDoor _doorReceiver;
        private Light _lightReceiver;
        private Stereo _stereoReceiver;

        private GarageDoorOpenCommand _doorOpenCommand; private GarageDoorCloseCommand _doorCloseCommand;

        private IRemoteCommand _lightOnCommand; private IRemoteCommand _lightOffCommand;
        private IRemoteCommand _kitchenLightOnCommand; private IRemoteCommand _kitchenLightOffCommand;
        private IRemoteCommand _stereoOnCommand; private IRemoteCommand _stereoOffCommand;
        private CeilingFan _ceilingFanReceiver;
        private CeilingFanOnCommand _ceilingFanOnCommand;
        private CeilingFanOffCommand _ceilingFanOffCommand;
        private Light _kitchenLightReceiver;


        [TestInitialize]
        public void TestSetup()
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



            _invoker.SetCommand(1, _lightOnCommand, _lightOffCommand, "Living Room Light");
            _invoker.SetCommand(2, _stereoOnCommand, _stereoOffCommand, "Stereo With CD");
            _invoker.SetCommand(3, _doorOpenCommand, _doorCloseCommand, "Garage Door");
            _invoker.SetCommand(4, _kitchenLightOnCommand, _kitchenLightOffCommand, "Kitchen Light");
            _invoker.SetCommand(5, _ceilingFanOnCommand, _ceilingFanOffCommand, "Ceiling Fan");
            //_invoker.SetCommand(6, _lightOnCommand, _lightOffCommand, "Living Room");
            //_invoker.SetCommand(7, _lightOnCommand, _lightOffCommand, "Living Room");
        }

        [TestCleanup]
        public void TestCleanup()
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

            // my Invoker object in the Command Pattern
            _invoker = null;







        }


        [TestMethod]
        public void Test_Function_And_Slots_Of_Buttons()
        {

            Console.WriteLine(_invoker.ToString());


            Assert.IsFalse(_doorReceiver.IsOpen);
            _invoker.OnButtonWasPressed(3);
            Assert.IsTrue(_doorReceiver.IsOpen);


            Assert.IsFalse(_lightReceiver.IsOn);
            _invoker.OnButtonWasPressed(1);
            Assert.IsTrue(_lightReceiver.IsOn);


            Assert.IsTrue(_doorReceiver.IsOpen);
            _invoker.OffButtonWasPressed(3);
            Assert.IsFalse(_doorReceiver.IsOpen);


            Assert.IsFalse(_ceilingFanReceiver.IsOn);
            _invoker.OnButtonWasPressed(5);
            Assert.IsTrue(_ceilingFanReceiver.IsOn);


            Assert.IsFalse(_stereoReceiver.IsOn);
            _invoker.OnButtonWasPressed(2);
            Assert.IsTrue(_stereoReceiver.IsOn);

            Assert.IsFalse(_kitchenLightReceiver.IsOn, "_lightReceiver.IsOn (should be off)");
            _invoker.OnButtonWasPressed(4);
            Assert.IsTrue(_kitchenLightReceiver.IsOn, "_lightReceiver.IsOn");


            Assert.IsTrue(_stereoReceiver.IsOn);
            _invoker.OffButtonWasPressed(2);
            Assert.IsFalse(_stereoReceiver.IsOn);
        }
    }
}
