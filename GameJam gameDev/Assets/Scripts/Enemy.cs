using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    [HideInInspector] public int health;
    private GameObject player;

    [SerializeField] private List<GameObject> explosion = new List<GameObject>();
    
    private float step;
    private float movespeed;
    private float size;

    private float lifeTimer;

    private SpriteRenderer spriteColour;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>().gameObject;
        spriteColour = GetComponent<SpriteRenderer>();
    }
    int rand;
    private void Start()
    {
        health = Random.Range(EnemyStats.Minhealth, EnemyStats.Maxhealth);
        movespeed = Random.Range(EnemyStats.MinMoveSpeed, EnemyStats.MaxMoveSpeed);
        size = Random.Range(EnemyStats.MinSize, EnemyStats.MaxSize);
        transform.localScale = new Vector3(size, size, size);
        step = movespeed * Time.deltaTime;

        int ran = Random.Range(0, Colours.coloursLength);

        spriteColour.color = Colours.colours[ran];

        rand = Random.Range(0, explosion.Count);
    }

    private void Update()
    {
        lifeTimer += Time.deltaTime;
        if(health <= 0)
        {
            EnemyStats.enemies.Remove(gameObject);
            Instantiate(explosion[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        float Disantace = Vector3.Distance(transform.position, player.transform.position);
        if (Disantace < EnemyStats.ExplosionRadius / 2 || lifeTimer > 60f)
        {
            Explode();
        }
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
    }

    void Explode()
    {
        Instantiate(explosion[rand], transform.position, Quaternion.identity);
        EnemyStats.enemies.Remove(gameObject);
        Destroy(gameObject);
    }
}


[System.Serializable]
public static class Colours
{
    public static Color red => new Color(1f, 0f, 0f, 1f);
    public static Color purple => new Color(124f/255f, 0f, 255f, 1f);
    public static Color orange => new Color(255f, 158f / 255f , 0f, 1f);
    public static Color pink => new Color(255f, 0f, 236f / 255f, 1f);
    public static Color cyan => new Color(0f, 0f / 220f / 255f, 255f, 1f);
    public static Color green => new Color(8f / 255f, 255f, 0f, 1f);

    public static Color[] colours => new Color[] { red, purple, cyan, orange, pink, green };
    public static int coloursLength = colours.Length;
}