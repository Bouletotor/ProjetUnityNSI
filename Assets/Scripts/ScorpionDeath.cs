using UnityEngine;

public class ScorpionDeath : MonoBehaviour
{
    public GameObject objectToDestroy;
    public Transform groundCheck;
    public float groundCheckRadius;
    private bool isGrounded;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerAttack.isDashing && isGrounded)
        {
            Destroy(objectToDestroy);
        }
    }

    private void OnDrawGizmos()
    {
        //cette fonction sert uniquement à dessiner un cercle rouge visible depuis unity (cercle qui définis isGrouded
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}