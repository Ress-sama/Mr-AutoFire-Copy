using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public static MusicController INSTANCE { get; set; }

    private void Awake()
    {
        INSTANCE = this;
        DontDestroyOnLoad(gameObject);
    }
}
