using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float damage;

    [SerializeField] private GameObject gun;
    [Header("Prefabs")]
    [SerializeField] private GameObject prfBulletOne;
    [SerializeField] private GameObject prfBulletTwo;
    [SerializeField] private GameObject prfBulletThree;

    //for draw line
    private LineRenderer lineRenderer;
    private EnemyStats[] enemys;
    private EnemyStats enemy;
    private Vector3 targetDirection;
    private float dist;


    [SerializeField] private bool canShoot;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        StartCoroutine(Shoot());
    }

    private void Update()
    {
        if (canShoot)
        {
            lineRenderer.SetPosition(0, transform.position);

            //mapdeki butun enemyleri tapir
            enemys = FindObjectsOfType<EnemyStats>();

            //birinci enemyni en qisa olaraq isaretleyir
            if (enemys.Length != 0)
            {
                targetDirection = enemys[0].transform.position - transform.position;
                targetDirection.Normalize();
                dist = Vector3.Distance(enemys[0].transform.position, transform.position);
                enemy = enemys[0];
            }
            else
            {
                lineRenderer.SetPosition(1, new Vector3(transform.position.x + 20, transform.position.y, transform.position.z));
                targetDirection = transform.right;
                GameController.INSTANCE.OpenDoor();
                canShoot = false;
            }

            //en yaxin enemyni tapir
            for (int i = 0; i < enemys.Length; i++)
            {
                if (dist > Vector3.Distance(enemys[i].transform.position, transform.position))
                {
                    targetDirection = enemys[i].transform.position - transform.position;
                    enemy = enemys[i];
                    targetDirection.Normalize();
                }
            }
            if (enemy)
            {
                lineRenderer.SetPosition(1, enemy.transform.position);
            }
            //silahi enemye cevirir
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
            gun.transform.eulerAngles = new Vector3(0, 0, angle);
        }
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
            if (canShoot)
            {
                bulletStartPosition = new Vector3(gun.transform.position.x, gun.transform.position.y, gun.transform.position.z);
                Bullet b = Instantiate(prfBulletOne).GetComponent<Bullet>();
                b.speed = bulletSpeed;
                b.transform.position = bulletStartPosition;
                b.Direction = targetDirection;
                b.bulletParent = BulletParent.Player;

            }

        }
    }
}
