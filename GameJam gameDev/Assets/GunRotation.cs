using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;

    [SerializeField] private SpriteRenderer gun;

    float angle;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (mousePos.x > transform.position.x)
        {
            gun.flipY = false;
        }
        else { gun.flipY = true; }
        
    }
}
