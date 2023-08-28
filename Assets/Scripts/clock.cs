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
        if (!(game_data.clock_counter == 0))
        {
            clock_sprite.sprite = hours[game_data.clock_counter - 1];
        }
        else
        {
            clock_sprite.sprite = hours[game_data.clock_counter];
        }
    }

    void Update()
    {
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.clockTimer -= Time.deltaTime;

            if (game_data.clockTimer <= 0)      // every 42 seconds (1/10 of 7 mins), switch to next hour sprite (10 sprites to switch to in total)
            {
                clock_sprite.sprite = hours[game_data.clock_counter];
                game_data.clock_counter++;
                game_data.clockTimer = 42;
            }
        }
    }
}
