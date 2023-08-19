using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;

public class finish_bowl_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public stat_data stat_data;
    public GameObject next_bowl_button, next_bowl_toggle, home;
    public AudioSource src;
    public AudioClip splash;

    user_log user = new user_log();

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;

        src.clip = splash;
    }

    private void OnMouseEnter()
    {
        if (!game_data.help)
        {
            render.enabled = true;
        }
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

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                if (!game_data.help)
                {
                    src.Play();
                    game_data.crafting = false;
                    game_data.bowl_complete = true;
                    game_data.crafting_blink = true;
                    game_data.crafting_continue = false;
                    game_data.home_on = true;
                    home.SetActive(true);

                    if (game_data.orders > 1)
                    {
                        next_bowl_button.SetActive(true);
                        next_bowl_toggle.SetActive(true);
                    }

                    // decrement num of orders
                    game_data.orders--;
                    game_data.constructed_orders++;

                    // post to database
                    if (!game_data.tutorial)
                    {
                        user.game_status = game_data.round_type;

                        stat_data.IfZeroRedo();
                        user.redo = stat_data.redo;

                        stat_data.IfZeroRatioHit();
                        user.ratio_hit = stat_data.ratio_hit;

                        stat_data.CalculateTotalTimeDrawing();
                        user.total_time_drawing = stat_data.total_time_drawing;

                        user.bowl_created_ts2 = game_data.timer;
                        RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                    }

                    // reset flag
                    stat_data.isFirstDot = true;
                    // reset redos
                    stat_data.redo = 0;
                    // reset color_switch
                    user.color_switch = 0;
                }
            }
        }
    }
}
