using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game_data", menuName = "Data")]
public class game_data : ScriptableObject
{
    // main
    public bool first_main_help;
    public bool help;
    public int click;
    public Vector3 character_position;

    // dishes station
    public bool first_dishes_help;
    public int collisions;
    public bool washing_complete;
    public int dirty_bowls;
    public int clean_bowls;
    public bool allow_bowls;

    // crafting station
    public bool first_crafting_help;
    public Color current_color;
    public bool beef_inside;
    public bool broth_inside;
    public bool herbs_inside;
    public bool noodles_inside;
    public bool allow_drawing;

    // serving station
    public bool first_serving_help;
    public int total_customers;
    public int counter;
    public List<GameObject> customers_line;
    public bool can_next;
}