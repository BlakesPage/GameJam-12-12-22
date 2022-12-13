using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerHealth;
    public TextMeshProUGUI MoveSpeed;
    public TextMeshProUGUI JumpHeight;
    public TextMeshProUGUI Weight;

    public TextMeshProUGUI ArFireRate;
    public TextMeshProUGUI ArMagSize;
    public TextMeshProUGUI ArMaxAmmo;
    public TextMeshProUGUI ArBulletDamage;
    public TextMeshProUGUI ArBulletVelocity;
    public TextMeshProUGUI ArRealoadTime;

    public TextMeshProUGUI SmgFireRate;
    public TextMeshProUGUI SmgMagSize;
    public TextMeshProUGUI SmgMaxAmmo;
    public TextMeshProUGUI SmgBulletDamage;
    public TextMeshProUGUI SmgBulletVelocity;
    public TextMeshProUGUI SmgReloadTime;

    public TextMeshProUGUI EnemySpawerInterval;
    public TextMeshProUGUI EnemySpawnerAmount;

    public TextMeshProUGUI EnemyMinSpeed;
    public TextMeshProUGUI EnemyMaxSpped;
    public TextMeshProUGUI EnemyMinHealth;
    public TextMeshProUGUI EnemyMaxHealth;
    public TextMeshProUGUI EnemyExplosionDamage;
    public TextMeshProUGUI EnemyExplosionRadius;

    public TextMeshProUGUI Gravity;

    void Update()
    {
        playerHealth.text = "Player Health: " + PlayerStats.PlayerHealth;
        MoveSpeed.text = "Player MoveSpeed: " + PlayerStats.MoveSpeed;
        JumpHeight.text = "Player JumpHeight: " + PlayerStats.JumpHeight;
        Weight.text = "Player Weight: " + PlayerStats.fallMultiplier;

        ArFireRate.text = "Fire Rate: " + AssulteRifleStats.FireRate;
        ArMagSize.text = "Mag Size: " + AssulteRifleStats.MagSize;
        ArMaxAmmo.text = "Max Ammo: " + AssulteRifleStats.MaxAmmo;
        ArBulletDamage.text = "Bullet Damage: " + AssulteRifleStats.BulletDamage;
        ArBulletVelocity.text = "Bullet Velocity: " + AssulteRifleStats.BulletVelocity;
        ArRealoadTime.text = "Reload Time: " + AssulteRifleStats.RealoadTime;

        SmgFireRate.text = "Fire Rate: " + SmgStats.FireRate;
        SmgMagSize.text = "Mag Size: " + SmgStats.MagSize;
        SmgMaxAmmo.text = "Max Ammo: " + SmgStats.MaxAmmo;
        SmgBulletDamage.text = "Bullet Damage: " + SmgStats.BulletDamage;
        SmgBulletVelocity.text = "Bullet Velocity: " + SmgStats.BulletVelocity;
        SmgReloadTime.text = "Reload Time: " + SmgStats.RealoadTime;

        EnemySpawerInterval.text = "Enemy Spawn Timer: " + EnemyStats.SpawnInterval;
        EnemySpawnerAmount.text = "Enemy Spawn Amount: " + EnemyStats.SpawnAmount;

        EnemyMinSpeed.text = "Enemy Min Speed: " + EnemyStats.MinMoveSpeed;
        EnemyMaxSpped.text = "Enemy Max Speed: " + EnemyStats.MaxMoveSpeed;
        EnemyMinHealth.text = "Enemy Min Health: " + EnemyStats.Minhealth;
        EnemyMaxHealth.text = "Enemy Max Health: " + EnemyStats.Maxhealth;
        EnemyExplosionDamage.text = "Explosion Damage: " + EnemyStats.ExplosionDamage;
        EnemyExplosionRadius.text = "Explosion Radius: " + EnemyStats.ExplosionRadius;

        Gravity.text = "Gravity: " + Physics2D.gravity.y;
    }
}
