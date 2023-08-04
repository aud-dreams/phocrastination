using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_control : MonoBehaviour
{
    public game_data game_data;
    public GameObject home;

    void Update()
    {
        if (!game_data.tutorial_main)
        {
            home.SetActive(false);
        }
        else if (game_data.can_next || (!game_data.can_next && game_data.customers_line.Count == 0 && !game_data.first_serving_help))
        {
            home.SetActive(true);
        }
        else
        {
            home.SetActive(false);
        }
    }
}
