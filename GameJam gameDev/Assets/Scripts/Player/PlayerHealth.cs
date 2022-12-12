using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public void CanDie()
    {
        if (PlayerStats.PlayerHealth <= 0)
        {
            // die
        }
    }
}
