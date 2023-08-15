using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class day_pad_toggle : MonoBehaviour
{
    public game_data game_data;
    private Renderer render;
    private new Collider collider;
    public GameObject[] items;
    public GameObject help;

    void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;

        if (game_data.first_day1_help || game_data.first_day2_help || game_data.first_day3_help)
        {
            game_data.help = true;
            game_data.allow_timer = false;
        }

    }

    private void OnMouseEnter()
    {
        render.enabled = true;
    }

    private void OnMouseExit()
    {
        render.enabled = false;
    }

    void Update()
    {
        help.SetActive(false);
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                foreach (GameObject item in items)
                {
                    item.SetActive(false);
                }

                game_data.allow_timer = true;
                game_data.allow_move = true;
                game_data.help = false;
                help.SetActive(true);

                if (game_data.round_type == 1)
                {
                    game_data.first_day1_help = false;
                }
                else if (game_data.round_type == 2)
                {
                    game_data.first_day2_help = false;
                }
                else if (game_data.round_type == 3)
                {
                    game_data.first_day3_help = false;
                    game_data.allow_timer = false;
                }
            }
        }
    }
}