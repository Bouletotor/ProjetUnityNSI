using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //Créer une instance du script pouvant être utilisée depuis n'importe où dans le projet
    public static Inventory instance;
    //Variable de type image qui représente l'image d'un objet qui sera transmise sur un interface
    public Image itemImageUI;
    
    //Créer une liste de type Item(qui est un scriptable object, voir def fichier texte)
    public List<Item> content = new List<Item>();

    private void Awake()
    {
    //Méthode Awake qui s'éxecute avant les premières frames
    //C'est une fonction traditionelle pour éviter les problèmes de script static
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
            return;
        }

        instance = this;
    }

    public void GetItem(Item item)
    {
    //@param: Une variable de type Item
        content.Add(item);//Rajoute l'item qui a été envoyé à l'appel de la fonction à la liste d'item de l'inventaire
        PlayerMovement.jumpNumber += item.JumpAdd;//Rajoute à la valeur jumpNumber(variable qui gère le nombre de saut dans PlayerMovement) un nombre entiers selon l'item ajouté à l'inventaire
        itemImageUI.sprite = content[0].image;//Change l'image de l'interface
    }

    public void RemoveItem(Item item)
    {
    //Méthode similaire à GetItem mais sert à enlever un item de l'inventaire
        if(content.Contains(item))
        {
            content.Remove(item);
            PlayerMovement.jumpNumber -= item.JumpAdd;
        }
    }
}
