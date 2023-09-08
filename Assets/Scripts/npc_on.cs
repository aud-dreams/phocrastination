using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_on : MonoBehaviour
{
    public game_data game_data;
    public GameObject npc;

    void Update()
    {
        if (game_data.round_type == 2 && game_data.transition)      // npc off during scene transition 2
        {
            npc.SetActive(false);
        }
        if (game_data.round_type == 3 && game_data.day3_counter == 3)   // npc on during round 3 after manager leaves
        {
            npc.SetActive(true);
        }
        else
        {
            npc.SetActive(false);
        }
    }
}
