using UnityEngine;

public class Lamp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            Destroy(collision.gameObject);
    }
}
