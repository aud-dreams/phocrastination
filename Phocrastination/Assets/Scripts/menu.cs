using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu : MonoBehaviour
{
    public GameObject[] start;
    public game_data game_data;

    void Update() {
        // turn menu on for first time loading main scene
        if (game_data.menu_on) {
            foreach (GameObject item in start) {
                item.SetActive(true);
            }
        } else {
            foreach (GameObject item in start) {
                item.SetActive(false);
            }
        }
    }
}
