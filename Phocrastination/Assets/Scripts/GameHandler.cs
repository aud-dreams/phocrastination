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
        
        // main initialization
        game_data.first_main_help = true;
        game_data.help = false;
        game_data.click = 1;
        game_data.character_position = new Vector3(0f, 0.3f, 0f);

        // serving initialization
        game_data.first_serving_help = true;
        game_data.total_customers = 5;
        game_data.counter = 5;
        game_data.customers_line = new List<GameObject>();

        // crafting initialization
        game_data.current_color = Color.black;
        game_data.crafting_continue = false;
        game_data.can_next = false;
        game_data.first_crafting_help = true;
        game_data.beef_inside = false;
        game_data.broth_inside = false;
        game_data.herbs_inside = false;
        game_data.noodles_inside = false;
        game_data.allow_drawing = false;
        game_data.allow_paintbrush = false;
        game_data.bowl_complete = false;

        // dishes initialization
        game_data.first_dishes_help = true;
        game_data.dirty_bowls = 6;
        game_data.allow_bowls = false;
        game_data.dirty_bowls = 6;

        // cat initialization
        game_data.first_cat_help = false;
        game_data.allow_hand = false;
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
