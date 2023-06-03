using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dishes_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;

    public GameObject buttonObject;

    public GameObject player;
    public float proximityThreshold = 5f;

    void Start() {
        // if start menu activated at beginning of game, disable hovers
        if (PlayerPrefs.GetInt("Bool") == 1) {
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
                SceneManager.LoadScene("Dishes");
            }
        }
        else {
            render.enabled = false;
        }
    }
}
