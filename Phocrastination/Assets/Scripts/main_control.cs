using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_control : MonoBehaviour
{
    public game_data game_data;
    public GameObject home;

    void Update()
    {
        if (gameObject.CompareTag("Serving"))
        {
            if (!game_data.tutorial_main || game_data.help)     // home off during tutorial
            {
                home.SetActive(false);
            }
            else if (game_data.last)        // home off while last customer talking
            {
                home.SetActive(false);
            }
            else if (game_data.customers_line.Count == 0 && !game_data.can_next)      // home on after last customer leaves
            {
                home.SetActive(true);
            }
            else if (!game_data.can_next)       // home off while customer talking
            {
                home.SetActive(false);
            }
            else if (game_data.can_next)      // home on after customer done
            {
                home.SetActive(true);
            }
        }
        else if (gameObject.CompareTag("Crafting"))
        {
            if (game_data.crafting)         // home off if currently crafting
            {
                home.SetActive(false);
            }
            else if (!game_data.crafting)   // home on if not currently crafting
            {
                home.SetActive(true);
            }
        }

    }
}
