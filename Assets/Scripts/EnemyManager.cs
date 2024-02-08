using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    
    public CircleCollider2D small_cl;
    public CircleCollider2D big_cl;
    public GameObject Coin_Drop;
    public GameObject Coin2_Drop;
    public GameObject axe;
    private GameObject player = null;
    private Animator _animator;
    public int health = 3;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _animator.enabled = false;
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 d = (transform.position - player.transform.position).normalized;
            transform.position += -(d / 800);
        }

        if (0 >= health)
        {
            int r = Random.Range(0, 3);
            GameObject p;
            switch(r)
            {
                case 0:
                    p = Instantiate(Coin_Drop, transform.position, Quaternion.identity);
                    break;
                case 1:
                    p = Instantiate(Coin2_Drop, transform.position, Quaternion.identity);
                    break;
                case 2:
                    p = Instantiate(axe, transform.position, Quaternion.identity);
                    break;
            }
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            small_cl.enabled = false;
            big_cl.enabled = true;
            _animator.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            small_cl.enabled = true;
            big_cl.enabled = false;
            _animator.enabled = false;
        }
    }
}
