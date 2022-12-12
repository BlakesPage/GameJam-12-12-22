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

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>().gameObject;
    }

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
            EnemyStats.enemies.Remove(gameObject);
            Destroy(gameObject);
        }
        float Disantace = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(Disantace);
        if (Disantace < EnemyStats.ExplosionRadius / 2)
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

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(Vector3.zero, 3f);
    //}
}
