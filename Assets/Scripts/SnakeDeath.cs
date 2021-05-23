using UnityEngine;

public class SnakeDeath : MonoBehaviour
{
    public GameObject objectToDestroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && PlayerAttack.isDashing)
        {
            Destroy(objectToDestroy);
        }
    }
}