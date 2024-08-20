using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
public class MoveTwo : MonoBehaviour
{
float horizontal;
float speed = 3f;
float jumpPower =5f;
bool isFacingRight = true;
float acceleration = 2f;
    [HideInInspector] public bool isFacingLeft;
    [HideInInspector] public bool isGrounded;
    public bool spawnFacingLeft;
    [SerializeField] private Rigidbody2D rb;
[SerializeField] private Transform groundCheck;
[SerializeField] private LayerMask groundLayer;
   public GameObject player;
    bool grounded = false;
    Vector2 facingLeft;
    

    private void Start()
    {
        Initializtion();
    }
    void Update()
    {
        horizontal = -Input.GetAxisRaw("Horizontal");
    
       if (Input.GetKey(KeyCode.Space)&& grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    protected virtual void Initializtion()
    {
        facingLeft = new Vector2(-transform.localScale.x, transform.localScale.y);
        if (spawnFacingLeft)
        {
            transform.localScale = facingLeft;
            isFacingLeft = true;
        }

    }
public virtual void Flip()
    {
        if (isFacingLeft)
        {
            transform.localScale = facingLeft;
        }
        if (!isFacingLeft)
        {
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

   


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))

            grounded = true;
    }
    void FixedUpdate()
    {
       
        rb.velocity = new Vector2(horizontal * speed * acceleration, rb.velocity.y);

        if (horizontal > 0)
            gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        if (horizontal < 0)
            gameObject.transform.localScale = new Vector3(-.5f, .5f, .5f);
}
}