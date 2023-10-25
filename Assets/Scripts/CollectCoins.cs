using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    HUD hud;

    private void Start()
    {
        hud = GameObject.FindObjectOfType<HUD>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            hud.coins++;
            Destroy(collision.gameObject);
        }
    }
}
