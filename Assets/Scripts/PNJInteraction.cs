using UnityEngine;

public class PNJInteraction : MonoBehaviour
{
    //Définis une variable de type Item qui, en l'occurence, va être le seul objet du jeu
    public Item amulette;
    
    //Fonction qui s'éxecute lorsque le pnj entre en collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Inventory.instance.content.Contains(amulette) == false)
        {
            Inventory.instance.GetItem(amulette);
        }
    }
}
