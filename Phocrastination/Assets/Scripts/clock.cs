using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clock : MonoBehaviour
{
    public game_data game_data;
    private SpriteRenderer clock_sprite;
    public List<Sprite> hours;

    void Start()
    {
        clock_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.clockTimer -= Time.deltaTime;
        }

        for (int i = 0; i < 5; i++)
        {
            if (game_data.clockTimer <= 0)      // every 84 seconds (1/5 of 7 mins), switch to next hour sprite (5 sprites to switch to in total)
            {
                clock_sprite.sprite = hours[i];
                game_data.clockTimer = 84;
            }
        }

    }
}
