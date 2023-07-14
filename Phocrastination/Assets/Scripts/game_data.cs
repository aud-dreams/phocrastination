using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game_data", menuName = "Data")]
public class game_data : ScriptableObject
{
    // global
    public double timer;

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
    public int orders;

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
    public bool start_drawing;

    // dishes station
    public bool first_dishes_help;
    public int dirty_bowls;
    public bool allow_bowls;

    // cat station
    public bool first_cat_help;
    public bool allow_hand;
    public bool hand_on;
    public Vector3 progress_position;
    public Vector3 progress_scale;
}