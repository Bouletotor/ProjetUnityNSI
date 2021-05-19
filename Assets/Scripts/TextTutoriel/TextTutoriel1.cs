using UnityEngine;
using UnityEngine.UI;

public class TextTutoriel1 : MonoBehaviour
{
    private string texte = "Appuiez sur [q] ou [d] pour aller a gauche ou a droite";
    public Text texteUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        texteUI.text = texte;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        texteUI.text = "";
    }
}
