using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Gun Command", menuName = "DeveloperConsole/SmgCommands/ReloadTime")]
    public class SMGReloadTime : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if (value < 0f) value = 0.1f;

            SmgStats.RealoadTime = value;

            return true;
        }
    }
}