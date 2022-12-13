using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;

    private void Update()
    {
        Transform cam = transform;
        cam.position = new Vector3(player.position.x, player.position.y, cam.position.z);

        if (player.position.y <= 2)
        {
            cam.position = new Vector3(player.position.x, 2, cam.position.z);
        }
        if(cam.position.x < -38f)
        {
            cam.position = new Vector3(-38, cam.position.y, cam.position.z);
        }
        if (cam.position.x > 38f)
        {
            cam.position = new Vector3(38, cam.position.y, cam.position.z);
        }
        if(cam.position.y > 37f)
        {
            cam.position = new Vector3(cam.position.x, 37, cam.position.z);
        }
    }
}
