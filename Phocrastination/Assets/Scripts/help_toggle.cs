using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class help_toggle : MonoBehaviour
{
    private Renderer render;
    private new Collider collider;
    public game_data game_data;
    public GameObject[] items;
    public GameObject help, home;

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
                game_data.help = true;
                game_data.click = 1;
                foreach (GameObject item in items) {
                    item.SetActive(true);
                }
                help.SetActive(false);
                home.SetActive(false);

                if (collider.CompareTag("Dishes")) {
                    game_data.allow_bowls = false;
                }
                game_data.allow_timer = false;
            }
        }
    }
}
