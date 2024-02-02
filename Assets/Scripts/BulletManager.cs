using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Vector2 bulletSpeed;
    public GameObject creator;
    public Collider2D myCollider;

    private void Start()
    {
        StartCoroutine(Iframe());
    }

    void Update()
    {
        transform.Translate(bulletSpeed*Time.deltaTime);
    }

    private IEnumerator Iframe()
    {
        yield return new WaitForSeconds(.5f);
        myCollider.isTrigger = false;
    }
}
