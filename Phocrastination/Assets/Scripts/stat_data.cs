using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "stat_data", menuName = "stat_data")]
public class stat_data : ScriptableObject
{

    // global

    // main

    // serving station
    public int order_collected_rem;

    // pickup station
    public int order_given_rem;

    // crafting station
    public int redo;
    public float ratio_hit;
    public double start_drawing, end_drawing;
    public double total_time_drawing;

    public void CalculateTotalTimeDrawing() 
    {
        total_time_drawing += end_drawing - start_drawing;
    }

    public int bowl_created_rem;

    // dishes station
    public int bowl_washed_rem;

    // cat station
    /* retrieve timestamp from cat sound & cat station entered, if <20 seconds, apply distractability weight */
    public bool distractability_bool = true;
}