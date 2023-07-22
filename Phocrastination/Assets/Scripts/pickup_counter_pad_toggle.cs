using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickup_counter_pad_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;

    public GameObject[] items;
    public GameObject button, toggle, customer_manager, help, home, bowl;

    void Start()
    {
        render = GetComponent<Renderer>();
        collider = GetComponent<Collider>();

        // set visibility at start
        render.enabled = false;
        if (!game_data.can_next) { button.SetActive(false); }
        toggle.GetComponent<Renderer>().enabled = false;

        if (game_data.first_pickup_help) { customer_manager.SetActive(false); } 
        else { customer_manager.SetActive(true); }

        if (game_data.first_pickup_help) {
            help.SetActive(false);
            home.SetActive(false);
            game_data.allow_timer = false;
        }

        // temp setup
        bowl.SetActive(false);
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
                foreach (GameObject item in items) {
                    item.SetActive(false);
                }

                customer_manager.SetActive(true);
                help.SetActive(true);
                home.SetActive(true);
                bowl.SetActive(true);

                game_data.first_pickup_help = false;
                game_data.help = false;
                game_data.allow_timer = true;
            }
        } else {
            toggle.GetComponent<Renderer>().enabled = false;
        }
    }
}
