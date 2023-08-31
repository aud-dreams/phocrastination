using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_on : MonoBehaviour
{
    public game_data game_data;
    public GameObject npc;

    void Update()
    {
        if (game_data.round_type == 3 && game_data.day3_counter == 3)
        {
            npc.SetActive(true);
        }
        else
        {
            npc.SetActive(false);
        }
    }
}
