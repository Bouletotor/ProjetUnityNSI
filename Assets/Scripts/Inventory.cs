using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public Image itemImageUI;

    public List<Item> content = new List<Item>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }

    public void GetItem(Item item)
    {
        content.Add(item);
        PlayerMovement.jumpNumber += item.JumpAdd;
        itemImageUI.sprite = content[0].image;
    }

    public void RemoveItem(Item item)
    {
        if(content.Contains(item))
        {
            content.Remove(item);
            PlayerMovement.jumpNumber -= item.JumpAdd;
        }
    }
}