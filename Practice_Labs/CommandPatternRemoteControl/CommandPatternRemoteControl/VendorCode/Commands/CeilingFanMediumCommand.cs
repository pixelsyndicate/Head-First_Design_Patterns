using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanMediumCommand :  IRemoteCommand
    {
        private readonly CeilingFan _receiver;
        private int _prevLevel;


        public CeilingFanMediumCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }


        public string GetCommandName
        {
            get
            {
                return
                    MethodBase.GetCurrentMethod()
                        .DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", "");
            }

        }
        

        public object Execute()
        {
            // we now track the speed before changes
            _prevLevel = _receiver.GetLevel();
            return  _receiver.Medium();
        }

       public Action Undo()
        {
            //  Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            // needed to track last state of multi-state elements so it could be undone.
            switch (_prevLevel)
            {
                case CeilingFan.HIGH:
                    _prevLevel = _receiver.GetLevel(); // added for unlimited undos
                    return () =>  _receiver.High();
                    break;
                case CeilingFan.LOW:
                    _prevLevel = _receiver.GetLevel(); // added for unlimited undos
                    return () => _receiver.Low();
                    break;
                case CeilingFan.MED:
                    _prevLevel = _receiver.GetLevel(); // added for unlimited undos
                    return () => _receiver.Medium();

                    break;
                default:
                    _prevLevel = _receiver.GetLevel(); // added for unlimited undos
                    return () => _receiver.Off();
                    break;
            }
        }
    }
}