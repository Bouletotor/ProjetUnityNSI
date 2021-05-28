// Programme permettant de placer le joueur lorsqu'il entre dans un niveau

// Importation de modules propres à Unity
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Appel à la fonction quand le script est utilisé 
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position; // On place le joueur aux position de playerSpawn
    }
}