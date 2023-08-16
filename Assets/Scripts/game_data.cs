using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game_data", menuName = "game_data")]
public class game_data : ScriptableObject
{
    // global
    public double timer;
    public string userID;
    public string db_url = "https://phocrastination-user-default-rtdb.firebaseio.com/";
    public bool allow_timer;
    public bool Day1;           // instantiation for beginning of day
    public bool Day2;
    public bool Day3;
    public int round_type;
    public bool first_day1_help;
    public bool first_day2_help;
    public bool first_day3_help;
    public double customerTimer;
    public double dishesTimer;
    public double clockTimer;
    public int clock_counter;
    public bool cue_once;
    public bool cue_twice;
    //public bool toggle_spawn;   // for toggles renders to be off when first spawned

    // tutorial
    public bool tutorial;
    public bool take_order_done;
    public bool make_order_done;
    public bool drop_order_done;
    public bool wash_dishes_done;
    public int tutorial_counter;
    public bool tutorial_main;
    public bool crafting_blink;
    public bool dishes_blink;
    public bool home_on;
    public bool cat_blink;
    public bool allow_blink;
    public bool listen_text;
    public bool outline_text;
    public bool remember_text;

    // day3
    public int day3_counter;
    public bool next_text1;
    public bool next_text2;

    // main
    public bool first_main_help;
    public bool help;
    public int click;
    public Vector3 character_position;
    public bool allow_move;
    public Sprite character_sprite;

    // serving station
    public bool first_serving_help;
    public int total_customers;
    public int current_customers;
    public List<GameObject> customers_line;
    public bool can_next;
    public bool last;       // bool for main_control during last customer in line
    public int orders;

    // pickup station
    public bool first_pickup_help;
    public int ordered_customers;
    public List<GameObject> ordered_line;
    public bool can_next2;
    public bool once;
    public bool once2;
    public int constructed_orders;
    public bool allow_drag;
    public bool last2;

    // crafting station
    public bool first_crafting_help;
    public bool crafting_continue;
    public Color current_color;
    public bool beef_inside;
    public bool broth_inside;
    public bool herbs_inside;
    public bool noodles_inside;
    public bool allow_drawing;
    public bool allow_paintbrush;
    public bool bowl_complete;
    public int counter;
    public bool pad_on;
    public bool crafting;
    public bool is_drawing;

    // dishes station
    public bool first_dishes_help;
    public int dirty_bowls;
    public bool allow_bowls;
    public bool washing;
    public bool bubbles;

    // cat station
    public bool first_cat_help;
    public bool allow_hand;
    public bool hand_on;
    public Vector3 progress_position;
    public Vector3 progress_scale;
    public bool outside_catscene;
}