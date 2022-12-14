using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int damage;
    private void Start()
    {
        switch (PlayerStats.type)
        {
            case GunType.AR:
                damage = AssulteRifleStats.BulletDamage;
                break;
            case GunType.SubmachineGun:
                damage = SmgStats.BulletDamage;
                break;
            default:
                PlayerStats.type = GunType.AR;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.health -= damage;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
