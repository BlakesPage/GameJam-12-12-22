using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

[System.Serializable]
public enum GunType { AR, ShotGun, SubmachineGun }
public class Gun : MonoBehaviour
{
    [SerializeField] private DeveloperConsoleBehaviour dev;
    [SerializeField] private GameObject _Bullet;
    [SerializeField] Transform _firePoint;

    private float lastTimeShoot = 0f;

    public void SpawnBullet()
    {
        GunType type = PlayerStats.type;
        if (Input.GetMouseButton(0))
        {
            switch (type)
            {
                case GunType.AR:
                    if (AssulteRifleStats.CurrentClip > 0)
                    {
                        GameObject ARbullet = Instantiate(_Bullet, _firePoint.position, _firePoint.rotation);
                        ARbullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * AssulteRifleStats.BulletVelocity, ForceMode2D.Impulse);
                        AssulteRifleStats.CurrentClip--;
                    }
                    break;

                case GunType.ShotGun:
                    if (ShotGunStats.CurrentClip > 0)
                    {
                        GameObject ShoutGunbullet = Instantiate(_Bullet, _firePoint.position, _firePoint.rotation);
                        ShoutGunbullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * ShotGunStats.BulletVelocity, ForceMode2D.Impulse);
                        ShotGunStats.CurrentClip--;
                    }
                    break;

                case GunType.SubmachineGun:
                    if (SmgStats.CurrentClip > 0)
                    {
                        GameObject SMGbullet = Instantiate(_Bullet, _firePoint.position, _firePoint.rotation);
                        SMGbullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * SmgStats.BulletVelocity, ForceMode2D.Impulse);
                        SmgStats.CurrentClip--;
                    }
                    break;

                default:
                    PlayerStats.type = GunType.AR;
                    break;
            }
        }
    }

    void Reload(GunType type)
    {
        if (Input.GetKeyDown(KeyCode.R) && !dev.uiCanvas.activeInHierarchy)
        {
            switch (type)
            {
                case GunType.AR:
                    AssulteRifleStats.ReloadAR();
                    break;

                case GunType.ShotGun:
                    ShotGunStats.ReloadShotGun();
                    break;

                case GunType.SubmachineGun:
                    SmgStats.ReloadSMG();
                    break;

                default:
                    PlayerStats.type = GunType.AR;
                    break;
            }
        }
    }
    public void Shoot(GunType type)
    {
        float fireRate = 0;
        
        switch (type)
        {
            case GunType.AR:
                fireRate = AssulteRifleStats.FireRate;
                break;

            case GunType.ShotGun:
                fireRate = ShotGunStats.FireRate;
                break;

            case GunType.SubmachineGun:
                fireRate = SmgStats.FireRate;
                break;

            default:
                PlayerStats.type = GunType.AR;
                break;
        }

        if (Time.time > lastTimeShoot + fireRate)
        {
            lastTimeShoot = Time.time;
            SpawnBullet();
        }

        Reload(type);
    }
}
