using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckerLeft;
    public Transform groundCheckerRight;

    public Rigidbody2D rb; 
    private Vector3 velocity = Vector3.zero; 

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckerLeft.position, groundCheckerRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 

        if (Input.GetButton("Jump") && isGrounded)
        {
            isJumping = true;
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