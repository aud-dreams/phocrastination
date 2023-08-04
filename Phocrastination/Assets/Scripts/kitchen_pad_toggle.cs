using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchen_pad_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    public main_dot mainDot;
    public GameObject[] start, ingredients, toggles, initial;
    private SpriteRenderer paintbrush_render;
    public GameObject home, help;

    private void Start()
    {
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        game_data.allow_drawing = false;
        game_data.allow_paintbrush = false;

        // set visibility at start
        render.enabled = false;

        home.SetActive(false);
        help.SetActive(false);
        foreach (GameObject i in ingredients) { i.SetActive(false); }
        foreach (GameObject toggle in toggles) { toggle.SetActive(false); }

        if (game_data.orders != 0)
        {
            foreach (GameObject i in initial) { i.SetActive(true); }
        }
        else
        {
            foreach (GameObject i in initial) { i.SetActive(false); }
        }

        if (game_data.first_crafting_help)
        {
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
        game_data.allow_drawing = false;
        game_data.allow_paintbrush = false;

        home.SetActive(false);
        help.SetActive(false);
        foreach (GameObject toggle in toggles) { toggle.SetActive(false); }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                foreach (GameObject s in start)
                {
                    s.SetActive(false);
                }

                game_data.help = false;

                if (!game_data.tutorial)
                {
                    home.SetActive(true);
                }
                help.SetActive(true);

                if (game_data.pad_on)
                {
                    game_data.allow_drawing = true;
                    game_data.allow_paintbrush = true;
                    foreach (GameObject toggle in toggles) { toggle.SetActive(true); }
                }

                game_data.first_crafting_help = false;
                game_data.allow_timer = true;
            }
        }
    }
}
