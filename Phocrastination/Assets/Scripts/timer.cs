using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public game_data game_data;

    void Update()
    {
        if (game_data.allow_timer && !game_data.tutorial)
        {
            game_data.timer += Time.deltaTime;
        }

        // decrement cat bar once cat scene first clicked on
        if (!game_data.first_cat_help && game_data.outside_catscene && game_data.progress_scale.x > 0)
        {
            game_data.progress_position = game_data.progress_position - new Vector3(0.0000099999f, 0f, 0f);
            game_data.progress_scale = game_data.progress_scale - new Vector3(0.00001f, 0f, 0f);
        }
    }
}
