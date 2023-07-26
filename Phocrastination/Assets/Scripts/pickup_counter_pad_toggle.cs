using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_counter_pad_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    public GameObject[] items;
    public GameObject button, toggle, customer_manager, help, home, sparkles;

    void Start()
    {
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
        // if (!game_data.can_next2) { button.SetActive(false); }

        if (game_data.first_pickup_help || game_data.help) {
            help.SetActive(false);
            home.SetActive(false);
            game_data.allow_timer = false;
            game_data.allow_drag = false;
        }

        button.SetActive(false);
        toggle.SetActive(false);
        sparkles.SetActive(false);
    }

    private void OnMouseEnter() {
        render.enabled = true;
    }

    private void OnMouseExit() {
        render.enabled = false;
    }

    void Update() {
        if (game_data.first_pickup_help || game_data.help) {
            help.SetActive(false);
            home.SetActive(false);
            game_data.allow_drag = false;
        }
        
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (collider.Raycast(ray, out hit, Mathf.Infinity)) {
                foreach (GameObject item in items) {
                    item.SetActive(false);
                }

                customer_manager.SetActive(true);
                help.SetActive(true);
                home.SetActive(true);

                game_data.first_pickup_help = false;
                game_data.help = false;
                game_data.allow_timer = true;
                game_data.allow_drag = true;
            }
        } else {
            toggle.GetComponent<Renderer>().enabled = false;
        }
    }
}
