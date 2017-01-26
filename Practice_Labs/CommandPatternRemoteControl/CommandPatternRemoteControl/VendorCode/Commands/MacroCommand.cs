using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class MacroCommand :  IRemoteCommand
    {
        private readonly IRemoteCommand[] _commands;

        public MacroCommand(IRemoteCommand[] commands)
        {
            _commands = commands;
            Name = "Macro Command";
        }

        public object Execute()
        {
            foreach (var cmd in _commands)
            {
                cmd.Execute();
            }
            return  " --- MacroCommand.Execute() Pushed --- ";
        }

        public Action Undo()
        {
            foreach (var cmd in _commands)
            {
                cmd.Undo();
            }
            return null;//{ " --- MacroCommand.Undo() Pushed --- "; }
        }

        public  string Name { get; set; }

        public string GetCommandName
        {
            get
            {
                Name =
                    MethodBase.GetCurrentMethod()
                        .DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", "");
                return Name;
            }

        }
        public Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }
    }
}
