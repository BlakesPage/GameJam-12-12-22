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
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] guns = new Sprite[3];

    [SerializeField] private UIStats _uiStats;

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
                        float arc = ShotGunStats.SpreadAngle;
                        float shots = ShotGunStats.Pellets;
                        float angleStep = arc / shots;

                        float rotation = (float)Mathf.Atan2(_firePoint.position.x - transform.position.x, _firePoint.position.y - transform.position.y) * 180 / Mathf.PI;
                        for (int i = 0; i < shots; i++)
                        {
                            float rotationO = -rotation - arc / 2 + angleStep / 2;
                            rotationO += angleStep * i;
                            Vector2 GoHere = PointWithPolarOffset(new Vector2(_firePoint.position.x, _firePoint.position.y), 1f, rotationO).normalized;

                            GameObject ShoutGunbullet = Instantiate(_Bullet, _firePoint.position, Quaternion.identity);
                            
                            ShoutGunbullet.GetComponent<Rigidbody2D>().AddForce(GoHere * ShotGunStats.BulletVelocity, ForceMode2D.Impulse);
                            //ShoutGunbullet.GetComponent<Rigidbody2D>().AddForce(GoHere, ForceMode2D.Impulse);

                            Debug.Log(GoHere * ShotGunStats.BulletVelocity);
                        }
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float arc = ShotGunStats.SpreadAngle;
        float shots = ShotGunStats.Pellets;
        float angleStep = arc / shots;

        float rotation = (float)Mathf.Atan2(_firePoint.position.x - transform.position.x, _firePoint.position.y - transform.position.y) * 180 / Mathf.PI;

        for(int i = 0; i < shots; i++)
        {
            float rotationO = rotation - arc / 2 + angleStep / 2;
            rotationO += angleStep * i;
            Vector2 GoHere = PointWithPolarOffset(new Vector2(_firePoint.position.x, _firePoint.position.y), 1f, rotationO);

            Gizmos.DrawWireSphere(GoHere, 0.1f);
        }
        Gizmos.DrawWireSphere(_firePoint.position, 0.2f);
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
        SwapWeapon();
    }

    private int weaponIndex;

    void SwapWeapon()
    {
        bool detect = false;
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponIndex = 0;
            detect = true;
            _uiStats.ARicon.SetActive(true);
            _uiStats.ShotGunIcon.SetActive(false);
            _uiStats.SMGIcon.SetActive(false);
            _spriteRenderer.sprite = guns[weaponIndex];
            Debug.Log("AR");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponIndex = 1;
            detect = true;
            _uiStats.ARicon.SetActive(false);
            _uiStats.ShotGunIcon.SetActive(true);
            _uiStats.SMGIcon.SetActive(false);
            _spriteRenderer.sprite = guns[weaponIndex];
            Debug.Log("ShotGun");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponIndex = 2;
            detect = true;
            _uiStats.ARicon.SetActive(false);
            _uiStats.ShotGunIcon.SetActive(false);
            _uiStats.SMGIcon.SetActive(true);
            _spriteRenderer.sprite = guns[weaponIndex];
            Debug.Log("SMG");
        }
        if(detect)
        {
            switch (weaponIndex)
            {
                case 0:
                    PlayerStats.type = GunType.AR;
                    break;
                case 1:
                    PlayerStats.type = GunType.ShotGun;
                    break;
                case 2:
                    PlayerStats.type = GunType.SubmachineGun;
                    break;
            }
        }
    }

    public static Vector2 PointWithPolarOffset(Vector2 origin, float distance, float offset)
    {
        Vector2 point;
        point.x = origin.x + Mathf.Sin((offset * Mathf.PI) / 180) * distance;
        point.y = origin.y + Mathf.Cos((offset * Mathf.PI) / 180) * distance;
        return point;
    }
}
