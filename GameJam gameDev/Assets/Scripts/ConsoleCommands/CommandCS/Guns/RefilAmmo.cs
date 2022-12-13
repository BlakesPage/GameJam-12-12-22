using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Ammo Command", menuName = "DeveloperConsole/RefilAmmo")]
    public class RefilAmmo : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            PlayerStats.RefilAmmo();
            return true;
        }
    }
}