using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;

public class dishes_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    private SpriteRenderer render2;

    public GameObject buttonObject, player;
    public float proximityThreshold = 5f;
    public game_data game_data;

    user_log user = new user_log();

    void Start() {
        // if start menu activated at beginning of game, disable hovers
        if (game_data.first_main_help) {
            buttonObject.SetActive(false);
        } else {
            buttonObject.SetActive(true);
        }

        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        render2 = player.GetComponent<SpriteRenderer>();

        // set visibility at start
        render.enabled = false;
    }

    private void Update() {
        // hover on if player gets close
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= proximityThreshold) {
            render.enabled = true;

            // switch scene if spacebar pressed
            if (Input.GetKey(KeyCode.Space)) {
                game_data.character_position = player.transform.position;
                game_data.character_sprite = render2.sprite;
                SceneManager.LoadScene("Dishes");

                // post to database
                user.counter = 1;
                RestClient.Post("https://phocrastination-27ee9-default-rtdb.firebaseio.com/" + game_data.userID + ".json", user);
            }
        }
        else {
            render.enabled = false;
        }
    }
}
