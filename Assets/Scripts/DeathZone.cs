// Programme permettant de replacer le joueur à un point donné du niveau lorsqu'il rentre dans une boîte de détection (ici, la bôite de détection est sous le niveau)

// Importation de modules propres à Unity
using UnityEngine; 

public class DeathZone : MonoBehaviour
{
    private Transform playerSpawn; // On crée une variable playerSpawn, relative au point de réaparition du joueur, que l'on modifiera plus tard

    private void Awake() // Appel à la fonction quand le script est utilisé (différent de Start car Start n'est appelé seulement quand le script est lancé et non utilisé, or on doit pouvoir modifier la position playerSpawn lorsqu'on change de scène)
    {
        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform; // On affecte à la variable playerSpawn les données de l'objet portant le tag PlayerSpawn
    }

    public void OnTriggerEnter2D(Collider2D collision) // Appel à la fonction quand deathZone rentre en contact avec une boîte de collision
    {
        if (collision.CompareTag("Player")) // Si la collision provient du joueur
        {
            collision.transform.position = playerSpawn.position; // On replace le joueur aux position de playerSpawn
        }
    }
}
