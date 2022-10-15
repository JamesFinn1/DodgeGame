using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float current, target;
    [SerializeField] private float movementSpeed = 0.5f;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private Vector2 goalPosition;

    private Camera cam;
    private float width;
    private float height;

    public float LerpMovementSpeed
    {
        get { return movementSpeed; }
        set { movementSpeed = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        target = 1;
        cam = Camera.main;
        float test = cam.orthographicSize;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        goalPosition.x = width / 2f;
        startPosition.x = -goalPosition.x;

        Debug.Log("Our goal is " + goalPosition.x);
        Debug.Log("cam.orthographicSize = " + test);
    }

    void Update()
    {
        if (transform.position.x == startPosition.x) target = target == 0 ? 1 : 0;// our target is 0 move towards 1
        if (transform.position.x == goalPosition.x) target = target == 1 ? 0 : 1;// out target is 1 move towards 0

        // Moving towards works with lerp function
        current = Mathf.MoveTowards(current, target, movementSpeed * Time.deltaTime);

        // Updating players local y position to start and goal position 
        startPosition.y = transform.position.y;
        goalPosition.y = transform.position.y;

        transform.position = Vector2.Lerp(startPosition, goalPosition, current);
    }

}
