using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game_data", menuName = "Data")]
public class game_data : ScriptableObject
{
    // main
    public bool menu_on;
    public Vector3 character_position;

    // dishes station
    public int collisions;
    public bool washing_complete = false;
    public int dirty_bowls;
    public int clean_bowls;
    public bool allow_bowls;

    // crafting station
    public Color current_color;
    public bool beef_inside;
    public bool broth_inside;
    public bool herbs_inside;
    public bool noodles_inside;
    public bool allow_drawing;

    // serving station
    public int total_customers;
    public int counter;
    public List<GameObject> customers_line = new List<GameObject>();
    public bool can_next;
}