using UnityEngine;

public class PNJInteraction : MonoBehaviour
{
    public Item amulette;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Inventory.instance.content.Contains(amulette) == false)
        {
            Inventory.instance.GetItem(amulette);
        }
    }
}