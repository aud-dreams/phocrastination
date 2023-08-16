using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private bool gameInProgress;
    public game_data game_data;
    public Sprite sprite;

    void Start()
    {
        gameInProgress = true;
        Initialize();
    }

    void Initialize()
    {
        // global initialization
        game_data.timer = 0;
        game_data.allow_timer = true;
        game_data.Day1 = false;
        game_data.Day2 = false;
        game_data.Day3 = false;
        game_data.round_type = 0;       // 0 - tutorial, 1 - Day1, 2 - Day2, 3 - Day3
        game_data.first_day1_help = false;
        game_data.first_day2_help = false;
        game_data.first_day3_help = false;
        game_data.customerTimer = 90;
        game_data.dishesTimer = 30;
        game_data.clockTimer = 0;
        game_data.clock_counter = 0;
        game_data.cue_once = false;
        game_data.cue_twice = false;
        //game_data.toggle_spawn = false;

        // tutorial initialization
        game_data.tutorial = true;
        game_data.take_order_done = false;
        game_data.make_order_done = false;
        game_data.drop_order_done = false;
        game_data.wash_dishes_done = false;
        game_data.tutorial_counter = 0;
        game_data.tutorial_main = false;
        game_data.crafting_blink = false;
        game_data.dishes_blink = false;
        game_data.home_on = false;
        game_data.cat_blink = true;
        game_data.allow_blink = false;
        game_data.listen_text = false;
        game_data.outline_text = false;
        game_data.remember_text = false;

        // day3
        game_data.day3_counter = 0;
        game_data.next_text1 = false;
        game_data.next_text2 = false;

        // main initialization
        game_data.first_main_help = true;
        game_data.help = false;
        game_data.click = 1;
        game_data.character_position = new Vector3(0f, 0.3f, 0f);
        game_data.allow_move = false;
        game_data.character_sprite = sprite;

        // serving initialization
        game_data.first_serving_help = true;
        game_data.total_customers = 1;
        game_data.current_customers = 1;
        game_data.customers_line = new List<GameObject>();
        game_data.orders = 0;
        game_data.can_next = false;
        game_data.last = false;

        // pickup initialization
        game_data.first_pickup_help = true;
        game_data.ordered_customers = 0;
        game_data.ordered_line = new List<GameObject>();
        game_data.can_next2 = false;
        game_data.once = true;
        game_data.once2 = true;
        game_data.constructed_orders = 0;
        game_data.allow_drag = false;
        game_data.last2 = false;

        // crafting initialization
        game_data.first_crafting_help = true;
        game_data.current_color = Color.black;
        game_data.crafting_continue = false;
        game_data.beef_inside = false;
        game_data.broth_inside = false;
        game_data.herbs_inside = false;
        game_data.noodles_inside = false;
        game_data.allow_drawing = false;
        game_data.allow_paintbrush = false;
        game_data.bowl_complete = false;
        game_data.counter = 0;
        game_data.pad_on = false;
        game_data.crafting = true;
        game_data.is_drawing = false;

        // dishes initialization
        game_data.first_dishes_help = true;
        game_data.dirty_bowls = 2;
        game_data.allow_bowls = false;
        game_data.washing = false;
        game_data.bubbles = false;

        // cat initialization
        game_data.first_cat_help = true;
        game_data.allow_hand = false;
        game_data.hand_on = false;
        game_data.progress_position = new Vector3(-1.16f, 3.79f, 0f);
        game_data.progress_scale = new Vector3(0.01f, 1.1f, 0f);
        game_data.outside_catscene = true;
    }

    void Update()
    {
        if (gameInProgress == false)
        {
            //endGame condition
        }

    }
}
