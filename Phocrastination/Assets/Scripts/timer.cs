using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    public game_data game_data;

    void Update()
    {
        game_data.timer += Time.deltaTime;
    }
}
