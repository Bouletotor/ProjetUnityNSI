using UnityEngine;

//Conservation de certains �l�ments lors d'un changement de niveau
public class DontDestroyOnLoadScene : MonoBehaviour
{

    //Ici la variable va prendre en compte certains �l�ments du niveau comme la vie du personnage
    //Et la conserver lors d'un changement de niveau. On garde les �l�ments qui sont sens� rester les m�mes lors d'un changement de sc�ne
    //Et on ne conserve pas ceux qui doivent �tre remplac�s comme le Grid.
    public GameObject[] objects;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
