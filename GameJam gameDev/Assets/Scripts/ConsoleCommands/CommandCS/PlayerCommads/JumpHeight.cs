using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Movement Command", menuName = "DeveloperConsole/JumpHeightCommands")]
    public class JumpHeight : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            PlayerStats.JumpHeight = value;

            return true;
        }
    }
}

