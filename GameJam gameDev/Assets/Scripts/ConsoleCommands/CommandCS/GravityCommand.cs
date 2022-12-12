using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "gravity Command", menuName = "DeveloperConsole/GravityCommands")]
    public class GravityCommand : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            if (args.Length != 1) { return false; }

            if (!float.TryParse(args[0], out float value))
            {
                return false;
            }

            Physics2D.gravity = new Vector2(0, value * -1);

            return true;
        }
    }

}

