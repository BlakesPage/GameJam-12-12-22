using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private bool damage = false;

    float destroyTimer = 0f;

    GameObject player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>().gameObject;
    }

    private void Update()
    {
        if(!damage)
        {
            float dis = Vector2.Distance(transform.position, player.transform.position);
            if (dis < EnemyStats.ExplosionRadius)
            {
                PlayerStats.PlayerHealth -= EnemyStats.ExplosionDamage;
            }
            damage = true;
        }

        destroyTimer += Time.deltaTime;
        if(destroyTimer > 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
