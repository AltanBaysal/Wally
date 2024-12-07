using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Header("Combat Settings")]
    [SerializeField] private GameObject bulletPrefab; // Mermi prefab'�
    [SerializeField] private Vector3 bulletOffset = new Vector3(0, 1.5f, 0); // Oyuncunun �st k�sm� i�in ofset
    [SerializeField] private float attackCooldown = 0.5f;

    private float lastAttackTime;

    private void Update()
    {
        
    }

    public void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= lastAttackTime + attackCooldown)
        {

            // Mouse'un d�nya koordinat�ndaki pozisyonunu al
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
            mousePosition.z = 0f; // 2D oyun i�in Z koordinat�n� s�f�rla

            // Mermiyi oyuncunun �st k�sm�ndan spawnla
            Vector3 bulletSpawnPosition = transform.position;
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);

            // Mermiye hedef pozisyonunu ilet
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(mousePosition);
            }

            // Son sald�r� zaman�n� g�ncelle
            lastAttackTime = Time.time;
        }
    }
}
