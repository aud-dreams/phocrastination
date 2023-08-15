using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayHandler : MonoBehaviour
{
    public game_data game_data;
    public stat_data stat_data;
    public GameObject[] items, pads;
    public Sprite sprite;
    public GameObject shadow, manager, tutorialHandler;

    user_log user = new user_log();

    void Update()
    {
        // tutorial stuff off
        if (!(game_data.round_type == 3) && !(game_data.round_type == 0))
        {
            manager.SetActive(false);
        }
        if (!(game_data.round_type == 0))
        {
            tutorialHandler.SetActive(false);
        }

        if (game_data.Day1 && game_data.help)
        {
            game_data.Day1 = false;
            game_data.clockTimer = 0;
            dayConfig(2, 3, 1);

            // Day1 pad on
            if (game_data.first_day1_help)
            {
                shadow.SetActive(true);
                pads[0].SetActive(true);
                pads[1].SetActive(false);
                pads[2].SetActive(false);
                pads[3].SetActive(true);
            }

            stat_data.dirty_bowls = game_data.dirty_bowls;
            stat_data.CalcualteTotalDirtyBowls();
        }
        else if (game_data.Day2 && game_data.help)
        {
            game_data.Day2 = false;
            game_data.clockTimer = 0;
            dayConfig(4, 5, 2);

            // Day2 pad on
            if (game_data.first_day2_help)
            {
                shadow.SetActive(true);
                pads[0].SetActive(false);
                pads[1].SetActive(true);
                pads[2].SetActive(false);
                pads[3].SetActive(true);
            }

            stat_data.dirty_bowls = game_data.dirty_bowls;
            stat_data.CalcualteTotalDirtyBowls();
        }
        else if (game_data.Day3 && game_data.help)
        {
            manager.SetActive(true);
            game_data.Day3 = false;
            game_data.clockTimer = 0;
            dayConfig(2, 3, 3);

            // Day3 pad on
            if (game_data.first_day3_help)
            {
                shadow.SetActive(true);
                pads[0].SetActive(false);
                pads[1].SetActive(false);
                pads[2].SetActive(true);
                pads[3].SetActive(true);
            }

            stat_data.dirty_bowls = game_data.dirty_bowls;
            stat_data.CalcualteTotalDirtyBowls();
        }
    }

    void dayConfig(int customers, int dishes, int round)
    {
        foreach (GameObject item in items)
        {
            item.SetActive(true);
        }

        // global initialization
        game_data.timer = 0;
        game_data.allow_timer = false;
        game_data.round_type = round;
        game_data.customerTimer = 90;
        game_data.dishesTimer = 30;
        game_data.clockTimer = 0;
        game_data.clock_counter = 0;
        game_data.cue_once = false;
        game_data.cue_twice = false;

        // tutorial initialization
        game_data.tutorial_main = true;
        game_data.tutorial = false;
        game_data.allow_blink = false;

        // main initialization
        game_data.first_main_help = false;
        game_data.help = false;
        game_data.click = 1;
        game_data.character_position = new Vector3(0f, 0.3f, 0f);
        game_data.allow_move = false;
        game_data.character_sprite = sprite;

        // serving initialization
        game_data.first_serving_help = false;
        game_data.total_customers = customers;
        game_data.current_customers = customers;
        game_data.customers_line = new List<GameObject>();
        game_data.orders = 0;
        game_data.can_next = false;
        game_data.last = false;

        // pickup initialization
        game_data.first_pickup_help = false;
        game_data.ordered_customers = 0;
        game_data.ordered_line = new List<GameObject>();
        game_data.can_next2 = false;
        game_data.once = true;
        game_data.once2 = true;
        game_data.constructed_orders = 0;
        game_data.allow_drag = true;
        game_data.last2 = false;

        // crafting initialization
        game_data.first_crafting_help = false;
        game_data.current_color = Color.black;
        game_data.crafting_continue = true;
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
        game_data.first_dishes_help = false;
        game_data.dirty_bowls = dishes;
        game_data.allow_bowls = true;
        game_data.washing = false;

        // cat initialization
        if (game_data.round_type == 1)
        {
            game_data.first_cat_help = true;
        }
        else
        {
            game_data.first_cat_help = false;
        }
        game_data.allow_hand = true;
        game_data.hand_on = true;
        game_data.progress_position = new Vector3(-1.16f, 3.79f, 0f);
        game_data.progress_scale = new Vector3(0.01f, 1.1f, 0f);
        game_data.outside_catscene = true;
    }
}

