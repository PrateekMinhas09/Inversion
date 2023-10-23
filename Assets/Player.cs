using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce = 7f; // Adjust the force to control the jump height
    private Rigidbody2D rb;
    private bool isGrounded = false;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {
        
      

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            Jump();
        }
    }

    void Jump()
    {
        // Apply a vertical force to make the player jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded=false;
    }


    private void OnCollisionEnter2D(Collision2D ground)
    {
        
        if (ground.gameObject.tag=="Ground")
        {
            
            isGrounded = true;
        }
        
    }
}
