// Script permettant de supprimer le serpent

// Importation de modules propres à Unity
using UnityEngine;

public class SnakeDeath : MonoBehaviour
{
    public GameObject objectToDestroy; // Variable définissant le snake

    private void OnTriggerEnter2D(Collider2D collision) // Lorsqu'il entre en collision
    {
        if (collision.CompareTag("Player") && PlayerAttack.isDashing) // Si la collision provient du joueur et qu'il est en train de dasher
        {
            Destroy(objectToDestroy); // On détruit l'ennemi
        }
    }
}