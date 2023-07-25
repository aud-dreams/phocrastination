using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finish_bowl_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public GameObject next_bowl_button, next_bowl_toggle;

    private void Start() {
        // get render component
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
    }

    private void OnMouseEnter() {
        if (!game_data.help) {
            render.enabled = true;
        }
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
                if (!game_data.help) {
                    game_data.bowl_complete = true;

                    if (game_data.orders > 1) {
                        next_bowl_button.SetActive(true);
                        next_bowl_toggle.SetActive(true);
                    }
                    
                    // decrement num of orders
                    game_data.orders--;
                    game_data.constructed_orders++;
                }
            }
        }
    }
}
