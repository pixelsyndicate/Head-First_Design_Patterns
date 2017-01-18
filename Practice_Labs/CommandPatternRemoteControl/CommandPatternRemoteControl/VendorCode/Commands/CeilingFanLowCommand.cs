using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanLowCommand : BaseCommand, IRemoteCommand
    {
        private readonly CeilingFan _receiver;
        private int _prevSpeed;

        public CeilingFanLowCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            // we now track the speed before changes
            _prevSpeed = _receiver.GetSpeed();
            _receiver.Low();
        }

        public void Undo()
        {
            Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            // needed to track last state of multi-state elements so it could be undone.
            switch (_prevSpeed)
            {
                case CeilingFan.HIGH:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetSpeed();
                    _receiver.High();
                    break;
                case CeilingFan.LOW:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetSpeed();
                    _receiver.Low();
                    break;
                case CeilingFan.MED:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetSpeed();
                    _receiver.Medium();
                    break;
                default:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetSpeed();
                    _receiver.Off();
                    break;
            }
        }


        public override string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }

        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }


    }
}