﻿using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanOffCommand : BaseCommand, IRemoteCommand
    {
        private readonly CeilingFan _receiver;
        private int _prevSpeed;
        public CeilingFanOffCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }

        public void Execute()
        {
            // Console.WriteLine("\n ----- Blink Blink Blink ----- \n");
            _prevSpeed = _receiver.GetLevel();
            _receiver.Off();
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
                    _receiver.Medium();
                    _prevSpeed = _receiver.GetLevel(); // added for unlimited undos
                    break;
                default:
                    _prevSpeed = _receiver.GetLevel(); // added for unlimited undos
                    _receiver.Off();
                    break;
            }
        }
    }
}