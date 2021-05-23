using System.Collections;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool canJump;

    public float jumpForce;

    private bool isJumpIntervalRunning = false;

    private void Update()
    {
        if(canJump == true)
        {
            Jump(jumpForce);
        }
        else if(isJumpIntervalRunning == false)
        {
            StartCoroutine(JumpInterval());
        }
    }

    private void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0f, jumpForce));
        canJump = false;
    }

    IEnumerator JumpInterval()
    {
        isJumpIntervalRunning = true;
        yield return new WaitForSeconds(3f);
        canJump = true;
        isJumpIntervalRunning = false;
    }
}