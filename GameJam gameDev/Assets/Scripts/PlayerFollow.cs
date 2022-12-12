using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        if(player.position.y <= 0)
        {
            transform.position = new Vector3(player.position.x, 0, transform.position.z);
        }
    }
}
