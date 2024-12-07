using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public float bulletSpeed = 20f; // Merminin hızı
    public int damage = 10; // Merminin hasarı

    private Vector3 direction; // Merminin hareket yönü
    void Start()
    {
        // Destroy the object after 5 seconds
        Invoke("DestroyObject", 5f);
    }

    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed; // Merminin hızını ayarla
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Düşmanla çarpışma durumunda
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Düşman üzerindeki hasarı uygula
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
            Destroy(gameObject); // Mermiyi yok et
        }

    }
    void DestroyObject()
    {
        Destroy(gameObject);
    }

}
