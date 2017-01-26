using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class GarageDoorCloseCommand :  IRemoteCommand
    {
        private readonly GarageDoor _receiver;

        public GarageDoorCloseCommand(GarageDoor receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            
            return _receiver.Down();

        }

        public  string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }

        public  Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

       public Action Undo()
        {
            //Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            return () => _receiver.Up();
        }
    }
}