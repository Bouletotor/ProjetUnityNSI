// Fonction permettant le déplacement de la caméra selon les déplacements du Joueur

using UnityEngine; // Importation de modules propres à Unity

public class CameraFollow : MonoBehaviour
{
    // On récupère les propriétés de Player
    public GameObject player;

    // On définit le temps et la position de décalage de la caméra 
    public float timeOffset;
    public Vector3 posOffset;

    // On crée une variable définissant sa vitesse
    private Vector3 velocity;

    void Update() // Appel à la fonction à chaque frames
    {
        // On modifie la position de la caméra
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}