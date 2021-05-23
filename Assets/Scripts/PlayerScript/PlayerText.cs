using UnityEngine;
using UnityEngine.UI;

public class PlayerText : MonoBehaviour
{   
    //Cr�er une variable texte dans un interface
    public Text texteUI;
    public Text titleUI;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //fonction qui qui s'execute quand le joueur entre en collision
        //D�tecte le nom de l'objet dans lequel le joueur entre collision pour afficher un texte diff�rent
        //Tuto1,2 et 3 corresponde aux diff�rents panneaux du tutoriel
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
            texteUI.text = "Bien jou�, tu as reussi � battre les ennemis. Maintenant prends cet objet beni par l'ap�tre du Saint Badlands Chugs";
            titleUI.text = "Darkaneky";
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        texteUI.text = "";
        titleUI.text = "";
    }
    
}