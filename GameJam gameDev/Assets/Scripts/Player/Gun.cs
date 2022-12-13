using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConsoleCommands;

[System.Serializable]
public enum GunType { AR, SubmachineGun }
public class Gun : MonoBehaviour
{
    [SerializeField] private DeveloperConsoleBehaviour dev;
    [SerializeField] private GameObject _Bullet;
    [SerializeField] Transform _firePoint;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite[] guns = new Sprite[2];

    [SerializeField] private UIStats _uiStats;

    private float lastTimeShoot = 0f;

    private void Start()
    {
        dev = FindObjectOfType<DeveloperConsoleBehaviour>();
    }

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

    bool isReloadingAR = false;
    float reloadTimerAR;
    float reloadTimerSMG;
    bool isReloadingSMG = false;


    public void TryingToReload()
    {
        if (isReloadingAR)
        {
            reloadTimerAR += Time.deltaTime;
            Debug.Log(reloadTimerAR);
            if(reloadTimerAR > AssulteRifleStats.RealoadTime)
            {
                AssulteRifleStats.ReloadAR();
                reloadTimerAR = 0;
                isReloadingAR = false;
            }
        }
        if (isReloadingSMG)
        {
            reloadTimerSMG += Time.deltaTime;
            if (reloadTimerSMG > AssulteRifleStats.RealoadTime)
            {
                SmgStats.ReloadSMG();
                reloadTimerSMG = 0;
                isReloadingSMG = false;
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
                    isReloadingAR = true;
                    break;

                case GunType.SubmachineGun:
                    isReloadingSMG = true;
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
            _uiStats.SMGIcon.SetActive(false);
            _spriteRenderer.sprite = guns[weaponIndex];
            Debug.Log("AR");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponIndex = 1;
            detect = true;
            _uiStats.ARicon.SetActive(false);
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
