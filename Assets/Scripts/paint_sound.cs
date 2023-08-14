using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paint_sound : MonoBehaviour
{
    public AudioSource src;
    public AudioClip paint;
    public game_data game_data;

    void Start()
    {
        src.clip = paint;
        src.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game_data.is_drawing)
        {
            src.Play();
        }
    }
}
