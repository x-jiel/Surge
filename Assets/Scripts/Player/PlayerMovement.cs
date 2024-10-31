using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    public float moveSpeed;
    Rigidbody2D rb;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;
    [HideInInspector]
    public Vector2 moveDirection;
    [HideInInspector]
    public Vector2 lastMovedVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastMovedVector = new Vector2(1, 0f); // makes weapon proj in a direction when game starts and player doesnt move

    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();

    }
    void FixedUpdate()
    {
        Move();
    }
    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;

        if(moveDirection.x !=0)
        {
            lastHorizontalVector = moveDirection.x;
            lastMovedVector = new Vector2(lastHorizontalVector, 0f); //last movement x

        }
        if(moveDirection.y !=0)
        {
            lastVerticalVector = moveDirection.y;
            lastMovedVector = new Vector2(0f, lastVerticalVector); //last movement y
        }

        if(moveDirection.x !=0 && moveDirection.y !=0)
        {
            lastMovedVector = new Vector2(lastHorizontalVector, lastVerticalVector); 
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
