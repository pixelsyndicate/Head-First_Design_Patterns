using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class HotTubOnCommand : BaseCommand, IRemoteCommand
    {
        private readonly HotTub _receiver;
        private int _prevTemp;

        public HotTubOnCommand(HotTub receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            _receiver.On(HotTub.MED);

        }
        public override string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }
        public override Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }

        public void Undo()
        {
           // Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            // needed to track last state of multi-state elements so it could be undone.
            switch (_prevTemp)
            {
                case HotTub.HIGH:
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.High();
                    break;
                case HotTub.LOW:
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.Low();
                    break;
                case HotTub.MED:
                    _receiver.Medium();
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    break;
                default:
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.Off();
                    break;
            }

        }
    }

}