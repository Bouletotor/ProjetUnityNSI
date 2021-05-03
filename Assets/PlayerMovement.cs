using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    public float moveSpeed;
    public float jumpForce;
    public float jumpNumber;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckerLeft;
    public Transform groundCheckerRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero; 

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckerLeft.position, groundCheckerRight.position);
        if (isGrounded == true)
        {
            jumpNumber = 2;
        }

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 

        if (Input.GetButtonDown("Jump") && jumpNumber > 0)
        {
            isJumping = true;
            jumpNumber -= 1;
        }

        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);           
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
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}