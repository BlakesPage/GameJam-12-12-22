using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;


namespace ConsoleCommands
{
    [CreateAssetMenu(fileName = "New Log Command", menuName = "DeveloperConsole/LogCommands")]
    public class LogCommands : ConsoleCommand
    {
        public override bool Process(string[] args)
        {
            string logText = string.Join(" ", args);

            Debug.Log(logText);

            return true;
        }
    }
}
