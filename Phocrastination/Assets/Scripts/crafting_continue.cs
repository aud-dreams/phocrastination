using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crafting_continue : MonoBehaviour
{
    public game_data game_data;
    public GameObject[] items;
    public GameObject complete_bowl;

    void Start()
    {
        complete_bowl.SetActive(false);
    }

    void Update()
    {
        if (game_data.crafting_continue) {
            game_data.allow_drawing = true;
            game_data.allow_paintbrush = true;
            
            foreach (GameObject item in items) {
                item.SetActive(true);
            }
        }
    }
}
