using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform bulletPosition;
    [SerializeField] private GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;

    void Update()
    {
        lookDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject fireBullet = Instantiate(bullet, bulletPosition.position, Quaternion.Euler(0f, 0f, lookAngle));
        fireBullet.GetComponent<Rigidbody2D>().velocity = lookDirection * 10f;
    }
}
