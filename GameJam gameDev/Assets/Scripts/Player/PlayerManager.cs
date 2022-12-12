using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Gun gun;
    [SerializeField] private PlayerHealth health;

    void Start()
    {
        movement = GetComponent<Movement>();
        gun = GetComponent<Gun>();
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        movement.MovementInputs();
        gun.Shoot(PlayerStats.type);
        health.CanDie();
    }

    private void FixedUpdate()
    {
        movement.Move();
    }
}
