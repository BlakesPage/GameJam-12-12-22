using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ConsoleCommands;

public class UIStats : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI AR;
    public TextMeshProUGUI ShotGun;
    public TextMeshProUGUI SMG;

    public GameObject ARicon;
    public GameObject ShotGunIcon;
    public GameObject SMGIcon;

    private void Start()
    {
        ARicon.SetActive(true);
        ShotGunIcon.SetActive(false);
        SMGIcon.SetActive(false);
    }

    private void Update()
    {
        health.text = PlayerStats.PlayerHealth.ToString();

        string Ar = AssulteRifleStats.CurrentClip.ToString();
        Ar += " / " + AssulteRifleStats.MagSize.ToString();
        Ar += " : " + AssulteRifleStats.CurrentAmmo.ToString();
        Ar += " / " + AssulteRifleStats.MaxAmmo.ToString();
        AR.text = Ar;

        string Shotgun = ShotGunStats.CurrentClip.ToString();
        Shotgun += " / " + ShotGunStats.MagSize.ToString();
        Shotgun += " : " + ShotGunStats.CurrentAmmo.ToString();
        Shotgun += " / " + ShotGunStats.MaxAmmo.ToString();
        ShotGun.text = Shotgun;

        string smg = SmgStats.CurrentClip.ToString();
        smg += " / " + SmgStats.MagSize.ToString();
        smg += " : " + SmgStats.CurrentAmmo.ToString();
        smg += " / " + SmgStats.MaxAmmo.ToString();
        SMG.text = smg;
    }
}
