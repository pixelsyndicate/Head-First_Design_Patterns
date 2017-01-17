using System;
using System.Reflection;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class NoCommand : BaseCommand, IRemoteCommand
    {

        public void Execute()
        {
            Console.WriteLine("Beep!");
            Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
        }

        public override string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.ToString().Replace("CommandPatternRemoteControl.VendorCode.", ""); }
        }

        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

        public string Name { get; set; } = "No Command";


    }

}
