using UnityEngine;

//Conservation de certains éléments lors d'un changement de niveau
public class DontDestroyOnLoadScene : MonoBehaviour
{

    //Ici la variable va prendre en compte certains éléments du niveau comme la vie du personnage
    //Et la conserver lors d'un changement de niveau. On garde les éléments qui sont sensé rester les mêmes lors d'un changement de scène
    //Et on ne conserve pas ceux qui doivent être remplacés comme le Grid.
    public GameObject[] objects;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
