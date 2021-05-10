using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;

    [Header("Prefabs")]
    [SerializeField] private GameObject prfBulletOne;

    [SerializeField] private GameObject gun;

    private Vector3 targetDirection;
    private PlayerStats player;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        StartCoroutine(Shoot());
    }

    private void Update()
    {
        targetDirection = player.transform.position - transform.position;
        targetDirection = new Vector3(Random.Range(targetDirection.x - 4, targetDirection.x + 4), Random.Range(targetDirection.y - 4, targetDirection.y + 4), 0);
        targetDirection.Normalize();
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        gun.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    /// <summary>
    /// Verilen saniye qeder gozleyib gulle atir
    /// </summary>

    IEnumerator Shoot()
    {
        Vector3 bulletStartPosition;
        while (true)
        {
            yield return new WaitForSeconds(shootSpeed);
            bulletStartPosition = new Vector3(gun.transform.position.x + 1, gun.transform.position.y - 0.01f, gun.transform.position.z);
            Bullet b = Instantiate(prfBulletOne).GetComponent<Bullet>();
            b.transform.position = bulletStartPosition;
            b.speed = bulletSpeed;
            b.Direction = targetDirection;
            b.bulletParent = BulletParent.Enemy;

        }
    }

}
