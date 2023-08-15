using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_main_config : MonoBehaviour
{
    public GameObject[] start, day_pads;
    public game_data game_data;
    public GameObject shadow;

    void Update()
    {
        if ((game_data.first_day1_help || game_data.first_day2_help || game_data.first_day3_help) && !game_data.tutorial)       // day pads on
        {
            foreach (GameObject item in start) { item.SetActive(false); }
        }
        else if (game_data.first_main_help || game_data.help)       // main pads on
        {
            foreach (GameObject item in start) { item.SetActive(true); }
            shadow.SetActive(true);
        }
        else    // all pads off
        {
            foreach (GameObject item in start) { item.SetActive(false); }
            foreach (GameObject pad in day_pads) { pad.SetActive(false); }
            shadow.SetActive(false);
        }
    }
}
