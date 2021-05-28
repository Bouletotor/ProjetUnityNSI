// Script permettant d'enregistrer les objets

// Importation de modules propres à unity
using UnityEngine;

// On cree un fichier permettant de regrouper les items
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject // ScriptableObject permet d'enregistrer des données
{
    // On enregistre l'objet dans l'inventaire
    public int id;
    public string Name;
    public string description;
    public Sprite image;

    // On ajoute un saut (ici, nous n'avons qu'un seul objet donc pas besoin de savoir quel objet c'est et d'effectuer une action selon ce dernier, oui, on a pas eu le temps et un peu la flemme aussi ^^')
    public int JumpAdd;
}
