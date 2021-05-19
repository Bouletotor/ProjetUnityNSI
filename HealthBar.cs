// Importation de modules
using UnityEngine; 
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Les variables de type Transform, RigidBody2D, Animator etc... sont des variables propres à unity. Elles sont ce qu'on appelle des component
    public Slider slider; 
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}