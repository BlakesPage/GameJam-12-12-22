using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Gun Command", menuName = "DeveloperConsole/ARCommands/MagSize")]
    public class ArMagSize : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if((int)value < AssulteRifleStats.CurrentClip) AssulteRifleStats.CurrentClip = (int)value;

            AssulteRifleStats.MagSize = (int)value;

            return true;
        }
    }
}