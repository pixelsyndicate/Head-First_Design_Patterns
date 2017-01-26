using System;
using System.Text;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using CommandPatternRemoteControl;
using CommandPatternRemoteControl.VendorCode.Commands;
using CommandPatternRemoteControl.VendorCode.Hardware;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandPatternRemoteTests
{
    /// <summary>
    /// Summary description for RemoteControlWithLambdaTests
    /// </summary>
    [TestClass]
    public class RemoteControlWithLambdaTests
    {
        public RemoteControlWithLambdaTests()
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
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //


            // set up the invoker
            RemoteControl remoteControl = new RemoteControl();

            // set up some devices to be affected (receivers)
            Light lightReceiverInLivingRoom = new Light("Living Room");

            Light lightReceiverInBedRoom = new Light("Bed Room");

            Stereo stereoReceiver = new Stereo();

            HotTub hotTubReceiver = new HotTub();

            TV tvReceiver = new TV("Living Room");



            /* 
             * instead of creating a LightOnCommand (and off), just pass a lambda exprssion in 
            place of each object with the code expected to be run inside of their Execute() methods. 
            */
            remoteControl.SetCommand(1, new LightOnCommand(lightReceiverInLivingRoom),
                new LightOffCommand(lightReceiverInLivingRoom)
            , "Living Room Lights");

            remoteControl.SetCommand(2, () => { new LightOnCommand(lightReceiverInLivingRoom).Execute(),
                new LightOffCommand(lightReceiverInLivingRoom)
            , "Living Room Lights");


        }


    }
}

