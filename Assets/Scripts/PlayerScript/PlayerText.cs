using UnityEngine;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour
{
    public LayerMask collisionLayers;
    private string texte = "";
    public Text texteUI;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Tuto1")
        {
            texte = "Appuyez sur [q] ou [d] pour vous deplacez de gauche a droite";
        }
        else if(collision.gameObject.name == "Tuto2")
        {
            texte = "Appuyez sur la touche [Espace] pour sauter et ainsi franchir l'obstacle";
        }
        else if (collision.gameObject.name == "Tuto3")
        {
            texte = "Voici votre premier ennemie, appuyez sur [Clic gauche] pour l'attaquer";
        }
        texteUI.text = texte;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        texte = "";
        texteUI.text = texte;
        
    }
    
}