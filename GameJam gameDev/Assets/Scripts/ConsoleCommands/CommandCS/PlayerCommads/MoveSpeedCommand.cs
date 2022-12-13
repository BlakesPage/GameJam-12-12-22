using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Movement Command", menuName = "DeveloperConsole/MovementCommands")]
    public class MoveSpeedCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if(args.Length != 1) { return false; }

            if(!float.TryParse(args[0], out float value))
            {
                return false;
            }

            PlayerStats.MoveSpeed = value;

            return true;
        }
    }
}
