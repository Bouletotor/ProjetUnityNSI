// Script permettant au joueur de faire une attaque (dash)

// Importation de modules propres à Unity
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // On récupère en variable la physique du monstre ainsi que ses rendus
    public Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;

    // On crée des variables relatives à la force du dash
    public float dashForceInit;
    private float dashForce;

    // On crée des booléens permettants de tester si le joueur peux dash ou non
    public static bool isAttack;
    public static bool isDashing;
    public bool test;
    private bool canDash = true;

    void Update() // Appel à la fonction chaque frames
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

    void FixedUpdate() // Appel à la fonction 50 fois par secondes (synchronisation au niveau du système de physique)
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