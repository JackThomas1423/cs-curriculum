using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManger : MonoBehaviour
{
    bool iframes = false;
    HUD hud;
    float timer;
    float originalTimer;
    void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
        originalTimer = 1.5f;
        timer = originalTimer;
    }

    void Update()
    {
        if(iframes)
        {
            timer -= Time.deltaTime;
            if(timer < 0)
            {
                iframes = false;
                timer = originalTimer;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!iframes)
            {
                iframes = true;
                hud.health--;
            }
        }
    }
}
