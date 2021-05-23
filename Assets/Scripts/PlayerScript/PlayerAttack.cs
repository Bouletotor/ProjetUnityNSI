using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody2D rb;
    public static bool isAttack;
    public SpriteRenderer spriteRenderer;

    public float dashForceInit;
    private float dashForce;

    public static bool isDashing;
    public bool test;
    private bool canDash = true;

    void Update()
    {
        test = isDashing;
        if (Input.GetMouseButtonDown(0) && isDashing == false && canDash)
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
            StartCoroutine (DashInterval(1.5f));
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
        StartCoroutine(DashTime(0.1f));
        rb.AddForce(new Vector2(_dashForce, 0f));
    }

    IEnumerator DashTime(float _dashTime)
    {
        yield return new WaitForSeconds(_dashTime);
        isDashing = false;
    }
}