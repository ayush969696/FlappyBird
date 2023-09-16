using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMovement : MonoBehaviour
{
    public float speed = 5f;
    private float leftEdge;

    private void Start()   // here we are going to calculate the leftEdge position 
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;  // .x - 1f => here we just giving it one unit further outside the scene Camera and then the pipes will destroy 
    }
    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
