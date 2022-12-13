using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Awake()
    {
        
    }
    private void Start()
    {
        float dis = Vector2.Distance(transform.position, player.transform.position);
        if(dis < EnemyStats.ExplosionRadius)
        {
            PlayerStats.PlayerHealth -= EnemyStats.ExplosionDamage;
            Debug.Log(PlayerStats.PlayerHealth);
            Debug.Log("Hit Player");
        }
    }

    float destroyTimer = 0f;

    private void Update()
    {
        destroyTimer += Time.deltaTime;
        if(destroyTimer > 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
