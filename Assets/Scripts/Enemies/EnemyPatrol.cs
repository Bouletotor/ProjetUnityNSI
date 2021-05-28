// Fonction permettant le déplacement des ennemis d'un point A à un point B avec une vitesse définie

using UnityEngine; // Importation de modules propres à Unity

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 100;
    public int damage = 15;

    // Variable permettant de modifier le rendu de enemy
    public SpriteRenderer enemy;

    // Variables permettant le déplacement de enemy
    public Transform[] waypoints; // Point A et B
    private Transform target; // Cible de enemy (point A ou B)
    private int destPoint; // Destination (0 ou 1)

    void Start() // Appel à la fonction au lancement du programme
    {
        target = waypoints[0]; // On définit la cible de enemy à la position du waypoint 0

        enemy.flipX = !enemy.flipX; // On change le rendu de enemy en l'inversant (pour que son rendu suive la bonne direction)
    }

    void Update() // Appel à la fonction chaque frame
    {
        // Déplcement de enemy
        Vector3 dir = target.position - transform.position; // On définit le déplacement à effectuer entre la cible et la position actuelle de enemy
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); // On déplace par une translation ennemy

        if (Vector3.Distance(transform.position, target.position) < 0.3f) // Si la norme du vecteur (différence de la position actuelle de enemy et sa cible) est inférieure à 0.3 (valeur normalisée)
        {
            destPoint = (destPoint + 1) % waypoints.Length; // On redéfinit la destination (si destPoint = 1 alors il passe à 0 et vice versa)
            target = waypoints[destPoint]; // On redéfinit la cible de enemy
            enemy.flipX = !enemy.flipX; // On flip son rendu
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Appel à la fonction si une collision est détéctée 
    {
        if (collision.transform.CompareTag("Player")) // Si la collision proviens d'un contact avec le joueur
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>(); // On récupère la variable PlayerHealth depuis les components de Player
            playerHealth.TakeDamage(damage); // On lui inflige des dégats dans un autre script
        }
    }
}