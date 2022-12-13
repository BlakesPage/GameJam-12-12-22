using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Gun gun;
    [SerializeField] public GameObject deathUI;

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
