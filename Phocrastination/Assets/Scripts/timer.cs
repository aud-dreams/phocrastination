using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public game_data game_data;

    void Update()
    {
        game_data.timer += Time.deltaTime;

        // decrement cat bar
        game_data.x_transform += 0.0000099999f;
        game_data.x_scale += 0.00001f;
    }
}
