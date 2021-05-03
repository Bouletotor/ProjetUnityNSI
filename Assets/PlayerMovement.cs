using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed;
    public float jumpForce;
    private float jumpNumber = 2;

    public bool isJumping;

    public Transform groundCheckerLeft;
    public Transform groundCheckerRight;

    public Rigidbody2D rb; 
    private Vector3 velocity = Vector3.zero; 

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 

        if (Input.GetButtonDown("Jump") && jumpNumber > 0)
        {
            isJumping = true;
            jumpNumber -= 1;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f);

        if (isJumping == true) 
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
