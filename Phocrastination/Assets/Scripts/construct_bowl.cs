using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class construct_bowl : MonoBehaviour
{
    public GameObject finish_bowl_button, finish_bowl_toggle, complete_bowl;
    public GameObject[] items;
    public game_data game_data;

    void Start()
    {
        finish_bowl_button.SetActive(false);
        finish_bowl_toggle.SetActive(false);
        complete_bowl.SetActive(false);
    }

    void Update() 
    {
        if (game_data.beef_inside && game_data.broth_inside && game_data.herbs_inside && game_data.noodles_inside && !game_data.bowl_complete) {
            finish_bowl_button.SetActive(true);
            finish_bowl_toggle.SetActive(true);
        } else {
            finish_bowl_button.SetActive(false);
            finish_bowl_toggle.SetActive(false);
        }

        if (game_data.bowl_complete) {
            complete_bowl.SetActive(true);
            foreach (GameObject item in items) {
                item.SetActive(false);
            }
        }
    }
}
