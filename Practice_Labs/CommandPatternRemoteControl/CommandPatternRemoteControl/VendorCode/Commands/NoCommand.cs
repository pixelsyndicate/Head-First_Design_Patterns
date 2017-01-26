using System;
using System.Reflection;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class NoCommand : IRemoteCommand
    {

        public object Execute()
        {
            // return "No Command Executed.";
            return "No Command Executed.";
        }

        public string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }

        public Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

        public Action Undo()
        {
            return null;//() => "No Command Executed.";

        }

        public string Name { get; set; } = "No Command";


    }

}
