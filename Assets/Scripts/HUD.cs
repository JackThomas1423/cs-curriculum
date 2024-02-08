using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public static HUD hud;
    public TextMeshProUGUI coinsMesh;
    public TextMeshProUGUI healthMesh;
    public int coins = 0;
    public int health = 0;
    public bool has_axe = false;
    public GameObject Door;
    public bool overworld;
    
    private void Awake()
    {
        if (hud != null && hud != this)
        {
            Destroy(gameObject);
        }
        else
        {
            hud = this;
            DontDestroyOnLoad(hud);
        }
    }

    void Start()
    {
        if (overworld)
        {
            Door = GameObject.FindObjectWithTag("WoodDoor");
        }
    }

    void Update()
    {
        coinsMesh.text = "coins: " + coins.ToString();
        healthMesh.text = "health: " + health.ToString();
    }
}
