// Script permettant de changer de scene et d'activer un fondu

// Importation de modules propres à Unity
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSpecificScene : MonoBehaviour
{
    public string sceneName; 
    public Animator fadeSystem; // Animation de fondu

    private void Awake() 
    {
        // On lie l'animation du fondu à l'objet FadeSystem (essentiel lors du changement de scène car l'objet "FadeSystem" n'est pas le même selon les scènes)
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) // Lorsque la porte rentre en collision
    {
        if (collision.CompareTag("Player")) // Si la collision provient du Joueur
        {
            StartCoroutine(loadNextScene()); // On lance la coroutine permettant de changer de scene
        }
    }

    public IEnumerator loadNextScene()
    {
        fadeSystem.SetTrigger("FadeIn"); // On active le fondu
        yield return new WaitForSeconds(1f); // On attends 1 seconde
        SceneManager.LoadScene(sceneName); // On change de scene
    }
}

