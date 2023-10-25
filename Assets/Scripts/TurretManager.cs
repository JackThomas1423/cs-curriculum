using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class TurretManager : MonoBehaviour
{
    public BulletManager bulletPrefab;
    private Collider2D target = null;
    private float og_time = 3;
    private float timer = 0;
    private bool IsOn = false;

    void Start()
    {
        timer = og_time;
    }

    void Update()
    {
        if (IsOn)
        {
            timer -= Time.deltaTime;
            if (0 >= timer)
            {
                if (target != null)
                {
                    timer = og_time;
                    BulletManager p = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    p.bulletSpeed = ((target.gameObject.transform.position - transform.position).normalized * 10);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = other;
            IsOn = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            target = null;
            IsOn = false;
        }
    }
}
