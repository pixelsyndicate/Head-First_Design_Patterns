using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class HotTubOffCommand :  IRemoteCommand
    {
        private readonly HotTub _receiver;
        private int _prevTemp;
        public HotTubOffCommand(HotTub receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            // we now track the speed before changes
            _prevTemp = _receiver.GetLevel();
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
            // Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            // needed to track last state of multi-state elements so it could be undone.
            switch (_prevTemp)
            {
                case HotTub.HIGH:
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    return () => _receiver.High();
                    break;
                case HotTub.LOW:
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    return () => _receiver.Low();
                    break;
                case HotTub.MED:

                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos   
                    return () => _receiver.Medium();
                    break;
                default:
                    _prevTemp = _receiver.GetLevel(); // added for unlimited undos
                    return () => _receiver.Off();
                    break;
            }
            // _receiver.Off();
        }
    }
}