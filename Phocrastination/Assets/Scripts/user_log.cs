using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class user_log
{
    // global

    // main

    // serving station

    // pickup station

    // crafting station

    // dishes station

    // cat station
    public double cat_scene_ts;  // when entered
    public bool distractability_bool;
    public List<(double, bool)> cat_list = new List<(double, bool)>();

}


public class initialize : MonoBehaviour
{
    private void Start()
    {
        user_log initialize = new user_log();

        double cat_scene_ts = 0;
        bool distractability_bool = false;
        initialize.cat_list.Add((cat_scene_ts, distractability_bool));
    }
}
