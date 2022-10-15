using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrfab : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private float speedTrack;
    //private Vector2 screenBounds;


    public float FireBallSpeed
    {
        get { return speed; }
        set
        {
            speed = value;
        }
    }


    private void Awake()
    {
        speed = 10f;
    }

    private void Start()
    {
        
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        
    }

    private void Update()
    {
        if (transform.position.y < -25.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
