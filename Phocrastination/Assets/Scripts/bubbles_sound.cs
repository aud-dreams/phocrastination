using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbles_sound : MonoBehaviour
{
    public AudioSource src;
    public AudioClip bubbles;
    public game_data game_data;

    void Start()
    {
        src.clip = bubbles;
        src.loop = true;
    }

    void Update()
    {
        if (!game_data.bubbles)
        {
            src.Play();
        }
    }
}
