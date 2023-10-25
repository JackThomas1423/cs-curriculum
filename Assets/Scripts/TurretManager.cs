using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    public GameObject bulletPrefab;
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
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
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
