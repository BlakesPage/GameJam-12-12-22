using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Gun Command", menuName = "DeveloperConsole/SmgCommands/MagSize")]
    public class SMGMagSize : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if (value <= 0f) value = 1f;

            if (value < SmgStats.CurrentClip) SmgStats.CurrentClip = (int)value;

            SmgStats.MagSize = (int)value;

            return true;
        }
    }
}