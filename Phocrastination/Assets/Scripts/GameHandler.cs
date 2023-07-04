using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public bool gameInProgress;
    public double timer;
    public game_data game_data;

    void Start()
    {
        gameInProgress = true;
        game_data.first_main_help = true;
        game_data.first_serving_help = true;
        game_data.help = false;
        game_data.click = 1;
        game_data.total_customers = 5;
        game_data.counter = 5;
        game_data.customers_line = new List<GameObject>();

        game_data.can_next = false;
        game_data.first_crafting_help = true;
        game_data.beef_inside = false;
        game_data.broth_inside = false;
        game_data.herbs_inside = false;
        game_data.noodles_inside = false;

        game_data.first_dishes_help = true;
        game_data.washing_complete = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (gameInProgress == false) {
            //endGame condition
        }
        
    }

    void dayConfig() {
        // reset state vars

        // switch between days
    }


    // log at start of day, end of day, enter & end scene, interacting w objects
}
