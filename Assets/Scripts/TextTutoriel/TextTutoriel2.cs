using UnityEngine;
using UnityEngine.UI;

public class TextTutoriel2 : MonoBehaviour
{
    private string texte = "Appuiez sur la touche [Espace] pour sauter et ainsi franchir l'obstacle";
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
