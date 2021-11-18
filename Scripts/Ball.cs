using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 speed;
    public float speedFactor;
    private bool isColliding;
    private Rigidbody2D ball;

    // Start is called before the first frame update
    void Start()
    {
        speed = new Vector3(-0.5f, 0.05f, 0);
        speedFactor = 1.0001f;
        ball = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ball.velocity = speed;
        speed *= speedFactor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
        if (collision.gameObject.tag.Equals("Vertical"))
        {
            speed = new Vector3(-speed.x, speed.y, 0);
        }else if (collision.gameObject.tag.Equals("Horizontal"))
        {
            speed = new Vector3(speed.x, -speed.y, 0);
        }
        
    }
}
