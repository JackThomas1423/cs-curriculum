using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void Update()
    {
        Vector3 d = (transform.position - player.transform.position).normalized;
        transform.position += -(d/1000);
    }
}
