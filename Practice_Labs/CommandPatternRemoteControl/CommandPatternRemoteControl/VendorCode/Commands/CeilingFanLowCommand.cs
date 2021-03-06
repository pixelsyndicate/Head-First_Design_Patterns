﻿using System;
using System.Reflection;
using CommandPatternRemoteControl.VendorCode.Hardware;

namespace CommandPatternRemoteControl.VendorCode.Commands
{
    public class CeilingFanLowCommand : IRemoteCommand
    {
        private readonly CeilingFan _receiver;
        private int _prevSpeed;

        public CeilingFanLowCommand(CeilingFan receiver)
        {
            _receiver = receiver;
        }

        public object Execute()
        {
            // we now track the speed before changes
            _prevSpeed = _receiver.GetLevel();
            return _receiver.Low();
        }

        public Action Undo()
        {
            //  Console.WriteLine("\n ----- UNDO PRESSED ----- \n");
            // needed to track last state of multi-state elements so it could be undone.
            switch (_prevSpeed)
            {
                case CeilingFan.HIGH:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetLevel();
                    _receiver.High();
                    break;
                case CeilingFan.LOW:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetLevel();
                    _receiver.Low();
                    break;
                case CeilingFan.MED:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetLevel();
                    _receiver.Medium();
                    break;
                default:
                    // we now track the speed before changes
                    _prevSpeed = _receiver.GetLevel();
                    _receiver.Off();
                    break;
            }

            return null;
        }

        public string GetCommandName
        {
            get { return MethodBase.GetCurrentMethod().DeclaringType?.FullName.Replace("CommandPatternRemoteControl.VendorCode.Commands.", ""); }

        }

        public Type GetCommandType
        {
            get { throw new NotImplementedException(); }
        }


    }
}