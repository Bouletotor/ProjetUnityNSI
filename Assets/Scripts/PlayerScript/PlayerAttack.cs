using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D rb;
    public static bool isAttack;
    public SpriteRenderer spriteRenderer;

    public float dashForceInit;
    private float dashForce;
    public bool isDashing;
    public bool canDash = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDashing == false && canDash == true)
        {
            isDashing = true;
            if (spriteRenderer.flipX == false)
            {
                dashForce = dashForceInit;
            }
            else
            {
                dashForce = -dashForceInit;
            }
            canDash = false;
            StartCoroutine (DashInterval(2f));
        }
    }

    void FixedUpdate()
    {
        if(isDashing == true)
        {
            DashPlayer(dashForce);
        }
    }

    IEnumerator DashInterval(float _secInterval)
    {
        yield return new WaitForSeconds(_secInterval);
        canDash = true;
    }

    void DashPlayer(float _dashForce)
    {
        rb.AddForce(new Vector2(_dashForce, 0f));
        isDashing = false;
    }
}