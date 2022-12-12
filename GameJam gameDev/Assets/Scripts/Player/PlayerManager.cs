using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Movement movement;


    void Start()
    {
        movement = GetComponent<Movement>();
    }

    void Update()
    {
        movement.MovementInputs();
    }

    private void FixedUpdate()
    {
        movement.Move();
    }
}
