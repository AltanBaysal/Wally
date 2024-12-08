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
        //Invoke("DestroyObject", 5f);
        Debug.Log(transform.position);
    }

    public void SetDirection(Vector3 newDirection)
    {
        
        direction = newDirection;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed; // Merminin hızını ayarla
            // Adjust rotation to face the direction of movement
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
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
