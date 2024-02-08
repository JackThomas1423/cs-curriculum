using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveMovment : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    private float xDirection;
    private float yDirection;
    private Collider2D col;
    private Rigidbody2D rd;
    public Scene scene;
    public TopDown_AnimatorController TDAC;
    public HUD hud;

    void Start()
    {
        xSpeed = 4;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Overworld")
        {
            hud.overworld = true;
            ySpeed = 4;
        }
        else
        {
            hud.overworld = false;
            ySpeed = 0;
        }

        col = GetComponent<Collider2D>();
        rd = GetComponent<Rigidbody2D>();

    }
    
    void Update()
    {
        RaycastHit2D h = Physics2D.Raycast(transform.position, Vector2.down);
        if (h.distance < col.bounds.extents.y)
        {
            if (Input.GetButton("Jump") && ySpeed == 0)
            {
                float force = 10f;
                force /= (scene.name == "Platformer") ? 1.5f: 1f;
                rd.AddForce(new Vector2(0f,force));
            }
        }
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        float xVector = xDirection * xSpeed * Time.deltaTime;
        float yVector = yDirection * ySpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector,yVector,0);

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 dir = (mousePos - transform.position).normalized;
            if (dir.x <= 0.16f && dir.y <= 0.16f)
            { 
                GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in Enemies)
                {
                    float dist = Vector3.Distance(enemy.transform.position, transform.position);
                    if (dist <= 2f)
                    {
                        EnemyManager em = enemy.GetComponent<EnemyManager>();
                        em.health--;
                    }
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Axe"))
        {
            hud.has_axe = true;
            TDAC.SwitchToAxe();
            Destroy(other.gameObject);
        }
    }
}
