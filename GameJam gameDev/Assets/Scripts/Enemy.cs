using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    [HideInInspector] public int health;
    private GameObject player;

    [SerializeField] private GameObject explosion;
    
    private float step;
    private float movespeed;

    private float lifeTimer;

    private SpriteRenderer spriteColour;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>().gameObject;
        spriteColour = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        health = Random.Range(EnemyStats.Minhealth, EnemyStats.Maxhealth);
        movespeed = Random.Range(EnemyStats.MinMoveSpeed, EnemyStats.MaxMoveSpeed);
        step = movespeed * Time.deltaTime;

        if(movespeed < 5f)
        {
            spriteColour.color = Color.blue;
        }
        else if(movespeed > 5f && movespeed < 10f)
        {
            spriteColour.color = Color.green;
        }
        else
        {
            spriteColour.color = Color.red;
        }
    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if(health <= 0)
        {
            EnemyStats.enemies.Remove(gameObject);
            Destroy(gameObject);
        }

        float Disantace = Vector3.Distance(transform.position, player.transform.position);
        if (Disantace < EnemyStats.ExplosionRadius / 2 || lifeTimer > 60f)
        {
            switch(type)
            {
                case EnemyType.Sqaure:
                    ExplodeSqaure();
                    break;
                case EnemyType.Circle:
                    ExplodeCircle();
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }

    void ExplodeSqaure()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        EnemyStats.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    void ExplodeCircle()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        EnemyStats.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}
