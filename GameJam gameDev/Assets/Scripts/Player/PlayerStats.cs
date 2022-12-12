using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    // Gun Type
    public static GunType type { get; set; } = GunType.AR;

    // Player Stats
    public static int PlayerHealth { get; set; } = 10;
    public static float MoveSpeed { get; set; } = 6f;
    public static float JumpHeight { get; set; } = 6f;
    public static float fallMultiplier { get; set; } = 1.05f;

    // Ar Stats
    public static float ArFireRate { get; set; } = 60f;
    public static int ArMagSize { get; set; } = 25; // mag size
    public static int ArCurrentClip { get; set; } = 25; // current ammo in mag
    public static int ArMaxAmmo { get; set; } = 150; // max ammo is reserve
    public static int ArCurrentAmmo { get; set; } = 150; // current ammo in reserve
    public static int ArBulletDamage { get; set; } = 4;
    public static float ArBulletVelocity { get; set; } = 25f;

    public static void ReloadAR()
    {
        int reloadAmount = PlayerStats.ArMagSize - PlayerStats.ArCurrentClip;
        reloadAmount = (PlayerStats.ArCurrentAmmo - reloadAmount) >= 0 ? reloadAmount : PlayerStats.ArCurrentAmmo;
        PlayerStats.ArCurrentClip += reloadAmount;
        PlayerStats.ArCurrentAmmo -= reloadAmount;
    }

    public static void AddAmmoAr(int ammoAmount)
    {
        ArCurrentAmmo += ammoAmount;
        if(ArCurrentAmmo > ArMaxAmmo)
        {
            ArCurrentAmmo = ArMaxAmmo;
        }
    }

    // ShotGun Stats
    public static float ShotGunFireRate { get; set; } = 12f;
    public static int ShotGunMagSize { get; set; } = 6;
    public static int ShotGunCurrentClip { get; set; } = 6;
    public static int ShotGunMaxAmmo { get; set; } = 60;
    public static int ShotGunCurrentAmmo { get; set; } = 60;
    public static int ShotGunBulletDamage { get; set; } = 8;
    public static float ShotGunBulletVelocity { get; set; } = 25f;

    public static void ReloadShotGun()
    {
        int reloadAmount = PlayerStats.ShotGunMagSize - PlayerStats.ShotGunCurrentClip;
        reloadAmount = (PlayerStats.ShotGunCurrentAmmo - reloadAmount) >= 0 ? reloadAmount : PlayerStats.ShotGunCurrentAmmo;
        PlayerStats.ShotGunCurrentClip += reloadAmount;
        PlayerStats.ShotGunCurrentAmmo -= reloadAmount;
    }
    public static void AddAmmoShotgun(int ammoAmount)
    {
        ShotGunCurrentAmmo += ammoAmount;
        if (ShotGunCurrentAmmo > ShotGunMaxAmmo)
        {
            ShotGunCurrentAmmo = ShotGunMaxAmmo;
        }
    }

    // Submachine Gun Stats
    public static float SubMachineGunFireRate { get; set; } = 120f;
    public static int SubMachineGunMagSize { get; set; } = 60;
    public static int SubMachineGunCurrentClip { get; set; } = 60;
    public static int SubMachineGunMaxAmmo { get; set; } = 240;
    public static int SubMachineGunCurrentAmmo { get; set; } = 240;
    public static int SubMachineGunBulletDamage { get; set; } = 2;
    public static float SubMachineGunBulletVelocity { get; set; } = 25f;

    public static void ReloadSMG()
    {
        int reloadAmount = PlayerStats.SubMachineGunMagSize - PlayerStats.SubMachineGunCurrentClip;
        reloadAmount = (PlayerStats.SubMachineGunCurrentAmmo - reloadAmount) >= 0 ? reloadAmount : PlayerStats.SubMachineGunCurrentAmmo;
        PlayerStats.SubMachineGunCurrentClip += reloadAmount;
        PlayerStats.SubMachineGunCurrentAmmo -= reloadAmount;
    }

    public static void AddAmmoSMG(int ammoAmount)
    {
        ShotGunCurrentAmmo += ammoAmount;
        if (ShotGunCurrentAmmo > ShotGunMaxAmmo)
        {
            ShotGunCurrentAmmo = ShotGunMaxAmmo;
        }
    }
}

[System.Serializable]
public enum EnemyType { Circle, Sqaure }
public static class EnemyStats
{ 
    public static int SpawnRate { get; set; } = 5;
    public static float MinMoveSpeed { get; set; } = 3f;
    public static float MaxMoveSpeed { get; set; } = 10f;
    public static int Minhealth { get; set; } = 10;
    public static int Maxhealth { get; set; } = 25;
}
