using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game_data", menuName = "Data")]
public class game_data : ScriptableObject
{
    // dishes station
    public int dirty_bowls;
    public int clean_bowls;
    public int firstClick;

    // crafting station
    public Color current_color;
    public bool beef_inside;
    public bool broth_inside;
    public bool herbs_inside;
    public bool noodles_inside;

    // serving station
    public int total_customers = 10;
    public int counter = 10;
    public List<GameObject> customers_line = new List<GameObject>();
    public bool can_next = false;

}