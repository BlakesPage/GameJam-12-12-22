using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Gun gun;
    [SerializeField] private GameObject deathUI;

    void Start()
    {
        movement = GetComponent<Movement>();
        gun = GetComponent<Gun>();
    }

    void Update()
    {
        movement.MovementInputs();

        gun.Shoot(PlayerStats.type);
        gun.TryingToReload();

        if(Died)
        {
            deathUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void FixedUpdate()
    {
        movement.Move();
    }

    public bool Died
    {
        get
        {
            if (PlayerStats.PlayerHealth <= 0)
            {
                return true;
            }
            return false;
        }
    }
}
