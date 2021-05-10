using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float lenght, startpos;
    public GameObject cam;
    public float parallaxEffect;
    public float textureUnitSizeX;

    void Start()
    {
        startpos = transform.position.x;
/*        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.height / sprite.pixelsPerUnit;*/

    }

    void FixedUpdate()
    {
        float temp = (cam.transform.position.x -transform.position.x);
        float dist = (cam.transform.position.x * parallaxEffect);
        transform.position = new Vector3(startpos+dist,transform.position.y, transform.position.z);

        if (temp>lenght)
        {
            startpos += lenght;
        }
        else if (temp<-lenght)
        {
            startpos -= lenght;
        }
    }
}
