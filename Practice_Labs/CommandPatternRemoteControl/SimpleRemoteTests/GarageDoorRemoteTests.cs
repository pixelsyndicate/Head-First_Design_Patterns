using CommandPatternRemoteControl;
using CommandPatternRemoteControl.VendorCode;
using CommandPatternRemoteControl.VendorCode.Commands;
using CommandPatternRemoteControl.VendorCode.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRemoteTests
{
    [TestClass]
    public class GarageDoorRemoteTests
    {
        private SimpleRemoteControl _invoker;
        private GarageDoor _doorReceiver;
        private Light _lightReceiver;
        private OldGarageDoorOpenCommand _doorOpenCommand;
        private OldLightOnCommand _lightOnCommand;

        [TestInitialize]
        public void TestSetup()
        {
            _invoker = new SimpleRemoteControl(); // my Invoker object in the Command Pattern
            _doorReceiver = new GarageDoor(); // my Receiver object in the Command Pattern
            _lightReceiver = new Light(); // my Receiver object in the Command Pattern
            _doorOpenCommand = new OldGarageDoorOpenCommand(_doorReceiver); // my Command object in the Command Pattern.
            _lightOnCommand = new OldLightOnCommand(_lightReceiver);// my Command object in the Command Pattern.
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _doorOpenCommand = null; // my Command object in the Command Pattern.
            _lightOnCommand = null;// my Command object in the Command Pattern.
            _doorReceiver = null; // my Receiver object in the Command Pattern
            _lightReceiver = null; // my Receiver object in the Command Pattern
            _invoker = null; // my Invoker object in the Command Pattern
        }

        [TestMethod]
        public void ReallyBasicTest()
        {
            _invoker = new SimpleRemoteControl();
            _invoker.SetCommand(new OldLightOnCommand(new Light()));
            // with no reference to the light, can't inspect it. But if it has output for console, we can see
            _invoker.ButtonWasPressed();
            _invoker.SetCommand(new OldLightOffCommand(new Light()));
            // with no reference to the light, can't inspect it. But if it has output for console, we can see
            _invoker.ButtonWasPressed();
        }
        [TestMethod]
        public void Can_I_Open_Garage_Door_Only_Registering_Command()
        {
            _invoker.SetCommand(_doorOpenCommand); // pass the command to the Invoker remote
            // _remote.ButtonWasPressed(); // the invoker now executes the command.execute().

            Assert.IsFalse(_doorReceiver.IsOpen); // verify the Receiver didn't get what it needed.
        }

        [TestMethod]
        public void Can_I_Open_Garage_Door_After_Invoker_Executes()
        {
            _invoker.SetCommand(_doorOpenCommand); // pass the command to the Invoker remote
            _invoker.ButtonWasPressed(); // the invoker now executes the command.execute().

            Assert.IsTrue(_doorReceiver.IsOpen); // verify the Receiver got what it needed.
        }

        [TestMethod]
        public void Can_I_Open_Garage_Door_And_Turn_On_Light()
        {

            // assert starting climate is correct
            Assert.IsFalse(_lightReceiver.IsOn);
            Assert.IsFalse(_doorReceiver.IsOpen);


            _invoker.SetCommand(_lightOnCommand); // pass the command to the Invoker remote
            _invoker.ButtonWasPressed(); // the invoker now executes the command.execute().

            _invoker.SetCommand(_doorOpenCommand); // pass the command to the Invoker remote
            _invoker.ButtonWasPressed(); // the invoker now executes the command.execute().

            Assert.IsTrue(_lightReceiver.IsOn); // verify the Receiver got what it needed.
            Assert.IsTrue(_doorReceiver.IsOpen); // verify the Receiver got what it needed.
        }
    }
}