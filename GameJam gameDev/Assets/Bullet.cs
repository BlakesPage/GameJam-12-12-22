using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GunType type;
    private int damage;


    private void Start()
    {
        switch (type)
        {
            case GunType.AR:
                damage = PlayerStats.ArBulletDamage;
                break;
            case GunType.ShotGun:
                damage = PlayerStats.ShotGunBulletDamage;
                break;
            case GunType.SubmachineGun:
                damage = PlayerStats.SubMachineGunBulletDamage;
                break;
            default:
                type = GunType.AR;
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
        }
    }
}
