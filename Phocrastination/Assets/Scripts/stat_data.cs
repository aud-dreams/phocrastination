using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "stat_data", menuName = "stat_data")]
public class stat_data : ScriptableObject
{

    // global
    public bool firstLoad = true;

    // main

    // serving station

    // pickup station
    public bool isFirstClick2 = true;

    // crafting station
    public int redo;
    public float ratio_hit;
    public bool has_start_drawing = true;
    public double start_drawing, end_drawing;
    public double total_time_drawing;

    public bool isFirstDot = true;

    public void IfZeroRedo() 
    {
        // flag for zero redos
        if (redo == 0)
        {
            redo = -1;
        }
    }

    public void IfZeroRatioHit()
    {
        // flag for zero ratios
        if (ratio_hit == 0)
        {
            ratio_hit = -1;
        }
    }

    public void CalculateTotalTimeDrawing() 
    {
        total_time_drawing += end_drawing - start_drawing;
    }

    // dishes station
    public bool isFirstClick = true;
    public int dirty_bowls;
    public int dirty_bowls_tot;

    public void CalcualteTotalDirtyBowls() 
    {
        dirty_bowls_tot = dirty_bowls + 7;
    }

    // cat station
    /* retrieve timestamp from cat sound & cat station entered, if <20 seconds, apply distractability weight */
    public double start_cat;
    public double cat_cue = 300;    // temp
    public bool distractability_bool = false;
    public double sec_between;

    public void CalculateDistractability()
    {
        sec_between = Math.Abs(start_cat - cat_cue);
        if (sec_between <= 20)
        {
            distractability_bool = true;
        }
    }

    public bool firstLoad2 = true;
    public bool firstLoad3 = true;   
}