using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    [HideInInspector] public int health;
    [SerializeField] private Transform player;
    
    private float step;
    private float movespeed;

    private void Start()
    {
        health = Random.Range(EnemyStats.Minhealth, EnemyStats.Maxhealth);
        movespeed = Random.Range(EnemyStats.MinMoveSpeed, EnemyStats.MaxMoveSpeed);
        step = movespeed * Time.deltaTime;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }
}
