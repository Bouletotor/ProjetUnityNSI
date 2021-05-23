using UnityEngine;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour
{   
    //Créer une variable texte dans un interface
    public Text texteUI;
    public Text titleUI;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //fonction qui qui s'execute quand le joueur entre en collision
        //Détecte le nom de l'objet dans lequel le joueur entre collision pour afficher un texte différent
        //Tuto1,2 et 3 corresponde aux différents panneaux du tutoriel
        if(collision.gameObject.name == "Tuto1")
        {
            texteUI.text = "Appuyez sur [q] ou [d] pour vous deplacez de gauche a droite";
        }
        else if(collision.gameObject.name == "Tuto2")
        {
            texteUI.text = "Appuyez sur la touche [Espace] pour sauter et ainsi franchir l'obstacle";
        }
        else if (collision.gameObject.name == "Tuto3")
        {
            texteUI.text = "Voici votre premier ennemie, appuyez sur [Clic gauche] pour l'attaquer";
        }
        else if (collision.gameObject.name == "Tuto4")
        {
            texteUI.text = "Cet ennemi etait faible, chaque ennemi n'a besoin que d'une seule attaque pour etre vaincue, seulement il faut trouver le point faible";
        }
        else if (collision.gameObject.name == "Darkaneky")
        {
            texteUI.text = "Bien joué, tu as reussi à battre les ennemis. Maintenant prends cet objet beni par l'apôtre du Saint Badlands Chugs";
            titleUI.text = "Darkaneky";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        texteUI.text = "";
        titleUI.text = "";
    }
    
}