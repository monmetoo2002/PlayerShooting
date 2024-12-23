using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletLifetime = 5f;
    [SerializeField] private int points = 1;
    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddPoint(points);
        }
    }
}
