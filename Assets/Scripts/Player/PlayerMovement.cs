using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpPower = 6f;
    [SerializeField] float acceleration = 2f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] float rightBorderXValue;
    [SerializeField] float leftBorderXValue;

    private SpriteRenderer sr;

    void FixedUpdate()
    {
        sr = GetComponent<SpriteRenderer>();

        rb.velocity = new UnityEngine.Vector2(horizontal * speed * acceleration, rb.velocity.y);
       
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        horizontal = -horizontal;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.16f, groundLayer);
    }

     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UnityEngine.Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        float rightSideOfScreenInWorld = rightBorderXValue;
        float leftSideOfScreenInWorld = leftBorderXValue;

        float TopOfScreenInWorld = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreenInWorld = Camera.main.ScreenToWorldPoint(new UnityEngine.Vector2(0f, 0f)).y;
    
         if (screenPos.x <= 0 && rb.velocity.x < 0f)
        {
            transform.position = new UnityEngine.Vector2(rightSideOfScreenInWorld, transform.position.y);
        }
        else if (screenPos.x >= Screen.width && rb.velocity.x > 0)
        {
            transform.position = new UnityEngine.Vector2(leftSideOfScreenInWorld, transform.position.y);
        }

        sr.flipX = rb.velocity.x < 0f;
       // else if (screenPos.y > Screen.height && rb.velocity.y > 0)
       // {
       //     transform.position = new UnityEngine.Vector2(transform.position.x, bottomOfScreenInWorld);
     //   }
      //  else if (screenPos.y <= 0 && rb.velocity.y < 0)
      //  {
        //    transform.position = new UnityEngine.Vector2(transform.position.x, TopOfScreenInWorld);
       // }

   
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new UnityEngine.Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
      
    }
}