using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter() {
        render.enabled = true;
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                SceneManager.LoadScene("Main");

                if (collider.CompareTag("Crafting")) {
                    game_data.crafting_continue = true;
                    game_data.current_color = Color.black;
                }

                if (collider.CompareTag("Cat")) {
                    game_data.allow_hand = true;
                    game_data.outside_catscene = true;
                }

                if (collider.CompareTag("Serving")) {
                    game_data.can_next = false;
                }

                if (collider.CompareTag("Pickup")) {
                    game_data.can_next2 = false;
                }
            }
        }
    }
}
