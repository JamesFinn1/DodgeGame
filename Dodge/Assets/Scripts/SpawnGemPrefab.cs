using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGemPrefab : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    private Rigidbody2D rb;
    [SerializeField] private float destroyObjectY = -25.0f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
    }

    private void Update()
    {
        if (transform.position.y < destroyObjectY)
        {
            Destroy(this.gameObject);
        }
    }
}
