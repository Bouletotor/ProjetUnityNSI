using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    //D�fini le point d'apparition du joueur quand il entre dans un niveau
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}