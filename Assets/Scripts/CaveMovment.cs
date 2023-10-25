using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveMovment : MonoBehaviour
{
    public float xSpeed;
    public float ySpeed;
    private float xDirection;
    private float yDirection;
    public Scene scene;
    void Start()
    {
        xSpeed = 4;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Overworld")
        {
            ySpeed = 4;
        }
        else
        {
            ySpeed = 0;
        }
    }
    
    void Update()
    {
        xDirection = Input.GetAxis("Horizontal");
        yDirection = Input.GetAxis("Vertical");
        float xVector = xDirection * xSpeed * Time.deltaTime;
        float yVector = yDirection * ySpeed * Time.deltaTime;
        transform.position = transform.position + new Vector3(xVector,yVector,0);
    }
}
