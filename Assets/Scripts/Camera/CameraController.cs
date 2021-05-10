using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    Vector3 offset;

    [SerializeField]
    float maxX;
    [SerializeField]
    float maxY;
    [SerializeField]
    float minX;
    [SerializeField]
    float minY;
    [SerializeField]
    float smoothValue;

    public bool shake;
    public float shakeDuration = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.Player);
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(
        Mathf.Clamp(player.transform.position.x, minX, maxX),
        Mathf.Clamp(player.transform.position.y, minY, maxY),
        transform.position.z), smoothValue);

        if (shake)
        {
            originalPos = transform.localPosition;
            if (shakeDuration == 0)
            {
                transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                transform.localPosition = originalPos;
            }
        }
    }
}
