using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinPrefab : MonoBehaviour
{
    private float speed = 8.0f;
    private Rigidbody2D rb;
    private const float OBJECT_DELETE_VAL = -25.0f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    private void Update()
    {
        if (transform.position.y < OBJECT_DELETE_VAL)
        {
            Destroy(this.gameObject);
        }
    }
}
