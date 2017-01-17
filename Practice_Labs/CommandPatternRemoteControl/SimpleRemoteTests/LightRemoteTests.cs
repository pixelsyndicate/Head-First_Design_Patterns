using System;
using CommandPatternRemoteControl;
using CommandPatternRemoteControl.VendorCode;
using CommandPatternRemoteControl.VendorCode.Commands;
using CommandPatternRemoteControl.VendorCode.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleRemoteTests
{
    [TestClass]
    public class LightRemoteTests
    {
        private SimpleRemoteControl _invoker;
        private Light _receiver;
        private OldLightOnCommand _command;

        [TestInitialize]
        public void TestSetup()
        {
            _invoker = new SimpleRemoteControl(); // my Invoker object in the Command Pattern
            _receiver = new Light(); // my Receiver object in the Command Pattern
            _command = new OldLightOnCommand(_receiver); // my Command object in the Command Pattern.
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _command = null; // my Command object in the Command Pattern.
            _receiver = null; // my Receiver object in the Command Pattern
            _invoker = null; // my Invoker object in the Command Pattern
        }

        [TestMethod]
        public void Can_I_Turn_On_Light_With_Registering_Command()
        {
            _invoker.SetCommand(_command); // pass the command to the Invoker remote
                                          // _remote.ButtonWasPressed(); // the invoker now executes the command.execute().

            Assert.IsFalse(_receiver.IsOn); // verify the Receiver didn't get what it needed.
        }



        [TestMethod]
        public void Can_I_Turn_On_Light_With_After_Invoker_Executes()
        {
            _invoker.SetCommand(_command); // pass the command to the Invoker remote
            _invoker.ButtonWasPressed(); // the invoker now executes the command.execute().

            Assert.IsTrue(_receiver.IsOn); // verify the Receiver got what it needed.
        }
    }
}
