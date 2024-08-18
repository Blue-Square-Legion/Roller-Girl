using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Move : MonoBehaviour
{
    public GameObject Square;
    Rigidbody2D Rb;
    float moveSpeed = 5f;
    float targetSpeed = 5f;
    private float _movementForce = 5f;
    float speedDif;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        speedDif = targetSpeed - Rb.velocity.x;
    }
    private void FixedUpdate()
    {

       
            Rb.velocity = new Vector2(Input.GetAxis("Horizontal") * _movementForce, Rb.velocity.y);// (_movementForce * Vector2.right);
        if (Input.GetKey(KeyCode.UpArrow))
            Rb.velocity= new Vector2(Rb.velocity.x,_movementForce);
    }
}