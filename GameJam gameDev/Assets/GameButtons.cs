using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    private PlayerManager playerManager;

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Start()
    {
        if(playerManager != null)
        {
            playerManager.deathUI.SetActive(false);
        }
        PlayerStats.PlayerHealth = 10;
        PlayerStats.RefilAmmo();
    }
    public void Restart()
    {
        PlayerStats.RefilAmmo();
        PlayerStats.PlayerHealth = 10;
        SceneManager.LoadScene(0);
    }

    public void StatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
