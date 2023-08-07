using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class main_pad_toggle : MonoBehaviour
{
    public game_data game_data;
    private Renderer render;
    private new Collider collider;

    public SpriteRenderer main_pad1, main_pad2, main_pad3, text_render;
    public GameObject[] start, toggles, station_text, manager_text, day_pads;
    public GameObject help, tutorial;

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;

        if (game_data.first_main_help)
        {
            help.SetActive(false);
            game_data.allow_timer = false;
            tutorial.SetActive(false);
        }
        foreach (GameObject text in station_text)
        {
            text_render = text.GetComponent<SpriteRenderer>();
            text_render.enabled = false;
        }
        foreach (GameObject text in manager_text)
        {
            text.SetActive(false);
        }
        foreach (GameObject day_pad in day_pads)
        {
            day_pad.SetActive(false);
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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (game_data.click == 1)
                {
                    main_pad2.enabled = true;
                    main_pad1.enabled = false;
                    game_data.click += 1;
                }
                else if (game_data.click == 2)
                {
                    main_pad3.enabled = true;
                    main_pad2.enabled = false;
                    game_data.click += 1;
                }
                else if (game_data.click == 3)
                {
                    // disable all menu sprites
                    foreach (GameObject item in start)
                    {
                        item.SetActive(false);
                    }
                    // enable all toggles if not tutorial
                    if (!game_data.tutorial)
                    {
                        foreach (GameObject item in toggles)
                        {
                            item.SetActive(true);
                        }
                    }

                    help.SetActive(true);
                    game_data.first_main_help = false;
                    game_data.help = false;
                    game_data.allow_move = true;
                    game_data.allow_timer = true;

                    // activate tutorial
                    if (game_data.tutorial)
                    {
                        tutorial.SetActive(true);
                    }
                }

            }
        }
    }
}
