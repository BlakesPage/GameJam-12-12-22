using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;
using ConsoleCommands;
using TMPro;

namespace ConsoleCommands
{
    public class DeveloperConsoleBehaviour : MonoBehaviour
    {
        [SerializeField] private string prefix = string.Empty;
        [SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];

        [Header("UI")]
        public GameObject uiCanvas = null;
        [SerializeField] private TMP_InputField inputField = null;

        private float pausedTimeScale;

        private static DeveloperConsoleBehaviour instance;

        private Console devConsole;

        private Console DevConsole
        {
            get
            {
                if (devConsole != null) { return devConsole; }
                return devConsole = new Console(prefix, commands);
            }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;

            DontDestroyOnLoad(gameObject);
        }

        public void Toggle(CallbackContext context)
        {
            if (!context.action.triggered) { return; }

            if (uiCanvas.activeSelf)
            {
                Time.timeScale = pausedTimeScale;
                inputField.text = "";
                uiCanvas.SetActive(false);
            }
            else
            {
                pausedTimeScale = Time.timeScale;
                Time.timeScale = 0;
                uiCanvas.SetActive(true);
                inputField.ActivateInputField();
            }
        }

        public void ProcessCommand(string inputValue)
        {
            DevConsole.ProcessCommand(inputValue);

            inputField.text = string.Empty;
            inputField.ActivateInputField();
        }
    }

}
