using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;

public class main_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public stat_data stat_data;
    private SpriteRenderer toggle_render;
    public GameObject home;

    user_log user = new user_log();

    private void Start()
    {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter()
    {
        render.enabled = true;
    }

    private void OnMouseExit()
    {
        render.enabled = false;
    }

    private IEnumerator blink(GameObject toggle)
    {
        toggle_render = toggle.GetComponent<SpriteRenderer>();
        while (game_data.allow_blink)
        {
            toggle_render.enabled = true;
            yield return new WaitForSeconds(0.3f);
            toggle_render.enabled = false;
            yield return new WaitForSeconds(0.3f);
        }
    }

    public Animator crossfade;
    public string scene;
    IEnumerator LoadScene()
    {
        crossfade.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        // blink home for tutorial after finish_bowl_button pressed (for crafting station)
        if (game_data.crafting_blink && game_data.tutorial)
        {
            game_data.allow_blink = true;
            StartCoroutine(blink(home));
            game_data.crafting_blink = false;
        }

        // blink home for tutorial when finish washing dishes
        if (game_data.dishes_blink && game_data.tutorial)
        {
            game_data.allow_blink = true;
            StartCoroutine(blink(home));
            game_data.dishes_blink = false;
            game_data.home_on = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (collider.CompareTag("Play"))
                {
                    user_log user = new user_log();
                    RestClient.Get<user_log>(game_data.db_url + "0.json").Then(callback =>
                    {
                        // take current player_count and increment
                        game_data.userID = "player" + (callback.player_count + 1).ToString();

                        // PUT (replace) player_count of player 0
                        user.player_count = callback.player_count + 1;
                        RestClient.Put(game_data.db_url + "0.json", user);

                        user.tutorial_started = true;
                        RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                    });
                }

                if (collider.CompareTag("Serving"))
                {
                    if (game_data.tutorial)
                    {
                        game_data.take_order_done = true;
                        game_data.home_on = false;
                        game_data.allow_blink = false;
                    }
                }

                if (collider.CompareTag("Crafting"))
                {
                    game_data.crafting_continue = true;
                    game_data.current_color = Color.black;

                    if (game_data.tutorial)
                    {
                        game_data.make_order_done = true;
                        game_data.home_on = false;
                        game_data.allow_blink = false;
                    }
                }

                if (collider.CompareTag("Pickup"))
                {
                    if (game_data.tutorial)
                    {
                        game_data.drop_order_done = true;
                        game_data.home_on = false;
                        game_data.allow_blink = false;
                    }
                }

                if (collider.CompareTag("Dishes"))
                {
                    if (game_data.tutorial)
                    {
                        game_data.wash_dishes_done = true;
                        game_data.home_on = false;
                        game_data.allow_blink = false;
                    }
                }

                if (collider.CompareTag("Cat"))
                {
                    game_data.allow_hand = false;
                    game_data.hand_on = false;
                    game_data.outside_catscene = true;

                    // post to database
                    if (!game_data.tutorial)
                    {
                        game_data.allow_blink = false;

                        // first load
                        if (stat_data.firstLoad3)
                        {
                            user.game_status = game_data.round_type;
                            user.cat_scene_ts2 = game_data.timer;
                            stat_data.end_cat = game_data.timer;
                            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);

                            stat_data.firstLoad3 = false;
                        }
                    }

                    stat_data.firstLoad2 = true;
                    stat_data.firstLoad3 = true;
                }

                StartCoroutine(LoadScene());
            }
        }
    }
}