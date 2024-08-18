using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveTwo : MonoBehaviour
{
    float horizontal;
float speed = 8f;
float jumpPower =5f;
bool isFacingRight = true;
float acceleration = 3f;
[SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer;


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    
if (Input.GetKey(KeyCode.Space))
{
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    void FixedUpdate()
    {
        if (isFacingRight)  
        rb.velocity = new Vector2(horizontal * speed * acceleration, rb.velocity.y);
        else
         rb.velocity = new Vector2(horizontal * speed , rb.velocity.y);
        if(!isFacingRight)
            rb.velocity = new Vector2(horizontal * speed * acceleration, rb.velocity.y);
        else
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
}