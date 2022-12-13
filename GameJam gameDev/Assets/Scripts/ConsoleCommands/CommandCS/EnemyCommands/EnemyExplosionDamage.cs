using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Spawner Command", menuName = "DeveloperConsole/EnemyCommands/ExplosionDamage")]
    public class EnemyExplosionDamage : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if (value <= 0) value = 1;

            EnemyStats.ExplosionDamage = (int)value;

            return true;
        }
    }
}
