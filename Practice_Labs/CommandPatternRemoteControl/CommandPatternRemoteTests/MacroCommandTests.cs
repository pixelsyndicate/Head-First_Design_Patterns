using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using CommandPatternRemoteControl;
using CommandPatternRemoteControl.VendorCode.Commands;
using CommandPatternRemoteControl.VendorCode.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandPatternRemoteTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class MacroCommandTests
    {
        public MacroCommandTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_I_Execute_Macro_On_And_Off()
        {
            //
            // TODO: Add test logic here
            //

            // set up the invoker
            RemoteControl remoteControl = new RemoteControl();

            // set up some devices to be affected (receivers)
            Light lightReceiverInLivingRoom = new Light("Living Room");
            Light lightReceiverInBedRoom = new Light("Master Bed Room");
            Stereo stereoReceiver = new Stereo(); ;
            HotTub hotTubReceiver = new HotTub(); ;
            TV tvReceiver = new TV(); ;

            // set up some commands
            LightOnCommand lightOnCmd = new LightOnCommand(lightReceiverInLivingRoom);
            StereoOnWithCdCommand stereoOnCmd = new StereoOnWithCdCommand(stereoReceiver);
            HotTubOnCommand hotTubOnCmd = new HotTubOnCommand(hotTubReceiver);
            TvOnCommand tvOnCmd = new TvOnCommand(tvReceiver);
            LightOffCommand lightOffCmd = new LightOffCommand(lightReceiverInLivingRoom);
            StereoOffWithCdCommand stereoOffCmd = new StereoOffWithCdCommand(stereoReceiver);
            HotTubOffCommand hotTubOffCmd = new HotTubOffCommand(hotTubReceiver);
            TvOffCommand tvOffCmd = new TvOffCommand(tvReceiver);

            // create arrays for ON and OFF commands for our groups
            IRemoteCommand[] partyOnCommands = new IRemoteCommand[] { lightOnCmd, stereoOnCmd, hotTubOnCmd, tvOnCmd };
            IRemoteCommand[] partyOffCommands = new IRemoteCommand[] { lightOffCmd, stereoOffCmd, hotTubOffCmd, tvOffCmd };

            MacroCommand partyOnMacro = new MacroCommand(partyOnCommands);
            MacroCommand partyOffMacro = new MacroCommand(partyOffCommands);

            // set the macroCommand to a button as in other tests.
            remoteControl.SetCommand(1, partyOnMacro, partyOffMacro, "Party");


            // test
            Console.WriteLine(remoteControl.ToString());

            // push the party on button
           
            remoteControl.OnButtonWasPressed(1);

            // push the party off button
            remoteControl.OffButtonWasPressed(1);
        }

        [TestMethod]
        public void Can_I_Execute_Macro_On_And_Undo()
        {
            //
            // TODO: Add test logic here
            //

            // set up the invoker
            RemoteControl remoteControl = new RemoteControl();

            // set up some devices to be affected (receivers)
            Light lightReceiverInLivingRoom = new Light("Living Room");
            Light lightReceiverInBedRoom = new Light("Master Bed Room");
            Stereo stereoReceiver = new Stereo(); ;
            HotTub hotTubReceiver = new HotTub(); ;
            TV tvReceiver = new TV(); ;

            // set up some commands
            LightOnCommand lightOnCmd = new LightOnCommand(lightReceiverInLivingRoom);
            StereoOnWithCdCommand stereoOnCmd = new StereoOnWithCdCommand(stereoReceiver);
            HotTubOnCommand hotTubOnCmd = new HotTubOnCommand(hotTubReceiver);
            TvOnCommand tvOnCmd = new TvOnCommand(tvReceiver);
            LightOffCommand lightOffCmd = new LightOffCommand(lightReceiverInLivingRoom);
            StereoOffWithCdCommand stereoOffCmd = new StereoOffWithCdCommand(stereoReceiver);
            HotTubOffCommand hotTubOffCmd = new HotTubOffCommand(hotTubReceiver);
            TvOffCommand tvOffCmd = new TvOffCommand(tvReceiver);

            // create arrays for ON and OFF commands for our groups
            IRemoteCommand[] partyOnCommands = new IRemoteCommand[] { lightOnCmd, stereoOnCmd, hotTubOnCmd, tvOnCmd };
            IRemoteCommand[] partyOffCommands = new IRemoteCommand[] { lightOffCmd, stereoOffCmd, hotTubOffCmd, tvOffCmd };

            MacroCommand partyOnMacro = new MacroCommand(partyOnCommands);
            MacroCommand partyOffMacro = new MacroCommand(partyOffCommands);

            // set the macroCommand to a button as in other tests.
            remoteControl.SetCommand(1, partyOnMacro, partyOffMacro, "Party");


            // test
            Console.WriteLine(remoteControl.ToString());

            // push the party on button
            remoteControl.OnButtonWasPressed(1);

            // push the party off button
            remoteControl.OffButtonWasPressed(1);
            
            // push the undo button to keep the party going!
            remoteControl.UndoButtonWasPressed();
        }
    }
}
