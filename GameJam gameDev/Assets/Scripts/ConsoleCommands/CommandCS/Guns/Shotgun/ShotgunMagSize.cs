using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Gun Command", menuName = "DeveloperConsole/ShotgunCommands/MagSize")]
    public class ShotgunMagSize : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if(value < 0f) value = 1f;

            if(value < ShotGunStats.CurrentClip) ShotGunStats.CurrentClip = (int)value;

            ShotGunStats.MagSize = (int)value;

            return true;
        }
    }
}