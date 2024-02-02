using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private float cooldown = 2;
    private float timer = 0;
    public BulletManager bl;
    
    void Start()
    {
        timer = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        } else
        {
            if (Input.GetMouseButton(1))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 dir = (mousePos - transform.position).normalized;
                BulletManager p = Instantiate(bl, transform.position, Quaternion.identity);
                p.bulletSpeed = dir * 10;
                p.transform.tag = "Ball";
                p.creator = gameObject;
                timer = cooldown;
            }
        }
    }
}