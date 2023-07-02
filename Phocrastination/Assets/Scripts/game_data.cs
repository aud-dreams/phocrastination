using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "game_data", menuName = "Data")]
public class game_data : ScriptableObject
{
    public int dirty_bowls;
    public int clean_bowls;
    public int firstClick;
}