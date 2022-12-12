using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public int health;

    private void Start()
    {
        health = Random.Range(EnemyStats.Minhealth, EnemyStats.Maxhealth);
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }
}
