using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class serving_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;

    public GameObject buttonObject, player;
    public float proximityThreshold = 5f;
    public game_data game_data;

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
                SceneManager.LoadScene("Serving");
            }
        }
        else {
            render.enabled = false;
        }
    }
}
