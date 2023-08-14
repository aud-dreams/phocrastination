using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;

public class serving_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    private SpriteRenderer render2, text_render;

    public GameObject buttonObject, player, text;
    public float proximityThreshold;
    public game_data game_data;

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

            // switch scene if spacebar pressed
            if (Input.GetKey(KeyCode.Space))
            {
                game_data.character_position = player.transform.position;
                game_data.character_sprite = render2.sprite;

                SceneManager.LoadScene("Serving");

                // post to database
                if (!game_data.tutorial) {
                    if (game_data.current_customers != 0) {
                        user.game_status = game_data.round_type;
                        user.order_collected_ts1 = game_data.timer;
                        RestClient.Post(game_data.db_url + game_data.userID + ".json", user);
                    }
                }
                
                StartCoroutine(LoadScene());
            }
        }
        else
        {
            if (!game_data.blink || !game_data.tutorial)
            {
                render.enabled = false;
                text_render.enabled = false;
            }
        }
    }
}
