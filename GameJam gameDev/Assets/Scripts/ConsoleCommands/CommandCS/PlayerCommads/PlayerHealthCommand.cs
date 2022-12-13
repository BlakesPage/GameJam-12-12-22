using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Movement Command", menuName = "DeveloperConsole/HealthCommands")]
    public class PlayerHealthCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            PlayerStats.PlayerHealth = (int)value;

            return true;
        }
    }
}

