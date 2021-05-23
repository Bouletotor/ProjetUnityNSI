using UnityEngine;

public class EnnemyDeath : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerAttack.isDashing)
        {
            Destroy(objectToDestroy);
        }
    }
}