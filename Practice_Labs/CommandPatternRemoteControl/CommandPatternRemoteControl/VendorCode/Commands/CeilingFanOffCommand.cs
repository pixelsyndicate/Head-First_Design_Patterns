using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanOffCommand : IRemoteCommand
    {
        private readonly CeilingFan _receiver;
        private int _prevSpeed;
        public CeilingFanOffCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            // Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _prevSpeed = _receiver.GetLevel();
            return _receiver.Off();
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
            //  Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            // needed to track last state of multi-state elements so it could be undone.
            switch (_prevSpeed)
            {
                case CeilingFan.HIGH:
                    _prevSpeed = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.High();
                    break;
                case CeilingFan.LOW:
                    _prevSpeed = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.Low();
                    break;
                case CeilingFan.MED:

                    _prevSpeed = _receiver.GetLevel(); // added for unlimited undos  
                    _receiver.Medium();
                    break;
                default:
                    _prevSpeed = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.Off();
                    break;
            }
            return null;
        }
    }
}