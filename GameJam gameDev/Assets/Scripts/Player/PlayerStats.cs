using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class PlayerStats
{
    // Gun Type
    public static GunType type { get; set; } = GunType.AR;

    public static int EnumCount = Enum.GetNames(typeof(GunType)).Length;

    // Player Stats
    public static int PlayerHealth { get; set; } = 10;
    public static float MoveSpeed { get; set; } = 6f;
    public static float JumpHeight { get; set; } = 6f;
    public static float fallMultiplier { get; set; } = 1.05f;

    public static void RefilAmmo()
    {
        SmgStats.CurrentAmmo += SmgStats.MaxAmmo;
        if (SmgStats.CurrentAmmo > SmgStats.MaxAmmo)
        {
            SmgStats.CurrentAmmo = SmgStats.MaxAmmo;
        }
        SmgStats.CurrentClip = SmgStats.MagSize;

        //Debug.Log(SmgStats.CurrentAmmo + " " + SmgStats.MaxAmmo);

        ShotGunStats.CurrentAmmo += ShotGunStats.MaxAmmo;
        if (ShotGunStats.CurrentAmmo > ShotGunStats.MaxAmmo)
        {
            ShotGunStats.CurrentAmmo = ShotGunStats.MaxAmmo;
        }
        ShotGunStats.CurrentClip = ShotGunStats.MagSize;

        //Debug.Log(ShotGunStats.CurrentAmmo + " " + ShotGunStats.MaxAmmo);

        AssulteRifleStats.CurrentAmmo += AssulteRifleStats.MaxAmmo;
        if (AssulteRifleStats.CurrentAmmo > AssulteRifleStats.MaxAmmo)
        {
            AssulteRifleStats.CurrentAmmo = AssulteRifleStats.MaxAmmo;
        }
        AssulteRifleStats.CurrentClip = AssulteRifleStats.MagSize;

        //Debug.Log(AssulteRifleStats.CurrentAmmo + " " + AssulteRifleStats.MaxAmmo);
        Debug.Log("Ammo Full");
    }
}

public static class SmgStats
{
    // Submachine Gun Stats
    public static float FireRate { get; set; } = 0.1f;
    public static int MagSize { get; set; } = 60;
    public static int CurrentClip { get; set; } = 60;
    public static int MaxAmmo { get; set; } = 240;
    public static int CurrentAmmo { get; set; } = 240;
    public static int BulletDamage { get; set; } = 2;
    public static float BulletVelocity { get; set; } = 25f;

    public static void ReloadSMG()
    {
        int reloadAmount = MagSize - CurrentClip;
        reloadAmount = (CurrentAmmo - reloadAmount) >= 0 ? reloadAmount : CurrentAmmo;
        CurrentClip += reloadAmount;
        CurrentAmmo -= reloadAmount;
    }

    public static void AddAmmoSMG(int ammoAmount)
    {
        CurrentAmmo += ammoAmount;
        if (CurrentAmmo > MaxAmmo)
        {
            CurrentAmmo = MaxAmmo;
        }
    }
}

public static class ShotGunStats
{
    // ShotGun Stats
    public static float FireRate { get; set; } = 0.8f;
    public static int MagSize { get; set; } = 6;
    public static int CurrentClip { get; set; } = 6;
    public static int MaxAmmo { get; set; } = 60;
    public static int CurrentAmmo { get; set; } = 60;
    public static int BulletDamage { get; set; } = 8;
    public static float BulletVelocity { get; set; } = 25f;

    public static void ReloadShotGun()
    {
        int reloadAmount = MagSize - CurrentClip;
        reloadAmount = (CurrentAmmo - reloadAmount) >= 0 ? reloadAmount : CurrentAmmo;
        CurrentClip += reloadAmount;
        CurrentAmmo -= reloadAmount;
    }
    public static void AddAmmoShotgun(int ammoAmount)
    {
        CurrentAmmo += ammoAmount;
        if (CurrentAmmo > MaxAmmo)
        {
            CurrentAmmo = MaxAmmo;
        }
    }
}

public static class AssulteRifleStats
{
    // Ar Stats
    public static float FireRate { get; set; } = 0.2f;
    public static int MagSize { get; set; } = 25; // mag size
    public static int CurrentClip { get; set; } = 25; // current ammo in mag
    public static int MaxAmmo { get; set; } = 150; // max ammo is reserve
    public static int CurrentAmmo { get; set; } = 150; // current ammo in reserve
    public static int BulletDamage { get; set; } = 4;
    public static float BulletVelocity { get; set; } = 25f;

    public static void ReloadAR()
    {
        int reloadAmount = MagSize - CurrentClip;
        reloadAmount = (CurrentAmmo - reloadAmount) >= 0 ? reloadAmount : CurrentAmmo;
        CurrentClip += reloadAmount;
        CurrentAmmo -= reloadAmount;
        Debug.Log("Current Clip: " + CurrentClip + " Current Ammo " + CurrentAmmo);
    }

    public static void AddAmmoAr(int ammoAmount)
    {
        CurrentAmmo += ammoAmount;
        if (CurrentAmmo > MaxAmmo)
        {
            CurrentAmmo = MaxAmmo;
        }
        
    }
}

[System.Serializable]
public enum EnemyType { Circle, Sqaure }
public static class EnemyStats
{ 
    public static List<GameObject> enemies = new List<GameObject>();
    public static int SpawnRate { get; set; } = 5;
    public static float SpawnInterval { get; set; } = 3f;
    public static float MinMoveSpeed { get; set; } = 2f;
    public static float MaxMoveSpeed { get; set; } = 5f;
    public static int Minhealth { get; set; } = 10;
    public static int Maxhealth { get; set; } = 25;
    public static int ExplosionDamage { get; set; } = 3;
    public static float ExplosionRadius { get; set; } = 4f;
}
