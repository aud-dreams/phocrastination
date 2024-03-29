using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_log
{
    // global
    public double global_timer;  // logged at end of day
    public int game_status;
    public int player_count;    // only used for initial player 0
    public bool game_done;
    public bool tutorial_started;

    // serving station
    public double order_collected_ts1;
    public double order_collected_ts2;
    public int order_collected_rem;
    public int order_collected_tot;

    // pickup station
    public double order_given_ts1;
    public double order_given_ts2;
    public int order_given_rem;
    public int order_given_tot;

    // crafting station
    public int redo;
    public float ratio_hit;
    public double total_time_drawing;
    public int color_switch;

    public double bowl_created_ts1;
    public double bowl_created_ts2;
    public int bowl_created_rem;
    public int bowl_created_tot;

    // dishes station
    public double bowl_washed_ts1;
    public double bowl_washed_ts2;
    public int bowl_washed_rem;
    public int bowl_washed_tot;

    // cat station
    public double cat_scene_ts1;
    public double cat_scene_ts2;
    public double cat_cue_ts1;
    public double cat_cue_ts2;
    public int distractability_bool;
}