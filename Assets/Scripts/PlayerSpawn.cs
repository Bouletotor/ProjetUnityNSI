using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    //Défini le point d'apparition du joueur quand il entre dans un niveau
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
    }
}