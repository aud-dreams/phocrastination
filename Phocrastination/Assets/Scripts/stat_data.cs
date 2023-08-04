using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "stat_data", menuName = "stat_data")]
public class stat_data : ScriptableObject
{

    // global

    // main

    // serving station

    // pickup station

    // crafting station
    public int redo;
    public float ratio_hit;
    public double start_drawing, end_drawing;
    public double total_time_drawing;

    public void CalculateTotalTimeDrawing() 
    {
        total_time_drawing += end_drawing - start_drawing;
    }

    // dishes station

    // cat station
    /* retrieve timestamp from cat sound & cat station entered, if <20 seconds, apply distractability weight */
    public bool distractability_bool = true;
}