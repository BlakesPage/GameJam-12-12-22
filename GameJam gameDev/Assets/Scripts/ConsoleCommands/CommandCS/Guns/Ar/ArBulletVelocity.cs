using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Gun Command", menuName = "DeveloperConsole/ARCommands/Velocity")]
    public class ArBulletVelocity : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if(value < 0f) value = 0.1f;

            AssulteRifleStats.BulletVelocity = value;

            return true;
        }
    }
}