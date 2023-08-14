using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat_cue : MonoBehaviour
{
    public game_data game_data;
    public AudioSource src;
    public AudioClip cue;
    private bool once = false, twice = false;

    void Start()
    {
        src.clip = cue;
    }

    void Update()
    {
        if (!once)
        {
            if (game_data.timer > 330)      // 5.5 mins
            {
                src.Play();
                once = true;
            }
        }

        if (!twice)
        {
            if (game_data.timer > 150)     // 2.5 mins
            {
                src.Play();
                twice = true;
            }
        }
    }
}
