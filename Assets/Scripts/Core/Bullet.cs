using UnityEngine;

public enum BulletParent
{
    Player,
    Enemy
}
public class Bullet : MonoBehaviour
{
    public float speed { set; get; }
    public Vector3 Direction { get; set; }
    public BulletParent bulletParent;

    private void FixedUpdate()
    {
        transform.Translate(Direction * speed);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.Wall) || collider.CompareTag(Tags.Ground))
        {
            Destroy(gameObject);
            return;
        }
        if (bulletParent == BulletParent.Player)
        {

            if (collider.CompareTag(Tags.Enemy))
            {
                float damage = Random.Range(10, 20);

                collider.GetComponent<EnemyStats>().GetDamage((int)damage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collider.CompareTag(Tags.Player))
            {
                float damage = Random.Range(10, 20);
                collider.GetComponent<PlayerStats>().GetDamage((int)damage);
                Destroy(gameObject);
            }
        }

    }
}
