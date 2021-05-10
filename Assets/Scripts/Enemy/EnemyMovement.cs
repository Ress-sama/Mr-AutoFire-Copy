using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float speed;

    Vector3 direction;

    private void Start()
    {
        maxX = 33.0f;
        maxY = 5.0f;
        minX = -13.0f;
        minY = -5.0f;
        speed = 1f;
        StartCoroutine(DirectionCalculator());
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,direction,speed/1000);
    }

    IEnumerator DirectionCalculator()
    {
        while (true)
        {
            direction = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY));
            yield return new WaitForSeconds(2f);
        }
    }
}
