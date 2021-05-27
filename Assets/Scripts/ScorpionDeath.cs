// Script permettant de supprimer l'ennemi scorpion ainsi que tous les objets qui lui sont liés

// Importation de modules propres à Unity
using UnityEngine;

public class ScorpionDeath : MonoBehaviour
{
    // On récupère les objets à détruire
    public GameObject objectToDestroy;
    public Transform groundCheck;

    public float groundCheckRadius;
    private bool isGrounded;

    void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius); // On regarde si le serpent touche le sol (sort un booléen)
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si la collision provient du joueur, qu'il est en train de dash et que le serpent est au sol
        if (collision.CompareTag("Player") && PlayerAttack.isDashing && isGrounded)
        {
            // On détruit le serpent (ce qui a effet de supprimer tous les objets suivants donc groundCheck)
            Destroy(objectToDestroy);
        }
    }

    private void OnDrawGizmos()
    {
        // Cette fonction sert uniquement a dessiner un cercle rouge visible depuis unity (cercle qui definis isGrounded)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}