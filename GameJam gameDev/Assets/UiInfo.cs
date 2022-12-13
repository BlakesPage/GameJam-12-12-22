using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiInfo : MonoBehaviour
{
    public GameObject playerUI;
    public GameObject enemyUI;
    public GameObject enemyspawnerUI;
    public GameObject GunsUI;
    public GameObject GlobalUI;

    private void Start()
    {
        PlayerUI();
    }

    public void PlayerUI()
    {
        playerUI.SetActive(true);
        enemyUI.SetActive(false);
        enemyspawnerUI.SetActive(false);
        GunsUI.SetActive(false);
        GlobalUI.SetActive(false);
    }

    public void EnemyUI()
    {
        playerUI.SetActive(false);
        enemyUI.SetActive(true);
        enemyspawnerUI.SetActive(false);
        GunsUI.SetActive(false);
        GlobalUI.SetActive(false);
    }
    public void EnemySpawnerUI()
    {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        enemyspawnerUI.SetActive(true);
        GunsUI.SetActive(false);
        GlobalUI.SetActive(false);
    }
    public void GunInfoUI()
    {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        enemyspawnerUI.SetActive(false);
        GunsUI.SetActive(true);
        GlobalUI.SetActive(false);
    }
    public void GlobalInfoUI()
    {
        playerUI.SetActive(false);
        enemyUI.SetActive(false);
        enemyspawnerUI.SetActive(false);
        GunsUI.SetActive(false);
        GlobalUI.SetActive(true);
    }
}
