using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Spawner Command", menuName = "DeveloperConsole/EnemySpawnCommands/SpawnInterval")]
    public class EnemySpawnInterval : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            if (value <= 0) value = 0.1f;

            EnemyStats.SpawnInterval = value;

            return true;
        }
    }
}
