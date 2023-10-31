using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public CircleCollider2D small_cl;
    public CircleCollider2D big_cl;
    private GameObject player = null;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 d = (transform.position - player.transform.position).normalized;
            transform.position += -(d / 850);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject;
        small_cl.enabled = false;
        big_cl.enabled = true;
        _animator.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player = null;
        small_cl.enabled = true;
        big_cl.enabled = false;
        _animator.enabled = false;
    }
}
