using UnityEngine;

//Conservation de certains éléments lors d'un changement de niveau
public class DontDestroyOnLoadScene : MonoBehaviour
{

    public GameObject[] objects;

    void Awake()
    {
        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }
}
