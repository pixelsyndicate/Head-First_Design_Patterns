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
        private CeilingFan _ceilingFanReceiver;

        private GarageDoorOpenCommand _doorOpenCommand;
        private GarageDoorCloseCommand _doorCloseCommand;

        private LightOnCommand _lightOnCommand;
        LightOffCommand _lightOffCommand;
        private LightOnCommand _kitchenLightOnCommand;
        LightOffCommand _kitchenLightOffCommand;
        private StereoOnWithCdCommand _stereoOnCommand;
        StereoOffWithCdCommand _stereoOffCommand;

        private CeilingFanOnCommand _ceilingFanOnCommand;
        private CeilingFanOffCommand _ceilingFanOffCommand;
        private Light _kitchenLightReceiver;
        private CeilingFanHighCommand _ceilingFanHighCommand;
        private CeilingFanMediumCommand _ceilingFanMediumCommand;
        private CeilingFanLowCommand _ceilingFanLowCommand;


        [TestInitialize]
        public void TestSetup()
        {
            // my Invoker object in the Command Pattern
            _invoker = new RemoteControl();

            // my Receiver object in the Command Pattern
            _doorReceiver = new GarageDoor();
            _lightReceiver = new Light();
            _stereoReceiver = new Stereo();
            _ceilingFanReceiver = new CeilingFan("Living Room");
            _kitchenLightReceiver = new Light("Kitchen");


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
            _ceilingFanHighCommand = new CeilingFanHighCommand(_ceilingFanReceiver);
            _ceilingFanMediumCommand = new CeilingFanMediumCommand(_ceilingFanReceiver);
            _ceilingFanLowCommand = new CeilingFanLowCommand(_ceilingFanReceiver);


            _invoker.SetCommand(1, _lightOnCommand, _lightOffCommand, "Living Room Light");
            _invoker.SetCommand(2, _stereoOnCommand, _stereoOffCommand, "Stereo With CD");
            _invoker.SetCommand(3, _doorOpenCommand, _doorCloseCommand, "Garage Door");
            _invoker.SetCommand(4, _kitchenLightOnCommand, _kitchenLightOffCommand, "Kitchen Light");
            _invoker.SetCommand(5, _ceilingFanLowCommand, _ceilingFanOffCommand, "Fan Low");
            _invoker.SetCommand(6, _ceilingFanMediumCommand, _ceilingFanOffCommand, "Fan Med");
            _invoker.SetCommand(7, _ceilingFanHighCommand, _ceilingFanOffCommand, "Fan High");
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
            Assert.AreEqual("Garage Door Is Open.", _invoker.OnButtonWasPressed(3));
            Assert.IsTrue(_doorReceiver.IsOpen);


            Assert.IsFalse(_lightReceiver.IsOn);
            Assert.AreEqual("Undefined Light Is On.", _invoker.OnButtonWasPressed(1));
            Assert.IsTrue(_lightReceiver.IsOn);


            Assert.IsTrue(_doorReceiver.IsOpen);
            Assert.AreEqual("Garage Door Is Closed.", _invoker.OffButtonWasPressed(3));
            Assert.IsFalse(_doorReceiver.IsOpen);


            Assert.IsFalse(_ceilingFanReceiver.IsOn);
            Assert.AreEqual("Living Room Ceiling Fan Is On 1", _invoker.OnButtonWasPressed(5));
            Assert.IsTrue(_ceilingFanReceiver.IsOn);


            Assert.IsFalse(_stereoReceiver.IsOn);
            Assert.AreEqual(" Play CD Enabled.  Volume Set To 11. Undefined Stereo Is On. ", _invoker.OnButtonWasPressed(2));
            Assert.IsTrue(_stereoReceiver.IsOn);

            Assert.IsFalse(_kitchenLightReceiver.IsOn, "_lightReceiver.IsOn (should be off)");
            Assert.AreEqual("Kitchen Light Is On.", _invoker.OnButtonWasPressed(4));
            Assert.IsTrue(_kitchenLightReceiver.IsOn, "_lightReceiver.IsOn");


            Assert.IsTrue(_stereoReceiver.IsOn);
            Assert.AreEqual("Undefined Stereo Is Off. ", _invoker.OffButtonWasPressed(2));
            Assert.IsFalse(_stereoReceiver.IsOn);
        }


        [TestMethod]
        public void Test_Function_And_Undo()
        {

            // display map
            Console.WriteLine(_invoker.ToString());

            // is initially closed
            Assert.IsFalse(_lightReceiver.IsOn);

            Assert.AreEqual("Undefined Light Is On.", _invoker.OnButtonWasPressed(1));

            // is now open
            Assert.IsTrue(_lightReceiver.IsOn);

            // display map
            Console.WriteLine(_invoker.ToString());

            // UNDO Button
            // Assert.AreEqual("Undefined Light Is Off.", 
            _invoker.UndoButtonWasPressed();
            //    );
            // ;

            // is now closed
            Assert.IsFalse(_lightReceiver.IsOn);


        }


        [TestMethod]
        public void Test_Function_And_Undo_For_Fan_Speeds()
        {
            _invoker = new RemoteControl();

            _invoker.SetCommand(1, _ceilingFanLowCommand, _ceilingFanOffCommand, "Fan Low");
            _invoker.SetCommand(2, _ceilingFanMediumCommand, _ceilingFanOffCommand, "Fan Med");
            _invoker.SetCommand(3, _ceilingFanHighCommand, _ceilingFanOffCommand, "Fan High");

            // is initially off
            Assert.IsFalse(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 0);

            // set to low
            _invoker.OnButtonWasPressed(1);
            // is now on at low speed
            Assert.IsTrue(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 1);
            // turn off 
            _invoker.OffButtonWasPressed(1);
            // is now off
            Assert.IsFalse(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 0);

            // peek
            Console.WriteLine(_invoker.ToString());

            // undo the off? should be back to low
            _invoker.UndoButtonWasPressed();

            // should now be low
            Assert.IsTrue(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 1);


            _invoker.OnButtonWasPressed(3); // high

            // is now on at high speed
            Assert.IsTrue(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 3);

            // peek
            Console.WriteLine(_invoker.ToString());

            _invoker.UndoButtonWasPressed(); // revert to low
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 1);

            _invoker.UndoButtonWasPressed();// revert to high
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 3);
            _invoker.UndoButtonWasPressed();// revert to low
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 1);
            _invoker.OffButtonWasPressed(3); // turn to off
            Assert.IsFalse(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 0);
            _invoker.UndoButtonWasPressed();// revert to low
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 1);
            _invoker.OffButtonWasPressed(3); // turn it off finally
            Assert.IsFalse(_ceilingFanReceiver.IsOn);
            Assert.IsTrue(_ceilingFanReceiver.GetLevel() == 0);
        }
    }
}
