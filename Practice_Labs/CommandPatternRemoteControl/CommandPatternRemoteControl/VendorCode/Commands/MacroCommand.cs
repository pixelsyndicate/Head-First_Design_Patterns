using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class MacroCommand : BaseCommand, IRemoteCommand
    {
        private readonly IRemoteCommand[] _commands;

        public MacroCommand(IRemoteCommand[] commands)
        {
            _commands = commands;
            Name = "Macro Command";
        }

        public void Execute()
        {
            foreach (var cmd in _commands)
            {
                cmd.Execute();
            }
        }

        public void Undo()
        {
            Console.WriteLine("Undo Macro Pushed.");
            foreach (var cmd in _commands)
            {
                cmd.Undo();
            }
        }

        public override string Name { get; set; }

        public override string GetCommandName
        {
            get
            {
                Name =
                    MethodBase.GetCurrentMethod()
                        .DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", "");
                return Name;
            }

        }
        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
