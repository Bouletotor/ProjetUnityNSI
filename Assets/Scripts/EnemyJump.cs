// Script permettant aux ennemis de sauter

// Importation de modules propres à Unity
using System.Collections;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public Rigidbody2D rb; // Variable relative à la physique de l'ennemi
    public float jumpForce; // Force du saut

    public bool canJump; 
    private bool isJumpIntervalRunning = false;

    private void Update()
    {
        if(canJump == true)
        {
            Jump(jumpForce); // On appelle la fonction Jump() définie plus loin
        }
        else if(isJumpIntervalRunning == false)
        {
            StartCoroutine(JumpInterval()); // On appelle la coroutine JumpInterval() définie plus loin
        }
    }

    private void Jump(float jumpForce)
    {
        rb.AddForce(new Vector2(0f, jumpForce)); // On ajoute au déplacement de l'ennemi (traité dans une autre fonction) un force verticale
        canJump = false; // On bloque le saut
    }

    IEnumerator JumpInterval() 
    {
        isJumpIntervalRunning = true; // On bloque l'appel à la coroutine
        yield return new WaitForSeconds(1.8f); // On attends 1.8 secondes
        canJump = true; // On permet à l'ennemi de sauter
        isJumpIntervalRunning = false; // On permet l'appel à la coroutine
    }
}