// Programme calculant des évenements liés à la vie du joueur

// Importation de modules propres à Unity
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    // Variables relatives aux points de vie
    public int maxHealth = 100;
    public int currentHealth;

    public float InvincibilityTime; // Variable définissant le temps d'invincibilité après un coup
    public float flashDelay; // Variable définissant le timing de l'animation
    public bool isInvincible = false; // Variable permettant de savoir si le joueur est invincible

    // Component relatif au rendu du personnage
    public SpriteRenderer graphics;

    // Variable relative à healthBar provenant du programme HealthBar :)
    public HealthBar healthBar;

    void Start() // Appel de la fonction au lancement du programme
    {
        // On définit la vie actuelle en fonction de la vie maximale et on l'applique à l'interface via SetMaxHealth()
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage) // Appel à cette fonction depuis un autre programme
    {
        if (isInvincible == false)
        {
            currentHealth -= damage; // On retire des points de vies au joueur
            healthBar.SetHealth(currentHealth); // On applique cette modification à l'UI
            isInvincible = true; // On rend le joueur invincible

            // Les Coroutines sont des fonctions répétées comme les routines sauf qu'elles peuvent être interrompues pour être redémarrées plus tard.
            StartCoroutine(InvincibilityFlash()); 
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible) 
        {
            graphics.color = new Color(1f, 1f, 1f, 0f); // On passe le rendu du joueur en rgba(255,255,255,0) (1f est une valeur normalisée)
            yield return new WaitForSeconds(flashDelay); // On attends pendant "flashDelay" secondes
            graphics.color = new Color(1f, 1f, 1f, 1f); // On passe le rendu du joueur en rgba(255,255,255,255) (1f est une valeur normalisée)
            yield return new WaitForSeconds(flashDelay); // On attends pendant "flashDelay" secondes
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(InvincibilityTime); // On attends InvincibilityTime secondes
        isInvincible = false; // On repasse le joueur en non-invincible ce qui a aussi pour effet de mettre en pause la coroutine InvincibilityFlash()
    }
}