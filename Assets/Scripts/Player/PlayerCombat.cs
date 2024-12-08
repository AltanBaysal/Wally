using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject bulletPrefab; // Mermi prefab'ı
    public GameObject firePoint;

    public void Shoot()
    {
        // Farenin konumunu almak
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Z eksenini sıfırlıyoruz çünkü 2D'de Z değeri önemli değil.

        // Mermi oluşturma
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);

        // Merminin hareket yönünü hesapla
        Vector3 direction = (mousePosition - transform.position).normalized;

        // Merminin yönünü ayarlamak için Bullet scriptine yönü gönder
        Mermi bulletScript = bullet.GetComponent<Mermi>();
        if (bulletScript != null)
        {
            bulletScript.SetDirection(direction); // Yönü ayarlıyoruz
        }
    }

}
