using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_log
{
    // global
    public float global_timer;  // logged at end of day

    // main

    // serving station
    public double order_collected_ts;
    public int order_collected_rem;

    // pickup station
    public double order_given_ts;
    public int order_given_rem;

    // crafting station
    public int redo;
    public float ratio_hit;
    public double total_time_drawing;
    
    public double bowl_created_ts;
    public int bowl_created_rem;

    // dishes station
    public double bowl_washed_ts;
    public int bowl_washed_rem;

    // cat station
    public double cat_scene_ts;  // when entered
    public bool distractability_bool;
}