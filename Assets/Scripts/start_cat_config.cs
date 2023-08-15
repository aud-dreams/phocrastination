using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_cat_config : MonoBehaviour
{
    public GameObject[] start;
    public game_data game_data;

    void Update() {
        // turn menu on for first time loading main scene
        if (game_data.first_cat_help) {
            foreach (GameObject item in start) { item.SetActive(true); }
        } else if (game_data.help) {
            foreach (GameObject item in start) { item.SetActive(true); }
        } else {
            foreach (GameObject item in start) { item.SetActive(false); }
        }
    }
}
