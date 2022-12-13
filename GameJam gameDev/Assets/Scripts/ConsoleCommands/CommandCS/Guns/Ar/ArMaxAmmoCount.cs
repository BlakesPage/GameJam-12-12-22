using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Gun Command", menuName = "DeveloperConsole/ARCommands/MaxAmmoCount")]
    public class ArMaxAmmoCount : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if((int)value < AssulteRifleStats.CurrentAmmo) AssulteRifleStats.CurrentAmmo = (int)value;

            AssulteRifleStats.MaxAmmo = (int)value;

            return true;
        }
    }
}