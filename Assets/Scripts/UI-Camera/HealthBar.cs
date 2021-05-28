// Programme permettant de faire le lien entre la vie du personnage et l'UI du joueur

// Importation de modules propres à Unity
using UnityEngine; 
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Création de variables components
    public Slider slider; 
    public Image fill;
    public Gradient gradient;

    public void SetMaxHealth(int health) // Fonction permettant de définir une barre de vie au lancement de la partie 
    {
        // On définit la "value" du slider pour pouvoir changer la longueur de la barre de vie
        slider.maxValue = health; // On définit le nombre de points de vies maximum que représente la barre
        slider.value = health;  // On définit le nombre de points de vies actuel dans la barre

        fill.color = gradient.Evaluate(1f); // On définit la couleur quand la vie est à son maximum grâce au dégradé (peu important)
    }

    public void SetHealth(int health) // Fonction permettant de redéfinir la barre de vie
    {
        slider.value = health; // On redéfinit la taille de la barre de vie selon les points de vies restants

        fill.color = gradient.Evaluate(slider.normalizedValue); // Changement de couleur selon le dégradé et les points de vies (peu important) ; "normalizedValue" donne une valeur entre 0 et 1 "normalisée"
    }
}