using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;

public class cat_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    private SpriteRenderer render2, text_render;

    public GameObject buttonObject, player, text;
    public float proximityThreshold;
    public game_data game_data;
    public stat_data stat_data;

    user_log user = new user_log();

    void Start()
    {
        // if start menu activated at beginning of game, disable hovers
        if (game_data.first_main_help)
        {
            buttonObject.SetActive(false);
        }
        else
        {
            buttonObject.SetActive(true);
        }

        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        render2 = player.GetComponent<SpriteRenderer>();
        text_render = text.GetComponent<SpriteRenderer>();

        // set visibility at start
        render.enabled = false;
    }

    public Animator crossfade;
    public string scene;
    IEnumerator LoadScene()
    {
        crossfade.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }

    private void Update()
    {
        // hover on if player gets close
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= proximityThreshold)
        {
            render.enabled = true;
            text_render.enabled = true;

            // switch scene if mouse click
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (collider.Raycast(ray, out hit, Mathf.Infinity))
                {
                    game_data.character_position = player.transform.position;
                    game_data.character_sprite = render2.sprite;
                    game_data.allow_blink = false;
                    game_data.outside_catscene = false;

                    // post to database
                    if (!game_data.tutorial)
                    {
                        // first load
                        if (stat_data.firstLoad2)
                        {
                            user.game_status = game_data.round_type;

                            user.cat_scene_ts1 = game_data.timer;
                            stat_data.start_cat = game_data.timer;

                            stat_data.CalculateDistractability();
                            user.distractability_bool = stat_data.distractability_bool;
                            RestClient.Post(game_data.db_url + game_data.userID + ".json", user);

                            stat_data.firstLoad2 = false;
                        }
                    }

                    StartCoroutine(LoadScene());
                }
            }
        }
        else
        {
            if (game_data.tutorial)
            {
                text_render.enabled = false;
            }
            else
            {
                text_render.enabled = false;
                render.enabled = false;
            }
        }
    }
}
