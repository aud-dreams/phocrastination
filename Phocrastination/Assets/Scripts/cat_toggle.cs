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

            // switch scene if spacebar pressed
            if (Input.GetKey(KeyCode.Space))
            {
                game_data.character_position = player.transform.position;
                game_data.character_sprite = render2.sprite;
                StartCoroutine(LoadScene());
                game_data.outside_catscene = false;

                // post to database
                user.cat_scene_ts = game_data.timer;
                user.distractability_bool = stat_data.distractability_bool;
                RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
            }
        }
        else
        {
            if (!game_data.blink)
            {
                render.enabled = false;
                text_render.enabled = false;
            }
        }
    }
}
