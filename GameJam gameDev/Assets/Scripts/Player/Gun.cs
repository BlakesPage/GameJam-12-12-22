using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum GunType { AR, ShotGun, SubmachineGun }
public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _Bullet;
    [SerializeField] Transform _firePoint;
    public void Shoot()
    {
        if(Input.GetMouseButton(0))
        {
            switch (PlayerStats.type)
            {
                case GunType.AR:
                    if(PlayerStats.ArCurrentClip > 0)
                    {
                        GameObject ARbullet = Instantiate(_Bullet, _firePoint.position, _firePoint.rotation);
                        ARbullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * PlayerStats.ArBulletVelocity, ForceMode2D.Impulse);
                        PlayerStats.ArCurrentAmmo--;
                    }
                    break;

                case GunType.ShotGun:
                    if (PlayerStats.ShotGunCurrentClip > 0)
                    {
                        GameObject ShoutGunbullet = Instantiate(_Bullet, _firePoint.position, _firePoint.rotation);
                        ShoutGunbullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * PlayerStats.SubMachineGunBulletVelocity, ForceMode2D.Impulse);
                        PlayerStats.ShotGunCurrentClip--;
                    }
                    break;

                case GunType.SubmachineGun:
                    if (PlayerStats.SubMachineGunCurrentClip > 0)
                    {
                        GameObject SMGbullet = Instantiate(_Bullet, _firePoint.position, _firePoint.rotation);
                        SMGbullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.right * PlayerStats.SubMachineGunBulletVelocity, ForceMode2D.Impulse);
                        PlayerStats.SubMachineGunCurrentClip--;
                    }
                    break;

                default:
                    PlayerStats.type = GunType.AR;
                    break;
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            switch (PlayerStats.type)
            {
                case GunType.AR:
                    PlayerStats.ReloadAR();
                    break;

                case GunType.ShotGun:
                    PlayerStats.ReloadShotGun();
                    break;

                case GunType.SubmachineGun:
                    PlayerStats.ReloadSMG();
                    break;

                default:
                    PlayerStats.type = GunType.AR;
                    break;
            }
        }
    }
}
